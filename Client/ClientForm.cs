using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
	public struct Intro
	{
		public string name, file, text;
	}

	public partial class ClientForm : Form
	{
		Socket client;
		Thread thread, sender;
		bool connected;
		BattleForm battleForm;
		List<string> users;
		List<string> waitSend;
		int introIndex, enemyIntroIndex;

		public ClientForm()
		{
			InitializeComponent();
			connected = false;
			users = new List<string>();
			waitSend = new List<string>();
			show_PB.Image = new Bitmap("StickMan/nothing.png");
		}

		private delegate void StrCallback(string log);
		private void Log(string log)
		{
			if (this.InvokeRequired)
			{
				try
				{
					StrCallback logCallback = new StrCallback(Log);
					this.Invoke(logCallback, log);
				}
				catch { }
			}
			else
			{
				if (log_TB.Text != "") log_TB.Text += Environment.NewLine;
				log_TB.Text += log;
				log_TB.ScrollBars = ScrollBars.Vertical;
				log_TB.SelectionStart = log_TB.Text.Length;
				log_TB.ScrollToCaret();
			}
		}

		private delegate void NoneCallback();
		private void UpdateList()
		{
			if (this.InvokeRequired)
			{
				NoneCallback updateListCallback = new NoneCallback(UpdateList);
				this.Invoke(updateListCallback);
			}
			else
			{
				online_LB.Items.Clear();
				for (int i = 0; i < users.Count; i++)
				{
					online_LB.Items.Add(users[i]);
				}
			}
		}

		private delegate void LockCallback(Control target, bool enable);
		private void Lock(Control target, bool enable)
		{
			if (this.InvokeRequired)
			{
				LockCallback lockCallback = new LockCallback(Lock);
				this.Invoke(lockCallback, target, enable);
			}
			else
			{
				target.Enabled = enable;
			}
		}

		private void OpenBattleForm()
		{
			if (this.InvokeRequired)
			{
				this.Invoke(new NoneCallback(OpenBattleForm));
			}
			else
			{
				battleForm = new BattleForm();
				battleForm.lobby = this;
				battleForm.name = nickname_TB.Text;
				battleForm.IntroIndex = introIndex;
				battleForm.EnemyIntroIndex = enemyIntroIndex;
				battleForm.Show();
			}
		}

		public void BattleFormClosed()
		{
			Send("end");
			Lock(invite_BT, true);
			//Show();
		}

		private void connect_BT_Click(object sender, EventArgs e)
		{
			if (server_IP_TB.Text != "" && server_port_TB.Text != "" && nickname_TB.Text != "")
			{
				try
				{
					if (!connected)
					{
						client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						client.Connect(server_IP_TB.Text, int.Parse(server_port_TB.Text));
						connected = true;
						thread = new Thread(Listen);
						thread.Start();
						this.sender = new Thread(Send_thread);
						this.sender.Start();
					}
					Send("checknick`" + nickname_TB.Text);
				}
				catch
				{
					MessageBox.Show("<系統>伺服器拒絕連線");
				}
			}
			else
			{
				MessageBox.Show("<系統>連線資料錯誤");
			}
		}

		public void Send_thread()
		{
			while (connected)
			{
				try
				{
					if (waitSend.Count > 0)
					{
						client.Send(Encoding.Default.GetBytes(waitSend[0] + "`"));
						Log("<送出>" + waitSend[0]);
						waitSend.RemoveAt(0);
					}
				}
				catch { }
			}
		}

		public void Send(string msg)
		{
			waitSend.Add(msg);
		}

		private void Listen()
		{
			byte[] data = new byte[1024];
			try
			{
				while (connected)
				{
					data = new byte[1024];
					client.Receive(data);
					string command = Encoding.Default.GetString(data).Trim();
					Log("<收到>" + command);
					string[] element = command.Split('`');
					if (element[0] == "join")
					{
						users.Clear();
						for (int i = 1; i < element.Length - 1; i++)
						{
							users.Add(element[i]);
						}
						UpdateList();
						Lock(connect_BT, false);
						Lock(invite_BT, true);
					}
					else if (element[0] == "nick")
					{
						Log("<系統>暱稱重複，請換一個暱稱");
						users.Clear();
						for (int i = 1; i < element.Length - 1; i++)
						{
							users.Add(element[i]);
						}
						UpdateList();
					}
					else if (element[0] == "new")
					{
						users.Add(element[1]);
						UpdateList();
					}
					else if (element[0] == "out")
					{
						users.Remove(element[1]);
						UpdateList();
					}
					else if (element[0] == "run")
					{
						Log("你的對手跑掉了");
						if (!(battleForm is null))
						{
							battleForm.Close();
						}
					}
					else if (element[0] == "invite")
					{
						if (MessageBox.Show(element[1] + "想邀請您一起遊戲", "遊玩邀請",
							MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
						{
							Send("accept`" + element[1] + "`" + nickname_TB.Text + "`" + introIndex);
							Lock(invite_BT, false);
						}
						else
						{
							Send("reject`" + element[1]);
						}
					}
					else if (element[0] == "accept")
					{
						MessageBox.Show(element[1] + "接受了你的邀請", "遊玩邀請");
						enemyIntroIndex = int.Parse(element[2]);
						Send("start`" + introIndex + "`" + enemyIntroIndex);
					}
					else if (element[0] == "reject")
					{
						MessageBox.Show("對方拒絕了你的邀請", "遊玩邀請");
						Lock(invite_BT, true);
					}
					else if (element[0] == "playing")
					{
						Log(element[1] + "正在與別人遊玩中");
						Lock(invite_BT, true);
					}
					else if (element[0] == "run")
					{
						Log(nickname_TB.Text + "你的敵人逃跑了");
						Lock(invite_BT, true);
					}
					else if (element[0] == "start")
					{
						introIndex = int.Parse(element[1]);
						enemyIntroIndex = int.Parse(element[2]);
						OpenBattleForm();
					}
					else
					{
						battleForm.SocketDo(element[0], element[1], int.Parse(element[2]), int.Parse(element[3]));
					}
				}
			}
			catch (Exception ex)
			{
				if (connected)
				{
					Log("伺服器斷線" + ex.ToString());
				}
			}
		}

		private void close_BT_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void invite_BT_Click(object sender, EventArgs e)
		{
			if (online_LB.SelectedIndex >= 0)
			{
				if (MessageBox.Show("確定要邀請" + online_LB.Items[online_LB.SelectedIndex] + "一起遊玩嗎？",
					"遊玩邀請", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					Send("invite`" + online_LB.Items[online_LB.SelectedIndex] + "`" + nickname_TB.Text);
					invite_BT.Enabled = false;
				}
			}
		}

		private void ClientForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			try
			{
				Send("out`" + nickname_TB.Text);
				connected = false;
				client.Close();
				thread.Abort();
			}
			catch { }
		}

		Intro[] intros = new Intro[] {
			new Intro()
			{
				name = "火柴人",
				file = "StickMan/nothing.png",
				text = "攻守兼備，拳拳到肉"
			},
			new Intro()
			{
				name = "特務J",
				file = "AgentJ/nothing1.png",
				text = "力拔山兮，穩若泰山"
			},
			new Intro()
			{
				name = "特務G",
				file = "AgentG/nothing1.png",
				text = "他一直看著你\n看得你心裡發寒"
			}
		};

		private void ClientForm_Load(object sender, EventArgs e)
		{
			introIndex = 0;
			enemyIntroIndex = 0;
			SwitchIntro(introIndex);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if (introIndex == intros.Length - 1) introIndex = 0;
			else introIndex++;
			SwitchIntro(introIndex);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (introIndex == 0) introIndex = intros.Length - 1;
			else introIndex--;
			SwitchIntro(introIndex);
		}

		private void SwitchIntro(int index)
		{
			show_PB.Image = new Bitmap(intros[index].file);
			label6.Text = "介紹：\n" + intros[index].text;
			name_Lb.Text = intros[index].name;
		}
	}
}
