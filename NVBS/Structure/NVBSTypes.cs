using System;
namespace NVBS.Structure
{
	public enum NVBSTypes : byte
	{
		End = 0xFF,
		String = 0xAA,
		Array = 0xBB,
		Map = 0xCC,
		Int = 0x11,
		Byte = 0x22,
		Short = 0x33,
		Long = 0x44,
		Float = 0x55,
		Double = 0x66,
	}

}

