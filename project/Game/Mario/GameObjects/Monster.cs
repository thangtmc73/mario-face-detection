using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	public abstract class Monster : BaseObject
	{
		public int _monsterLife = 1;
		public Monster(string a_name, System.Drawing.Point a_pos) : base(a_name)
		{
			_sprite.Position = a_pos;
			_defaultPos = a_pos;
			State = 0;
		}
		public void Die()
		{
			this._sprite.ImageSpr.Visible = false;
			//this._sprite.Position = new System.Drawing.Point(this._sprite.Position.X, this._sprite.Position.Y + 1000);
		}

		public int State { get; set; }

		public abstract void UpdateState();
		protected System.Drawing.Point _defaultPos;
	}
}