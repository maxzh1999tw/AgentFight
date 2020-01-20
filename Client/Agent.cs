using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentFight
{
	class Agent
	{
		//常數
		public const bool LEFT = false, RIGHT = true;
		//座標相關
		public Point Location { get; set; }
		public Size Size { get; set; }

		public int Top() { return Location.Y; }
		public int Bottom() { return Location.Y + Size.Height; }
		public int Left() { return Location.X; }
		public int Right() { return Location.X + Size.Width; }

		//共用
		public int Gravity { get; set; }
		public int Energy { get; set; }
		public bool Standing { get; set; }
		public bool Facing { get; set; }

		public int Health { get; set; }
		public enum Action { Nothing, Jump, Attack, Defand, Hurt }
		public int Attacktion { get; set; }
		public int AttackRange { get; set; }
		public Dictionary<Action, int> SetCooldown { get; set; }
		public Dictionary<Action, int> Cooldown { get; set; }
		public Dictionary<Action, int> Recover { get; set; }
		public int Step { get; set; }
		public Action Doing { get; set; }
		public int DoingDelate { get; set; }

		public Dictionary<Action, Bitmap[]> Views;
		public Dictionary<Action, int[]> DrawDeviation;
		public int ViewVersion;

		public Agent()
		{
			Gravity = 2;
			Energy = 0;
			Standing = false;
			Facing = RIGHT;
			Health = 100;
			Attacktion = 10;
			Cooldown = new Dictionary<Action, int>() { { Action.Attack, 0 }, { Action.Defand, 0 } };
			Doing = Action.Nothing;
			DoingDelate = 0;
			ViewVersion = 40;
			Step = 10;
		}

		public void Do(Action action)
		{
			Doing = action;
			//View = Views[action];
			switch (action)
			{
				case Action.Nothing:
					DoingDelate = 0;
					break;
				case Action.Jump:
					DoingDelate = Recover[action];
					break;
				case Action.Attack:
					DoingDelate = Recover[action];
					Cooldown[action] = SetCooldown[action];
					break;
				case Action.Defand:
					DoingDelate = Recover[action];
					Cooldown[action] = SetCooldown[action];
					break;
				case Action.Hurt:
					DoingDelate = Recover[action];
					break;
			}
		}

		public void Fall()
		{
			Location = new Point(Location.X, Location.Y - Energy);
			Energy -= Gravity;
		}

		public void Stand()
		{
			Energy = 0;
			Standing = true;
			Do(Action.Nothing);
			DoingDelate = 5;
		}

		public void Jump(int power)
		{
			Energy += power;
			Standing = false;
			Do(Action.Jump);
		}

		public void Tick()
		{
			if (DoingDelate > 0) DoingDelate--;
			if (Doing != Action.Nothing && DoingDelate <= 0) Do(Action.Nothing);
			Action[] keys = { Action.Attack, Action.Defand, Action.Hurt };
			foreach (Action key in keys)
			{
				if (Cooldown.ContainsKey(key) && Cooldown[key] > 0) Cooldown[key]--;
			}
			if (Doing == Action.Nothing) ViewVersion--;
			if (ViewVersion < -40) ViewVersion = 40;
		}
	}
}
