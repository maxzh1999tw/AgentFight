namespace Server
{
	partial class ServerForm
	{
		/// <summary>
		/// 設計工具所需的變數。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清除任何使用中的資源。
		/// </summary>
		/// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form 設計工具產生的程式碼

		/// <summary>
		/// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
		/// 這個方法的內容。
		/// </summary>
		private void InitializeComponent()
		{
			this.log_TB = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.online_LB = new System.Windows.Forms.ListBox();
			this.button = new System.Windows.Forms.Button();
			this.my_port_TB = new System.Windows.Forms.TextBox();
			this.my_IP_TB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// log_TB
			// 
			this.log_TB.Location = new System.Drawing.Point(252, 11);
			this.log_TB.Margin = new System.Windows.Forms.Padding(2);
			this.log_TB.Multiline = true;
			this.log_TB.Name = "log_TB";
			this.log_TB.ReadOnly = true;
			this.log_TB.Size = new System.Drawing.Size(314, 436);
			this.log_TB.TabIndex = 35;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(77, 170);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 26);
			this.label3.TabIndex = 34;
			this.label3.Text = "線上列表";
			// 
			// online_LB
			// 
			this.online_LB.FormattingEnabled = true;
			this.online_LB.ItemHeight = 12;
			this.online_LB.Location = new System.Drawing.Point(15, 203);
			this.online_LB.Name = "online_LB";
			this.online_LB.Size = new System.Drawing.Size(226, 244);
			this.online_LB.TabIndex = 33;
			// 
			// button
			// 
			this.button.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.button.Location = new System.Drawing.Point(54, 96);
			this.button.Name = "button";
			this.button.Size = new System.Drawing.Size(140, 58);
			this.button.TabIndex = 32;
			this.button.Text = "建立伺服器";
			this.button.UseVisualStyleBackColor = true;
			this.button.Click += new System.EventHandler(this.button_Click);
			// 
			// my_port_TB
			// 
			this.my_port_TB.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.my_port_TB.Location = new System.Drawing.Point(95, 44);
			this.my_port_TB.Name = "my_port_TB";
			this.my_port_TB.Size = new System.Drawing.Size(146, 23);
			this.my_port_TB.TabIndex = 31;
			this.my_port_TB.Text = "6666";
			// 
			// my_IP_TB
			// 
			this.my_IP_TB.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.my_IP_TB.Location = new System.Drawing.Point(95, 11);
			this.my_IP_TB.Name = "my_IP_TB";
			this.my_IP_TB.ReadOnly = true;
			this.my_IP_TB.Size = new System.Drawing.Size(146, 23);
			this.my_IP_TB.TabIndex = 30;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(11, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 20);
			this.label2.TabIndex = 29;
			this.label2.Text = "我的Port";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(11, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 20);
			this.label1.TabIndex = 28;
			this.label1.Text = "我的IP";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(587, 460);
			this.Controls.Add(this.log_TB);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.online_LB);
			this.Controls.Add(this.button);
			this.Controls.Add(this.my_port_TB);
			this.Controls.Add(this.my_IP_TB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Server_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox log_TB;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox online_LB;
		private System.Windows.Forms.Button button;
		private System.Windows.Forms.TextBox my_port_TB;
		private System.Windows.Forms.TextBox my_IP_TB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
	}
}

