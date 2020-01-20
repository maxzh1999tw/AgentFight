using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AgentFight;

namespace Client
{
	public partial class BattleForm : Form
	{
		Bitmap bitmap;
		HealthUI healthUI;
		AgentUI agentUI;
		World world;
		public string name;
		public ClientForm lobby;
		bool[] press = { false, false, false, false, false };
		bool[] triggered = { false, false, false, false, false };
		int[] walking = { 0, 0 };
		const int KEY_JUMP = 0, KEY_LEFT = 1, KEY_RIGHT = 2, KEY_ATK = 3, KEY_DEF = 4;
		public int IntroIndex = 0, EnemyIntroIndex = 0;

		public BattleForm()
		{
			InitializeComponent();
		}

		private void BattleForm_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space && !press[KEY_JUMP]) press[KEY_JUMP] = true;
			else if (e.KeyCode == Keys.Left && !press[KEY_LEFT])
				press[KEY_LEFT] = true;
			else if (e.KeyCode == Keys.Right && !press[KEY_RIGHT])
				press[KEY_RIGHT] = true;
			else if (e.KeyCode == Keys.A && !press[KEY_ATK])
				press[KEY_ATK] = true;
			else if (e.KeyCode == Keys.D && !press[KEY_DEF])
				press[KEY_DEF] = true;
		}

		private void BattleForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space)
			{
				press[KEY_JUMP] = false;
				triggered[KEY_JUMP] = false;
			}
			else if (e.KeyCode == Keys.Left)
			{
				lobby.Send("stopleft`" + name + "`" + world.p1.Left() + "`" + world.p1.Health);
				press[KEY_LEFT] = false;
				triggered[KEY_LEFT] = false;
			}
			else if (e.KeyCode == Keys.Right)
			{
				lobby.Send("stopright`" + name + "`" + world.p1.Left() + "`" + world.p1.Health);
				press[KEY_RIGHT] = false;
				triggered[KEY_RIGHT] = false;
			}
			else if (e.KeyCode == Keys.A)
			{
				press[KEY_ATK] = false;
				triggered[KEY_ATK] = false;
			}
			else if (e.KeyCode == Keys.D)
			{
				press[KEY_DEF] = false;
				triggered[KEY_DEF] = false;
			}
		}

		private void BattleForm_FormClosed(object sender, FormClosedEventArgs e)
		{
			lobby.BattleFormClosed();
		}

		private void BattleForm_Load(object sender, EventArgs e)
		{
			canvas_PB.BackgroundImage = new Bitmap("icon/background.png");
			CheckForIllegalCrossThreadCalls = false;
			healthUI = new HealthUI();
			Agent p1 = StickMan(), p2 = StickMan();
			switch (IntroIndex)
			{
				case 1:
					p1 = AgentJ();
					break;
				case 2:
					p1 = AgentG();
					break;
			}
			switch (EnemyIntroIndex)
			{
				case 1:
					p2 = AgentJ();
					break;
				case 2:
					p2 = AgentG();
					break;
			}
			world = new World(new Size(canvas_PB.Size.Width, canvas_PB.Size.Height), p1, p2);
			agentUI = new AgentUI(world);
			operator_Tm.Start();
			ticker_Tm.Start();
			painter_Tm.Start();
		}

		private void operator_Tm_Tick(object sender, EventArgs e)
		{
			if (walking[0] != 0) world.Move(world.p1, walking[0] == -1 ? Agent.LEFT : Agent.RIGHT, world.p1.Step);
			if (walking[1] != 0) world.Move(world.p2, walking[1] == -1 ? Agent.LEFT : Agent.RIGHT, world.p2.Step);
			if (press[KEY_ATK] && !triggered[KEY_ATK])
			{
				if (world.p1.DoingDelate <= 0 && world.p1.Cooldown[Agent.Action.Attack] <= 0)
				{
					lobby.Send("attack`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
					world.p1.DoingDelate = 50;
				}
				triggered[KEY_ATK] = true;
			}
			if (press[KEY_JUMP] && !triggered[KEY_JUMP])
			{
				if (world.p1.DoingDelate <= 0)
				{
					lobby.Send("jump`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
					world.p1.DoingDelate = 50;
				}
				triggered[KEY_JUMP] = true;
			}
			if (press[KEY_DEF] && !triggered[KEY_DEF])
			{
				if (world.p1.DoingDelate <= 0 && world.p1.Cooldown[Agent.Action.Defand] <= 0)
				{
					lobby.Send("defand`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
					world.p1.DoingDelate = 50;
				}
				triggered[KEY_DEF] = true;
			}
			if (press[KEY_LEFT] && !triggered[KEY_LEFT])
			{
				walking[0] = -1;
				lobby.Send("left`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
				triggered[KEY_LEFT] = true;
			}
			else if (!press[KEY_LEFT] && triggered[KEY_LEFT])
			{
				lobby.Send("stopleft`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
				triggered[KEY_LEFT] = false;
			}
			else if (press[KEY_RIGHT] && !triggered[KEY_RIGHT])
			{
				walking[0] = 1;
				lobby.Send("right`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
				triggered[KEY_RIGHT] = true;
			}
			else if (!press[KEY_RIGHT] && triggered[KEY_RIGHT])
			{
				lobby.Send("stopright`" + name + "`" + world.p1.Location.X + "`" + world.p1.Health);
				triggered[KEY_RIGHT] = false;
			}
		}

		private void ticker_Tm_Tick(object sender, EventArgs e)
		{
			world.Tick();
		}

		private Agent AgentJ()
		{
			Agent agent = new Agent()
			{
				Size = new Size(152, 310),
				AttackRange = 230,
				Attacktion = 30,
				Step = 7,
				Gravity = 6,
				SetCooldown = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 70 },
					{ Agent.Action.Defand, 45 }
				},
				Recover = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 30 },
					{ Agent.Action.Defand, 25 },
					{ Agent.Action.Hurt, 20 },
					{ Agent.Action.Jump, int.MaxValue }
				},
				Views = new Dictionary<Agent.Action, Bitmap[]>()
				{
					{ Agent.Action.Nothing, new Bitmap[] { new Bitmap("AgentJ/nothing1.png"), new Bitmap("AgentJ/nothing2.png") } },
					{ Agent.Action.Jump, new Bitmap[] { new Bitmap("AgentJ/jump.png") } },
					{ Agent.Action.Attack, new Bitmap[] { new Bitmap("AgentJ/attack.png") } },
					{ Agent.Action.Defand, new Bitmap[] { new Bitmap("AgentJ/defand.png") } },
					{ Agent.Action.Hurt, new Bitmap[] { new Bitmap("AgentJ/hurt.png") } }
				},
				DrawDeviation = new Dictionary<Agent.Action, int[]>()
				{
					//向右 //向下 //寬度加大 //高度加大
					{ Agent.Action.Nothing, new int[] { 0, 0, 0, 0 } },
					{ Agent.Action.Jump, new int[] { 0, 0, 40, 0 } },
					{ Agent.Action.Attack, new int[] { 6, -40, 230, 40 } },
					{ Agent.Action.Hurt, new int[] { 0, 0, 0, 0 } },
					{ Agent.Action.Defand, new int[] { 5, 0, 100, 0 } }
				}
			};
			return agent;
		}

		private Agent StickMan()
		{
			Agent agent = new Agent()
			{
				Size = new Size(90, 250),
				AttackRange = 108,
				Attacktion = 10,
				Step = 15,
				SetCooldown = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 40 },
					{ Agent.Action.Defand, 30 }
				},
				Recover = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 15 },
					{ Agent.Action.Defand, 20 },
					{ Agent.Action.Hurt, 30 },
					{ Agent.Action.Jump, int.MaxValue }
				},
				Views = new Dictionary<Agent.Action, Bitmap[]>()
				{
					{ Agent.Action.Nothing, new Bitmap[] { new Bitmap("StickMan/nothing.png"), new Bitmap("StickMan/nothing.png") } },
					{ Agent.Action.Jump, new Bitmap[] { new Bitmap("StickMan/jump.png") } },
					{ Agent.Action.Attack, new Bitmap[] { new Bitmap("StickMan/attack.png") } },
					{ Agent.Action.Defand, new Bitmap[] { new Bitmap("StickMan/defand.png") } },
					{ Agent.Action.Hurt, new Bitmap[] { new Bitmap("StickMan/hurt.png") } }
				},
				DrawDeviation = new Dictionary<Agent.Action, int[]>()
				{
					//向右 //向下 //寬度加大 //高度加大
					{ Agent.Action.Nothing, new int[] { 0, 0, 0, 0 } },
					{ Agent.Action.Jump, new int[] { 0, 0, 10, -61 } },
					{ Agent.Action.Attack, new int[] { 0, 0, 108, 0 } },
					{ Agent.Action.Hurt, new int[] { -80, 0, 99, 10 } },
					{ Agent.Action.Defand, new int[] { -11, -13, 22, 13 } }
				}
			};
			return agent;
		}

		private Agent AgentG()
		{
			Agent agent = new Agent()
			{
				Size = new Size(120, 300),
				AttackRange = 150,
				Step = 8,
				Gravity = 3,
				Attacktion = 15,
				SetCooldown = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 55 },
					{ Agent.Action.Defand, 60 }
				},
				Recover = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 35 },
					{ Agent.Action.Defand, 40 },
					{ Agent.Action.Hurt, 30 },
					{ Agent.Action.Jump, int.MaxValue }
				},
				Views = new Dictionary<Agent.Action, Bitmap[]>()
				{
					{ Agent.Action.Nothing, new Bitmap[] { new Bitmap("AgentG/nothing1.png"), new Bitmap("AgentG/nothing2.png") } },
					{ Agent.Action.Jump, new Bitmap[] { new Bitmap("AgentG/jump.png") } },
					{ Agent.Action.Attack, new Bitmap[] { new Bitmap("AgentG/attack.png") } },
					{ Agent.Action.Defand, new Bitmap[] { new Bitmap("AgentG/defand.png") } },
					{ Agent.Action.Hurt, new Bitmap[] { new Bitmap("AgentG/hurt.png") } }
				},
				DrawDeviation = new Dictionary<Agent.Action, int[]>()
				{
					//向右 //向下 //寬度加大 //高度加大
					{ Agent.Action.Nothing, new int[] { 0, 0, 0, 0 } },
					{ Agent.Action.Jump, new int[] { -50, 0, 80, 0 } },
					{ Agent.Action.Attack, new int[] { 5, 0, 150, 0 } },
					{ Agent.Action.Hurt, new int[] { 0, 0, 0, 0 } },
					{ Agent.Action.Defand, new int[] { 5, 0, -10, 0 } }
				}
			};
			return agent;
		}

		public void SocketDo(string command, string name, int x, int h)
		{
			Agent agent = this.name == name ? world.p1 : world.p2;
			int i = this.name == name ? 0 : 1;
			if (i == 0) agent.Location = new Point(x, agent.Location.Y);
			else agent.Location = new Point(world.Size.Width - world.p2.Size.Width - x, agent.Location.Y);
			if (i == 1) world.p2.Health = h;
			if (command == "attack")
			{
				world.Attack(agent);
			}
			else if (command == "jump")
			{
				world.Jump(agent, 35);
			}
			else if (command == "defand")
			{
				world.Defence(agent);
			}
			else if (command == "left")
			{
				walking[i] = i == 0 ? -1 : 1;
			}
			else if (command == "right")
			{
				walking[i] = i == 0 ? 1 : -1;
			}
			else if (command == "stopleft")
			{
				if (walking[i] == (i == 0 ? -1 : 1)) walking[i] = 0;
			}
			else if (command == "stopright")
			{
				if (walking[i] == (i == 0 ? 1 : -1)) walking[i] = 0;
			}
		}

		private void painter_Tm_Tick(object sender, EventArgs e)
		{
			try
			{
				bitmap = new Bitmap(canvas_PB.Size.Width, canvas_PB.Size.Height);
				agentUI.Paint(bitmap);
				healthUI.Paint(bitmap, world.p1.Health, world.p2.Health);
				canvas_PB.Image = bitmap;
				GC.Collect();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}
	}
}
