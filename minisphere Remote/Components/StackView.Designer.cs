﻿namespace minisphere.Remote.Components
{
    partial class StackView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.listStack = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // listStack
            // 
            this.listStack.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listStack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listStack.FullRowSelect = true;
            this.listStack.GridLines = true;
            this.listStack.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listStack.Location = new System.Drawing.Point(0, 0);
            this.listStack.MultiSelect = false;
            this.listStack.Name = "listStack";
            this.listStack.Size = new System.Drawing.Size(317, 477);
            this.listStack.TabIndex = 0;
            this.listStack.UseCompatibleStateImageBehavior = false;
            this.listStack.View = System.Windows.Forms.View.Details;
            this.listStack.DoubleClick += new System.EventHandler(this.listStack_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Function";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Location";
            this.columnHeader2.Width = 200;
            // 
            // StackView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listStack);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StackView";
            this.Size = new System.Drawing.Size(317, 477);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listStack;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
    }
}