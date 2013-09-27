using System;

namespace SampleCsSkin
{
  public class SplashScreenWorker
  {
    public event EventHandler<SplashScreenWorkerArgs> ProgressChanged;
    public event EventHandler HardWorkDone;

    public void DoHardWork()
    {
      // Do something time consuming...
      for (int i = 1; i <= 100; i++)
      {
        for (int j = 1; j <= 500000; j++)
        {
          Math.Pow(i, j);
        }
        this.OnProgressChanged(i);
      }

      this.OnWorkerDone();
    }

    private void OnProgressChanged(int progress)
    {
      var handler = this.ProgressChanged;
      if (handler != null)
      {
        handler(this, new SplashScreenWorkerArgs(progress));
      }
    }

    private void OnWorkerDone()
    {
      var handler = this.HardWorkDone;
      if (handler != null)
      {
        handler(this, EventArgs.Empty);
      }
    }
  }

  public class SplashScreenWorkerArgs : EventArgs
  {
    public SplashScreenWorkerArgs(int progress)
    {
      this.Progress = progress;
    }

    public int Progress
    {
      get;
      private set;
    }
  }
}