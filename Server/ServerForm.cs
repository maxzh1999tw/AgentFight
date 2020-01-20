using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
	public partial class ServerForm : Form
	{
		bool opened;
		TcpListener tcpListener;
		Socket client;
		Thread th_serv, th_clie;
		Dictionary<string, Socket> users;
		Dictionary<Socket, Socket> games;

		public ServerForm()
		{
			InitializeComponent();

			my_IP_TB.Text = GetMyIP();
			opened = false;
			users = new Dictionary<string, Socket>();
			games = new Dictionary<Socket, Socket>();
		}

		private string GetMyIP()
		{
			IPAddress[] ip = Dns.GetHostEntry(Dns.GetHostName()).AddressList;
			foreach (IPAddress it in ip)
				if (it.AddressFamily == AddressFamily.InterNetwork) return it.ToString();
			return "";
		}

		private delegate void LogCallback(string log);
		private void Log(string log)
		{
			if (this.InvokeRequired)
			{
				LogCallback logCallback = new LogCallback(Log);
				this.Invoke(logCallback, log);
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

		private delegate void UpdateListCallback();

		private void button_Click(object sender, EventArgs e)
		{
			if (!opened)
			{
				if (int.TryParse(my_port_TB.Text, out int port) && port >= 1024 && port <= 65535)
				{
					opened = true;
					button.Text = "關閉伺服器";
					th_serv = new Thread(ServerSub);
					th_serv.IsBackground = true;
					th_serv.Start();
				}
				else
				{
					Log("Port設置錯誤");
				}
			}
			else
			{
				opened = false;
				tcpListener.Stop();
				th_serv.Abort();
				foreach (Socket socket in users.Values)
				{
					socket.Close();
				}
				users.Clear();
				UpdateList();
				Log("成功關閉伺服器");
				button.Text = "建立伺服器";
			}
		}

		private void UpdateList()
		{
			if (this.InvokeRequired)
			{
				UpdateListCallback updateListCallback = new UpdateListCallback(UpdateList);
				this.Invoke(updateListCallback);
			}
			else
			{
				online_LB.Items.Clear();
				foreach (string str in users.Keys)
				{
					online_LB.Items.Add(str);
				}
			}
		}

		private void Server_FormClosing(object sender, FormClosingEventArgs e)
		{
			opened = false;
			try
			{
				tcpListener.Stop();
				th_serv.Abort();
			}
			catch { }
		}

		private void ServerSub()
		{
			tcpListener = new TcpListener(new IPEndPoint(IPAddress.Parse(GetMyIP()), int.Parse(my_port_TB.Text)));
			tcpListener.Start(10);
			Log("成功建立伺服器");
			while (opened)
			{
				try
				{
					client = tcpListener.AcceptSocket();
					th_clie = new Thread(Listen);
					th_clie.IsBackground = true;
					th_clie.Start();
				}
				catch { }
			}
		}

		private void Send(Socket socket, string msg)
		{
			socket.Send(Encoding.Default.GetBytes(msg + "`"));
			Log("<發送>" + msg);
		}

		private void Broadcast(string msg)
		{
			foreach (Socket socket in users.Values)
			{
				Send(socket, msg);
			}
		}

		private void Listen()
		{
			EndPoint ep = (EndPoint)client.RemoteEndPoint;
			Socket socket = client;
			byte[] data = new byte[1024];

			try
			{
				while (opened)
				{
					data = new byte[1024];
					int len = socket.ReceiveFrom(data, ref ep);
					string command = Encoding.Default.GetString(data).Trim();
					Log("<收到>" + command);
					string[] element = command.Split('`');
					if (element[0] == "checknick")
					{
						if (!users.ContainsKey(element[1]))
						{
							string temp = "join`";
							foreach (string s in users.Keys)
							{
								temp += s + "`";
							}
							Send(socket, temp.Substring(0, temp.Length - 1));
							Broadcast("new`" + element[1]);
							users.Add(element[1], socket);
							UpdateList();
						}
						else
						{
							string temp = "nick`";
							foreach (string s in users.Keys)
							{
								temp += s + "`";
							}
							Send(socket, temp.Substring(0, temp.Length - 1));
						}
					}
					else if (element[0] == "out")
					{
						users.Remove(element[1]);
						UpdateList();
						Broadcast("out`" + element[1]);
						Log(element[1] + " 離開伺服器");
						if (games.ContainsKey(socket))
						{
							Send(games[socket], "run");
							games.Remove(games[socket]);
							games.Remove(socket);
						}
					}
					else if (element[0] == "invite")
					{
						if (!games.ContainsKey(users[element[1]]))
						{
							Send(users[element[1]], "invite`" + element[2]);
						}
						else
						{
							Send(socket, "playing`" + element[1]);
						}
					}
					else if (element[0] == "accept")
					{
						Send(users[element[1]], "accept`" + element[2] + "`" + element[3]);
						games.Add(users[element[1]], users[element[2]]);
						games.Add(users[element[2]], users[element[1]]);
					}
					else if (element[0] == "reject")
					{
						Send(users[element[1]], "reject");
					}
					else if (element[0] == "start")
					{
						Send(socket, "start`" + element[1] + "`" + element[2]);
						Send(games[socket], "start`" + element[2] + "`" + element[1]);
					}
					else if (element[0] == "end")
					{
						if (games.ContainsKey(socket))
						{
							Send(games[socket], "run");
							games.Remove(games[socket]);
							games.Remove(socket);
						}
					}
					else
					{
						string sendstr = command.Substring(0, command.Length - 1);
						Send(socket, sendstr);
						Send(games[socket], sendstr);
					}
				}
			}
			catch (Exception ex) { }
		}
	}
}
