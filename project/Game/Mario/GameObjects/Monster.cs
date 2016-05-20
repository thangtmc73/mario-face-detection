using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	public abstract class Monster : BaseObject
	{
		public Monster(string a_name, System.Drawing.Point a_pos) : base(a_name)
		{
			_sprite.Position = a_pos;
			_defaultPos = a_pos;
			State = 0;
		}
		public int State { get; set; }
		public abstract void UpdateState();
		protected System.Drawing.Point _defaultPos;
	}
}
