using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
	public class PictureBoxManager
	{
		private static PictureBoxManager _instance;
		public static PictureBoxManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new PictureBoxManager();
				}
				return _instance;
			}
		}
		private PictureBoxManager()
		{
			Length = 0;
			_linkedNameWithIndex = new System.Collections.Generic.Dictionary<string, int>();
			_listOfAllPictureBox = new System.Collections.Generic.List<System.Windows.Forms.PictureBox>();
		}
		private System.Windows.Forms.Form _relatedForm;
		private System.Collections.Generic.Dictionary<string, int> _linkedNameWithIndex;
		private System.Collections.Generic.List<System.Windows.Forms.PictureBox> _listOfAllPictureBox;
		private int Length { get; set; }
		public void ReplaceForm(System.Windows.Forms.Form a_form)
		{
			if (_relatedForm == null || a_form.Name != _relatedForm.Name)
			{
				_linkedNameWithIndex.Clear();
				_listOfAllPictureBox.Clear();
			}
			_relatedForm = a_form;
		}
		public void AddPictureBox(System.Windows.Forms.PictureBox a_pic)
		{
			int k = 0;
			if (_linkedNameWithIndex.TryGetValue(a_pic.Name, out k))
			{
				return;
			}
			_linkedNameWithIndex.Add(a_pic.Name, Length);
			_relatedForm.Controls.Add(a_pic);
			_listOfAllPictureBox.Add(a_pic);
			Length++;
		}
		public void RemovePictureBoxWithName(string a_name)
		{
			int k = 0;
			if (_linkedNameWithIndex.TryGetValue(a_name, out k))
			{

				for (int i = 0; i < _linkedNameWithIndex.Count; i++)
				{
					if (_linkedNameWithIndex.ElementAt(i).Value < k)
					{
						continue;
					}
					else
					{
						_linkedNameWithIndex[_linkedNameWithIndex.ElementAt(i).Key] = _linkedNameWithIndex.ElementAt(i).Value - 1;
					}
				}
				_linkedNameWithIndex.Remove(a_name);
				_relatedForm.Controls.Remove(_listOfAllPictureBox[k]);
				_listOfAllPictureBox.Remove(_listOfAllPictureBox[k]);
				Length--;
			}
		}
		public System.Windows.Forms.PictureBox GetPictureBoxWithName(string a_name)
		{
			int k;
			if (_linkedNameWithIndex.TryGetValue(a_name, out k) == false)
			{
				return null;
			}
			return  _listOfAllPictureBox[k];
		}
		public void UpdatePictureBoxWithName(string a_name)
		{
			int k;
			if (_linkedNameWithIndex.TryGetValue(a_name, out k) == false)
			{
				return;
			}
			_relatedForm.Controls[a_name].Location = _listOfAllPictureBox[_linkedNameWithIndex[a_name]].Location;
		}
	}
}