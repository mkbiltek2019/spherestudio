﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Plugins
{
    /// <summary>
    /// Describes a dockable control.
    /// </summary>
    public class DockDescription
    {
        public event EventHandler OnShow;
        public event EventHandler OnHide;
        public event EventHandler OnToggle;

        /// <summary>
        /// The root form control that takes the space of this plugin.
        /// </summary>
        public Control Control { get; set; }

        /// <summary>
        /// The icon to associate to this editor.
        /// </summary>
        public Icon Icon { get; set; }

        /// <summary>
        /// The text to associate to this editor.
        /// </summary>
        public String TabText { get; set; }

        /// <summary>
        /// The dock state of this editor, either a document or a sidebar widget.
        /// </summary>
        public DockDescStyle DockState { get; set; }

        /// <summary>
        /// Dictates where you are allowed to put the docked form.
        /// </summary>
        public DockDescAreas DockAreas { get; set; }

        /// <summary>
        /// Optionally choose to hide the control on close rather than destroy it.
        /// </summary>
        public Boolean HideOnClose { get; set; }

        public DockDescription()
        {
            DockState = DockDescStyle.Document;
            DockAreas = DockDescAreas.Document;
        }

        public void Show()
        {
            if (OnShow != null)
                OnShow(this, EventArgs.Empty);
        }

        public void Hide()
        {
            if (OnHide != null)
                OnHide(this, EventArgs.Empty);
        }

        public void Toggle()
        {
            if (OnToggle != null)
                OnToggle(this, EventArgs.Empty);
        }
    }

    /// <summary>
    /// Specifies the preferred docking location for a dockable control.
    /// </summary>
    public enum DockDescStyle
    {
        Document,
        Side,
        Opposite,
    }

    /// <summary>
    /// Specifies valid docking positions for a dockable control.
    /// </summary>
    [Flags]
    public enum DockDescAreas
    {
        None = 0,
        Document = 1,
        Sides = 2,
        Both = 3,
    }
}
