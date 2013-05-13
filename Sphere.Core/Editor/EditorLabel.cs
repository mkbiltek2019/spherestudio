﻿using System.Drawing;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// A label with a blue-themed background.
    /// </summary>
    public class EditorLabel : Label
    {
        private static readonly Brush BgBrush = new TextureBrush(Properties.Resources.BarImage);

        /// <summary>
        /// Initializes a new instance of an EditorLabel.
        /// </summary>
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            Font = new Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TextAlign = ContentAlignment.MiddleLeft;
            Height = 23;
            AutoSize = false;
            ForeColor = Color.MidnightBlue;
        }

        /// <summary>
        /// Overrides the default background to draw a classy blue background.
        /// </summary>
        /// <param name="pevent"></param>
        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
            pevent.Graphics.FillRectangle(BgBrush, ClientRectangle);
        }
    }
}
