using System;
using System.IO;

namespace ToyRobotConsole
{
    public class Program
    {
        static void Main(string[] args)
        {
            const string commandFile = @"commands.txt";
            var currentfolder = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            
            if (!File.Exists(Path.Combine(currentfolder, commandFile))) 
                Console.WriteLine("Command.txt file not found.");   
            else
            {
                // Read the file and display it line by line.
                using (var file = new StreamReader(commandFile))
                {
                    var remoteControl = new Controller(new Map(5, 5));
                    string command;
                    
                    while ((command = file.ReadLine()) != null)
                    {
                        var result = remoteControl.Command(command);
                        if (!string.IsNullOrWhiteSpace(result))
                            Console.WriteLine(result);
                    }
                    file.Close();
                }
            }
            Console.WriteLine("Completed.  Please press enter to end Toy Robot programme.");
            Console.ReadLine();
        }
    }
}
