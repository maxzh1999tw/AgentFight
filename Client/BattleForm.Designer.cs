namespace Client
{
	partial class BattleForm
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
			this.components = new System.ComponentModel.Container();
			this.canvas_PB = new System.Windows.Forms.PictureBox();
			this.painter_Tm = new System.Windows.Forms.Timer(this.components);
			this.operator_Tm = new System.Windows.Forms.Timer(this.components);
			this.ticker_Tm = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)(this.canvas_PB)).BeginInit();
			this.SuspendLayout();
			// 
			// canvas_PB
			// 
			this.canvas_PB.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.canvas_PB.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.canvas_PB.Location = new System.Drawing.Point(0, 0);
			this.canvas_PB.Name = "canvas_PB";
			this.canvas_PB.Size = new System.Drawing.Size(1200, 600);
			this.canvas_PB.TabIndex = 1;
			this.canvas_PB.TabStop = false;
			// 
			// painter_Tm
			// 
			this.painter_Tm.Interval = 1;
			this.painter_Tm.Tick += new System.EventHandler(this.painter_Tm_Tick);
			// 
			// operator_Tm
			// 
			this.operator_Tm.Interval = 1;
			this.operator_Tm.Tick += new System.EventHandler(this.operator_Tm_Tick);
			// 
			// ticker_Tm
			// 
			this.ticker_Tm.Interval = 1;
			this.ticker_Tm.Tick += new System.EventHandler(this.ticker_Tm_Tick);
			// 
			// BattleForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1200, 600);
			this.Controls.Add(this.canvas_PB);
			this.Name = "BattleForm";
			this.Text = "Agent Fight 特務戰爭";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BattleForm_FormClosed);
			this.Load += new System.EventHandler(this.BattleForm_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BattleForm_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BattleForm_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.canvas_PB)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox canvas_PB;
		private System.Windows.Forms.Timer painter_Tm;
		private System.Windows.Forms.Timer operator_Tm;
		private System.Windows.Forms.Timer ticker_Tm;
	}
}