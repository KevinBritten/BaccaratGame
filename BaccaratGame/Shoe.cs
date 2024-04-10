using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Play {
    internal class Shoe {
        private int _deckN = 8;
        private int _cardN = 52;
        private int _cutCard = 7;
        private int[] _stack = new int[8 * 52];
        private int _tallyS, _position;
        private int[] _check = new int[52];

        public Shoe() {
            _tallyS = 0;
            for (int i = 0; i < _check.Length; i++) { _check[i] = 0; }
            ReplenishShoe();
        }

        public int DeckN() { return _deckN; }
        public int CardN() { return _cardN;}
        public int Position() { return _position; }
        public int[] Check() { return _check; }
        public int TallyS() { return _tallyS; }
        public int[] Stack() { return _stack; }

        public Boolean CheckCutCard() {
            if ((_stack.Length - _position) <= _cutCard) { return true; } else { return false; }
        }

        public void ReplenishShoe() {
            int i, j, index, temp;
            Random rand = new Random();
            // Fill the stack with cards.
            for (i = 0; i < _deckN; i++) { for (j = 0; j < _cardN; j++) { _stack[i * _cardN + j] = j; } }
            // Shuffle the stack.
            for (i = 0; i < _stack.Length; i++) {
                index = rand.Next(_stack.Length);
                temp = _stack[i];
                _stack[i] = _stack[index];
                _stack[index] = temp;
            }
            // Updating attributes.
            for (i = 0; i < _stack.Length; i++) { _check[_stack[i]] += 1; }
            _position = 0;
            _tallyS += 1;
        }

        public int[] PrimingShoe() {
            int[] ValueCard = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 
                            10, 10, 10, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 10, 10, 10, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
            int Start = PickCard();
            int[] P = new int[1 + ValueCard[Start]];
            P[0] = Start;
            for (int i = 1; i < P.Length; i++) { P[i] = PickCard(); }
            return P; 
        }

        public int[] DrainingShoe() {
            int[] D = new int[_stack.Length - _position];
            int Start = _position;
            for (int i = Start; i < _stack.Length; i++) { D[i - Start] = PickCard(); }
            return D;
        }

        public int PickCard() {
            int Card = _stack[_position];
            _position += 1;
            if (_position == _stack.Length) { ReplenishShoe(); }
            return Card;
        }
    }
}
