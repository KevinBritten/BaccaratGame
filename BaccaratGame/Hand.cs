using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play {
    internal class Hand {
        private Boolean PLAYER = true;
        private Boolean BANKER = false;
        private int[] _banker = new int[3];
        private int[] _player = new int[3];
        private int[] _scores = new int[2];
        private Boolean[] _thirdCard = new Boolean[2];
        private Boolean _naturalHand;
        private int _result;
        private int[] _cardValue = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 0, 0, 0,
                                    0, 0, 0, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0, 0, 0, 0, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
        private string[] _resultName = { "Player", "Banker", "Tie" };

        public Hand() { _thirdCard[0] = false; _thirdCard[1] = false; _naturalHand = false; }

        public int[] Banker() { return _banker; }
        public int[] Player() { return _player; }
        public int[] Scores() { return _scores; }
        public Boolean[] ThirdCard() { return _thirdCard; }
        public Boolean NaturalHand() { return _naturalHand; }
        public int Result() { return _result; }
        public string ResultName() { return _resultName[_result]; }

        public void DistributeFourCards(int[] C) {
            _player[0] = C[0]; _player[1] = C[2];
            _banker[0] = C[1]; _banker[1] = C[3];
            _scores[0] = CalculateScore(_cardValue[_player[0]] + _cardValue[_player[1]]);
            if (_scores[0] >= 8) { _naturalHand = true; }
            _scores[1] = CalculateScore(_cardValue[_banker[0]] + _cardValue[_banker[1]]);
            if (_scores[1] >= 8) { _naturalHand = true; }
        }

        public void GetThirdCard(int C, Boolean Choice) {
            if (Choice == PLAYER) { GetPlayerThirdCard(C); } else { GetBankerThirdCard(C); }
        }

        public void GetPlayerThirdCard(int C) {
            _player[2] = C;
            _scores[0] = CalculateScore(_cardValue[_player[0]] + _cardValue[_player[1]] + _cardValue[_player[2]]);
        }

        public void GetBankerThirdCard(int C) {
            _banker[2] = C;
            _scores[1] = CalculateScore(_cardValue[_banker[0]] + _cardValue[_banker[1]] + _cardValue[_banker[2]]);
        }

        public int CalculateScore(int S) {
            if (S >= 20) { return S - 20; } else if (S >= 10) { return S - 10; } else { return S; }
        }

        public Boolean NoNaturalHand() { if (_naturalHand) { return false; } else { return true; } }

        public Boolean NeedPlayerThirdCard() {
            if (_scores[0] <= 5) { _thirdCard[0] = true;  return true; } else { return false; }
        }

        public Boolean NeedBankerThirdCard() { 
            if (!_thirdCard[0]) { 
                if (_scores[1] <= 5) { _thirdCard[1] = true; return true; } else { return false; } 
            }
            else {
                int thirdCardP = _cardValue[_player[2]];
                if (_scores[1] <= 2) { _thirdCard[1] = true; return true; }
                else if ((_scores[1] == 3) && (thirdCardP != 8)) { _thirdCard[1] = true; return true; }
                else if ((_scores[1] == 4) && (thirdCardP >= 2 && thirdCardP <= 7)) { _thirdCard[1] = true; return true; }
                else if ((_scores[1] == 5) && (thirdCardP >= 4 && thirdCardP <= 7)) { _thirdCard[1] = true; return true; }
                else if ((_scores[1] == 6) && (thirdCardP >= 6 && thirdCardP <= 7)) { _thirdCard[1] = true; return true; }
                else { return false; }
            }
        }

        public void DetermineWinningHand() { 
            if (_scores[0] > _scores[1]) { _result = 0; }
            else if (_scores[0] < _scores[1]) { _result = 1; }
            else { _result = 2; }
        }

        public void ResetHand() { _thirdCard[0] = false; _thirdCard[1] = false; _naturalHand = false; }
    }
}
