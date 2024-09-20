using System;
namespace NVBS.Structure
{
	public sealed class NVBSInt : NVBSObject
	{
		public readonly int Data;
		public override NVBSTypes Type => NVBSTypes.Int;

		public NVBSInt(int data)
		{
			Data = data;
		}
		
		public override bool Equals(object? obj) {
			if (obj is NVBSInt i) {
				return i.Data == Data;
			}
			return false;
		}

		public override int GetHashCode() {
			return Data.GetHashCode();
		}
		
		public override string ToString() {
			return Data.ToString();
		}
	}
}

