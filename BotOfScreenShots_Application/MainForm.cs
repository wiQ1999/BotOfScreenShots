﻿using BotOfScreenShots_Algorithms;
using BotOfScreenShots_Application.Interfaces;
using BotOfScreenShots_Application.XMLSerilizer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BotOfScreenShots_Application
{
    public partial class MainForm : Form
    {
        private readonly ISerializer _serializer = new XMLSerializer();
        private List<Profile> _profilesList;
        private int _profilesListTempIndex;
        private Rectangle _workArea;
        
        public Profile Profile
        {
            get
            {
                if (ProfilesList.SelectedIndex < 0)
                    return null;
                return _profilesList[ProfilesList.SelectedIndex];
            }
        }

        public MainForm()
        {
            InitializeComponent();
            DeserializeData();
            EnableControls(true);
        }

        private void EnableControls(bool isEnable)
        {
            FilesTreeView.Visible = isEnable;
            WorkAreaButton.Enabled = isEnable;
            ScreenShotButton.Enabled = isEnable;
            PreviewCheckBox.Enabled = isEnable;
            SaveButton.Enabled = isEnable;
            BuildButton.Enabled = isEnable;
            PlayButton.Enabled = isEnable;
            DeveloperModeCheckBox.Enabled = isEnable;
            CodeArea.Enabled = isEnable;
        }

        #region Serialization

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you want to save changes before exit?", "Exiting", MessageBoxButtons.YesNoCancel);

            if (dialog == DialogResult.Yes)
                Save();
            else if (dialog == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void DeserializeData()
        {
            _profilesList = _serializer.Deserialize();
            UpdateProfilesList();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            Profile.Code = CodeArea.Lines;
            Profile.WorkArea = _workArea;
            Profile.IsPreview = PreviewCheckBox.Checked;
            Profile.IsDeveloperMode = DeveloperModeCheckBox.Checked;
            _serializer.Serialize(_profilesList);
        }

        #endregion

        #region ProfilesList

        private void UpdateProfilesList()
        {
            ProfilesList.Items.Clear();
            ProfilesList.Items.AddRange(_profilesList.ToArray());
        }

        private void ProfileAddButton_Click(object sender, EventArgs e)
        {
            _profilesList.Add(new Profile("Profile" + Profile.ID));
            UpdateProfilesList();
            ProfilesList.SelectedIndex = ProfilesList.Items.Count - 1;
        }

        private void ProfileRemoveButton_Click(object sender, EventArgs e)
        {
            if (ProfilesList.SelectedIndex > -1)
            {
                _profilesList.RemoveAt(ProfilesList.SelectedIndex);
                UpdateProfilesList();
                if (ProfilesList.Items.Count > 0)
                    ProfilesList.SelectedIndex = ProfilesList.Items.Count - 1;
                else
                    ProfilesList.Text = string.Empty;
            }
        }

        private void ProfileChangeNameButton_Click(object sender, EventArgs e)
        {
            if (ProfilesList.DropDownStyle == ComboBoxStyle.DropDownList && ProfilesList.SelectedIndex > -1)
            {
                EnableControls(false);
                ProfileAddButton.Enabled = false;
                ProfileRemoveButton.Enabled = false;
                _profilesListTempIndex = ProfilesList.SelectedIndex;
                ProfilesList.DropDownStyle = ComboBoxStyle.Simple;
            }
            else if(ProfilesList.DropDownStyle == ComboBoxStyle.Simple)
            {
                EnableControls(true);
                ProfileAddButton.Enabled = true;
                ProfileRemoveButton.Enabled = true;
                _profilesList[_profilesListTempIndex].ChangeName(ProfilesList.Text);
                ProfilesList.DropDownStyle = ComboBoxStyle.DropDownList;
                UpdateProfilesList();
                ProfilesList.SelectedIndex = _profilesListTempIndex;
            }
        }

        private void ProfilesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FilesList
            PreviewCheckBox.Checked = Profile.IsPreview;
            _workArea = Profile.WorkArea;
            DeveloperModeCheckBox.Checked = Profile.IsDeveloperMode;
            CodeArea.Lines = Profile.Code;
        }

        private void ProfileCheckSaved()
        {
            if (ProfilesList.SelectedIndex > -1 && !Profile.IsSaved)
            {
                DialogResult dialog = MessageBox.Show("Do you want to save changes before shift profile?", "Data not saved", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                    Save();
            }
        }

        #endregion

        //muszę dodać zmianę właściwości IsSaved w profilu na false kiedy zmieniam workarea, zaznaczam checkboxy i kiedy piszę text w codearea
    }
}
