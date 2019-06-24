using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sudo
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                if (args.Length < 1)
                    throw new ArgumentException("Must provide a command to execute.");

                var fileName = args[0];
                var arguments = string.Join(" ", args.Skip(1));

                var psi = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = arguments,
                    Verb = "runas",
                    UseShellExecute = true,
                    WorkingDirectory = Environment.CurrentDirectory,
                };
                var proc = Process.Start(psi);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(1);
            }
        }
    }
}
