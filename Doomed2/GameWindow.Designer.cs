﻿namespace Doomed2
{
    partial class GameWindow
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
            this.SuspendLayout();
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnGameWindow_FormClosing);
            this.Load += new System.EventHandler(this.OnGameWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.OnGameWindow_Paint);
            this.Resize += new System.EventHandler(this.OnGameWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion
    }
}