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
        private int[] _bets = new int[3]; 

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

        public int[] Bets
        {
            get { return _bets; }
        }
    

        public void clearAllBets() { 
            for (int i = 0; i < _bets.Length; i++)
            {
                _bets[i] = 0;
            }
        }

        public event EventHandler FundsChanged;

        protected virtual void OnMyFundsChanged()
        {
            FundsChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
