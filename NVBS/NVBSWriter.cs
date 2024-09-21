using System.Text;
using NVBS.Structure;

namespace NVBS
{
	public class NVBSWriter
	{
		private readonly BinaryWriter _writer;
		public NVBSWriter(BinaryWriter writer)
		{
			_writer = writer;
		}
		//Write Type then decide how to write it
		public void Write(NVBSObject obj) {
			switch (obj.Type) {
				case NVBSTypes.String:
					WriteString((NVBSString)obj);
					break;
				case NVBSTypes.Array:
					WriteArray((NVBSArray)obj, (byte)((NVBSArray)obj).First().Type);
					break;
				case NVBSTypes.Map:
					WriteMap((NVBSMap)obj);
					break;
				case NVBSTypes.Byte:
					_writer.Write(((NVBSByte)obj).Data);
					break;
				case NVBSTypes.Short:
					_writer.Write(((NVBSShort)obj).Data);
					break;
				case NVBSTypes.Double:
					_writer.Write(((NVBSDouble)obj).Data);
					break;
				case NVBSTypes.Float:
					_writer.Write(((NVBSFloat)obj).Data);
					break;
				case NVBSTypes.Long:
					_writer.Write(((NVBSLong)obj).Data);
					break;
				case NVBSTypes.Int:
					_writer.Write(((NVBSInt)obj).Data);
					break;
			}

		}
		//Write Map Type
		private void WriteMap(NVBSMap obj)
		{
			foreach(var item in obj) {
				_writer.Write((byte)item.Value.Type);
				_writer.Write((ushort)item.Key.Length);
				_writer.Write(Encoding.UTF8.GetBytes(item.Key));
				Write(item.Value);
			}
			_writer.Write((byte)NVBSTypes.End);
		}
		//Write String Type
		private void WriteString(NVBSString obj)
		{
			_writer.Write((ushort)obj.Data.Length);
			_writer.Write(Encoding.UTF8.GetBytes(obj.Data));
		}
		//Write Array Type
		private void WriteArray(NVBSArray obj, byte type)
		{
			_writer.Write(type);
			_writer.Write((ushort)obj.Count);
			foreach (var item in obj) {
				Write(item);
			}
		}
	}
}

