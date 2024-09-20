using System;
using System.Collections;
using System.Linq;

namespace NVBS.Structure
{
	public sealed class NVBSArray : NVBSObject, ICollection<NVBSObject>
	{
		private readonly List<NVBSObject> _data = new List<NVBSObject>();

		public int Count => _data.Count;

		public void Add(NVBSObject item) {
			_data.Add(item);
		}

		public NVBSArray(params NVBSObject[] array) {
			NVBSObject first = array.First();
			foreach (var item in array)
			{
				if(item.Type != first.Type)
				{
					throw new Exception("All items in an array must be of the same type");
				}
				Add(item);
				
			}
		}

		public void Clear() { _data.Clear(); }

		public bool Contains(NVBSObject item) { return _data.Contains(item); }

		public void CopyTo(NVBSObject[] array, int arrayIndex) { _data.CopyTo(array, arrayIndex); }

		public bool Remove(NVBSObject item)
		{
			return _data.Remove(item);
		}

		bool ICollection<NVBSObject>.IsReadOnly => false;

		public override NVBSTypes Type => NVBSTypes.Array;


		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<NVBSObject> GetEnumerator()
		{
			return _data.GetEnumerator();
		}
	}
}

