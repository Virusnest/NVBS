using System.Text;
using System.Text.RegularExpressions;
using NVBS.Structure;

namespace NVBS;

public class NVBSStringReader
{
  private readonly StringReader _reader;
  private static Regex BytePattern = new Regex(@"(:?[0-9]*)b");
  private static Regex ShortPattern = new Regex(@"(:?[0-9]*)s");
  private static Regex IntPattern = new Regex(@"(:?[0-9]*)");
  private static Regex LongPattern = new Regex(@"(:?[0-9]*)l");
  private static Regex FloatPattern = new Regex(@"[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?");
  private static Regex DoublePattern = new Regex(@"[-+]?[0-9]*\.?[0-9]+([eE][-+]?[0-9]+)?");
  public NVBSStringReader(StringReader reader)
  {
    _reader = reader;
  }


  public NVBSObject Read()
  {
    return null;
  }

  public NVBSMap Destringify()
  {
    var map = new NVBSMap();
    return map;
  }

  public string ReadString()
  {
    if (_reader.Read() == -1)
    {
      return string.Empty;
    }
    StringBuilder sb = new StringBuilder();
    if (_reader.Peek() == '"')
    {
      _reader.Read();
      while (_reader.Peek() != '"')
      {
        sb.Append((char)_reader.Read());
      }
    }
    return sb.ToString();
  }

  public NVBSObject ReadNumber() { return null; }
  public NVBSArray ReadArray() { return null; }

  public NVBSMap ReadMap()
  {
    _reader.Read();
    while (true)
    {
      if (_reader.Peek() == '}') break;


    }
    return null;
  }

}