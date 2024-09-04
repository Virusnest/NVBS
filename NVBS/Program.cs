// See https://aka.ms/new-console-template for more information
using NVBS;
using NVBS.Structure;

Console.WriteLine("Hello, World!");
var map = new NVBSMap
{
  { "Hello", new NVBSString("World") },
  { "Numbers", new NVBSArray(new NVBSByte[] { 1,2,3,4,5,6,7,8,9,10,11,12 })},
  { "Maps", new NVBSArray(new NVBSMap[] {
    new NVBSMap {
      { "Byte", (NVBSByte) 0},
      {"Example1", (NVBSString)"example" }
    },
    new NVBSMap {
      { "Byte", (NVBSByte) 255},
      {"Example2", (NVBSString)"exampled" }
    }
  }) }
};
var stream = File.OpenWrite("asd.nvbs");
new NVBSWriter(new BinaryWriter(stream)).Write(map);
stream.Close();
var readstream = File.OpenRead("asd.nvbs");
var obj = new NVBSReader(new BinaryReader(readstream)).Read();
readstream.Close();




