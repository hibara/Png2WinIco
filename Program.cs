using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Png2WinIco.Properties;

namespace png2winico
{
  static class Program
  {
    /// <summary>
    /// アプリケーションのメイン エントリ ポイントです。
    /// </summary>
    [STAThread]
    static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);

      // Language
      if (Settings.Default.Language == "ja-JP")
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
      }
      else if (Settings.Default.Language == "EN" )
      {
        Thread.CurrentThread.CurrentCulture = new CultureInfo("", true);
        Thread.CurrentThread.CurrentUICulture = new CultureInfo("", true);
      }
      else
      {
        if (CultureInfo.CurrentCulture.Name == "ja-JP")
        {
          Thread.CurrentThread.CurrentCulture = new CultureInfo("ja-JP");
          Thread.CurrentThread.CurrentUICulture = new CultureInfo("ja-JP");
        }
        else
        {
          Thread.CurrentThread.CurrentCulture = new CultureInfo("", true);
          Thread.CurrentThread.CurrentUICulture = new CultureInfo("", true);
        }
      }
      Application.Run(new Form1());
    }
  }
}
