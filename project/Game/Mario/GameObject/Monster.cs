using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
	class Monster : GameObject
	{
		public Monster(string a_name, System.Drawing.Point a_pos)
		{
			_pos = a_pos;
			_state = 0;
			_name = a_name;
		}
		public int State
		{
			get
			{
				return _state;
			}
			set
			{
				_state = value;
			}
		}
		public void setPositionX(int a_x)
		{
			_pos.X = a_x;
		}
		public void setPositionY(int a_y)
		{
			_pos.Y = a_y;
		}
		public int getState()
		{
			return _state;
		}
		public void updateState()
		{

			System.Drawing.Point p = MainForm.Instance.getPictureBoxWithName("pic" + _name[0].ToString().ToUpper() + _name.Substring(1)).Location;
			if (_state == 0 && p.X <= _pos.X - 50)
			{
				_state = 1;
				return;
			}
			if (_state == 1 && p.X >= _pos.X + 50)
			{
				_state = 0;
				return;
			}
		}
		public override void Move()
		{
			string s = "pic" + _name[0].ToString().ToUpper() + _name.Substring(1);
			System.Drawing.Point pos = MainForm.Instance.getPictureBoxWithName(s).Location;
			int x = pos.X;
			switch (_state)
			{
				case 0:
					x = x - 5;
					break;
				case 1:
					x = x + 5;
					break;
			}
			System.Drawing.Point locate = new System.Drawing.Point(x, pos.Y);
			MainForm.Instance.movePictureBox(s, locate);
		}
		public void getPostion()
		{
			_pos = MainForm.Instance.getPictureBoxWithName("pic" + _name[0].ToString().ToUpper() + _name.Substring(1)).Location;
		}
		private int _state;
	}
}
