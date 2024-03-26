﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    internal class PlayingCards
    {
        private string[] Color = { "Spade", "Diamond", "Club", "Hearth" };
        private string[] Face = { "Ace", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Jack", "Queen", "King" };

        private int[,] Pack = { {0,0}, {0,1}, {0,2}, {0,3}, {0,4}, {0,5}, {0,6}, {0,7}, {0,8}, {0,9}, {0,10}, {0,11}, {0,12},
            {1,0}, {1,1}, {1,2}, {1,3}, {1,4}, {1,5}, {1,6}, {1,7}, {1,8}, {1,9}, {1,10}, {1,11}, {1,12},
            {2,12}, {2,11}, {2,10}, {2,9}, {2,8}, {2,7}, {2,6}, {2,5}, {2,4}, {2,3}, {2,2}, {2,1}, {2,0},
            {3,12}, {3,11}, {3,10}, {3,9}, {3,8}, {3,7}, {3,6}, {3,5}, {3,4}, {3,3}, {3,2}, {3,1}, {3,0} };

        public PlayingCards() { }

        public string GetColor(int n) { return Color[n]; }
        public string GetFace(int n) { return Face[n]; }
        public int[] GetCard(int n) { int[] card = { Pack[n, 0], Pack[n, 1] }; return card; }
    }
}
