
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.ProfileRemoveButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ProfileChangeNameButton = new System.Windows.Forms.Button();
            this.RefreshFilesButton = new System.Windows.Forms.Button();
            this.OpenDirectoryButton = new System.Windows.Forms.Button();
            this.ReferencesList = new System.Windows.Forms.DataGridView();
            this.BackgroundPanel = new System.Windows.Forms.Panel();
            this.AlgorithmsLinkLabel = new System.Windows.Forms.LinkLabel();
            this.ProjectLinkLabel = new System.Windows.Forms.LinkLabel();
            this.GlobalPropertiesLabel = new System.Windows.Forms.Label();
            this.SameImageInfoLabel = new System.Windows.Forms.Label();
            this.SimilarImageInfoLabel = new System.Windows.Forms.Label();
            this.SameImageProp1Label = new System.Windows.Forms.Label();
            this.SimilarImageProp1Label = new System.Windows.Forms.Label();
            this.SimilarImageProp2Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReferencesList)).BeginInit();
            this.BackgroundPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ProfilesList
            // 
            this.ProfilesList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ProfilesList.FormattingEnabled = true;
            this.ProfilesList.Location = new System.Drawing.Point(12, 12);
            this.ProfilesList.Name = "ProfilesList";
            this.ProfilesList.Size = new System.Drawing.Size(219, 21);
            this.ProfilesList.TabIndex = 2;
            this.ProfilesList.DropDown += new System.EventHandler(this.ProfilesList_DropDown);
            this.ProfilesList.SelectedIndexChanged += new System.EventHandler(this.ProfilesList_SelectedIndexChanged);
            // 
            // FilesTreeView
            // 
            this.FilesTreeView.Location = new System.Drawing.Point(12, 39);
            this.FilesTreeView.Name = "FilesTreeView";
            this.FilesTreeView.Size = new System.Drawing.Size(300, 200);
            this.FilesTreeView.TabIndex = 3;
            this.FilesTreeView.Visible = false;
            this.FilesTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FilesTreeView_NodeMouseDoubleClick);
            // 
            // ProfileAddButton
            // 
            this.ProfileAddButton.Location = new System.Drawing.Point(291, 12);
            this.ProfileAddButton.Name = "ProfileAddButton";
            this.ProfileAddButton.Size = new System.Drawing.Size(21, 21);
            this.ProfileAddButton.TabIndex = 4;
            this.ProfileAddButton.Text = "+";
            this.ProfileAddButton.UseVisualStyleBackColor = true;
            this.ProfileAddButton.Click += new System.EventHandler(this.ProfileAddButton_Click);
            // 
            // PreviewPictureBox
            // 
            this.PreviewPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.PreviewPictureBox.Location = new System.Drawing.Point(12, 272);
            this.PreviewPictureBox.Name = "PreviewPictureBox";
            this.PreviewPictureBox.Size = new System.Drawing.Size(300, 300);
            this.PreviewPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PreviewPictureBox.TabIndex = 6;
            this.PreviewPictureBox.TabStop = false;
            // 
            // WorkAreaButton
            // 
            this.WorkAreaButton.Enabled = false;
            this.WorkAreaButton.Location = new System.Drawing.Point(12, 578);
            this.WorkAreaButton.Name = "WorkAreaButton";
            this.WorkAreaButton.Size = new System.Drawing.Size(112, 21);
            this.WorkAreaButton.TabIndex = 7;
            this.WorkAreaButton.Text = "Work area";
            this.WorkAreaButton.UseVisualStyleBackColor = true;
            this.WorkAreaButton.Click += new System.EventHandler(this.WorkAreaButton_Click);
            // 
            // PreviewCheckBox
            // 
            this.PreviewCheckBox.AutoSize = true;
            this.PreviewCheckBox.Enabled = false;
            this.PreviewCheckBox.Location = new System.Drawing.Point(248, 581);
            this.PreviewCheckBox.Name = "PreviewCheckBox";
            this.PreviewCheckBox.Size = new System.Drawing.Size(64, 17);
            this.PreviewCheckBox.TabIndex = 8;
            this.PreviewCheckBox.Text = "Preview";
            this.PreviewCheckBox.UseVisualStyleBackColor = true;
            this.PreviewCheckBox.CheckedChanged += new System.EventHandler(this.PreviewCheckBox_CheckedChanged);
            // 
            // ScreenShotButton
            // 
            this.ScreenShotButton.Enabled = false;
            this.ScreenShotButton.Location = new System.Drawing.Point(130, 578);
            this.ScreenShotButton.Name = "ScreenShotButton";
            this.ScreenShotButton.Size = new System.Drawing.Size(112, 21);
            this.ScreenShotButton.TabIndex = 9;
            this.ScreenShotButton.Text = "Screen shot";
            this.ScreenShotButton.UseVisualStyleBackColor = true;
            this.ScreenShotButton.Click += new System.EventHandler(this.ScreenShotButton_Click);
            // 
            // PlayButton
            // 
            this.PlayButton.BackColor = System.Drawing.Color.ForestGreen;
            this.PlayButton.Enabled = false;
            this.PlayButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PlayButton.ForeColor = System.Drawing.Color.White;
            this.PlayButton.Location = new System.Drawing.Point(297, 3);
            this.PlayButton.Name = "PlayButton";
            this.PlayButton.Size = new System.Drawing.Size(147, 23);
            this.PlayButton.TabIndex = 10;
            this.PlayButton.Text = "Play";
            this.PlayButton.UseVisualStyleBackColor = false;
            this.PlayButton.Click += new System.EventHandler(this.PlayButton_Click);
            // 
            // CodeArea
            // 
            this.CodeArea.AcceptsTab = true;
            this.CodeArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeArea.Enabled = false;
            this.CodeArea.Font = new System.Drawing.Font("Consolas", 10F);
            this.CodeArea.Location = new System.Drawing.Point(3, 27);
            this.CodeArea.Multiline = true;
            this.CodeArea.Name = "CodeArea";
            this.CodeArea.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CodeArea.Size = new System.Drawing.Size(591, 540);
            this.CodeArea.TabIndex = 11;
            this.CodeArea.TextChanged += new System.EventHandler(this.CodeArea_TextChanged);
            // 
            // BuildButton
            // 
            this.BuildButton.Enabled = false;
            this.BuildButton.Location = new System.Drawing.Point(216, 3);
            this.BuildButton.Name = "BuildButton";
            this.BuildButton.Size = new System.Drawing.Size(75, 23);
            this.BuildButton.TabIndex = 12;
            this.BuildButton.Text = "Build";
            this.BuildButton.UseVisualStyleBackColor = true;
            this.BuildButton.Click += new System.EventHandler(this.BuildButton_Click);
            // 
            // ProfileRemoveButton
            // 
            this.ProfileRemoveButton.Location = new System.Drawing.Point(264, 12);
            this.ProfileRemoveButton.Name = "ProfileRemoveButton";
            this.ProfileRemoveButton.Size = new System.Drawing.Size(21, 21);
            this.ProfileRemoveButton.TabIndex = 14;
            this.ProfileRemoveButton.Text = "-";
            this.ProfileRemoveButton.UseVisualStyleBackColor = true;
            this.ProfileRemoveButton.Click += new System.EventHandler(this.ProfileRemoveButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(110, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 15;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ProfileChangeNameButton
            // 
            this.ProfileChangeNameButton.Location = new System.Drawing.Point(237, 12);
            this.ProfileChangeNameButton.Name = "ProfileChangeNameButton";
            this.ProfileChangeNameButton.Size = new System.Drawing.Size(21, 21);
            this.ProfileChangeNameButton.TabIndex = 16;
            this.ProfileChangeNameButton.Text = "R";
            this.ProfileChangeNameButton.UseVisualStyleBackColor = true;
            this.ProfileChangeNameButton.Click += new System.EventHandler(this.ProfileChangeNameButton_Click);
            // 
            // RefreshFilesButton
            // 
            this.RefreshFilesButton.Location = new System.Drawing.Point(166, 245);
            this.RefreshFilesButton.Name = "RefreshFilesButton";
            this.RefreshFilesButton.Size = new System.Drawing.Size(146, 21);
            this.RefreshFilesButton.TabIndex = 17;
            this.RefreshFilesButton.Text = "Refresh list";
            this.RefreshFilesButton.UseVisualStyleBackColor = true;
            this.RefreshFilesButton.Click += new System.EventHandler(this.RefreshFilesButton_Click);
            // 
            // OpenDirectoryButton
            // 
            this.OpenDirectoryButton.Location = new System.Drawing.Point(12, 245);
            this.OpenDirectoryButton.Name = "OpenDirectoryButton";
            this.OpenDirectoryButton.Size = new System.Drawing.Size(146, 21);
            this.OpenDirectoryButton.TabIndex = 18;
            this.OpenDirectoryButton.Text = "Open directory";
            this.OpenDirectoryButton.UseVisualStyleBackColor = true;
            this.OpenDirectoryButton.Click += new System.EventHandler(this.OpenDirectoryButton_Click);
            // 
            // ReferencesList
            // 
            this.ReferencesList.AllowUserToOrderColumns = true;
            this.ReferencesList.AllowUserToResizeColumns = false;
            this.ReferencesList.AllowUserToResizeRows = false;
            this.ReferencesList.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.ReferencesList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReferencesList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ReferencesList.ColumnHeadersHeight = 21;
            this.ReferencesList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.ReferencesList.DefaultCellStyle = dataGridViewCellStyle2;
            this.ReferencesList.Location = new System.Drawing.Point(922, 12);
            this.ReferencesList.MultiSelect = false;
            this.ReferencesList.Name = "ReferencesList";
            this.ReferencesList.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ReferencesList.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.ReferencesList.RowHeadersWidth = 25;
            this.ReferencesList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.ReferencesList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ReferencesList.Size = new System.Drawing.Size(200, 466);
            this.ReferencesList.TabIndex = 20;
            this.ReferencesList.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ReferencesList_CellValueChanged);
            // 
            // BackgroundPanel
            // 
            this.BackgroundPanel.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.BackgroundPanel.Controls.Add(this.AlgorithmsLinkLabel);
            this.BackgroundPanel.Controls.Add(this.ProjectLinkLabel);
            this.BackgroundPanel.Controls.Add(this.CodeArea);
            this.BackgroundPanel.Controls.Add(this.SaveButton);
            this.BackgroundPanel.Controls.Add(this.BuildButton);
            this.BackgroundPanel.Controls.Add(this.PlayButton);
            this.BackgroundPanel.Location = new System.Drawing.Point(318, 12);
            this.BackgroundPanel.Name = "BackgroundPanel";
            this.BackgroundPanel.Size = new System.Drawing.Size(598, 587);
            this.BackgroundPanel.TabIndex = 21;
            // 
            // AlgorithmsLinkLabel
            // 
            this.AlgorithmsLinkLabel.AutoSize = true;
            this.AlgorithmsLinkLabel.Location = new System.Drawing.Point(85, 570);
            this.AlgorithmsLinkLabel.Name = "AlgorithmsLinkLabel";
            this.AlgorithmsLinkLabel.Size = new System.Drawing.Size(99, 13);
            this.AlgorithmsLinkLabel.TabIndex = 18;
            this.AlgorithmsLinkLabel.TabStop = true;
            this.AlgorithmsLinkLabel.Text = "Algorithms research";
            this.AlgorithmsLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AlgorithmsLinkLabel_LinkClicked);
            // 
            // ProjectLinkLabel
            // 
            this.ProjectLinkLabel.AutoSize = true;
            this.ProjectLinkLabel.Location = new System.Drawing.Point(3, 570);
            this.ProjectLinkLabel.Name = "ProjectLinkLabel";
            this.ProjectLinkLabel.Size = new System.Drawing.Size(76, 13);
            this.ProjectLinkLabel.TabIndex = 17;
            this.ProjectLinkLabel.TabStop = true;
            this.ProjectLinkLabel.Text = "GitHub Project";
            this.ProjectLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ProjectLinkLabel_LinkClicked);
            // 
            // GlobalPropertiesLabel
            // 
            this.GlobalPropertiesLabel.AutoSize = true;
            this.GlobalPropertiesLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.GlobalPropertiesLabel.Location = new System.Drawing.Point(975, 481);
            this.GlobalPropertiesLabel.Name = "GlobalPropertiesLabel";
            this.GlobalPropertiesLabel.Size = new System.Drawing.Size(147, 20);
            this.GlobalPropertiesLabel.TabIndex = 22;
            this.GlobalPropertiesLabel.Text = "Global properties";
            // 
            // SameImageInfoLabel
            // 
            this.SameImageInfoLabel.AutoSize = true;
            this.SameImageInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SameImageInfoLabel.Location = new System.Drawing.Point(1018, 530);
            this.SameImageInfoLabel.Name = "SameImageInfoLabel";
            this.SameImageInfoLabel.Size = new System.Drawing.Size(104, 13);
            this.SameImageInfoLabel.TabIndex = 23;
            this.SameImageInfoLabel.Text = "Find the same image";
            // 
            // SimilarImageInfoLabel
            // 
            this.SimilarImageInfoLabel.AutoSize = true;
            this.SimilarImageInfoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SimilarImageInfoLabel.Location = new System.Drawing.Point(916, 589);
            this.SimilarImageInfoLabel.Name = "SimilarImageInfoLabel";
            this.SimilarImageInfoLabel.Size = new System.Drawing.Size(206, 13);
            this.SimilarImageInfoLabel.TabIndex = 24;
            this.SimilarImageInfoLabel.Text = "Set similarity percent and find similar image";
            // 
            // SameImageProp1Label
            // 
            this.SameImageProp1Label.AutoSize = true;
            this.SameImageProp1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SameImageProp1Label.Location = new System.Drawing.Point(942, 514);
            this.SameImageProp1Label.Name = "SameImageProp1Label";
            this.SameImageProp1Label.Size = new System.Drawing.Size(180, 16);
            this.SameImageProp1Label.TabIndex = 25;
            this.SameImageProp1Label.Text = "SameImage(Bitmap toFinde)";
            // 
            // SimilarImageProp1Label
            // 
            this.SimilarImageProp1Label.AutoSize = true;
            this.SimilarImageProp1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SimilarImageProp1Label.Location = new System.Drawing.Point(932, 556);
            this.SimilarImageProp1Label.Name = "SimilarImageProp1Label";
            this.SimilarImageProp1Label.Size = new System.Drawing.Size(190, 16);
            this.SimilarImageProp1Label.TabIndex = 26;
            this.SimilarImageProp1Label.Text = "SimilarImage.SimilarityPercent";
            // 
            // SimilarImageProp2Label
            // 
            this.SimilarImageProp2Label.AutoSize = true;
            this.SimilarImageProp2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SimilarImageProp2Label.Location = new System.Drawing.Point(937, 573);
            this.SimilarImageProp2Label.Name = "SimilarImageProp2Label";
            this.SimilarImageProp2Label.Size = new System.Drawing.Size(185, 16);
            this.SimilarImageProp2Label.TabIndex = 27;
            this.SimilarImageProp2Label.Text = "SimilarImage(Bitmap toFinde)";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1134, 611);
            this.Controls.Add(this.SimilarImageProp2Label);
            this.Controls.Add(this.SimilarImageProp1Label);
            this.Controls.Add(this.SameImageProp1Label);
            this.Controls.Add(this.SimilarImageInfoLabel);
            this.Controls.Add(this.SameImageInfoLabel);
            this.Controls.Add(this.GlobalPropertiesLabel);
            this.Controls.Add(this.BackgroundPanel);
            this.Controls.Add(this.ReferencesList);
            this.Controls.Add(this.OpenDirectoryButton);
            this.Controls.Add(this.RefreshFilesButton);
            this.Controls.Add(this.ProfileChangeNameButton);
            this.Controls.Add(this.ProfileRemoveButton);
            this.Controls.Add(this.ScreenShotButton);
            this.Controls.Add(this.PreviewCheckBox);
            this.Controls.Add(this.WorkAreaButton);
            this.Controls.Add(this.PreviewPictureBox);
            this.Controls.Add(this.ProfileAddButton);
            this.Controls.Add(this.FilesTreeView);
            this.Controls.Add(this.ProfilesList);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximumSize = new System.Drawing.Size(1150, 650);
            this.MinimumSize = new System.Drawing.Size(1150, 650);
            this.Name = "MainForm";
            this.Text = "BotOfScreenShots";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.PreviewPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ReferencesList)).EndInit();
            this.BackgroundPanel.ResumeLayout(false);
            this.BackgroundPanel.PerformLayout();
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
        private System.Windows.Forms.Button ProfileRemoveButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ProfileChangeNameButton;
        private System.Windows.Forms.Button RefreshFilesButton;
        private System.Windows.Forms.Button OpenDirectoryButton;
        private System.Windows.Forms.DataGridView ReferencesList;
        private System.Windows.Forms.Panel BackgroundPanel;
        private System.Windows.Forms.LinkLabel AlgorithmsLinkLabel;
        private System.Windows.Forms.LinkLabel ProjectLinkLabel;
        private System.Windows.Forms.Label GlobalPropertiesLabel;
        private System.Windows.Forms.Label SameImageInfoLabel;
        private System.Windows.Forms.Label SimilarImageInfoLabel;
        private System.Windows.Forms.Label SameImageProp1Label;
        private System.Windows.Forms.Label SimilarImageProp1Label;
        private System.Windows.Forms.Label SimilarImageProp2Label;
    }
}

