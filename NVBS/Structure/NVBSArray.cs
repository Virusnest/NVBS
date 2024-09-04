using System;
using System.Collections;
using System.Linq;

namespace NVBS.Structure
{
	public sealed class NVBSArray : NVBSObject, ICollection<NVBSObject>
	{
		public List<NVBSObject> Data = new List<NVBSObject>();

		public int Count { get { return Data.Count; } }
		
		public void Add(NVBSObject item) {
			Data.Add(item);
		}
		public NVBSArray()
		{

		}

		public NVBSArray(params NVBSObject[] array)
		{
			AddRange(array.ToArray());
		}

		public void AddRange(NVBSObject[] array)
		{
			Data.AddRange(array);
		}

		public void Clear() { Data.Clear(); }

		public bool Contains(NVBSObject item) { return Data.Contains(item); }

		public void CopyTo(NVBSObject[] array, int arrayIndex) { Data.CopyTo(array, arrayIndex); }

		public bool Remove(NVBSObject item)
		{
			return true;
		}

		bool ICollection<NVBSObject>.IsReadOnly => false;

		public override Types Type => Types.Array;


		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void CopyTo(NVBSObject array, int index)
		{
			CopyTo(array, index);
		}

		public IEnumerator<NVBSObject> GetEnumerator()
		{
			return Data.GetEnumerator();
		}
	}
}

