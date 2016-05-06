using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
	class Monster
	{
		public Monster()
		{
			_direction = 0;
		}
		public void setDirection(int type)
		{
			_direction = type;
		}
		public int getDirection()
		{
			return _direction;
		}
		public void updateDirection()
		{
			
		}
		private int _direction;

	}
}
