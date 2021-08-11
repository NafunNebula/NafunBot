using System;

namespace NafunBot
{
    public class CommandFactory
    {
        public static CommandInterface create(string command)
        {
            if (command.Equals("Dice"))
            {
                return new Dice();
            }
            else if (command.Equals("RandomNumber"))
            {
                return new RandomNumber();
            }
            else if (command.Equals("CoinFlip"))
            {
                return new CoinFlip();
            }
            else
            {
                return null;
            }
        }
    }
}