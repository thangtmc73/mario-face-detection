using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
	public class Sprite
	{
		public Sprite()
		{
			_parent = null;
			ImageSpr = new System.Windows.Forms.PictureBox();
			ImageSpr.BackColor = System.Drawing.Color.Transparent;
			ImageSpr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
		}
		
		public Sprite(System.Windows.Forms.Form a_container, System.Windows.Forms.PictureBox a_picturebox)
		{
			_parent = a_container;
			if (ImageSpr != null)
			{
				ImageSpr = a_picturebox;
			}
			else
			{
				ImageSpr = new System.Windows.Forms.PictureBox();
			}
		}
		public void SetContainer(System.Windows.Forms.Form a_container)
		{
			if (a_container == null)
			{
				return;
			}
			if (ImageSpr.Parent != null)
			{
				ImageSpr.Parent.Controls.Remove(ImageSpr);
			}
			_parent = a_container;
			_parent.Controls.Add(ImageSpr);
		}

		public void Destroy()
		{
			if (_parent != null)
			{
				_parent.Controls.Remove(ImageSpr);
			}
		}
		public string Name { get; set; }
		public System.Windows.Forms.PictureBox ImageSpr { get; set; }
		public System.Drawing.Point Position
		{
			get
			{
				return ImageSpr.Location;
			}
			set
			{
				ImageSpr.Location = value;
			}
		}
		private System.Windows.Forms.Form _parent;
	}
}
