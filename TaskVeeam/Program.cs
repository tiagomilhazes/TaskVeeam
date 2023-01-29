    int threshold = 10; // threshold in seconds
    string processName = "notepad";
   
    while (true)
    {
    var processID = ProcessMonitor.ProcessExists(processName);
    if (processID != null) {

        try
        {
            if (ProcessMonitor.ProcessThresholdReached(processID.StartTime, threshold))
            {
                ProcessMonitor.KillProcess(processID);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        Thread.Sleep(1000);
    }
           
    }
