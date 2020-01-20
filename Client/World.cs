using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgentFight
{
	class World
	{
		public Size Size { get; set; }
		public Agent p1 { get; set; }
		public Agent p2 { get; set; }
		public bool End { get; set; }

		public World(Size size, Agent p1, Agent p2)
		{
			int distance = 100, height = 250;
			Size = size;
			this.p1 = p1;
			this.p1.Location = new Point(distance, height);
			this.p2 = p2;
			this.p2.Location = new Point(Size.Width - distance - p2.Size.Width, height);
			p2.Facing = Agent.LEFT;
			End = false;
		}

		public void Tick()
		{
			foreach (Agent agent in new Agent[] { p1, p2 })
			{
				if (agent.Bottom() - agent.Energy >= Size.Height && !agent.Standing)
				{
					agent.Location = new Point(agent.Location.X, Size.Height - agent.Size.Height);
					agent.Stand();
				}
				else if (!agent.Standing)
				{
					agent.Fall();
				}
				agent.Tick();
			}
		}

		public void Jump(Agent agent, int power)
		{
			agent.Jump(power);
		}

		public void Move(Agent agent, bool way, int step)
		{
			if (agent.Doing == Agent.Action.Jump || agent.DoingDelate <= 0)
			{
				if (way == Agent.RIGHT && agent.Right() + step > Size.Width)
				{
					agent.Location = new Point(Size.Width - agent.Size.Width, agent.Location.Y);
				}
				else if (way == Agent.LEFT && agent.Location.X - step < 0)
				{
					agent.Location = new Point(0, agent.Location.Y);
				}
				else
				{
					agent.Location = new Point(agent.Location.X + (step * (way ? 1 : -1)), agent.Location.Y);
				}
				if (agent.Facing != way) agent.Facing = way;
			}
		}

		public void Attack(Agent agent)
		{
			agent.Do(Agent.Action.Attack);
			Agent enemy = agent.Equals(p1) ? p2 : p1;
			bool hit = false;
			if (agent.Facing == Agent.RIGHT)
			{
				if ((enemy.Top() >= agent.Top() && enemy.Top() <= agent.Bottom()) || (enemy.Bottom() >= agent.Top() && enemy.Bottom() <= agent.Bottom()))
				{
					if (enemy.Left() - agent.Right() < agent.AttackRange && enemy.Right() - agent.Right() > 0)
					{
						hit = true;
					}
				}
			}
			else
			{
				if ((enemy.Top() >= agent.Top() && enemy.Top() <= agent.Bottom()) || (enemy.Bottom() >= agent.Top() && enemy.Bottom() <= agent.Bottom()))
				{
					if (agent.Left() - enemy.Right() < agent.AttackRange && agent.Left() - enemy.Left() > 0)
					{
						hit = true;
					}
				}
			}
			if (hit && enemy.Doing != Agent.Action.Defand)
			{
				enemy.Do(Agent.Action.Hurt);
				enemy.Health -= agent.Attacktion;
				enemy.Energy = 0;
				if (enemy.Health <= 0) End = true;
			}
		}

		public void Defence(Agent agent)
		{
			agent.Do(Agent.Action.Defand);
		}
	}
}
