using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class Fire : BaseObject
	{
		public Fire(string a_name, System.Drawing.Point a_pos, Direction a_direction) : base(a_name)
		{
			_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprFire;
			_sprite.Position = a_pos;
			_direct = a_direction;
		}
		public override void Move()
		{
			if (_direct == Direction.left)
			{
				MoveLeft();
			}
			else if (_direct == Direction.right)
			{
				MoveRight();
			}
			//_sprite.Position = new System.Drawing.Point(_sprite.Position.X + 5, _sprite.Position.Y);
		}
		public void MoveRight()
		{
			_sprite.Position = new System.Drawing.Point(_sprite.Position.X + 20, _sprite.Position.Y);
		}
		public void MoveLeft()
		{
			_sprite.Position = new System.Drawing.Point(_sprite.Position.X - 20, _sprite.Position.Y);
		}

		public void CollideMonster(Monster a_monster)
		{
			if (CheckCollision(a_monster._sprite.ImageSpr))
			{
				this._sprite.Position = new System.Drawing.Point(this._sprite.Position.X, this._sprite.Position.Y + 150);
				a_monster._monsterLife--;
				if (a_monster._monsterLife == 0)
					a_monster.Die();

			}
		}
		private Direction _direct;
	}
}