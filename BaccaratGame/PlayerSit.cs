using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaccaratGame
{
    public partial class PlayerSit : Form
    {
        Player[] _players;
        int[] _playerStates;
        int _position;
        EventHandler _fundsChangedCallback;
        public PlayerSit(int S, Player[] players, EventHandler fundsChangedCallback,int[] playerStates)
        {
            InitializeComponent();
            SeatNumberLabel.Text = "Let's occupy seat " + (S + 1).ToString();
            _position = S;
            _players = players;
            _fundsChangedCallback = fundsChangedCallback;
            _playerStates = playerStates;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            String name = PlayerNameTextBox.Text;
            int funds = (int)FundCommit.Value;
            //TODO: replace placeholder with avatar filepath
            _players[_position] = new Player(name, 0, "placeholder");
            _players[_position].FundsChanged += _fundsChangedCallback;
            _players[_position].Funds = funds;
            _playerStates[_position] = 2;
            this.Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
