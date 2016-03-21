﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ScintillaNET;

namespace SphereStudio.ScriptEditor.Components
{
    /// <summary>
    /// Implements the Search box (Find and Replace UI).
    /// </summary>
    [ToolboxItem(false)]
    public partial class SearchBox : UserControl
    {
        // some of the logic here may seem a bit hard to follow.  unfortunately most
        // of the spaghetti is necessary, to keep the UI usable.  notes:
        //
        //     * ideally, checkboxes should not accept focus.  trouble is, even with .TabStop
        //       set to false, using an accelerator key will activate the control.  so the best
        //       we can do is refocus a textbox whenever a checkbox is changed.
        //     * non-Form controls cannot have an AcceptButton.  thus we need to handle
        //       the KeyPress event and activate the correct button when a Return character
        //       is received.
        //     * switching between Find and Replace textboxes should perform a Select All
        //       on the textbox being activated.  however, this should only happen when
        //       switching textboxes -- receiving focus from, e.g., a checkbox should NOT
        //       trigger a Select All.  this allows the user to manipulate search options
        //       in the middle of typing a term without affecting the cursor.
        //     * pressing a Find hotkey (Ctrl+F or Ctrl+H) while the Search box is visible
        //       should NOT change the text in the Find box nor trigger a search, but SHOULD
        //       select the text.  this matches MSVC behavior.

        private Scintilla _codeBox = null;
        private int _fullHeight;
        private TextBox _lastTextBox;
        private Control _parent;

        /// <summary>
        /// Constructs a new Search box.  Initially the box is invisible.
        /// </summary>
        /// <param name="parent">The parent control.  The Search box will display in the top-right corner of this control.</param>
        public SearchBox(Control parent)
        {
            InitializeComponent();

            _fullHeight = Height;
            _parent = parent;
            _parent.Resize += parent_Resize;
            _parent.Controls.Add(this);

            Visible = false;
        }

        public override string Text
        {
            get { return FindTextBox.Text; }
            set
            {
                FindTextBox.Text = value;
                FindTextBox.SelectAll();
            }
        }

        /// <summary>
        /// Opens the Search box.  The word under the cursor is automatically
        /// filled into the Find field.
        /// </summary>
        /// <param name="codeBox">The Scintilla control being searched.</param>
        /// <param name="replace">A boolean value specifying whether we want Replace functionality.</param>
        public void Open(Scintilla codeBox, bool replace = false)
        {
            _codeBox = codeBox;

            bool wasVisible = Visible;
            Show();
            BringToFront();

            int wordStart = _codeBox.WordStartPosition(_codeBox.CurrentPosition, false);
            int wordEnd = _codeBox.WordEndPosition(_codeBox.CurrentPosition, false);
            if (!wasVisible)
            {
                _codeBox.TargetStart = wordStart;
                FindTextBox.Text = _codeBox.GetWordFromPosition(_codeBox.CurrentPosition);
            }
            FindTextBox.SelectAll();
            FindTextBox.Focus();

            PerformFind();

            ReplaceTextBox.Visible = ReplaceButton.Visible = ReplaceAllButton.Visible
                = replace;

            if (replace)
                Height = _fullHeight;
            else
                Height = _fullHeight - ReplaceTextBox.Height;
        }

        /// <summary>
        /// Closes the Search box.
        /// </summary>
        public void Close()
        {
            _codeBox = null;
            Hide();
        }

