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
      resources.ApplyResources(this.pictureBox1, "pictureBox1");
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.TabStop = false;
      // 
      // buttonOK
      // 
      resources.ApplyResources(this.buttonOK, "buttonOK");
      this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.buttonOK.Name = "buttonOK";
      this.buttonOK.UseVisualStyleBackColor = true;
      this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
      // 
      // labelAppName
      // 
      resources.ApplyResources(this.labelAppName, "labelAppName");
      this.labelAppName.Name = "labelAppName";
      // 
      // labelVersion
      // 
      resources.ApplyResources(this.labelVersion, "labelVersion");
      this.labelVersion.Name = "labelVersion";
      // 
      // labelCopyright
      // 
      resources.ApplyResources(this.labelCopyright, "labelCopyright");
      this.labelCopyright.Name = "labelCopyright";
      // 
      // pictureBox2
      // 
      resources.ApplyResources(this.pictureBox2, "pictureBox2");
      this.pictureBox2.Name = "pictureBox2";
      this.pictureBox2.TabStop = false;
      // 
      // linkLabelHome
      // 
      resources.ApplyResources(this.linkLabelHome, "linkLabelHome");
      this.linkLabelHome.Name = "linkLabelHome";
      this.linkLabelHome.TabStop = true;
      this.linkLabelHome.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHome_LinkClicked);
      // 
      // pictureBox3
      // 
      resources.ApplyResources(this.pictureBox3, "pictureBox3");
      this.pictureBox3.Name = "pictureBox3";
      this.pictureBox3.TabStop = false;
      // 
      // linkLabelGitHub
      // 
      resources.ApplyResources(this.linkLabelGitHub, "linkLabelGitHub");
      this.linkLabelGitHub.Name = "linkLabelGitHub";
      this.linkLabelGitHub.TabStop = true;
      this.linkLabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelGitHub_LinkClicked);
      // 
      // Form2
      // 
      resources.ApplyResources(this, "$this");
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.CancelButton = this.buttonOK;
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
      this.Name = "Form2";
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