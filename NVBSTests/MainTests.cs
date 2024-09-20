using NVBS;
using NVBS.Structure;

namespace NVBSTests;

public class NVBSTests {
  public static NVBSMap Map = new() {
    {"Test", new NVBSString("value")},
    {"Test2", new NVBSInt(1)},
    {"TestMap", new NVBSMap {
      { "Test", new NVBSString("value") },
      { "Test2", new NVBSInt(2) }, {
        "Test3", new NVBSArray {
          new NVBSByte(1),
          new NVBSByte(1),
        }
      }
    } }
  };
  [SetUp]
  public void Setup() {

  }

  [Test]
  public void ReadWriteConsistency() {
    var memStream = new MemoryStream();
    new NVBSWriter(new BinaryWriter(memStream)).Write(Map);
    memStream.Position = 0;
    var map = new NVBSReader(new BinaryReader(memStream)).Read();
    memStream.Close();
    Assert.That(map, Is.EqualTo(Map));
  }

  [Test]
  public void CheckMemoryValues() {
    Assert.IsTrue(Map.Keys.Contains("Test"));
    Assert.IsTrue(Map.Keys.Contains("Test2"));
    Assert.IsTrue(Map.Keys.Contains("TestMap"));
    Assert.That(Map["Test"].AsString(), Is.EqualTo("value"));
    Assert.That(Map["Test2"].AsInt(), Is.EqualTo(1)); 
    Assert.That(Map["TestMap"].AsMap()["Test"].AsString(), Is.EqualTo("value"));
    Assert.That(Map["TestMap"].AsMap()["Test2"].AsInt(), Is.EqualTo(2));
  }
  
}