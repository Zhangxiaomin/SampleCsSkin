using System;
using System.Windows.Forms;

namespace SampleCsSkin
{
  public partial class SplashScreen : Form
  {
    private delegate void ProgressDelegate(int progress);
    private ProgressDelegate m_delegate;

    public SplashScreen()
    {
      InitializeComponent();
      progressBar.Maximum = 100;
      m_delegate = this.UpdateProgressInternal;
    }

    private void SplashScreen_Load(object sender, EventArgs e)
    {
    }

    private void UpdateProgressInternal(int progress)
    {
      if (null != Handle)
        progressBar.Value = progress;
    }

    public void UpdateProgress(int progress)
    {
      Invoke(m_delegate, progress);
    }
  }
}
