using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mario
{
	public abstract class GameObject
	{
		public abstract void Move();
		public string Name
		{
			get
			{
				return _name;
			}
			set
			{
				_name = value;
			}
		}

		protected string _name;
		protected System.Drawing.Point _pos;
	}
}
