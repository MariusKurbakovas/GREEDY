﻿namespace GREEDY
{
    partial class Greedy
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
            this.nothing_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nothing_button
            // 
            this.nothing_button.Location = new System.Drawing.Point(361, 309);
            this.nothing_button.Name = "nothing_button";
            this.nothing_button.Size = new System.Drawing.Size(139, 54);
            this.nothing_button.TabIndex = 0;
            this.nothing_button.Text = "does nothing";
            this.nothing_button.UseVisualStyleBackColor = true;
            this.nothing_button.Click += new System.EventHandler(this.Nothing_button);
            // 
            // Greedy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 483);
            this.Controls.Add(this.nothing_button);
            this.Name = "Greedy";
            this.Text = "GREEDY";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button nothing_button;
    }
}
