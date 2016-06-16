using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class Thorn : BaseObject
	{
		public Thorn(string a_name, System.Drawing.Point a_pos) : base(a_name)
		{
			_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprThorn;
			_sprite.Position = a_pos;
		}
		public override void Move() { }
	}
}