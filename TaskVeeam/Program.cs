using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;


    int threshold = 10; // threshold in seconds
    string processName = "Notepad";
    while (true)
    {
    var process = Process.GetProcessesByName(processName).FirstOrDefault();
    
    if (process != null) {

        try
        {
            if (process.StartTime < DateTime.Now.AddSeconds(-threshold))
            {
                Console.WriteLine($"Killing process {process.ProcessName} that has been running for {(DateTime.Now - process.StartTime).TotalSeconds} seconds.");
                process.Kill();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Thread.Sleep(1000);
    }
           
    }

