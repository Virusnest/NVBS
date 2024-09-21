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

		public NVBSArray(NVBSObject[] array) {
			if (array.Length == 0) return;

				_data.AddRange(array);
				
		}
		
		public static implicit operator NVBSArray(NVBSObject[] array) {
			return new NVBSArray(array);
		}
		
		public static implicit operator NVBSObject[](NVBSArray array) {
			return array._data.ToArray();
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
		
		public NVBSObject this[int index] => _data[index];
	}
}

