using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class FinalMonster : Monster
	{
		//_monsterLife = 3;
		public FinalMonster(string a_name, System.Drawing.Point a_pos) : base(a_name, a_pos)
		{
			_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprFinalMonster;
			base._monsterLife = 3;
		}
		public override void UpdateState()
		{
			System.Drawing.Point p = Manager.SpriteManager.Instance.GetSpriteWithName(_sprite.Name).ImageSpr.Location;
			if (State == 0 && p.Y <= _defaultPos.Y - 100)
			{
				State = 1;
				return;
			}
			if (State == 1 && p.Y >= _defaultPos.Y)
			{
				State = 0;
				return;
			}
		}
		public override void Move()
		{
			System.Windows.Forms.PictureBox pic = Manager.SpriteManager.Instance.GetSpriteWithName(_sprite.Name).ImageSpr;
			int y = pic.Location.Y;
			switch (State)
			{
				case 0:
					y = y - 2;
					break;
				case 1:
					y = y + 2;
					break;
			}
			Manager.SpriteManager.Instance.GetSpriteWithName(_sprite.Name).Position = new System.Drawing.Point(pic.Location.X, y);
		}
	}
}