using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class RedMushroom : Mushroom
	{
		public RedMushroom(string a_name, System.Drawing.Point a_pos) : base(a_name, a_pos)
		{
			_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprRedMushroom;
            _sprite.Position = a_pos;
            base._type = 1;
		}
		public override void Move() { }
	}
}
