enum Type : u8 {
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
};

struct MapElement {
    Type type;
    string name;
    if (parent.tag == Tag::Byte)
        s8 value;
    else if (parent.tag == Tag::Short)
        s16 value;
    else if (parent.tag == Tag::Int)
        s32 value;
    else if (parent.tag == Tag::Long)
        s64 value;
    else if (parent.tag == Tag::Float)
        float value;
    else if (parent.tag == Tag::Double)
        double value;
    else if (parent.tag == Tag::ByteArray) {
        s32 arrayLength;
        s8 value[arrayLength] [[sealed]];
    } else if (parent.tag == Tag::String) {
        u16 stringLength;
        char value[stringLength];
    } else if (parent.tag == Tag::List) {
        Tag tag;
        s32 listLength;
        Value values[listLength] [[static]];
    } else if (parent.tag == Tag::Compound) {       
        Element values[while(true)];
    } else if (parent.tag == Tag::IntArray){
        s32 arrayLength;
        s32 value[arrayLength] [[sealed]];
    } else if (parent.tag == Tag::LongArray) {
        s32 arrayLength;
        s64 value[arrayLength] [[sealed]];
    } else {
        std::error(std::format("Invalid tag {:02X}", TypeTag));
    }

    
};

struct string {
    u16 len;
    char string[len];
} [[name(string)]];

struct Map{
    MapElement elements[];
};

Map map @0x00;