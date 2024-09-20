using System;
using Microsoft.VisualBasic;

namespace NVBS.Structure
{
	public sealed class NVBSShort : NVBSObject
	{
		public readonly short Data;
		public override NVBSTypes Type => NVBSTypes.Short;

		public NVBSShort(short data)
		{
			Data = data;
		}

		public override bool Equals(object? obj) {
			if (obj is NVBSShort srt) {
				return srt.Data == Data;
			}
			return false;
		}
		
		public static implicit operator NVBSShort(short value)
		{
			return new NVBSShort(value);
		}
		
		public override string ToString() {
			return Data.ToString();
		}

		public override int GetHashCode() {
			return Data.GetHashCode();
		}
	}
}

