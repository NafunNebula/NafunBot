using System;

namespace NafunBot
{
    public class Dice : CommandInterface
    {
        public string executeCommand(string[] args)
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            return dice.ToString();
        }
    }
}