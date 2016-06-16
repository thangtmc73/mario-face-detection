using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	public enum Direction
	{
		left = 0,
		right = 1,
		up = 2,
		down = 3,
		stay = 4,
	}
	public abstract class BaseObject
	{
		public BaseObject(string a_name)
		{
			_sprite = new Core.Sprite();
			_sprite.Name = a_name;
			Manager.SpriteManager.Instance.Add(_sprite);
		}
		public abstract void Move();
		public string Name
		{
			get
			{
				return _sprite.Name;
			}
			set
			{
				_sprite.Name = value;
			}
		}
		public Core.Sprite _sprite;

		public bool CheckCollision(System.Windows.Forms.PictureBox a_otherObject)
		{
			if (a_otherObject == null || a_otherObject.Visible == false)
			{
				return false;
			}
			if (this._sprite.ImageSpr.Bounds.IntersectsWith(a_otherObject.Bounds))
			{
				return true;
			}
			return false;
		}
	}
}