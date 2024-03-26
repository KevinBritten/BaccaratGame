using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaccaratGame
{
    internal class Shoe
    {
        private int DeckN = 8;
        private int CardN = 52;
        private int[] Stack = new int[8 * 52];
        private int TallyS, Position;

        public Shoe() { }

        public void ReplenishShoe()
        {
            int i, j, index, temp;
            int k = 0;
            Random rand = new Random();

            // Fill the stack with cards.
            for (i = 0; i < DeckN; i++)
            {
                for (j = 0; j < CardN; j++)
                {
                    Stack[k] = j;
                    k++;
                }
            }

            // Shuffle the stack.
            for (i = 0; i < Stack.Length; i++)
            {
                index = rand.Next(Stack.Length);
                temp = Stack[i];
                Stack[i] = Stack[index];
                Stack[index] = temp;
            }
        }

        public void ShowStack()
        {
            int i;
            int[] Check = new int[52];
            for (i = 0; i < Check.Length; i++) { Check[i] = 0; }
            for (i = 0; i < Stack.Length; i++)
            {
                Console.WriteLine(i + " " + Stack[i]);
                Check[Stack[i]] += 1;
            }
            Console.WriteLine("");
            for (i = 0; i < Check.Length; i++) { Console.WriteLine(i + " " + Check[i]); }
        }
    }
}
