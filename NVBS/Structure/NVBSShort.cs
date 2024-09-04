using System;
using Microsoft.VisualBasic;

namespace NVBS.Structure
{
	public sealed class NVBSShort : NVBSObject
	{
		public short Data;
		public override Types Type {
			get { return Types.Short; }
		}

		public NVBSShort(short data)
		{
			Data = data;
		}
	}
}

