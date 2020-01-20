namespace Client
{
	partial class ClientForm
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
			this.invite_BT = new System.Windows.Forms.Button();
			this.close_BT = new System.Windows.Forms.Button();
			this.nickname_TB = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.online_LB = new System.Windows.Forms.ListBox();
			this.connect_BT = new System.Windows.Forms.Button();
			this.server_port_TB = new System.Windows.Forms.TextBox();
			this.server_IP_TB = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.button2 = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.name_Lb = new System.Windows.Forms.Label();
			this.show_PB = new System.Windows.Forms.PictureBox();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.show_PB)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// log_TB
			// 
			this.log_TB.Location = new System.Drawing.Point(721, 15);
			this.log_TB.Margin = new System.Windows.Forms.Padding(2);
			this.log_TB.Multiline = true;
			this.log_TB.Name = "log_TB";
			this.log_TB.ReadOnly = true;
			this.log_TB.Size = new System.Drawing.Size(327, 501);
			this.log_TB.TabIndex = 56;
			// 
			// invite_BT
			// 
			this.invite_BT.Enabled = false;
			this.invite_BT.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.invite_BT.Location = new System.Drawing.Point(145, 489);
			this.invite_BT.Margin = new System.Windows.Forms.Padding(2);
			this.invite_BT.Name = "invite_BT";
			this.invite_BT.Size = new System.Drawing.Size(63, 27);
			this.invite_BT.TabIndex = 55;
			this.invite_BT.Text = "邀請";
			this.invite_BT.UseVisualStyleBackColor = true;
			this.invite_BT.Click += new System.EventHandler(this.invite_BT_Click);
			// 
			// close_BT
			// 
			this.close_BT.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.close_BT.Location = new System.Drawing.Point(119, 243);
			this.close_BT.Name = "close_BT";
			this.close_BT.Size = new System.Drawing.Size(75, 32);
			this.close_BT.TabIndex = 54;
			this.close_BT.Text = "關閉";
			this.close_BT.UseVisualStyleBackColor = true;
			this.close_BT.Click += new System.EventHandler(this.close_BT_Click);
			// 
			// nickname_TB
			// 
			this.nickname_TB.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.nickname_TB.Location = new System.Drawing.Point(109, 204);
			this.nickname_TB.Name = "nickname_TB";
			this.nickname_TB.Size = new System.Drawing.Size(99, 23);
			this.nickname_TB.TabIndex = 53;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label4.Location = new System.Drawing.Point(12, 205);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(73, 20);
			this.label4.TabIndex = 52;
			this.label4.Text = "我的暱稱";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label3.Location = new System.Drawing.Point(65, 298);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(96, 26);
			this.label3.TabIndex = 51;
			this.label3.Text = "線上列表";
			// 
			// online_LB
			// 
			this.online_LB.Font = new System.Drawing.Font("新細明體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.online_LB.FormattingEnabled = true;
			this.online_LB.ItemHeight = 15;
			this.online_LB.Location = new System.Drawing.Point(16, 327);
			this.online_LB.Name = "online_LB";
			this.online_LB.Size = new System.Drawing.Size(192, 154);
			this.online_LB.TabIndex = 50;
			// 
			// connect_BT
			// 
			this.connect_BT.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.connect_BT.Location = new System.Drawing.Point(26, 243);
			this.connect_BT.Name = "connect_BT";
			this.connect_BT.Size = new System.Drawing.Size(75, 32);
			this.connect_BT.TabIndex = 49;
			this.connect_BT.Text = "連線";
			this.connect_BT.UseVisualStyleBackColor = true;
			this.connect_BT.Click += new System.EventHandler(this.connect_BT_Click);
			// 
			// server_port_TB
			// 
			this.server_port_TB.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.server_port_TB.Location = new System.Drawing.Point(109, 169);
			this.server_port_TB.Name = "server_port_TB";
			this.server_port_TB.Size = new System.Drawing.Size(99, 23);
			this.server_port_TB.TabIndex = 48;
			this.server_port_TB.Text = "6666";
			// 
			// server_IP_TB
			// 
			this.server_IP_TB.Font = new System.Drawing.Font("新細明體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.server_IP_TB.Location = new System.Drawing.Point(109, 137);
			this.server_IP_TB.Name = "server_IP_TB";
			this.server_IP_TB.Size = new System.Drawing.Size(99, 23);
			this.server_IP_TB.TabIndex = 47;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label2.Location = new System.Drawing.Point(12, 172);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(89, 20);
			this.label2.TabIndex = 46;
			this.label2.Text = "伺服器Port";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.label1.Location = new System.Drawing.Point(12, 140);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 20);
			this.label1.TabIndex = 45;
			this.label1.Text = "伺服器IP";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.button2);
			this.groupBox1.Controls.Add(this.button1);
			this.groupBox1.Controls.Add(this.label6);
			this.groupBox1.Controls.Add(this.name_Lb);
			this.groupBox1.Controls.Add(this.show_PB);
			this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.groupBox1.Location = new System.Drawing.Point(220, 3);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(496, 513);
			this.groupBox1.TabIndex = 57;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "選擇角色";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(346, 453);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(65, 54);
			this.button2.TabIndex = 4;
			this.button2.Text = ">";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(74, 453);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(65, 54);
			this.button1.TabIndex = 3;
			this.button1.Text = "<";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(118, 324);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(258, 70);
			this.label6.TabIndex = 2;
			this.label6.Text = "介紹：\r\n攻守兼備，拳拳到肉";
			// 
			// name_Lb
			// 
			this.name_Lb.Font = new System.Drawing.Font("微軟正黑體", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
			this.name_Lb.Location = new System.Drawing.Point(168, 453);
			this.name_Lb.Name = "name_Lb";
			this.name_Lb.Size = new System.Drawing.Size(147, 54);
			this.name_Lb.TabIndex = 1;
			this.name_Lb.Text = "特務S";
			this.name_Lb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// show_PB
			// 
			this.show_PB.Location = new System.Drawing.Point(153, 58);
			this.show_PB.Name = "show_PB";
			this.show_PB.Size = new System.Drawing.Size(188, 250);
			this.show_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.show_PB.TabIndex = 0;
			this.show_PB.TabStop = false;
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::Client.Properties.Resources.logo;
			this.pictureBox1.Location = new System.Drawing.Point(6, 15);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(208, 104);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 58;
			this.pictureBox1.TabStop = false;
			// 
			// ClientForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1059, 527);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.log_TB);
			this.Controls.Add(this.invite_BT);
			this.Controls.Add(this.close_BT);
			this.Controls.Add(this.nickname_TB);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.online_LB);
			this.Controls.Add(this.connect_BT);
			this.Controls.Add(this.server_port_TB);
			this.Controls.Add(this.server_IP_TB);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "ClientForm";
			this.Text = "Agent Fight 特務戰爭";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClientForm_FormClosed);
			this.Load += new System.EventHandler(this.ClientForm_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.show_PB)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox log_TB;
		private System.Windows.Forms.Button invite_BT;
		private System.Windows.Forms.Button close_BT;
		private System.Windows.Forms.TextBox nickname_TB;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox online_LB;
		private System.Windows.Forms.Button connect_BT;
		private System.Windows.Forms.TextBox server_port_TB;
		private System.Windows.Forms.TextBox server_IP_TB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox show_PB;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label name_Lb;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}

