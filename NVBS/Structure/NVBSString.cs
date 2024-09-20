using System;
namespace NVBS.Structure
{
	public sealed class NVBSString : NVBSObject
	{
		public readonly string Data;
		public override NVBSTypes Type => NVBSTypes.String;

		public static implicit operator NVBSString(string value)
		{
			return new NVBSString(value);
		}
		public NVBSString(string data)
		{
			Data = data;
		}

		public override bool Equals(object? obj) {
			if (obj is NVBSString str) {
				return str.Data == Data;
			}
			return false;
		}
		
		public override string ToString() {
			return Data;
		}
		
		public override int GetHashCode() {
			return Data.GetHashCode();
		}
		
		public static NVBSString operator +(NVBSString a, NVBSString b) {
			return new NVBSString(a.Data + b.Data);
		}
	}
}

