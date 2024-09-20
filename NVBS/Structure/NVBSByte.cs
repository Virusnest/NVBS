using System;
namespace NVBS.Structure
{
	public sealed class NVBSByte : NVBSObject
	{
		public readonly byte Data;
		public override NVBSTypes Type => NVBSTypes.Byte;

		public static implicit operator NVBSByte(byte value)
		{
			return new NVBSByte(value);
		}

		public NVBSByte(byte data)
		{
			Data = data;
		}
		
		public override bool Equals(object? obj) {
			if (obj is NVBSByte byt) {
				return byt.Data == Data;
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

