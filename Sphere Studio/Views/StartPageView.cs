﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using SphereStudio.Base;
using SphereStudio.Ide.Forms;
using SphereStudio.Ide.Properties;
using SphereStudio.UI;

namespace SphereStudio.Ide.BuiltIns
{
    [ToolboxItem(false)]
    partial class StartPageView : DocumentView, IStyleAware
    {
        private Project _proj;
        private ListViewItem _currentItem;

        private readonly DockPanel _startDock = new DockPanel();
        private readonly DockContent _gameContent = new DockContent();
        private readonly DockContent _infoContent = new DockContent();
        private readonly IdeWindow _mainEditor;

        private readonly ImageList _listIcons = new ImageList();
        private readonly ImageList _listIconsSmall = new ImageList();

        public StartPageView(IdeWindow mainEditor)
        {
            InitializeComponent();
            InitializeDocking();

            Icon = Icon.FromHandle(Resources.SphereEditor.GetHicon());

            _mainEditor = mainEditor;

            _listIcons.ImageSize = new Size(48, 48);
            _listIcons.ColorDepth = ColorDepth.Depth32Bit;
            _listIcons.Images.Add(Properties.Resources.SphereEditor);
            _listIconsSmall.ImageSize = new Size(16, 16);
            _listIconsSmall.ColorDepth = ColorDepth.Depth32Bit;
            _listIconsSmall.Images.Add(Properties.Resources.SphereEditor);
            GameFolders.LargeImageList = _listIcons;
            GameFolders.SmallImageList = _listIconsSmall;

            InitializeView();
            StyleManager.AutoStyle(this);
        }

        public override bool CanSave { get { return false; } }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        private void InitializeDocking()
        {
            Controls.Remove(MainSplitter);
            _startDock.DocumentStyle = DocumentStyle.DockingSdi;
            _startDock.Dock = DockStyle.Fill;
            Controls.Add(_startDock);

            GamesPanel.Dock = InfoPanel.Dock = DockStyle.Fill;
            _gameContent.Controls.Add(GamesPanel);
            _gameContent.DockAreas = DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document;
            _gameContent.AllowEndUserDocking = false;
            _gameContent.DockHandler.CloseButtonVisible = false;
            _gameContent.Text = @"Local Projects";
            _infoContent.Controls.Add(InfoPanel);
            _infoContent.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight;
            _infoContent.Text = @"Game Information";

            _gameContent.Show(_startDock, DockState.Document);
            _infoContent.Show(_startDock, DockState.DockBottom);
        }

        private void InitializeView()
        {
            View v = Core.Settings.StartPageView;
            GameFolders.View = v;
            TilesItem.Checked = false;
            switch (v)
            {
                case View.Details: DetailsItem.Checked = true; break;
                case View.Tile: TilesItem.Checked = true; break;
                case View.List: ListItem.Checked = true; break;
                case View.SmallIcon: SmallIconItem.Checked = true; break;
                case View.LargeIcon: LargeIconItem.Checked = true; break;
            }
        }

        public ToolStripLabel HelpLabel { get; set; }

        /// <summary>
        /// Adds Sphere games to the games panel for start-up use.
        /// </summary>
        public void PopulateGameList()
        {
            GameFolders.Items.Clear();
            GameFolders.BeginUpdate();
            if (_listIcons.Images.Count == 0) return;
            Image holdOnToMe = _listIcons.Images[0]; // keep this sucker alive.
            _listIcons.Images.Clear();
            _listIcons.Images.Add(holdOnToMe);

            // Search through a list of supplied directories.
            string sphereDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Sphere Studio");
            var paths = new List<string>(Core.Settings.ProjectPaths);
            paths.Insert(0, Path.Combine(sphereDir, "Projects"));
            foreach (string path in paths)
            {
                if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                    continue;
                var baseDir = new DirectoryInfo(path);
                var fileInfos = baseDir.GetFiles("*.ssproj", SearchOption.AllDirectories);
                var ssprojDirs = from fi in fileInfos
                                 select fi.DirectoryName + @"\";
                foreach (var fileInfo in fileInfos)
                {
                    var dirPath = Path.GetDirectoryName(fileInfo.FullName);
                    int img = CheckForIcon(dirPath);
                    Project proj = Project.Open(fileInfo.FullName);
                    ListViewItem item = new ListViewItem(proj.Name, img) { Tag = fileInfo.FullName };
                    item.SubItems.Add(proj.Author);
                    item.SubItems.Add(fileInfo.FullName);
                    GameFolders.Items.Add(item);
                }
                var sgmFileInfos = from fi in baseDir.GetFiles("game.sgm", SearchOption.AllDirectories)
                                   where !ssprojDirs.Any(x => fi.FullName.StartsWith(x))
                                   select fi;
                foreach (var fileInfo in sgmFileInfos)
                {
                    var dirPath = Path.GetDirectoryName(fileInfo.FullName);
                    int img = CheckForIcon(dirPath);
                    Project proj = Project.Open(fileInfo.FullName);
                    ListViewItem item = new ListViewItem(proj.Name, img) { Tag = fileInfo.FullName };
                    item.SubItems.Add(proj.Author);
                    item.SubItems.Add(fileInfo.FullName);
                    GameFolders.Items.Add(item);
                }
            }
            GameFolders.EndUpdate();
            GameFolders.Invalidate();
        }

