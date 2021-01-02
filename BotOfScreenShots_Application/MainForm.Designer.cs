
namespace BotOfScreenShots_Application
{
    partial class MainForm
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ProfilesList = new System.Windows.Forms.ComboBox();
            this.FilesTreeView = new System.Windows.Forms.TreeView();
            this.ProfileAddButton = new System.Windows.Forms.Button();
            this.PreviewPictureBox = new System.Windows.Forms.PictureBox();
            this.WorkAreaButton = new System.Windows.Forms.Button();
            this.PreviewCheckBox = new System.Windows.Forms.CheckBox();
            this.ScreenShotButton = new System.Windows.Forms.Button();
            this.PlayButton = new System.Windows.Forms.Button();
            this.CodeArea = new System.Windows.Forms.TextBox();
            this.BuildButton = new System.Windows.Forms.Button();
            this.DeveloperModeCheckBox = new System.Windows.Forms.CheckBox();
            this.ProfileRemoveButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ProfileChangeNameButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ProfilesList
            // 
            this.ProfilesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfilesList.FormattingEnabled = true;
            this.ProfilesList.Location = new System.Drawing.Point(12, 12);
            this.ProfilesList.Name = "ProfilesList";
            this.ProfilesList.Size = new System.Drawing.Size(200, 21);
            this.ProfilesList.TabIndex = 2;
            // 
            // FilesTreeView
            // 
            this.FilesTreeView.Location = new System.Drawing.Point(12, 41);
            this.FilesTreeView.Name = "FilesTreeView";
            this.FilesTreeView.Size = new System.Drawing.Size(253, 206);
            this.FilesTreeView.TabIndex = 3;
            this.FilesTreeView.Visible = false;
            // 
            // ProfileAddButton
            // 
            this.ProfileAddButton.Location = new System.Drawing.Point(218, 12);
            this.ProfileAddButton.Name = "ProfileAddButton";
            this.ProfileAddButton.Size = new System.Drawing.Size(21, 21);
            this.ProfileAddButton.TabIndex = 4;
            this.ProfileAddButton.Text = "+";
            this.ProfileAddButton.UseVisualStyleBackColor = true;
            this.ProfileAddButton.Click += new System.EventHandler(this.ProfileAddButton_Click);
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.Location = new System.Drawing.Point(13, 281);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(253, 268);
            this.PreviewPictureBox.TabIndex = 6;
            this.PreviewPictureBox.TabStop = false;
            // 
            // WorkAreaButton
            // 
            this.WorkAreaButton.Enabled = false;
            this.WorkAreaButton.Location = new System.Drawing.Point(13, 252);
            this.WorkAreaButton.Name = "WorkAreaButton";
            this.WorkAreaButton.Size = new System.Drawing.Size(75, 23);
            this.WorkAreaButton.TabIndex = 7;
            this.WorkAreaButton.Text = "Work area";
            this.WorkAreaButton.UseVisualStyleBackColor = true;
            // 
            // PreviewCheckBox
            // 
            this.PreviewCheckBox.AutoSize = true;
            this.PreviewCheckBox.Enabled = false;
            this.PreviewCheckBox.Location = new System.Drawing.Point(175, 256);
            this.PreviewCheckBox.Name = "PreviewCheckBox";
            this.PreviewCheckBox.Size = new System.Drawing.Size(64, 17);
            this.PreviewCheckBox.TabIndex = 8;
            this.PreviewCheckBox.Text = "Preview";
            this.PreviewCheckBox.UseVisualStyleBackColor = true;
            // 
            // ScreenShotButton
            // 
            this.ScreenShotButton.Enabled = false;
            this.ScreenShotButton.Location = new System.Drawing.Point(94, 250);
            this.ScreenShotButton.Name = "ScreenShotButton";
            this.ScreenShotButton.Size = new System.Drawing.Size(75, 23);
            this.ScreenShotButton.TabIndex = 9;
            this.ScreenShotButton.Text = "Screen shot";
            this.ScreenShotButton.UseVisualStyleBackColor = true;
            // 
            // PlayButton
            // 
            this.PlayButton.Enabled = false;
            this.PlayButton.Location = new System.Drawing.Point(475, 12);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(147, 23);
            this.PlayButton.TabIndex = 10;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = true;
            // 
            // CodeArea
            // 
            this.CodeArea.Enabled = false;
            this.CodeArea.Location = new System.Drawing.Point(272, 41);
            this.CodeArea.Multiline = true;
            this.CodeArea.Name = "CodeArea";
            this.CodeArea.Size = new System.Drawing.Size(500, 416);
            this.CodeArea.TabIndex = 11;
            // 
            // BuildButton
            // 
            this.BuildButton.Enabled = false;
            this.BuildButton.Location = new System.Drawing.Point(394, 12);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 12;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            // 
            // DeveloperModeCheckBox
            // 
            this.DeveloperModeCheckBox.AutoSize = true;
            this.DeveloperModeCheckBox.Enabled = false;
            this.DeveloperModeCheckBox.Location = new System.Drawing.Point(629, 15);
            this.DeveloperModeCheckBox.Name = "DeveloperModeCheckBox";
            this.DeveloperModeCheckBox.Size = new System.Drawing.Size(104, 17);
            this.DeveloperModeCheckBox.TabIndex = 13;
            this.DeveloperModeCheckBox.Text = "Developer mode";
            this.DeveloperModeCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProfileRemoveButton
            // 
            this.ProfileRemoveButton.Location = new System.Drawing.Point(245, 12);
            this.ProfileRemoveButton.Name = "ProfileRemoveButton";
            this.ProfileRemoveButton.Size = new System.Drawing.Size(21, 21);
            this.ProfileRemoveButton.TabIndex = 14;
            this.ProfileRemoveButton.Text = "-";
            this.ProfileRemoveButton.UseVisualStyleBackColor = true;
            this.ProfileRemoveButton.Click += new System.EventHandler(this.ProfileRemoveButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(313, 11);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ProfileChangeNameButton
            // 
            this.ProfileChangeNameButton.Location = new System.Drawing.Point(272, 12);
            this.ProfileChangeNameButton.Name = "ProfileChangeNameButton";
            this.ProfileChangeNameButton.Size = new System.Drawing.Size(21, 21);
            this.ProfileChangeNameButton.TabIndex = 16;
            this.ProfileChangeNameButton.Text = "R";
            this.ProfileChangeNameButton.UseVisualStyleBackColor = true;
            this.ProfileChangeNameButton.Click += new System.EventHandler(this.ProfileChangeNameButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ProfileChangeNameButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.ProfileRemoveButton);
            this.Controls.Add(this.DeveloperModeCheckBox);
            this.Controls.Add(this.BuildButton);
            this.Controls.Add(this.CodeArea);
            this.Controls.Add(this.PlayButton);
            this.Controls.Add(this.ScreenShotButton);
            this.Controls.Add(this.PreviewCheckBox);
            this.Controls.Add(this.WorkAreaButton);
            this.Controls.Add(this.PreviewPictureBox);
            this.Controls.Add(this.ProfileAddButton);
            this.Controls.Add(this.FilesTreeView);
            this.Controls.Add(this.ProfilesList);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "MainForm";
            this.Text = "BotOfScreenShots";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox ProfilesList;
        private System.Windows.Forms.TreeView FilesTreeView;
        private System.Windows.Forms.Button ProfileAddButton;
        private System.Windows.Forms.PictureBox PreviewPictureBox;
        private System.Windows.Forms.Button WorkAreaButton;
        private System.Windows.Forms.CheckBox PreviewCheckBox;
        private System.Windows.Forms.Button ScreenShotButton;
        private System.Windows.Forms.Button PlayButton;
        private System.Windows.Forms.TextBox CodeArea;
        private System.Windows.Forms.Button BuildButton;
        private System.Windows.Forms.CheckBox DeveloperModeCheckBox;
        private System.Windows.Forms.Button ProfileRemoveButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ProfileChangeNameButton;
    }
}

