using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	public abstract class BaseObject
	{
		public BaseObject()
		{
			_sprite = new Core.Sprite();
		}
		public BaseObject(string a_name)
		{
			_sprite = new Core.Sprite();
			_sprite.Name = a_name;
		}
		public abstract void Move();
		public string Name { get; set; }
		protected Core.Sprite _sprite;
	}
}