        private int CheckForIcon(string fullpath)
        {
            try {
                string[] files = Directory.GetFiles(fullpath);
                foreach (string s in files)
                {
                    if (s.EndsWith(".png"))
                    {
                        _listIcons.Images.Add(Image.FromFile(s));
                        _listIconsSmall.Images.Add(Image.FromFile(s));
                        return _listIcons.Images.Count - 1;
                    }
                    if (s.EndsWith(".ico"))
                    {
                        _listIcons.Images.Add(new Icon(s));
                        _listIconsSmall.Images.Add(new Icon(s));
                        return _listIcons.Images.Count - 1;
                    }
                }
            }
            catch { return 0; }
            return 0;
        }

        private void GameFolders_MouseClick(object sender, MouseEventArgs e)
        {
            _currentItem = GameFolders.GetItemAt(e.X, e.Y);
            if (_currentItem == null) return;
            _proj = Project.Open((string)_currentItem.Tag);
            SetProjData();
        }

        public void SetProjData()
        {
            NameLabel.Text = @"Name: " + _proj.Name;
            AuthorLabel.Text = @"Author: " + _proj.Author;
            SizeLabel.Text = string.Format(@"Resolution: {0}x{1}", _proj.ScreenWidth, _proj.ScreenHeight);
            DescTextLabel.Text = _proj.Summary;
        }

        private async void PlayMenuItem_Click(object sender, EventArgs e)
        {
            await BuildEngine.Test(_proj);
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentItem == null) return;
            _mainEditor.OpenProject((string)_currentItem.Tag);
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            _currentItem.BeginEdit();
        }

        private void GameFolders_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            ListViewItem item = GameFolders.Items[e.Item];
            string path = Path.GetDirectoryName(Path.GetDirectoryName(GameFolders.Items[e.Item].Tag as string));

            if (System.IO.File.Exists(path + e.Label)) e.CancelEdit = true;
            else if (!RenameProject(path + "\\" + item.Text, path + "\\" + e.Label))
            {
                e.CancelEdit = true;
            }
        }

        private bool RenameProject(string oldname, string newname)
        {
            if (oldname == Core.Project.RootPath)
            {
                MessageBox.Show(@"Can't change name of active project.", @"Name Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Directory.Move(oldname, newname);
            return true;
        }

        private void SetIconItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                string selPath = Path.GetDirectoryName((string)_currentItem.Tag);
                diag.Filter = @"image files (.png)|*.png";
                diag.InitialDirectory = selPath;

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    if (diag.FileName == selPath + "\\icon.png") return;
                    if (System.IO.File.Exists(selPath + "\\icon.png")) System.IO.File.Delete(selPath + "\\icon.png");
                    System.IO.File.Copy(diag.FileName, selPath + "\\icon.png");

                    if (_currentItem.ImageIndex == 0)
                    {
                        _listIcons.Images.Add(Image.FromFile(selPath + "\\icon.png"));
                        _currentItem.ImageIndex = _listIcons.Images.Count - 1;
                    }
                    else
                    {
                        _listIcons.Images.RemoveAt(_currentItem.ImageIndex);
                        _listIcons.Images.Add(Image.FromFile(selPath + "\\icon.png"));
                        _currentItem.ImageIndex = _listIcons.Images.Count - 1;
                    }
                    PopulateGameList();
                }
            }
        }

        private void TilesItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = ListItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = GameFolders.View = View.Tile;
        }

        private void ListItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = TilesItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = GameFolders.View = View.List;
        }

        private void SmallIconItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = TilesItem.Checked = ListItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = GameFolders.View = View.SmallIcon;
        }

        private void LargeIconItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = TilesItem.Checked = ListItem.Checked = SmallIconItem.Checked = false;
            Core.Settings.StartPageView = GameFolders.View = View.LargeIcon;
        }

        private void DetailsItem_Click(object sender, EventArgs e)
        {
            ListItem.Checked = TilesItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = GameFolders.View = View.Details;
        }

        private void ItemContextStrip_Opening(object sender, CancelEventArgs e)
        {
            Point p = GameFolders.PointToClient(Cursor.Position);
            _currentItem = GameFolders.GetItemAt(p.X, p.Y);
            PlayGameItem.Visible = LoadMenuItem.Visible =
                RenameProjectItem.Visible = SetIconItem.Visible =
                OpenFolderItem.Visible = (_currentItem != null);
        }

        private void OpenFolderItem_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName((string)_currentItem.Tag);
            Process p = Process.Start("explorer.exe", string.Format(@"/select,""{0}\game.sgm""", path));
            if (p != null) p.Dispose();
        }

        private void RefreshItem_Click(object sender, EventArgs e)
        {
            PopulateGameList();
        }

        #region tip texts
        private void ClearTip(object sender, EventArgs e)
        {
            HelpLabel.Text = "";
        }

        private void GameFolders_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Right-click to view context menu.";
        }

        private void SetIconItem_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Sets a project icon mainly for the editors use.";
        }

        private void InfoPanel_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"These are the games properties stored in their ""game.sgm"" file.";
        }
        #endregion

        private void GameFolders_ItemActivate(object sender, EventArgs e)
        {
            _currentItem = GameFolders.SelectedItems[0];
            if (_currentItem == null) return;
            _mainEditor.OpenProject((string)_currentItem.Tag);
        }

        public void ApplyStyle(UIStyle theme)
        {
            theme.AsUIElement(GamesPanel);
            theme.AsUIElement(InfoSplitter.Panel1);
            theme.AsUIElement(InfoSplitter.Panel2);
            theme.AsTextView(GamePanel);
            theme.AsTextView(DescTextLabel);
            theme.AsTextView(GameFolders);
        }
    }
}
