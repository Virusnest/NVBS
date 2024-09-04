using System;
namespace NVBS.Structure
{
	public sealed class NVBSFloat : NVBSObject
	{
		public float Data;
		public override Types Type {
			get { return Types.Float; }
		}

		public NVBSFloat(float data)
		{
			Data = data;
		}
	}
}

