using System;
namespace NVBS.Structure
{
	public sealed class NVBSByte : NVBSObject
	{
		public byte Data;
		public override Types Type {
			get { return Types.Byte; }
		}

		public static implicit operator NVBSByte(byte value)
		{
			return new NVBSByte(value);
		}

		public NVBSByte(byte data)
		{
			Data = data;
		}
	}
}

