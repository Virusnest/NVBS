using System;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using NVBS.Structure;

namespace NVBS
{
	public class NVBSWriter
	{
		private BinaryWriter Writer;
		public NVBSWriter(BinaryWriter writer)
		{
			Writer = writer;
		}
		public void Write(NVBSObject obj) {
			switch (obj.Type) {
				case Types.String:
					writeString((NVBSString)obj);
					break;
				case Types.Array:
					writeArray((NVBSArray)obj, (byte)((NVBSArray)obj).First().Type);
					break;
				case Types.Map:
					writeMap((NVBSMap)obj);
					break;
				case Types.Byte:
					Writer.Write(((NVBSByte)obj).Data);
					break;
				case Types.Short:
					Writer.Write(((NVBSShort)obj).Data);
					break;
				case Types.Double:
					Writer.Write(((NVBSDouble)obj).Data);
					break;
				case Types.Float:
					Writer.Write(((NVBSFloat)obj).Data);
					break;
				case Types.Long:
					Writer.Write(((NVBSLong)obj).Data);
					break;
				case Types.Int:
					Writer.Write(((NVBSInt)obj).Data);
					break;
			}

		}
		private void writeMap(NVBSMap obj)
		{
			foreach(var item in obj) {
				Writer.Write((byte)item.Value.Type);
				Writer.Write((short)item.Key.Length);
				Writer.Write(Encoding.UTF8.GetBytes(item.Key));
				Write(item.Value);
			}
			Writer.Write((byte)Types.End);
		}
		private void writeString(NVBSString obj)
		{
			Writer.Write((short)obj.Data.Length);
			Writer.Write(Encoding.UTF8.GetBytes(obj.Data));
		}
		private void writeArray(NVBSArray obj, byte type)
		{
			Writer.Write(type);
			Writer.Write((short)obj.Count);
			foreach (var item in obj) {
				Write(item);
			}
		}
	}
}

