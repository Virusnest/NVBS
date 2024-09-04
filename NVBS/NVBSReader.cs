using System.Text;
using NVBS.Structure;

namespace NVBS
{
	public class NVBSReader
	{
		private BinaryReader Reader;
		public NVBSReader(BinaryReader reader)
		{
			Reader = reader;
			//Reader.ReadByte();
		}

		public NVBSMap Read()
		{
			return (NVBSMap)Read(Types.Map);
		}

		private NVBSObject Read(Types type)
		{
			switch (type) {
				case Types.String:
					return readString();
				case Types.Array:
					return readArray();
				case Types.Map:
					return readMap();
				case Types.Byte:
					return new NVBSByte(Reader.ReadByte());
				case Types.Short:
					return new NVBSShort(Reader.ReadInt16());
				case Types.Double:
					return new NVBSDouble(Reader.ReadDouble());
				case Types.Float:
					return new NVBSFloat(Reader.ReadSingle());
				case Types.Long:
					return new NVBSLong(Reader.ReadInt64());
				case Types.Int:
					return new NVBSInt(Reader.ReadInt32());
			}
			return null;

		}

		private NVBSMap readMap()
		{
			var map = new NVBSMap();
			while (true)
			{
				Console.WriteLine((Types)Reader.PeekChar());
				Types type = (Types)Reader.ReadByte();
				if (type == Types.End) break;
				string name = Encoding.UTF8.GetString(Reader.ReadBytes(Reader.ReadInt16()));
				NVBSObject value = Read(type);
				if (value == null) break;
				map.Add(name,value);
			}
			return map;
		}
		private NVBSString readString()
		{
			return new NVBSString(Encoding.UTF8.GetString(Reader.ReadBytes(Reader.ReadInt16())));
		}
		private NVBSArray readArray()
		{
			NVBSArray array = new NVBSArray();
			Types type = (Types)Reader.ReadByte();
			short count = Reader.ReadInt16();
			
			for (short i = 0; i < count; i++) {
				array.Add(Read(type));
			}
			return array;
		}
		
	}
}

