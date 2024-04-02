using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    internal class Player
    {
        private String _name;
        private decimal _funds;
        //TODO: add avatar files
        //private Image _avatar;
        private decimal _playerBet;
        private decimal _dealerBet;
        private decimal _tieBet;

        public Player(String name, decimal funds, String avatarFilePath)
        {
            _name = name;
            _funds = funds;
            //_avatar = Image.FromFile(avatarFilePath);
        }

        public String Name
        {
            get { return _name; }
        }

        public decimal Funds
        {
            get { return _funds; }
            set {
                OnMyFundsChanged();
                _funds = value; 
            }
        }

        //public Image Avatar
        //{
        //    get { return _avatar; }
        //}

        public decimal PlayerBet
        {
            get { return _playerBet; }
            set { _playerBet = value; }
        } 
        public decimal DealerBet
        {
            get { return _dealerBet; }
            set { _dealerBet = value; }
        }
        public decimal TieBet
        {
            get { return _tieBet; }
            set { _tieBet = value; }
        }
    

        public void clearAllBets() { 
            _playerBet = 0;
            _dealerBet = 0;
            _tieBet = 0;
        }

        public event EventHandler FundsChanged;

        protected virtual void OnMyFundsChanged()
        {
            FundsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
