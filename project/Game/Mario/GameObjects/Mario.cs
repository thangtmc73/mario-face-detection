using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
	class Mario : BaseObject
	{
        //=======================VARS=======================
        //private variables
        private int _life { get; set; } = 1;
        private int _stateOfShapeMario { get; set; }        // 1 là trạng thái bình thường
                                                            // 2 là trạng thái cầm súng
        private bool _eatingBlueMushroom = false;

        //public variables
        public bool _left, _right, _jump;

        //=======================FUNCTIONS=======================

        //Construction
        public Mario(string a_name, System.Drawing.Point a_defaultPos) : base(a_name)
		{
            _sprite.Position = a_defaultPos;
            _sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario;
            _stateOfShapeMario = 1;
            _life = 1;
        }
        
        //Get Set
        public int Get_life()
        {
            return _life;
        }

        //Moving Function
        public override void Move()
        {
            //nếu Mario CHƯA ăn nấm Xanh
            if (_eatingBlueMushroom == false)
            {
                if (_left)
                    MoveLeft();
                if (_right)
                    MoveRight();
            }

            //nếu Mario ĐÃ ăn nấm Xanh
            else
            {
                if (_left)
                    MoveRight();
                if (_right)
                    MoveLeft();
            }
            if (_jump)
                Jump();
            else
                FallDown();
        }
        public void MoveRight()
        {
            _sprite.Position = new System.Drawing.Point(_sprite.Position.X + 5, _sprite.Position.Y);
        }
        public void MoveLeft()
        {
            _sprite.Position = new System.Drawing.Point(_sprite.Position.X - 5, _sprite.Position.Y);
        }
        public void Jump()
        {
            if (_sprite.Position.Y > 120)
            {
                _sprite.Position = new System.Drawing.Point(_sprite.Position.X, _sprite.Position.Y - 10);
            }
            else
                _jump = false;
        }
        public void FallDown()
        {
            if (_sprite.Position.Y <= 172) // 177 là tạo độ Y của Mario
            {
                _sprite.Position = new System.Drawing.Point(_sprite.Position.X, _sprite.Position.Y + 5);
            }
        }

        //Change outside shape (thay đổi hình dạng khi Mario chạm vào các đối tượng là a_nameOfGameObject)
        public void Change(string a_nameOfGameObject)
        {
            if (a_nameOfGameObject == "normalMonster" || a_nameOfGameObject == "finalMonster" || a_nameOfGameObject == "thorn")
            {
                _life--;
                _stateOfShapeMario = 1;
                ChangeNormal();
            }
            if (a_nameOfGameObject == "redMushroom")
            {
                _life = 2;
                _stateOfShapeMario = 2;
                ChangeSoldier();
            }
            if (a_nameOfGameObject == "blueMushroom")
            {
                _life = 2;
                _stateOfShapeMario = 3;
                ChangeNormal();
                _eatingBlueMushroom = true; //cờ để thông báo rẳng Mario đã ăn nấm Xanh
            }
        }
        public void ChangeSoldier()
        {
            _sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMarioSoldier;
        }
        public void ChangeNormal()
        {
            _sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprMario;
        }

        //Die
        public bool Die()
        {
            _sprite.Destroy();
            return true;
        }
    }
}
