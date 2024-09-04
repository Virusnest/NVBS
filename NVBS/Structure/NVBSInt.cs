using System;
namespace NVBS.Structure
{
	public sealed class NVBSInt : NVBSObject
	{
		public int Data;
		public override Types Type {
			get { return Types.Int; }
		}

		public NVBSInt(int data)
		{
			Data = data;
		}
	}
}

