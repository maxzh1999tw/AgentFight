using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgentFight
{
	public partial class TestForm : Form
	{
		Bitmap bitmap;
		HealthUI healthUI;
		AgentUI agentUI;
		World world;
		bool[] press = { false, false, false, false, false };
		const int KEY_JUMP = 0, KEY_LEFT = 1, KEY_RIGHT = 2, KEY_ATK = 3, KEY_DFE = 4;

		private void Form1_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space && !press[KEY_JUMP]) press[KEY_JUMP] = true;
			else if (e.KeyCode == Keys.Left && !press[KEY_LEFT])
				press[KEY_LEFT] = true;
			else if (e.KeyCode == Keys.Right && !press[KEY_RIGHT])
				press[KEY_RIGHT] = true;
			else if (e.KeyCode == Keys.A && !press[KEY_ATK])
				press[KEY_ATK] = true;
			else if (e.KeyCode == Keys.D && !press[KEY_DFE])
				press[KEY_DFE] = true;
		}

		private void Form1_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Space) press[KEY_JUMP] = false;
			else if (e.KeyCode == Keys.Left) press[KEY_LEFT] = false;
			else if (e.KeyCode == Keys.Right) press[KEY_RIGHT] = false;
			else if (e.KeyCode == Keys.A) press[KEY_ATK] = false;
			else if (e.KeyCode == Keys.D) press[KEY_DFE] = false;
		}

		public TestForm()
		{
			InitializeComponent();
		}

		private Agent AgentJ()
		{
			Agent agent = new Agent()
			{
				Size = new Size(152, 310),
				AttackRange = 230,
				Attacktion = 30,
				SetCooldown = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 80 },
					{ Agent.Action.Defand, 45 }
				},
				Recover = new Dictionary<Agent.Action, int>()
				{
					{ Agent.Action.Attack, 50 },
					{ Agent.Action.Defand, 30 },
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
				SetCooldown = new Dictionary<Agent.Action, int>() 
				{ 
					{ Agent.Action.Attack, 35 }, 
					{ Agent.Action.Defand, 60 } 
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
				Attacktion = 30,
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

		private void Form1_Load(object sender, EventArgs e)
		{
			CheckForIllegalCrossThreadCalls = false;
			healthUI = new HealthUI();
			world = new World(new Size(canvas_PB.Size.Width, canvas_PB.Size.Height), AgentJ(), AgentG());
			agentUI = new AgentUI(world);
			painter_Tm.Start();
		}

		private void painter_Tm_Tick(object sender, EventArgs e)
		{
			try
			{
				if (world.End)
				{
					painter_Tm.Stop();
					MessageBox.Show("遊戲結束");
				}
				if (press[KEY_ATK]) world.Attack(world.p1);
				if (press[KEY_JUMP]) world.Jump(world.p1, 35);
				if (press[KEY_LEFT]) world.Move(world.p1, Agent.LEFT);
				if (press[KEY_RIGHT]) world.Move(world.p1, Agent.RIGHT);
				if (press[KEY_DFE]) world.Defence(world.p1);
				world.Attack(world.p2);
				world.Tick();
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
