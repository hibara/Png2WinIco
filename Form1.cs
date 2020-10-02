using Png2WinIco.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace png2winico
{
  public partial class Form1 : Form
  {
    // 縮小する画像サイズ
    // The size of images size to be reduced
    int[] sizes = new int[] { 256, 64, 48, 32, 24, 16 };
    // アイコンの各イメージサイズを格納する
    // Store each image size of an icon as a key-value array
    Dictionary<int, Bitmap> iconImages = new Dictionary<int, Bitmap>();
    // 読み込んだPNGファイルパス
    // The original PNG file path to be loaded
    string InputFilePath = "";

    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      // アイコンに含める「サイズ」分の Bitmap を Dictionary に登録
      // Add a Bitmap for the "size" of the icon to the Dictionary array
      foreach (int size in sizes)
      {
        iconImages.Add(size, new Bitmap(size, size));
      }

      labelPngFilePath.Text = "";

      // 表示言語
      // Language
      if (CultureInfo.CurrentCulture.Name == "ja-JP")
      {
        toolStripStatusLabel1.Text = "日本語 ( 日本 )";
      }
      else
      {
        toolStripStatusLabel1.Text = "English ( Default )";
      }

      // 記憶したフォーム位置に表示（設定がなければ画面中央に表示)
      // Displayed at the memorized form position (or in the center of the screen if not set)
      if (Settings.Default.FormPosX > -1)
      {
        this.Left = Settings.Default.FormPosX;
      }
      else
      {
        this.Left = Screen.GetBounds(this).Width / 2 - this.Width / 2;
      }
      if (Settings.Default.FormPosY > -1)
      {
        this.Top = Settings.Default.FormPosY;
      }
      else
      {
        this.Top = Screen.GetBounds(this).Height / 2 - this.Height / 2;
      }
    }
    private void Form1_Shown(object sender, EventArgs e)
    {
    }
    private void Form1_FormClosed(object sender, FormClosedEventArgs e)
    {
      // アイコンイメージを格納する Bitmap を Dispose
      // Dispose the Bitmap for storing the icon images
      foreach (int size in sizes)
      {
        iconImages[size].Dispose();
      }
      // 言語 ( Language )
      //Settings.Default.Language = CultureInfo.CurrentCulture.Name;

      // フォームの位置を設定に保存する
      // Save the position of the form in the configuration
      Settings.Default.FormPosX = this.Left;
      Settings.Default.FormPosY = this.Top;
      Settings.Default.Save();
    }
    private void MenuItemOpen_Click(object sender, EventArgs e)
    {
      // オープンダイアログの初期ディレクトリを指定
      // Specify the initial directory for the open-dialog
      if (Directory.Exists(Settings.Default.OpenDialogIniDir)){
        openFileDialog1.InitialDirectory = Settings.Default.OpenDialogIniDir;
      }
      else
      {
        // デフォルトはデスクトップ
        // The default is desktop path
        openFileDialog1.InitialDirectory = 
          Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      }

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        if (OpenPngfileToImages(openFileDialog1.FileName) == true)
        {
          buttonSave.Enabled = true;
          MenuItemSave.Enabled = true;
          Settings.Default.OpenDialogIniDir = Path.GetDirectoryName(openFileDialog1.FileName);
        }
      }
    }
    private void ToolStripMenuItemWebSite_Click(object sender, EventArgs e)
    {
      string StringHomeUrl = "https://hibara.org/";
      System.Diagnostics.Process.Start(StringHomeUrl);
    }
    private void ToolStripMenuItemGitHub_Click(object sender, EventArgs e)
    {
      string StringGitHubUrl = "https://github.com/hibara/Png2WinIco";
      System.Diagnostics.Process.Start(StringGitHubUrl);
    }
    private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
    {
      Form2 frm2 = new Form2();
      frm2.ShowDialog();
      frm2.Dispose();
    }
    // コンテキストメニュー
    // Context menu
    private void contextMenuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
    {
      if (CultureInfo.CurrentCulture.Name == "ja-JP")
      {
        toolStripMenuItemEn.Checked = false;
        toolStripMenuItemJP.Checked = true;
        toolStripStatusLabel1.Text = "日本語 ( 日本 )";
      }
      else
      {
        toolStripMenuItemEn.Checked = true;
        toolStripMenuItemJP.Checked = false;
        toolStripStatusLabel1.Text = "English ( Default )";
      }
    }
    private void toolStripMenuItemEn_Click(object sender, EventArgs e)
    {
      if (ChangeApplicationLanguage("EN") == true)
      {
      }
    }
    private void toolStripMenuItemJP_Click(object sender, EventArgs e)
    {
      if (ChangeApplicationLanguage("ja-JP") == true)
      { 
      }
    }
    private void buttonSave_Click(object sender, EventArgs e)
    {
      saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(InputFilePath);
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        // アイコンファイル（*.ico）として保存
        // Save as an icon file (*.ico)
        if (CreateIconFile(saveFileDialog1.FileName) == false)
        {
          return;
        }
      }
    }
    private void buttonExit_Click(object sender, EventArgs e)
    {
      Close();
    }
    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop))
      {
        e.Effect = DragDropEffects.Copy;
      }
      else
      {
        e.Effect = DragDropEffects.None;
      }
    }
    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      // ドロップされたすべてのファイル名を取得する
      // Retrieve all dropped file names
      string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

      // ドラッグ＆ドロップされたPNGファイルをそれぞれのサイズにリサイズして表示する
      // Resize the drag-and-drop PNG files to their respective sizes
      if ( OpenPngfileToImages(fileName[0]) == true)
      {
        buttonSave.Enabled = true;
        MenuItemSave.Enabled = true;
      }
    }
    private void statusStrip1_Click(object sender, EventArgs e)
    {
      Point p = Cursor.Position;
      // コンテキストメニューを表示する
      // Show the context menu
      this.contextMenuStrip.Show(p);
    }
    private bool ChangeApplicationLanguage(string lang)
    {
      if (MessageBox.Show(
        // To change the language display, the application must be restarted.
        // Do you want to restart the application?
        // 言語表示を変更するには、アプリケーションの再起動が必要です。
        // 再起動を行いますか？
        Resources.MsgApplicationRestart,
        Resources.MsgTitleQuestion, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
        MessageBoxDefaultButton.Button1) == DialogResult.Yes )
      {
        Settings.Default.Language = lang;
        Application.Restart();
        return (true);
      }
      else
      {
        return (false);
      }
    }
    private bool OpenPngfileToImages(string FilePath)
    {
      InputFilePath = FilePath;
      try
      {
        using (Bitmap baseImage = new Bitmap(FilePath))
        {
          if (baseImage.Width < 256 || baseImage.Height < 256)
          {
            if (MessageBox.Show(
                  // The loaded image is less than 256px. If you continue, it generates a low-resolution icon.
                  // Do you want to continue?
                  // 読み込まれたされた画像が256px以下です。
                  // このままだと低解像度のアイコンが生成されますが、続行しますか？
                  Resources.MsgLessThan256px,
                  Resources.MsgTitleQuestion, MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                  MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
              return (false);
            }
          }
          foreach (int size in sizes)
          {
            iconImages[size] = ResizeImage(baseImage, size, size);
            Control[] cList = this.Controls.Find("pictureBox" + size.ToString(), true);
            if (cList[0] is PictureBox)
            {
              ((PictureBox)cList[0]).Image = iconImages[size];
            }
          }
          // ボタン上にあるラベルにドラッグ＆ドロップされたPNGファイルパスを表示する
          // Show the drag-and-drop PNG file path on the Label above the Button
          labelPngFilePath.Text = FilePath;
        }
      }
      catch
      {
        MessageBox.Show(
                  // An error seems to have occurred while loading the image file. Stop the process.\n
                  // 画像ファイルの読み込みでエラーが発生したようです。処理を中止します。\n
                  Resources.MsgErrorWhileLoadingImage + FilePath,
                  Resources.MsgTitleError, MessageBoxButtons.OK, MessageBoxIcon.Error
                  );
        return (false);
      }
      return (true);
    }

    private object FindControlByFieldName(Form1 form1, object p)
    {
      throw new NotImplementedException();
    }

    // ref. https://gist.github.com/darkfall/1656050/
    /// <summary>
    /// PNGファイルが読み込まれリサイズされたデータをまとめてアイコンファイルを生成する
    /// Generate icon file from the resized data of PNG file loaded
    /// </summary>
    /// <param name="OutFilePath">出力するアイコンファイルパス [ Output icon file path ] </param>
    /// <returns>アイコンファイルが正常に生成されたか否か（bool）[ Whether the icon file has been generated successfully(bool) ]</returns>
    private bool CreateIconFile(string OutFilePath)
    {
      using (FileStream outfs = new FileStream(OutFilePath, FileMode.OpenOrCreate))
      {
        BinaryWriter iconWriter = new BinaryWriter(outfs);
        if (outfs == null || iconWriter == null)
          return false;

        List<MemoryStream> imageStreams = new List<MemoryStream>();
        foreach (int size in sizes)
        {
          MemoryStream ms = new MemoryStream();
          iconImages[size].Save(ms, ImageFormat.Png);
          imageStreams.Add(ms);
        }

        int offset = 0;

        // 0-1 reserved, 0
        iconWriter.Write((byte)0);
        iconWriter.Write((byte)0);
        // 2-3 image type, 1 = icon, 2 = cursor
        iconWriter.Write((short)1);
        // 4-5 number of images
        iconWriter.Write((short)sizes.Length);

        offset += 6 + (16 * sizes.Length);

        for (int i = 0; i < sizes.Length; i++)
        {
          // image entry 1
          // 0 image width
          iconWriter.Write((byte)sizes[i]);
          // 1 image height
          iconWriter.Write((byte)sizes[i]);
          // 2 number of colors
          iconWriter.Write((byte)0);
          // 3 reserved
          iconWriter.Write((byte)0);
          // 4-5 color planes
          iconWriter.Write((short)0);
          // 6-7 bits per pixel
          iconWriter.Write((short)32);
          // 8-11 size of image data
          iconWriter.Write((int)imageStreams[i].Length);
          // 12-15 offset of image data
          iconWriter.Write((int)offset);

          offset += (int)imageStreams[i].Length;
        }

        for (int i = 0; i < sizes.Length; i++)
        {
          // write image data
          // png data must contain the whole png data file
          iconWriter.Write(imageStreams[i].ToArray());
          imageStreams[i].Close();
        }

        iconWriter.Flush();
        // Dispose
        foreach (var stream in imageStreams)
        {
          stream.Dispose();
        }
        imageStreams.Clear();

      }
      return (true);
    }
    /// <summary>
    /// 指定されたサイズ幅、サイズ高さでPNGファイル画像をリサイズする
    /// Resize the PNG file image to the specified size width and height
    /// ref: https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
    /// ref: https://gist.github.com/darkfall/1656050/
    /// </summary>
    /// <param name="image">リサイズされたイメージ[ Resized Image ]</param>
    /// <param name="width">リサイズする画像幅[ Image width to resize ]</param>
    /// <param name="height">リサイズする画像高さ[ Image height to resize ]</param>
    /// <returns>リサイズされたBitmap画像[ Resized Bitmap image ]</returns>
    public static Bitmap ResizeImage(Image image, int width, int height)
    {
      var destRect = new Rectangle(0, 0, width, height);
      var destImage = new Bitmap(width, height);

      destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

      using (var graphics = Graphics.FromImage(destImage))
      {
        graphics.CompositingMode = CompositingMode.SourceCopy;
        graphics.CompositingQuality = CompositingQuality.HighQuality;
        graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
        graphics.SmoothingMode = SmoothingMode.HighQuality;
        graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

        using (var wrapMode = new ImageAttributes())
        {
          wrapMode.SetWrapMode(WrapMode.TileFlipXY);
          graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
        }
      }
      return destImage;
    }

  }
}
