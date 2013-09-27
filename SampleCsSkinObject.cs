using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace SampleCsSkin
{
  public class SampleCsSkinObject : Rhino.Runtime.Skin
  {
    private SplashScreen m_splash;
    private bool m_done = false;

    protected override string ApplicationName
    {
      get
      {
        return "SampleCsSkin";
      }
    }

    protected override System.Drawing.Bitmap MainRhinoIcon
    {
      get
      {
        Icon icon = new Icon(Properties.Resources.SampleCsSkin, new Size(32, 32));
        return icon.ToBitmap();
      }
    }

    protected override void ShowSplash()
    {
      m_splash = new SplashScreen();

      Thread thread = new Thread(new ThreadStart(this.ShowSplashScreen));
      thread.Start();

      SplashScreenWorker worker = new SplashScreenWorker();
      worker.ProgressChanged += (o, ex) =>
      {
        m_splash.UpdateProgress(ex.Progress);
      };

      worker.HardWorkDone += (o, ex) =>
      {
        m_done = true;
      };

      worker.DoHardWork();
    }

    private void ShowSplashScreen()
    {
      m_splash.Show();
      
      while (!m_done)
      {
        Application.DoEvents();
      }

      m_splash.Close();
      m_splash.Dispose();
      m_splash = null;
    }

  }
}
