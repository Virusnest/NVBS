using System;
using System.Globalization;

namespace NVBS.Structure
{
	public sealed class NVBSDouble : NVBSObject
	{
		public readonly double Data;
		public NVBSDouble(double data)
		{
			Data = data;
		}
		public override NVBSTypes Type => NVBSTypes.Double;
		
		public override bool Equals(object? obj) {
			if (obj is NVBSDouble dbl) {
				return dbl.Data == Data;
			}
			return false;
		}
		
		public override int GetHashCode() {
			return Data.GetHashCode();
		}
		
		public override string ToString() {
			return Data.ToString(CultureInfo.CurrentCulture);
		}
		
		public static implicit operator NVBSDouble(double value)
		{
			return new NVBSDouble(value);
		}
	}
	
}

