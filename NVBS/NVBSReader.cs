using System.Text;
using NVBS.Structure;

namespace NVBS
{
	public class NVBSReader
	{
		private readonly BinaryReader _reader;
		public NVBSReader(BinaryReader reader)
		{
			_reader = reader;
			//Reader.ReadByte();
		}

		public NVBSMap Read()
		{
			return (NVBSMap)Read(NVBSTypes.Map);
		}
		//Read Type then decide how to read it
		private NVBSObject Read(NVBSTypes type)
		{
			switch (type) {
				case NVBSTypes.String:
					return ReadString();
				case NVBSTypes.Array:
					return ReadArray();
				case NVBSTypes.Map:
					return ReadMap();
				case NVBSTypes.Byte:
					return new NVBSByte(_reader.ReadByte());
				case NVBSTypes.Short:
					return new NVBSShort(_reader.ReadInt16());
				case NVBSTypes.Double:
					return new NVBSDouble(_reader.ReadDouble());
				case NVBSTypes.Float:
					return new NVBSFloat(_reader.ReadSingle());
				case NVBSTypes.Long:
					return new NVBSLong(_reader.ReadInt64());
				case NVBSTypes.Int:
					return new NVBSInt(_reader.ReadInt32());
				default: { 
					throw new InvalidOperationException("Invalid Type");
				}
			}
		}
		//Read Map Type	
		private NVBSMap ReadMap()
		{
			var map = new NVBSMap();
			while (true)
			{
				NVBSTypes type = (NVBSTypes)_reader.ReadByte();
				if (type == NVBSTypes.End) break;
				string name = Encoding.UTF8.GetString(_reader.ReadBytes(_reader.ReadUInt16()));
				NVBSObject value = Read(type);
				map.Add(name,value);
			}
			return map;
		}
		//read String Type
		private NVBSString ReadString()
		{
			return new NVBSString(Encoding.UTF8.GetString(_reader.ReadBytes(_reader.ReadUInt16())));
		}
		//Read Array Type
		private NVBSArray ReadArray()
		{
			NVBSArray array = new NVBSArray(Array.Empty<NVBSObject>());
			NVBSTypes type = (NVBSTypes)_reader.ReadByte();
			ushort count = _reader.ReadUInt16();
			
			for (short i = 0; i < count; i++) {
				array.Add(Read(type));
			}
			return array;
		}
		
	}
}

