using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace Mario.GameObjects
{
	class Mario : BaseObject
	{
		private SoundPlayer eatBlueMushroomSound = new SoundPlayer("smw_1-up.wav");
		public string StringCurrentState { get; set; }
		public int Life { get; set; }
		public Direction Direct { get; set; }
		public bool Moving { get; set; }
		public bool BlueMushroomEaten { get; set; }
		public int Jumping { get; set; }

		//public variables
		public bool _collision = false; //va chạm hoặc không va chạm

		//=======================CONSTRUSTION=======================
		public Mario(string a_name, System.Drawing.Point a_pos) : base(a_name)
		{
			_sprite.Position = a_pos;
			_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario;
			Direct = Direction.stay;
			Life = 1;
			BlueMushroomEaten = false;
			Jumping = 0;
			Moving = false;
		}
		public override void Move()
		{
			//nếu Mario CHƯA ăn nấm Xan
			if (Jumping == 0)
			{
				if (Direct == Direction.left)
				{
					MoveLeft();
					StringCurrentState = "go to back";
				}
				else if (Direct == Direction.right)
				{
					MoveRight();
					StringCurrentState = "go ahead";
				}
				else
				{
					StringCurrentState = "stay";
				}
			}
			else
			{
				Jump();
			}
		}
		public void MoveRight()
		{
			_sprite.Position = new System.Drawing.Point(_sprite.Position.X + 7, _sprite.Position.Y);
			Direct = Direction.stay;
			Moving = false;
		}
		public void MoveLeft()
		{
			Direct = Direction.stay;
			Moving = false;
			if (_sprite.Position.X < -10)
			{
				return;
			}		
			_sprite.Position = new System.Drawing.Point(_sprite.Position.X - 7, _sprite.Position.Y);
		}
		public void Jump()
		{
			int x = _sprite.Position.X;
			int y = _sprite.Position.Y;

			if (Jumping == 1)
			{
				y -= 10;
			}
			else if (Jumping == 2)
			{
				y += 10;
			}

			if (Direct == Direction.left)
			{
				x -= 7;
				StringCurrentState = "jump back";
			}
			else if (Direct == Direction.right)
			{
				x += 7;
				StringCurrentState = "jump ahead";
			}
			else
			{
				StringCurrentState = "jump";
			}
			_sprite.Position = new System.Drawing.Point(x, y);
			if (_sprite.Position.Y < 100 && Jumping == 1)
			{
				Jumping = 2;
			}
			if (_sprite.Position.Y >= 202 && Jumping == 2)
			{
				Jumping = 0;
				Direct = Direction.stay;
			}
		}

		//=======================CHANGING FUNCTIONS=======================
		public void ChangeSoldier(Direction a_direction)
		{
			if (Life != 2)
			{
				return;
			}
			if (a_direction == Direction.right)
			{
				_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMarioSoldier;
			}
			else
			{
				_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMarioSoldier_Inverse;
			}
		}
		public void ChangeNormal(Direction a_direction)
		{
			if (Life != 1)
			{
				return;
			}
			if (a_direction == Direction.right)
			{
				_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario;
			}
			else
			{
				_sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario_Inverse;
			}
		}

		//=======================DIE FUNTION=======================
		public bool Die()
		{
			_sprite.ImageSpr.Visible = false;
			return true;
		}

		//=======================CHECKING COLLISION FUNCTIONS=======================
		////Kiểm tra va chạm bên phải Mario
		//public bool CheckCollisionRightOfMario(System.Windows.Forms.PictureBox a_otherObject)
		//{
		//    if (CheckCollision(a_otherObject) && this._sprite.ImageSpr.Left < a_otherObject.Left && this._sprite.ImageSpr.Bottom > a_otherObject.Top)
		//    {
		//        return true;
		//    }
		//    return false;
		//}

		////Kiểm tra va chạm bên trái Mario
		//public bool CheckCollisionLeftOfMario(System.Windows.Forms.PictureBox a_otherObject) 
		//{
		//    if (CheckCollision(a_otherObject) && this._sprite.ImageSpr.Right > a_otherObject.Right && this._sprite.ImageSpr.Bottom > a_otherObject.Top)
		//    {
		//        return true;
		//    }
		//    return false;
		//}

		//Kiểm tra va chạm bên dưới Mario
		public bool CheckCollisionBottomOfMario(System.Windows.Forms.PictureBox a_otherObject)
		{
			if (CheckCollision(a_otherObject) && this._sprite.ImageSpr.Bottom >= a_otherObject.Top)
			{
				return true;
			}
			return false;
		}

		////=======================COLLISION TO OBJECTS FUNTIONS=======================
		//Va chạm với chông (Thorn)
		public void CollideThorn(Thorn a_thorn)
		{
			if (CheckCollision(a_thorn._sprite.ImageSpr))
			{
				Life--;
				if (Life == 1)
				{
					ChangeNormal(Direct);
					this._sprite.ImageSpr.Location = new System.Drawing.Point(12, 209);
				}
				if (Life == 0)
				{
					this._sprite.ImageSpr.Visible = false;
				}
			}
		}

		public void CollideMonster(Monster a_Monster)
		{
			//trường hợp va chạm hai bên với NormalMonster
			if (CheckCollision(a_Monster._sprite.ImageSpr))
			{
				Life--;
				if (Life == 1)
				{
					ChangeNormal(Direct);
					this._sprite.ImageSpr.Location = new System.Drawing.Point(12, 207);
					BlueMushroomEaten = false;
				}
				if (Life == 0)
				{
					this._sprite.ImageSpr.Visible = false;
				}
			}
		}

		public void CollideMushroom(Mushroom a_Mushroom)
		{
			if (CheckCollision(a_Mushroom._sprite.ImageSpr))
			{
				this.ChangeSoldier(Direct);
				//a_Mushroom._sprite.ImageSpr.Visible = false;
				a_Mushroom._sprite.ImageSpr.Location = new System.Drawing.Point(328, 300);
				Life = 2;
				if (a_Mushroom._type == 2)
				{
					BlueMushroomEaten = true;
				}
			}
		}
	}
}
