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

        private void Which(Graphics g, Agent agent)
        {
            int i = 0;
            if (agent.Doing == Agent.Action.Nothing && agent.ViewVersion < 0) i = 1;
            //向右 //向下 //寬度加大 //高度加大
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

        public void Sign(Graphics g, Agent agent)
        {
            g.DrawImage(new Bitmap("icon/triangle.png"), agent.Location.X + (agent.Size.Width - 40) / 2, agent.Location.Y - 40, 40, 40);
        }

        public void Paint(Bitmap bitmap)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                if (world.p1.Health > 0)
                {
                    Which(g, world.p1);
                    Sign(g, world.p1);
                }
                if (world.p2.Health > 0) Which(g, world.p2);
            }
        }
    }
}
