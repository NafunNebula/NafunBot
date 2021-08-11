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
            else
            {
                return null;
            }

        }
    }
}