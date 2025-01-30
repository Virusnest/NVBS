
using System.Text;
using NVBS;
using NVBS.Structure;

namespace NVBSTests
{
    public class StringTests
    {

        private static readonly NVBSMap Map = new() {
            { "Test", new NVBSString("value") },
            { "Test2", new NVBSInt(1) }, {
            "TestMap", new NVBSMap {
                { "Test", new NVBSString("value") },
                { "Test2", new NVBSInt(2) }, {
                "Test3", (NVBSArray)new NVBSByte[] {
                    1, 2, 3, 4, 5
                }
                }, {
                "Test4", (NVBSArray)new NVBSInt[] {
                    1, 2, 3, 4, 5
                }
                },
            }
            }
        };
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var fileStream = File.Open("asd.txt", FileMode.OpenOrCreate);
            StringBuilder sb = new StringBuilder();
            var witer = new StringWriter(sb);
            var StringWriter = new NVBSStringWriter(witer);
            StringWriter.Stringify(Map);
            StreamWriter streamWriter = new StreamWriter(fileStream);
            foreach (char c in sb.ToString())
            {
                fileStream.WriteByte((byte)c);
            }
            streamWriter.Close();
            fileStream.Close();
            Assert.Pass();
        }
    }
}