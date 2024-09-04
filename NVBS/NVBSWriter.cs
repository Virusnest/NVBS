using System.Text;
using NVBS.Structure;

namespace NVBS
{
	public class NVBSWriter
	{
		private readonly BinaryWriter Writer;
		public NVBSWriter(BinaryWriter writer)
		{
			Writer = writer;
		}
		//Write Type then devide how to write it
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
		//Write Map Type
		private void writeMap(NVBSMap obj)
		{
			foreach(var item in obj) {
				Writer.Write((byte)item.Value.Type);
				Writer.Write((ushort)item.Key.Length);
				Writer.Write(Encoding.UTF8.GetBytes(item.Key));
				Write(item.Value);
			}
			Writer.Write((byte)Types.End);
		}
		//Write String Type
		private void writeString(NVBSString obj)
		{
			Writer.Write((ushort)obj.Data.Length);
			Writer.Write(Encoding.UTF8.GetBytes(obj.Data));
		}
		//Write Array Type
		private void writeArray(NVBSArray obj, byte type)
		{
			Writer.Write(type);
			Writer.Write((ushort)obj.Count);
			foreach (var item in obj) {
				Write(item);
			}
		}
	}
}

