using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc24
{
    class RandomNumbersBuilder
    {
        private int Count=0;
        private List<int> RandomNumbers;

        public int NumberA
        {
            get;
            set;
        }
        public int NumberB
        {
            get;
            set;
        }
        public int NumberC
        {
            get;
            set;
        }
        public int NumberD
        {
            get;
            set;
        }

        public RandomNumbersBuilder()
        {

        }

        public void RenderRandomNumbers()
        {       
            RandomNumbers = new List<int>();

            var singleRandomItem = new Random();
            for (int i = 0; i < 4; i++)
            {
                RandomNumbers.Add(singleRandomItem.Next(12) + 1);
            }
            NumberA=RandomNumbers[0];
            NumberB = RandomNumbers[1];
            NumberC = RandomNumbers[2];
            NumberD = RandomNumbers[3];

            Count++; 
        }

        public int PickupRandomNumber(int n)
        {
            return RandomNumbers[n];
        }

    }
}
