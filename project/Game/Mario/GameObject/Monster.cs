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
			_pic.Image = global::Mario.Properties.Resources.spr_monster;
			_pic.Location = a_pos;
			_defaultPos = a_pos;
			_pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			_name = a_name;
			_pic.Name = "pic" + a_name[0].ToString().ToUpper() + a_name.Substring(1);
			_state = 0;
			Manager.PictureBoxManager.Instance.AddPictureBox(_pic);
		}
		public int State { get; set; }
		public void updateState()
		{
			System.Drawing.Point p = Manager.PictureBoxManager.Instance.GetPictureBoxWithName(_pic.Name).Location;
			if (_state == 0 && p.X <= _defaultPos.X - 100)
			{
				_state = 1;
				return;
			}
			if (_state == 1 && p.X >= _defaultPos.X + 100)
			{
				_state = 0;
				return;
			}
		}
		public override void Move()
		{
			System.Windows.Forms.PictureBox pic = Manager.PictureBoxManager.Instance.GetPictureBoxWithName(_pic.Name);
			int x = pic.Location.X;
			switch (_state)
			{
				case 0:
					x = x - 5;
					break;
				case 1:
					x = x + 5;
					break;
			}
			Manager.PictureBoxManager.Instance.GetPictureBoxWithName(_pic.Name).Location = new System.Drawing.Point(x, pic.Location.Y);
		}
		private int _state;
		private System.Drawing.Point _defaultPos;
	}
}
