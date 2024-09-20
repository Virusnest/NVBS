using System;
namespace NVBS.Structure
{
	public class NVBSLong : NVBSObject
	{
		public readonly long Data;
		public NVBSLong(long data)
		{
			Data = data;
		}

		public override NVBSTypes Type => NVBSTypes.Long;
		
		public override bool Equals(object? obj) {
			if (obj is NVBSLong lng) {
				return lng.Data == Data;
			}
			return false;
		}
		
		public override string ToString() {
			return Data.ToString();
		}
		
		public override int GetHashCode() {
			return Data.GetHashCode();
		}
	}
}

