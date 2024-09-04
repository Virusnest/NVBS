using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NVBS.Structure
{
	public sealed class NVBSMap : NVBSObject, IDictionary<string, NVBSObject>
	{
		public Dictionary<string, NVBSObject> Data;
		public override Types Type {
			get { return Types.Map; }
		}

		public ICollection<string> Keys => Data.Keys;

		public ICollection<NVBSObject> Values => Data.Values;

		public int Count => Data.Count;

		bool ICollection<KeyValuePair<string, NVBSObject>>.IsReadOnly => false;

		public bool IsReadOnly()
		{
			return false;
		}

		public NVBSObject this[string key] { get => Data[key]; set => Data[key] = value; }

		public NVBSMap()
		{
			Data = new Dictionary<string, NVBSObject>();
		}

		public void Add(string key, NVBSObject value)
		{
			Data.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return Data.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return Data.Remove(key);
		}

		public bool TryGetValue(string key, [MaybeNullWhen(false)] out NVBSObject value)
		{
			return Data.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<string, NVBSObject> item)
		{
			Data.ToHashSet().Add(item);
		}

		public void Clear()
		{
			Data.Clear();
		}

		public bool Contains(KeyValuePair<string, NVBSObject> item)
		{
			return Data.ToHashSet().Contains(item);
		}

		public void CopyTo(KeyValuePair<string, NVBSObject>[] array, int arrayIndex)
		{
			Data.ToHashSet().CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, NVBSObject> item)
		{
			return Data.ToHashSet().Remove(item);
		}

		public IEnumerator<KeyValuePair<string, NVBSObject>> GetEnumerator()
		{
			return Data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

	}
}

