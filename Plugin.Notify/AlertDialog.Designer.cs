namespace Plugin.Notify
{
	partial class AlertDialog
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlertDialog));
			this.ilIcons = new System.Windows.Forms.ImageList(this.components);
			this.opacityTimer = new System.Windows.Forms.Timer(this.components);
			this.moveTimer = new System.Windows.Forms.Timer(this.components);
			this.pnlTitle = new System.Windows.Forms.Panel();
			this.bnClose = new System.Windows.Forms.Button();
			this.lblTitle = new System.Windows.Forms.Label();
			this.flowLabels = new System.Windows.Forms.FlowLayoutPanel();
			this.pnlTitle.SuspendLayout();
			this.SuspendLayout();
			// 
			// ilIcons
			// 
			this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
			this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.ilIcons.Images.SetKeyName(0, "Cross.png");
			this.ilIcons.Images.SetKeyName(1, "Cross_Hover.png");
			// 
			// opacityTimer
			// 
			this.opacityTimer.Interval = 30;
			this.opacityTimer.Tick += new System.EventHandler(this.opacityTimer_Tick);
			// 
			// moveTimer
			// 
			this.moveTimer.Interval = 30;
			this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
			// 
			// pnlTitle
			// 
			this.pnlTitle.BackColor = System.Drawing.Color.ForestGreen;
			this.pnlTitle.Controls.Add(this.bnClose);
			this.pnlTitle.Controls.Add(this.lblTitle);
			this.pnlTitle.Dock = System.Windows.Forms.DockStyle.Top;
			this.pnlTitle.Location = new System.Drawing.Point(0, 0);
			this.pnlTitle.Name = "pnlTitle";
			this.pnlTitle.Size = new System.Drawing.Size(289, 40);
			this.pnlTitle.TabIndex = 0;
			this.pnlTitle.Text = "You have {0} expired tasks";
			// 
			// bnClose
			// 
			this.bnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.bnClose.FlatAppearance.BorderSize = 0;
			this.bnClose.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
			this.bnClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
			this.bnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.bnClose.ImageIndex = 0;
			this.bnClose.ImageList = this.ilIcons;
			this.bnClose.Location = new System.Drawing.Point(258, 8);
			this.bnClose.Name = "bnClose";
			this.bnClose.Size = new System.Drawing.Size(28, 23);
			this.bnClose.TabIndex = 1;
			this.bnClose.TabStop = false;
			this.bnClose.UseMnemonic = false;
			this.bnClose.UseVisualStyleBackColor = true;
			this.bnClose.MouseLeave += new System.EventHandler(this.bnClose_MouseLeave);
			this.bnClose.Click += new System.EventHandler(this.bnClose_Click);
			this.bnClose.MouseHover += new System.EventHandler(this.bnClose_MouseHover);
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Arial", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblTitle.ForeColor = System.Drawing.SystemColors.Window;
			this.lblTitle.Location = new System.Drawing.Point(12, 9);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(45, 22);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title";
			// 
			// flowLabels
			// 
			this.flowLabels.Dock = System.Windows.Forms.DockStyle.Fill;
			this.flowLabels.Location = new System.Drawing.Point(0, 40);
			this.flowLabels.Name = "flowLabels";
			this.flowLabels.Padding = new System.Windows.Forms.Padding(42, 0, 0, 0);
			this.flowLabels.Size = new System.Drawing.Size(289, 2);
			this.flowLabels.TabIndex = 1;
			// 
			// AlertDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.ClientSize = new System.Drawing.Size(289, 42);
			this.ControlBox = false;
			this.Controls.Add(this.flowLabels);
			this.Controls.Add(this.pnlTitle);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "AlertDialog";
			this.Opacity = 0;
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "InfoDialog";
			this.TopMost = true;
			this.pnlTitle.ResumeLayout(false);
			this.pnlTitle.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel pnlTitle;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.Timer opacityTimer;
		private System.Windows.Forms.Timer moveTimer;
		private System.Windows.Forms.ImageList ilIcons;
		private System.Windows.Forms.Button bnClose;
		private System.Windows.Forms.FlowLayoutPanel flowLabels;
	}
}