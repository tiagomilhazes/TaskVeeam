using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;

public class ProcessMonitor
{
    public static Process ProcessExists(string processName)
    {
        var process = Process.GetProcessesByName(processName).FirstOrDefault();
        if (process != null)
        {
            return process;
        }
        else
        {
            return null;
        }
    }

    public static bool ProcessThresholdReached(DateTime startTime, int threshold)
    {
        if (startTime < DateTime.Now.AddSeconds(-threshold))
        {
            return true;
        }
        else
            return false;
    }

    public static void KillProcess(Process process)
    {
        Console.WriteLine($"Killing process {process.ProcessName} that has been running for {(DateTime.Now - process.StartTime).TotalSeconds} seconds.");
        process.Kill();
    }
}
