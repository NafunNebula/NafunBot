using System;
using NafunBot;

namespace NafunBot
{
    public class CoinFlip : CommandInterface
    {
        public string executeCommand(string[] args)
        {
            Random random = new Random();
            int dice = random.Next(1, 2);
            string coinFlip = "";
            if (random.Next() == 1)
            {
                return coinFlip = "heads";
            }
            else
            {
                return coinFlip = "tails";

            }

        }
    }
}