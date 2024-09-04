using System;
namespace NVBS.Structure
{
	public sealed class NVBSString : NVBSObject
	{
		public string Data = "";
		public override Types Type {
			get { return Types.String; }
		}
		public static implicit operator NVBSString(string value)
		{
			return new NVBSString(value);
		}
		public NVBSString(string data)
		{
			Data = data;
		}
	}
}

