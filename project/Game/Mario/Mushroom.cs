using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class Mushroom : BaseObject
	{
        public int _type;

        public Mushroom(string a_name, System.Drawing.Point a_pos) : base(a_name)
		{
			//_sprite.ImageSpr.Image = global::Mario.Properties.Resources.;
			_sprite.Position = a_pos;
		}
		public override void Move() { }
	}
}
