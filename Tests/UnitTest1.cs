

namespace Tests
{
    public class Tests
    {
        [Test]
        public void TestProcessExists()
        {
            var processName = "notepad";
            var process = ProcessMonitor.ProcessExists(processName);
            Assert.IsNotNull(process);
            Assert.AreEqual(process.ProcessName, processName);
        }

        [Test]
        public void TestProcessThresholdReached()
        {
            var startTime = DateTime.Now.AddSeconds(-11);
            var threshold = 10;
            var result = ProcessMonitor.ProcessThresholdReached(startTime, threshold);
            Assert.IsTrue(result);
        }
    }
}