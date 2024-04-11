using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaccaratGame
{
    public partial class PlayerSit : Form
    {
        Player[] _players;
        int _position;
        EventHandler _fundsChangedCallback;
        String[] avatarStrings = { "monkey", "cat", "monkey", "monkey", "monkey", "monkey", "monkey", "monkey", "monkey" };
        String selectedAvatar = "";
        public PlayerSit(int S, Player[] players, EventHandler fundsChangedCallback)
        {
            InitializeComponent();
            SeatNumberLabel.Text = "Let's occupy seat " + (S + 1).ToString();
            _position = S;
            _players = players;
            _fundsChangedCallback = fundsChangedCallback;
            DisableChosenAvatars();
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            String name = PlayerNameTextBox.Text;
            int funds = (int)FundCommit.Value;
            Boolean nameSet = !String.IsNullOrWhiteSpace(name);
            Boolean avatarSet = !String.IsNullOrEmpty(selectedAvatar);
            Boolean fundsSet = !(funds == 0);
            NameRequiredErrorLabel.Visible = !nameSet;
            AvatarRequiredErrorLabel.Visible = !avatarSet;
            FundsRequiredErrorLabel.Visible = !fundsSet;
            if (nameSet && fundsSet && avatarSet)
            {
                //TODO: replace placeholder with avatar filepath
                _players[_position] = new Player(name, 0, selectedAvatar);
                _players[_position].FundsChanged += _fundsChangedCallback;
                _players[_position].Funds = funds;
                this.Close();
            }
        }

        private void SelectAvatar(int avatarIndex)
        {
            foreach (PictureBox avatarPictureBox in AvatarBox.Controls.OfType<PictureBox>())
            {
                if (avatarPictureBox.Name.Contains(avatarIndex.ToString()))
                {
                    avatarPictureBox.BackColor = SystemColors.Highlight;
                    avatarPictureBox.BorderStyle = BorderStyle.Fixed3D;
                }
                else
                {
                    avatarPictureBox.BackColor = SystemColors.Control;
                    avatarPictureBox.BorderStyle = BorderStyle.None;
                }
            }
            selectedAvatar = avatarStrings[avatarIndex - 1];
        }

        private void DisableChosenAvatars()
        {
            ArrayList chosenAvatars = new ArrayList();
            foreach (Player player in _players)
            {
                if (player != null)
                {
                    chosenAvatars.Add(player.AvatarName);
                }
            }
            foreach (string chosenAvatar in chosenAvatars)
            {
                int avatarIndex = Array.IndexOf(avatarStrings, chosenAvatar);
                PictureBox avatarPictureBox = (PictureBox)AvatarBox.Controls.Find($"avatarPictureBox{avatarIndex + 1}", false)[0];
                avatarPictureBox.Enabled = false;
                Image grayScaleImage = ToolStripRenderer.CreateDisabledImage(avatarPictureBox.Image);
                avatarPictureBox.Image = grayScaleImage;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void avatarPictureBox1_Click(object sender, EventArgs e)
        {
            SelectAvatar(1);
        }

        private void avatarPictureBox2_Click(object sender, EventArgs e)
        {
            SelectAvatar(2);
        }

        private void avatarPictureBox3_Click(object sender, EventArgs e)
        {
            SelectAvatar(3);
        }

        private void avatarPictureBox4_Click(object sender, EventArgs e)
        {
            SelectAvatar(4);
        }

        private void avatarPictureBox5_Click(object sender, EventArgs e)
        {
            SelectAvatar(5);
        }

        private void avatarPictureBox6_Click(object sender, EventArgs e)
        {
            SelectAvatar(6);
        }

        private void avatarPictureBox7_Click(object sender, EventArgs e)
        {
            SelectAvatar(7);
        }

        private void avatarPictureBox8_Click(object sender, EventArgs e)
        {
            SelectAvatar(8);
        }

        private void avatarPictureBox9_Click(object sender, EventArgs e)
        {
            SelectAvatar(9);
        }


    }
}
