using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace png2winico
{
  public partial class Form1 : Form
  {
    // 縮小する画像サイズ
    int[] sizes = new int[] { 256, 64, 48, 32, 24, 16 };
    // アイコンの各イメージサイズを格納する
    Dictionary<int, Bitmap> iconImages = new Dictionary<int, Bitmap>();
    // 読み込んだPNGファイルパス
    string InputFilePath = "";

    public Form1()
    {
      InitializeComponent();
    }
    private void Form1_Load(object sender, EventArgs e)
    {
      // アイコンに含める「サイズ」分の Bitmap を Dictionary に登録
      foreach(int size in sizes)
      {
        iconImages.Add(size, new Bitmap(size, size));
      }

      // 記憶したフォーム位置に表示（設定がなければ画面中央に表示)
      if (Png2WinIco.Properties.Settings.Default.FormPosX > -1)
      {
        this.Left = Png2WinIco.Properties.Settings.Default.FormPosX;
      }
      else
      {
        this.Left = Screen.GetBounds(this).Width / 2 - this.Width / 2;
      }
      if (Png2WinIco.Properties.Settings.Default.FormPosY > -1)
      {
        this.Top = Png2WinIco.Properties.Settings.Default.FormPosY;
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
      foreach (int size in sizes)
      {
        iconImages[size].Dispose();
      }
      // フォームの位置を設定に保存する
      Png2WinIco.Properties.Settings.Default.FormPosX = this.Left;
      Png2WinIco.Properties.Settings.Default.FormPosY = this.Top;
      Png2WinIco.Properties.Settings.Default.Save();
    }
    private void MenuItemOpen_Click(object sender, EventArgs e)
    {
      // オープンダイアログの初期ディレクトリを指定
      if (Directory.Exists(Png2WinIco.Properties.Settings.Default.OpenDialogIniDir)){
        openFileDialog1.InitialDirectory = Png2WinIco.Properties.Settings.Default.OpenDialogIniDir;
      }
      else
      {
        // デスクトップ
        openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      }

      if (openFileDialog1.ShowDialog() == DialogResult.OK)
      {
        if (CreateIconFile(openFileDialog1.FileName) == true)
        {
          buttonSave.Enabled = true;
          MenuItemSave.Enabled = true;
          Png2WinIco.Properties.Settings.Default.OpenDialogIniDir = 
            Path.GetDirectoryName(openFileDialog1.FileName);
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
    private void buttonSave_Click(object sender, EventArgs e)
    {
      saveFileDialog1.FileName = Path.GetFileNameWithoutExtension(InputFilePath);
      if (saveFileDialog1.ShowDialog() == DialogResult.OK)
      {
        // アイコンファイル（*.ico）として保存
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
      string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);

      // ステータスバーにドラッグ＆ドロップされたファイル名を表示
      toolStripStatusLabel1.Text = fileName[0];

      // 投げ込まれたpngファイルをそれぞれのサイズにリサイズして表示する
      if ( OpenPngfileToImages(fileName[0]) == true)
      {
        buttonSave.Enabled = true;
        MenuItemSave.Enabled = true;
      }
    }
    private bool OpenPngfileToImages(string FilePath)
    {
      InputFilePath = FilePath;
      Graphics g;
      try
      {
        using (Bitmap baseImage = new Bitmap(FilePath))
        {
          if (baseImage.Width < 256 || baseImage.Height < 256)
          {
            if (MessageBox.Show(
                  "読み込まれたされた画像が256px以下です。\nこのままだと低解像度のアイコンが生成されますが、続行しますか？",
                  "問い合わせ", MessageBoxButtons.YesNo, MessageBoxIcon.Question,
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
        }
      }
      catch
      {
        MessageBox.Show(
                  "画像ファイルの読み込みでエラーが発生したようです。処理を中止します。\n" + FilePath,
                  "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error
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
    /// </summary>
    /// <param name="OutFilePath">出力するアイコンファイルパス</param>
    /// <returns>アイコンファイルが正常に生成されたか否か（bool）</returns>
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
    /// 指定されたサイズ幅、サイズ高さでリサイズする
    /// ref: https://stackoverflow.com/questions/1922040/resize-an-image-c-sharp
    /// ref: https://gist.github.com/darkfall/1656050/
    /// </summary>
    /// <param name="image">リサイズされたイメージ</param>
    /// <param name="width">リサイズする画像幅</param>
    /// <param name="height">リサイズする画像高さ</param>
    /// <returns>リサイズされた画像</returns>
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
