using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SampleCsSkin
{
  public class SampleCsSkinObject : Rhino.Runtime.Skin
  {
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
  }
}
