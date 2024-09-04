using System;
namespace NVBS.Structure
{
	public class NVBSLong : NVBSObject
	{
		public long Data;
		public NVBSLong(long data)
		{
			Data = data;
		}

		public override Types Type => Types.Long;
	}
}

