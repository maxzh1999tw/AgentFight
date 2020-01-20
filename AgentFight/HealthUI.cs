using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgentFight
{
	class HealthUI
	{
		public Size Margin { get; set; }
		public int Padding { get; set; }
		public Color HealthColor { get; set; }
		public Color ReduceColor { get; set; }
		public Color RecoverColor { get; set; }
		public Size Size { get; set; }
		public int Delate { get; set; }
		int left_old, right_old;
		int left_stop, right_stop;
		public int Stop { get; set; }
		int rate;
		public HealthUI()
		{
			Margin = new Size(15, 15);
			Padding = 2;
			HealthColor = Color.Red;
			ReduceColor = Color.Brown;
			RecoverColor = Color.Pink;
			Size = new Size(500, 35);
			left_old = 0;
			right_old = 0;
			Delate = 1;
			left_stop = 0;
			right_stop = 0;
			Stop = 10;
			rate = Size.Width / 100;
		}

		public void Paint(Bitmap bitmap, int left, int right)
		{
			left = Math.Max(left, 0);
			right = Math.Max(right, 0);
			using (Graphics g = Graphics.FromImage(bitmap))
			{
				Pen pen = new Pen(Color.Black, Padding);
				g.DrawRectangle(pen, Margin.Width, Margin.Height, Size.Width + Padding * 2, Size.Height + Padding * 2);
				g.DrawRectangle(pen, bitmap.Width - Margin.Width - Size.Width - Padding * 2, Margin.Height, Size.Width + Padding * 2, Size.Height + Padding * 2);
				Brush HealthBrush = new SolidBrush(HealthColor);
				Brush RecoverBrush = new SolidBrush(RecoverColor);
				Brush ReduceBrush = new SolidBrush(ReduceColor);
				if (left <= left_old)
				{
					g.FillRectangle(HealthBrush, Margin.Width + Padding, Margin.Height + Padding, left * rate, Size.Height);
					g.FillRectangle(ReduceBrush, Margin.Width + Padding + left * rate, Margin.Height + Padding, (left_old - left) * rate, Size.Height);
				}
				else
				{
					g.FillRectangle(HealthBrush, Margin.Width + Padding, Margin.Height + Padding, left_old * rate, Size.Height);
					g.FillRectangle(RecoverBrush, Margin.Width + Padding + left_old * rate, Margin.Height + Padding, (left - left_old) * rate, Size.Height);
				}
				if (right <= right_old)
				{
					g.FillRectangle(HealthBrush, bitmap.Width - Margin.Width - (right * rate) - Padding, Margin.Height + Padding, right * rate, Size.Height);
					g.FillRectangle(ReduceBrush, bitmap.Width - Margin.Width - (right_old * rate) - Padding , Margin.Height + Padding, (right_old - right) * rate, Size.Height);
				}
				else
				{
					g.FillRectangle(HealthBrush, bitmap.Width - Margin.Width - (right_old * rate) - Padding, Margin.Height + Padding, right_old * rate, Size.Height);
					g.FillRectangle(RecoverBrush, bitmap.Width - Margin.Width - Size.Width - Padding, Margin.Height + Padding, (right - right_old) * rate, Size.Height);
				}
				if (left_old < left && left_stop-- <= 0)
				{
					int left_speed = (left - left_old) > left_old / 2 ? 2 : 1;
					left_old += Delate * left_speed;
				}
				else if (left_old > left && left_stop-- <= 0) left_old -= Delate;
				else if (left == left_old) left_stop = Stop;
				if (right_old < right && right_stop-- <= 0)
				{
					int right_speed = (right - right_old) > right_old / 2 ? 2 : 1;
					right_old += Delate * right_speed;
				}
				else if (right_old > right && right_stop-- <= 0) right_old -= Delate;
				else if (right == right_old) right_stop = Stop;
			}
		}
	}
}
