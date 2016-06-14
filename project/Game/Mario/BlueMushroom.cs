using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario.GameObjects
{
    class BlueMushroom:Mushroom
    {
        public BlueMushroom (string a_name,System.Drawing.Point a_pos):base(a_name, a_pos)
        {
            _sprite.ImageSpr.Image = global::Mario.Properties.Resources.sprBlueMushroom;
            _sprite.Position = a_pos;
            base._type = 2;
            
        }
        public override void Move()
        {
           
        }
    }
}
