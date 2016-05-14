using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manager
{
	public class SpriteManager
	{
		private SpriteManager()
		{
			_linkedNameWithIndex = new System.Collections.Generic.Dictionary<string, int>();
			_listOfAllSprites = new System.Collections.Generic.List<Core.Sprite>();
		}
		
		public void Add(Core.Sprite a_sprite)
		{
			if (a_sprite != null)
			{
				int k = 0;
				if (_linkedNameWithIndex.TryGetValue(a_sprite.Name, out k))
				{
					return;
				}
				_linkedNameWithIndex.Add(a_sprite.Name, _linkedNameWithIndex.Count);
				//a_sprite.AddImageToContainer();
				_listOfAllSprites.Add(a_sprite);
			}
		}
		public void RemoveWithName(string a_name)
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
				_listOfAllSprites[k].Destroy();
				_listOfAllSprites[k] = null;
				_listOfAllSprites.Remove(_listOfAllSprites[k]);
				//Length--;
			}
		}
		public Core.Sprite GetSpriteWithName(string a_name)
		{
			int k;
			if (_linkedNameWithIndex.TryGetValue(a_name, out k) == false)
			{
				return null;
			}
			return  _listOfAllSprites[k];
		}
		private static SpriteManager _instance;
		public static SpriteManager Instance
		{
			get
			{
				if (_instance == null)
				{
					_instance = new SpriteManager();
				}
				return _instance;
			}
		}
		private System.Collections.Generic.Dictionary<string, int> _linkedNameWithIndex;
		private System.Collections.Generic.List<Core.Sprite> _listOfAllSprites;
	}
}