using System;
using System.Globalization;

namespace NVBS.Structure
{
	public sealed class NVBSFloat : NVBSObject
	{
		public readonly float Data;
		public override NVBSTypes Type => NVBSTypes.Float;

		public NVBSFloat(float data)
		{
			Data = data;
		}
		
		public override bool Equals(object? obj) {
			if (obj is NVBSFloat flt) {
				return flt.Data == Data;
			}
			return false;
		}
		
		public static implicit operator NVBSFloat(float value)
		{
			return new NVBSFloat(value);
		}
		
		public override string ToString() {
			return Data.ToString(CultureInfo.CurrentCulture);
		}
		
		public override int GetHashCode() {
			return Data.GetHashCode();
		}
	}
}

