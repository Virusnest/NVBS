using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace NVBS.Structure
{
	public sealed class NVBSMap : NVBSObject, IDictionary<string, NVBSObject>
	{
		private readonly Dictionary<string, NVBSObject> _data = new();
		public override NVBSTypes Type => NVBSTypes.Map;

		public ICollection<string> Keys => _data.Keys;

		public ICollection<NVBSObject> Values => _data.Values;

		public int Count => _data.Count;

		bool ICollection<KeyValuePair<string, NVBSObject>>.IsReadOnly => false;

		public bool IsReadOnly()
		{
			return false;
		}

		public NVBSObject this[string key] { get => _data[key]; set => _data[key] = value; }

		public void Add(string key, NVBSObject value)
		{
			_data.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return _data.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return _data.Remove(key);
		}

		public bool TryGetValue(string key, [MaybeNullWhen(false)] out NVBSObject value)
		{
			return _data.TryGetValue(key, out value);
		}

		public void Add(KeyValuePair<string, NVBSObject> item)
		{
			_data.ToHashSet().Add(item);
		}

		public void Clear()
		{
			_data.Clear();
		}

		public bool Contains(KeyValuePair<string, NVBSObject> item)
		{
			return _data.ToHashSet().Contains(item);
		}

		public void CopyTo(KeyValuePair<string, NVBSObject>[] array, int arrayIndex)
		{
			_data.ToHashSet().CopyTo(array, arrayIndex);
		}

		public bool Remove(KeyValuePair<string, NVBSObject> item)
		{
			return _data.ToHashSet().Remove(item);
		}

		public IEnumerator<KeyValuePair<string, NVBSObject>> GetEnumerator()
		{
			return _data.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
		
		

	}
}

