using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentFight
{
	class AgentUI
	{
		public World world;
		public AgentUI(World world)
		{
			this.world = world;
		}

		/*private void Which(Graphics g, Agent agent)
		{
			Brush brush;
			if (agent.Doing == Agent.Action.Defand)
				brush = new SolidBrush(Color.Blue);
			else if (agent.Doing == Agent.Action.Hurt)
				brush = new SolidBrush(Color.Green);
			else
				brush = new SolidBrush(Color.Black);
			//g.DrawImage(new Bitmap("stand.png"), new Rectangle(agent.Location, agent.Size));
			g.FillRectangle(brush, new Rectangle(agent.Location, agent.Size));
			if (agent.Doing == Agent.Action.Attack)
			{
				brush = new SolidBrush(Color.Red);
				if (agent.Facing == Agent.RIGHT)
					g.FillRectangle(brush, agent.Location.X + agent.Size.Width, agent.Location.Y, agent.AttackRange, agent.Size.Height);
				else
					g.FillRectangle(brush, agent.Location.X - agent.AttackRange, agent.Location.Y, agent.AttackRange, agent.Size.Height);
			}
		}*/

		private void Which(Graphics g, Agent agent)
		{
			int i = 0;
			if (agent.Doing == Agent.Action.Nothing && agent.ViewVersion < 0) i = 1;
			//location向右傾斜 //寬度加大 //高度加大
			if (agent.Facing == Agent.RIGHT)
			{
				int[] deviation = agent.DrawDeviation[agent.Doing];
				g.DrawImage(
					agent.Views[agent.Doing][i],
					agent.Location.X + deviation[0],
					agent.Location.Y + deviation[1],
					agent.Size.Width + deviation[2],
					agent.Size.Height + deviation[3]
				);
			}
			else
			{
				Bitmap v = new Bitmap(agent.Views[agent.Doing][i]);
				v.RotateFlip(RotateFlipType.RotateNoneFlipX);
				int[] deviation = agent.DrawDeviation[agent.Doing];
				g.DrawImage(
					v,
					agent.Location.X - deviation[0] - deviation[2],
					agent.Location.Y + deviation[1],
					agent.Size.Width + deviation[2],
					agent.Size.Height + deviation[3]
				);
			}
		}

		public void Paint(Bitmap bitmap)
		{
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				Which(g, world.p1);
				Which(g, world.p2);
			}
		}
	}
}
