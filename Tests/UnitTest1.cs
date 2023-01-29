

using System.Diagnostics;

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestProcessExists()
        {
            var processName = "notepad";
            Process.Start(processName);
            var process = ProcessMonitor.ProcessExists(processName);
            Assert.IsNotNull(process);
            Assert.AreEqual(process.ProcessName, processName);
            ProcessMonitor.KillProcess(process);
        }

        [Test]
        public void TestProcessThresholdReached()
        {
            var startTime = DateTime.Now.AddSeconds(-11);
            var threshold = 10;
            var result = ProcessMonitor.ProcessThresholdReached(startTime, threshold);
            Assert.IsTrue(result);
        }


        [Test]
        public void TestProcessClosed()
        {
            var processName = "notepad";
            Process.Start(processName);
            var process = ProcessMonitor.ProcessExists(processName);
            if (process != null)
            {
                ProcessMonitor.KillProcess(process);
                Assert.IsNull(ProcessMonitor.ProcessExists(processName));
            }
        }
    }
}