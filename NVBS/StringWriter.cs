using NVBS.Structure;

namespace NVBS;

public class NVBSStringWriter
{
  private StringWriter _writer;

  public NVBSStringWriter(StringWriter writer)
  {
    _writer = writer;
  }

  public void Stringify(NVBSMap map)
  {
    WriteMap(map);
  }

  private void WriteMap(NVBSMap map, int indent = 0)
  {
    _writer.Write('{');
    indent += 1;
    foreach (var item in map)
    {
      WriteIndents(indent);
      _writer.Write($"\"{item.Key}\":");
      Write(item.Value, indent);

    }
    WriteIndents(indent);
    _writer.Write('}');
  }

  private void WriteIndents(int indent)
  {
    _writer.Write('\n');
    for (int i = 0; i < indent; i++)
    {
      _writer.Write(' ');
    }
  }

  private void Write(NVBSObject obj, int indent)
  {
    switch (obj.Type)
    {
      case NVBSTypes.String:
        WriteString((NVBSString)obj, indent);
        break;
      case NVBSTypes.Array:
        WriteArray((NVBSArray)obj, indent);
        break;
      case NVBSTypes.Map:
        WriteMap((NVBSMap)obj, indent);
        break;
      case NVBSTypes.Byte:
        _writer.Write(((NVBSByte)obj).Data + 'b');
        break;
      case NVBSTypes.Short:
        _writer.Write(((NVBSShort)obj).Data + 's');
        break;
      case NVBSTypes.Double:
        _writer.Write(((NVBSDouble)obj).Data + 'd');
        break;
      case NVBSTypes.Float:
        _writer.Write(((NVBSFloat)obj).Data);
        break;
      case NVBSTypes.Long:
        _writer.Write(((NVBSLong)obj).Data + 'l');
        break;
      case NVBSTypes.Int:
        _writer.Write(((NVBSInt)obj).Data);
        break;
    }
  }


  private void WriteArray(NVBSArray obj, int indent)
  {
    _writer.Write('[');
    foreach (var item in obj)
    {
      Write(item, indent);
      _writer.Write(',');
    }
    _writer.Write(']');
  }

  private void WriteString(NVBSString obj, int indent)
  {
    _writer.Write($"\"{obj.Data}\"");
  }
}