
namespace BotOfScreenShots_Application.Selector
{
    partial class SelectorArea
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
            this.Information1Label = new System.Windows.Forms.Label();
            this.Information2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Information1Label
            // 
            this.Information1Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Information1Label.AutoSize = true;
            this.Information1Label.Location = new System.Drawing.Point(102, 113);
            this.Information1Label.Name = "Information1Label";
            this.Information1Label.Size = new System.Drawing.Size(44, 13);
            this.Information1Label.TabIndex = 0;
            this.Information1Label.Text = "Enter or";
            // 
            // Information2Label
            // 
            this.Information2Label.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Information2Label.AutoSize = true;
            this.Information2Label.Location = new System.Drawing.Point(102, 126);
            this.Information2Label.Name = "Information2Label";
            this.Information2Label.Size = new System.Drawing.Size(61, 13);
            this.Information2Label.TabIndex = 1;
            this.Information2Label.Text = "doubleclick";
            // 
            // SelectorArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Information2Label);
            this.Controls.Add(this.Information1Label);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SelectorArea";
            this.Opacity = 0.3D;
            this.Text = "SelectorArea";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SelectorArea_KeyDown);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SelectorArea_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SelectorArea_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Information1Label;
        private System.Windows.Forms.Label Information2Label;
    }
}