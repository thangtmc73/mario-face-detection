using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class NormalMonster : Monster
	{
		public NormalMonster(string a_name, System.Drawing.Point a_pos) : base(a_name, a_pos)
		{
			_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprNormalMonster;
		}
		public override void UpdateState()
		{
			System.Drawing.Point p = new System.Drawing.Point(0, 0);
			if (_sprite != null)
			{
				p = _sprite.Position;
			}
			if (State == 0 && p.X <= _defaultPos.X - 100)
			{
				State = 1;
				_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprNormalMonster_Inverse;
				return;
			}
			if (State == 1 && p.X >= _defaultPos.X + 100)
			{
				State = 0;
				_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprNormalMonster;
				return;
			}
		}
		public override void Move()
		{
			int x = _sprite.Position.X;
			switch (State)
			{
				case 0:
					x = x - 2;
					break;
				case 1:
					x = x + 2;
					break;
			}
			_sprite.Position = new System.Drawing.Point(x, _sprite.Position.Y);
		}
	}
}