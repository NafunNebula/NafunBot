using System;

namespace NafunBot
{
    class Program
    {
        static void Main(string[] args)
        {


            while (true)
            {
                Console.WriteLine("Enter a command: ");

                string command = Console.ReadLine();
            
                var myCommand = CommandFactory.create(command);
                Console.WriteLine(myCommand.executeCommand(null));
            }
            
        }
    }
}