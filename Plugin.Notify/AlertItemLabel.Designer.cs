namespace Plugin.Notify
{
	partial class AlertItemLabel
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
			if(disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.pbOwned = new System.Windows.Forms.PictureBox();
			this.lblTitle = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pbOwned)).BeginInit();
			this.SuspendLayout();
			// 
			// pbOwned
			// 
			this.pbOwned.Image = global::Plugin.Notify.Properties.Resources.Arrow;
			this.pbOwned.Location = new System.Drawing.Point(3, 7);
			this.pbOwned.Name = "pbOwned";
			this.pbOwned.Size = new System.Drawing.Size(21, 16);
			this.pbOwned.TabIndex = 2;
			this.pbOwned.TabStop = false;
			// 
			// lblTitle
			// 
			this.lblTitle.AutoSize = true;
			this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblTitle.Location = new System.Drawing.Point(30, 7);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(48, 16);
			this.lblTitle.TabIndex = 3;
			this.lblTitle.Text = "lblTitle";
			// 
			// AlertItemLabel
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Window;
			this.Controls.Add(this.lblTitle);
			this.Controls.Add(this.pbOwned);
			this.Name = "AlertItemLabel";
			this.Size = new System.Drawing.Size(196, 30);
			((System.ComponentModel.ISupportInitialize)(this.pbOwned)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pbOwned;
		private System.Windows.Forms.Label lblTitle;
	}
}
