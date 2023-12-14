using System.Diagnostics;

namespace TrayCPUTool
{
    internal class ComputerCpu
    {
        PerformanceCounter cpuCounter;
        PerformanceCounter ramCounter;

        private System.Windows.Forms.Timer cpuTimer = new System.Windows.Forms.Timer();
        private const int CPU_TIMER_INTERVAL = 1000;

        private float cpuUtilization = 0;
        private float ramUtilization = 0;

        public ComputerCpu()
        {
            cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");

            cpuTimer.Interval = CPU_TIMER_INTERVAL;
            cpuTimer.Tick += new EventHandler(cpuTimerHandle);
            cpuTimer.Start();
        }

        public float cpuUtilizationGet()
        {
            return cpuUtilization;
        }

        public float ramUtilizationGet()
        {
            return ramUtilization;
        }

        private void cpuTimerHandle(object? sender, EventArgs e)
        {
            cpuUtilization = cpuCounter.NextValue();
            ramUtilization = ramCounter.NextValue();
        }
    }
}
