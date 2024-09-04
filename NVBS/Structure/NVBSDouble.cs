using System;
namespace NVBS.Structure
{
	public sealed class NVBSDouble : NVBSObject
	{
		public double Data;

		public NVBSDouble(double data)
		{
			Data = data;
		}

		public override Types Type => Types.Double;
	}
}