        private bool PerformFind()
        {
            _codeBox.SearchFlags = SearchFlags.None;
            if (MatchCaseCheckBox.Checked)
                _codeBox.SearchFlags |= SearchFlags.MatchCase;
            if (WholeWordCheckBox.Checked)
                _codeBox.SearchFlags |= SearchFlags.WholeWord;
            if (RegexCheckBox.Checked)
                _codeBox.SearchFlags |= SearchFlags.Regex | SearchFlags.Posix;

            _codeBox.TargetEnd = _codeBox.TextLength;
            int pos = _codeBox.SearchInTarget(FindTextBox.Text);
            if (pos == Scintilla.InvalidPosition)
            {
                _codeBox.TargetStart = 0;
                pos = _codeBox.SearchInTarget(FindTextBox.Text);
            }
            if (pos != Scintilla.InvalidPosition)
            {
                FindTextBox.BackColor = SystemColors.Window;
                FindButton.Enabled = true;
                ReplaceButton.Enabled = true;
                ReplaceAllButton.Enabled = true;
                _codeBox.FirstVisibleLine = _codeBox.LineFromPosition(_codeBox.TargetStart)
                    - _codeBox.LinesOnScreen / 2;
                _codeBox.SelectionStart = _codeBox.TargetStart;
                _codeBox.SelectionEnd = _codeBox.TargetEnd;
            }
            else
            {
                FindTextBox.BackColor = Color.LightPink;
                FindButton.Enabled = false;
                ReplaceButton.Enabled = false;
                ReplaceAllButton.Enabled = false;
            }

            return pos != Scintilla.InvalidPosition;
        }

        private void PerformReplace()
        {
            if (RegexCheckBox.Checked)
                _codeBox.ReplaceTargetRe(ReplaceTextBox.Text);
            else
                _codeBox.ReplaceTarget(ReplaceTextBox.Text);
            _codeBox.TargetStart = _codeBox.TargetEnd;
            PerformFind();
        }

        private void PerformReplaceAll()
        {
            _codeBox.TargetStart = 0;
            _codeBox.TargetEnd = _codeBox.TextLength;
            _codeBox.BeginUndoAction();
            while (PerformFind())
            {
                PerformReplace();
            }
            _codeBox.EndUndoAction();
        }

        private void parent_Resize(object sender, EventArgs e)
        {
            Width = _parent.ClientSize.Width / 3;
            Left = _parent.ClientSize.Width - Width - SystemInformation.VerticalScrollBarWidth - SystemInformation.BorderSize.Width;
            Top = SystemInformation.BorderSize.Height;
        }

        private void FindTextBox_TextChanged(object sender, EventArgs e)
        {
            if (_codeBox == null)
                return;

            PerformFind();
            if (FindTextBox.Text == string.Empty)
            {
                FindButton.Enabled = false;
                ReplaceButton.Enabled = false;
                ReplaceAllButton.Enabled = false;
            }
        }

        private void FindTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\r')
                FindButton.PerformClick();
            else if (e.KeyChar == '\x1B')
                Close();
            else
                e.Handled = false;
        }

        private void ReplaceTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
            if (e.KeyChar == '\x1B')
                Close();
            else if (e.KeyChar == '\r')
                ReplaceButton.PerformClick();
            else
                e.Handled = false;
        }

        private void MatchCaseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            _lastTextBox.Focus();
        }

        private void RegexCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            _lastTextBox.Focus();
        }

        private void WholeWordCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            PerformFind();
            _lastTextBox.Focus();
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            _codeBox.TargetStart = _codeBox.TargetEnd;
            PerformFind();
            _lastTextBox.Focus();
        }

        private void ReplaceButton_Click(object sender, EventArgs e)
        {
            PerformReplace();
            _lastTextBox.Focus();
        }

        private void FindTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (_lastTextBox != FindTextBox)
                FindTextBox.SelectAll();
            _lastTextBox = FindTextBox;
        }

        private void ReplaceTextBox_Enter(object sender, EventArgs e)
        {
            // don't Select All unless we came from a different textbox
            if (_lastTextBox != ReplaceTextBox)
                ReplaceTextBox.SelectAll();
            _lastTextBox = ReplaceTextBox;
        }

        private void ReplaceAllButton_Click(object sender, EventArgs e)
        {
            PerformReplaceAll();
            _lastTextBox.Focus();
        }
    }
}
