using System;
namespace NVBS.Structure
{
	public abstract class NVBSObject
	{
		public abstract NVBSTypes Type { get; }
		public string AsString() {
			if (!(this is NVBSString)) {
				throw new InvalidOperationException("Object is not a string");
			}
			return ((NVBSString)this).Data;
		}
		
		public long AsLong() {
			if (!(this is NVBSLong)) {
				throw new InvalidOperationException("Object is not a long");
			}
			return ((NVBSLong)this).Data;
		}
		
		public short AsShort() {
			if (!(this is NVBSShort)) {
				throw new InvalidOperationException("Object is not a short");
			}
			return ((NVBSShort)this).Data;
		}
		
		public byte AsByte() {
			if (!(this is NVBSByte)) {
				throw new InvalidOperationException("Object is not a byte");
			}
			return ((NVBSByte)this).Data;
		}
		
		public bool AsBool() {
			if (!(this is NVBSByte)) {
				throw new InvalidOperationException("Object is not a byte");
			}
			return ((NVBSByte)this).Data != 0;
		}
		
		public int AsInt() {
			if (!(this is NVBSInt)) {
				throw new InvalidOperationException("Object is not an int");
			}
			return ((NVBSInt)this).Data;
		}

		public NVBSMap AsMap() {
			if (!(this is NVBSMap)) {
				throw new InvalidOperationException("Object is not a map");
			}

			return (NVBSMap)this;
		}

		public NVBSArray AsArray() {
			if (!(this is NVBSArray)) {
				throw new InvalidOperationException("Object is not an array");
			}
			return (NVBSArray)this;
		}
	}

}

