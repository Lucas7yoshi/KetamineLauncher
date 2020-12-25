using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KetamineHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("KetamineHelper v1 by Lucas7yoshi, because why would this need a second version?");
            Console.WriteLine("Ready, launch the game and this'll auto launch it when it closes again!");
            new Program().Run().GetAwaiter().GetResult();
        }
        public async Task Run() // async to avoid Thread sleeping
        {
            //intial launch
            bool firstsight = false;
            string ketamineexe = null;
            while (!firstsight)
            {
                await Task.Delay(1000);
                var ps = Process.GetProcessesByName("OH_MR_KRABS-Win64-Shipping");
                if (ps.Length != 0)
                {
                    ketamineexe = ps[0].MainModule.FileName;
                    firstsight = true;
                    Console.WriteLine("Identified MKODOK exe location: " + ketamineexe);
                }
            }
            Console.WriteLine("To close this, press the X button or CTRL+C");
            while (true)
            {
                var ps = Process.GetProcessesByName("OH_MR_KRABS-Win64-Shipping");
                if (ps.Length == 0)
                {
                    Console.WriteLine(DateTime.Now.ToString("[" + "HH:mm:ss" + "]") + " Launching game.");
                    Process.Start(ketamineexe);
                    await Task.Delay(1000); // give time to launch
                    continue;
                }
                await Task.Delay(200);
            }
        }
    }
}
