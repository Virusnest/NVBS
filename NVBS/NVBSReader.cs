using System.Text;
using NVBS.Structure;

namespace NVBS
{
	public class NVBSReader
	{
		private readonly BinaryReader Reader;
		public NVBSReader(BinaryReader reader)
		{
			Reader = reader;
			//Reader.ReadByte();
		}

		public NVBSMap Read()
		{
			return (NVBSMap)Read(NVBSTypes.Map);
		}
		//Read Type then devide how to read it
		private NVBSObject Read(NVBSTypes type)
		{
			switch (type) {
				case NVBSTypes.String:
					return readString();
				case NVBSTypes.Array:
					return readArray();
				case NVBSTypes.Map:
					return readMap();
				case NVBSTypes.Byte:
					return new NVBSByte(Reader.ReadByte());
				case NVBSTypes.Short:
					return new NVBSShort(Reader.ReadInt16());
				case NVBSTypes.Double:
					return new NVBSDouble(Reader.ReadDouble());
				case NVBSTypes.Float:
					return new NVBSFloat(Reader.ReadSingle());
				case NVBSTypes.Long:
					return new NVBSLong(Reader.ReadInt64());
				case NVBSTypes.Int:
					return new NVBSInt(Reader.ReadInt32());
				default: {
					Console.WriteLine("Unknown type: " + type);
					return null;
				}
			}
		}
		//Read Map Type	
		private NVBSMap readMap()
		{
			var map = new NVBSMap();
			while (true)
			{
				NVBSTypes type = (NVBSTypes)Reader.ReadByte();
				if (type == NVBSTypes.End) break;
				string name = Encoding.UTF8.GetString(Reader.ReadBytes(Reader.ReadUInt16()));
				NVBSObject value = Read(type);
				if (value == null) break;
				map.Add(name,value);
			}
			return map;
		}
		//read String Type
		private NVBSString readString()
		{
			return new NVBSString(Encoding.UTF8.GetString(Reader.ReadBytes(Reader.ReadUInt16())));
		}
		//Read Array Type
		private NVBSArray readArray()
		{
			NVBSArray array = new NVBSArray();
			NVBSTypes type = (NVBSTypes)Reader.ReadByte();
			ushort count = Reader.ReadUInt16();
			
			for (short i = 0; i < count; i++) {
				array.Add(Read(type));
			}
			return array;
		}
		
	}
}

