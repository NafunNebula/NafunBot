using System;
using NafunBot;

namespace NafunBot
{
    public class RandomNumber : CommandInterface
    {
        public string executeCommand(string[] args)
        {
            Random random = new Random();
            int dice = random.Next(1, 100);
            return dice.ToString();
        }
    }
}