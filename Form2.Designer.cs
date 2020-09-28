namespace png2winico
{
  partial class Form2
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
      this.buttonOK = new System.Windows.Forms.Button();
      this.labelAppName = new System.Windows.Forms.Label();
      this.labelVersion = new System.Windows.Forms.Label();
      this.labelCopyright = new System.Windows.Forms.Label();
      this.pictureBox2 = new System.Windows.Forms.PictureBox();
      this.linkLabelHome = new System.Windows.Forms.LinkLabel();
      this.pictureBox3 = new System.Windows.Forms.PictureBox();
      this.linkLabelGitHub = new System.Windows.Forms.LinkLabel();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
      this.SuspendLayout();
      // 
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(21, 22);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(48, 48);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // buttonOK
      // 
      this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonOK.Location = new System.Drawing.Point(257, 112);
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.Size = new System.Drawing.Size(75, 23);
      this.buttonOK.TabIndex = 1;
      this.buttonOK.Text = "&OK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // labelAppName
      // 
      this.labelAppName.AutoSize = true;
      this.labelAppName.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.labelAppName.Location = new System.Drawing.Point(88, 25);
      this.labelAppName.Name = "labelAppName";
      this.labelAppName.Size = new System.Drawing.Size(116, 15);
      this.labelAppName.TabIndex = 2;
      this.labelAppName.Text = "Application Name";
      // 
      // labelVersion
      // 
      this.labelVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
      this.labelVersion.AutoSize = true;
      this.labelVersion.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.labelVersion.Location = new System.Drawing.Point(222, 25);
      this.labelVersion.Name = "labelVersion";
      this.labelVersion.Size = new System.Drawing.Size(55, 15);
      this.labelVersion.TabIndex = 3;
      this.labelVersion.Text = "Version";
      this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      // 
      // labelCopyright
      // 
      this.labelCopyright.AutoSize = true;
      this.labelCopyright.Font = new System.Drawing.Font("MS UI Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
      this.labelCopyright.Location = new System.Drawing.Point(88, 46);
      this.labelCopyright.Name = "labelCopyright";
      this.labelCopyright.Size = new System.Drawing.Size(59, 15);
      this.labelCopyright.TabIndex = 4;
      this.labelCopyright.Text = "Cpyright";
      // 
      // pictureBox2
      // 
      this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
      this.pictureBox2.Location = new System.Drawing.Point(21, 88);
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.Size = new System.Drawing.Size(16, 16);
      this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox2.TabIndex = 5;
      this.pictureBox2.TabStop = false;
      // 
      // linkLabelHome
      // 
      this.linkLabelHome.AutoSize = true;
      this.linkLabelHome.Location = new System.Drawing.Point(43, 90);
      this.linkLabelHome.Name = "linkLabelHome";
      this.linkLabelHome.Size = new System.Drawing.Size(100, 12);
      this.linkLabelHome.TabIndex = 6;
      this.linkLabelHome.TabStop = true;
      this.linkLabelHome.Text = "https://hibara.org/";
      this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
      // 
      // pictureBox3
      // 
      this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
      this.pictureBox3.Location = new System.Drawing.Point(21, 110);
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.Size = new System.Drawing.Size(16, 16);
      this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox3.TabIndex = 7;
      this.pictureBox3.TabStop = false;
      // 
      // linkLabelGitHub
      // 
      this.linkLabelGitHub.AutoSize = true;
      this.linkLabelGitHub.Location = new System.Drawing.Point(44, 112);
      this.linkLabelGitHub.Name = "linkLabelGitHub";
      this.linkLabelGitHub.Size = new System.Drawing.Size(200, 12);
      this.linkLabelGitHub.TabIndex = 8;
      this.linkLabelGitHub.TabStop = true;
      this.linkLabelGitHub.Text = "https://github.com/hibara/Png2WinIco";
      this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
      // 
      // Form2
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonOK;
      this.ClientSize = new System.Drawing.Size(344, 147);
      this.Controls.Add(this.linkLabelGitHub);
      this.Controls.Add(this.pictureBox3);
      this.Controls.Add(this.linkLabelHome);
      this.Controls.Add(this.pictureBox2);
      this.Controls.Add(this.labelCopyright);
      this.Controls.Add(this.labelVersion);
      this.Controls.Add(this.labelAppName);
      this.Controls.Add(this.buttonOK);
      this.Controls.Add(this.pictureBox1);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form2";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "バージョン情報";
      this.TopMost = true;
      this.Load += new System.EventHandler(this.Form2_Load);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox pictureBox1;
    private System.Windows.Forms.Button buttonOK;
    private System.Windows.Forms.Label labelAppName;
    private System.Windows.Forms.Label labelVersion;
    private System.Windows.Forms.Label labelCopyright;
    private System.Windows.Forms.PictureBox pictureBox2;
    private System.Windows.Forms.LinkLabel linkLabelHome;
    private System.Windows.Forms.PictureBox pictureBox3;
    private System.Windows.Forms.LinkLabel linkLabelGitHub;
  }
}