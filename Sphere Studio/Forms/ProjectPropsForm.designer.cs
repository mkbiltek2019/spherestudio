﻿namespace SphereStudio.Forms
{
    partial class ProjectPropsForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PathLabel = new System.Windows.Forms.Label();
            this.GameTitleLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.AuthorTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.editorLabel1 = new Sphere.Core.Editor.EditorLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.GeneralPage = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.SummaryTextBox = new System.Windows.Forms.TextBox();
            this.BuildPage = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BuildDirTextBox = new System.Windows.Forms.TextBox();
            this.CompilerComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.tabControl1.SuspendLayout();
            this.GeneralPage.SuspendLayout();
            this.BuildPage.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // PathLabel
            // 
            this.PathLabel.AutoSize = true;
            this.PathLabel.Location = new System.Drawing.Point(12, 20);
            this.PathLabel.Name = "PathLabel";
            this.PathLabel.Size = new System.Drawing.Size(44, 15);
            this.PathLabel.TabIndex = 0;
            this.PathLabel.Text = "Project";
            // 
            // GameTitleLabel
            // 
            this.GameTitleLabel.AutoSize = true;
            this.GameTitleLabel.Location = new System.Drawing.Point(17, 49);
            this.GameTitleLabel.Name = "GameTitleLabel";
            this.GameTitleLabel.Size = new System.Drawing.Size(39, 15);
            this.GameTitleLabel.TabIndex = 2;
            this.GameTitleLabel.Text = "Name";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(12, 78);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(44, 15);
            this.AuthorLabel.TabIndex = 4;
            this.AuthorLabel.Text = "Author";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PathTextBox.Location = new System.Drawing.Point(62, 17);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.ReadOnly = true;
            this.PathTextBox.Size = new System.Drawing.Size(357, 23);
            this.PathTextBox.TabIndex = 1;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(62, 46);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(357, 23);
            this.NameTextBox.TabIndex = 3;
            // 
            // AuthorTextBox
            // 
            this.AuthorTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AuthorTextBox.Location = new System.Drawing.Point(62, 75);
            this.AuthorTextBox.Name = "AuthorTextBox";
            this.AuthorTextBox.Size = new System.Drawing.Size(357, 23);
            this.AuthorTextBox.TabIndex = 5;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OKButton.Location = new System.Drawing.Point(293, 7);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(80, 25);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(379, 7);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(80, 25);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // editorLabel1
            // 
            this.editorLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.editorLabel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.editorLabel1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.editorLabel1.ForeColor = System.Drawing.Color.White;
            this.editorLabel1.Location = new System.Drawing.Point(0, 0);
            this.editorLabel1.Name = "editorLabel1";
            this.editorLabel1.Size = new System.Drawing.Size(473, 23);
            this.editorLabel1.TabIndex = 0;
            this.editorLabel1.Text = "Configure your Sphere Studio game project";
            this.editorLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.GeneralPage);
            this.tabControl1.Controls.Add(this.BuildPage);
            this.tabControl1.Location = new System.Drawing.Point(14, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(445, 427);
            this.tabControl1.TabIndex = 1;
            // 
            // GeneralPage
            // 
            this.GeneralPage.Controls.Add(this.label3);
            this.GeneralPage.Controls.Add(this.SummaryTextBox);
            this.GeneralPage.Controls.Add(this.PathLabel);
            this.GeneralPage.Controls.Add(this.GameTitleLabel);
            this.GeneralPage.Controls.Add(this.AuthorLabel);
            this.GeneralPage.Controls.Add(this.PathTextBox);
            this.GeneralPage.Controls.Add(this.NameTextBox);
            this.GeneralPage.Controls.Add(this.AuthorTextBox);
            this.GeneralPage.Location = new System.Drawing.Point(4, 24);
            this.GeneralPage.Name = "GeneralPage";
            this.GeneralPage.Padding = new System.Windows.Forms.Padding(3);
            this.GeneralPage.Size = new System.Drawing.Size(437, 399);
            this.GeneralPage.TabIndex = 0;
            this.GeneralPage.Text = "General";
            this.GeneralPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Project Summary";
            // 
            // SummaryTextBox
            // 
            this.SummaryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SummaryTextBox.Location = new System.Drawing.Point(15, 137);
            this.SummaryTextBox.Multiline = true;
            this.SummaryTextBox.Name = "SummaryTextBox";
            this.SummaryTextBox.Size = new System.Drawing.Size(404, 243);
            this.SummaryTextBox.TabIndex = 7;
            // 
            // BuildPage
            // 
            this.BuildPage.Controls.Add(this.groupBox1);
            this.BuildPage.Controls.Add(this.label4);
            this.BuildPage.Controls.Add(this.BuildDirTextBox);
            this.BuildPage.Controls.Add(this.CompilerComboBox);
            this.BuildPage.Controls.Add(this.label1);
            this.BuildPage.Location = new System.Drawing.Point(4, 24);
            this.BuildPage.Name = "BuildPage";
            this.BuildPage.Padding = new System.Windows.Forms.Padding(3);
            this.BuildPage.Size = new System.Drawing.Size(437, 399);
            this.BuildPage.TabIndex = 1;
            this.BuildPage.Text = "Build";
            this.BuildPage.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(17, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 83);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "IMPORTANT";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(12, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(382, 48);
            this.label5.TabIndex = 0;
            this.label5.Text = "Changing the build settings of an established project may prevent the project fro" +
    "m being built or even lead to undesirable behavior.  Proceed with caution.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "Build In";
            // 
            // BuildDirTextBox
            // 
            this.BuildDirTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.BuildDirTextBox.Location = new System.Drawing.Point(83, 123);
            this.BuildDirTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BuildDirTextBox.Name = "BuildDirTextBox";
            this.BuildDirTextBox.Size = new System.Drawing.Size(335, 23);
            this.BuildDirTextBox.TabIndex = 2;
            // 
            // CompilerComboBox
            // 
            this.CompilerComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompilerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CompilerComboBox.FormattingEnabled = true;
            this.CompilerComboBox.Location = new System.Drawing.Point(83, 151);
            this.CompilerComboBox.Name = "CompilerComboBox";
            this.CompilerComboBox.Size = new System.Drawing.Size(335, 23);
            this.CompilerComboBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Compiler";
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.CloseButton);
            this.ButtonPanel.Controls.Add(this.OKButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 480);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(473, 38);
            this.ButtonPanel.TabIndex = 2;
            // 
            // ProjectPropsForm
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CloseButton;
            this.ClientSize = new System.Drawing.Size(473, 518);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.editorLabel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectPropsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Properties";
            this.Load += new System.EventHandler(this.ProjectPropsForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.GeneralPage.ResumeLayout(false);
            this.GeneralPage.PerformLayout();
            this.BuildPage.ResumeLayout(false);
            this.BuildPage.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PathLabel;
        private System.Windows.Forms.Label GameTitleLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox AuthorTextBox;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CloseButton;
        private Sphere.Core.Editor.EditorLabel editorLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage GeneralPage;
        private System.Windows.Forms.TabPage BuildPage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox SummaryTextBox;
        private System.Windows.Forms.TextBox BuildDirTextBox;
        private System.Windows.Forms.ComboBox CompilerComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel ButtonPanel;
    }
}