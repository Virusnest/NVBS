#pragma author Virusnest
#pragma description NVBS data
#pragma endian little
import std.sys;
import std.string;
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

using Value;

struct string {
    u16 len;
    char string[len];
}[[name("("+std::string::to_string(len)+", \""+string+"\")")]];

struct MapElement {
    Type type;
    if(type == Type::End){
        break;
    }else{
        string id;
        Value value;
    }  
    
}[[name(name(this))]];

fn name(MapElement e){
    str id;
    try{
        str type=typestr(e.type);
        if(e.type==Type::Array){
            str a = typestr(e.value.value.type);
            type=type+'<'+a+'>';
        }
        id = '"'+ e.id.string+'"' +" " + type;
    }catch{
        id="END";
    }
    return id;
};

fn typestr(Type t){
    match (t) {
        (Type::End):     return "END";
        (Type::String):  return "String";
        (Type::Array):   return "Array";
        (Type::Map):     return "Map";
        (Type::Int):     return "Int";
        (Type::Byte):    return "Byte";
        (Type::Short):   return "Short";
        (Type::Long):    return "Long";
        (Type::Float):   return "Float";
        (Type::Double):  return "Double";
    }
};

struct Map{
   MapElement elements[while(true)] [[inline]];

};
struct Array{
    Type type;
    u16 len;
    Value values[len];
}[[inline]];

struct Value {
    if (parent.type == Type::Byte)
        u8 value;
    else if (parent.type == Type::Short)
        s16 value;
    else if (parent.type == Type::Int)
        s32 value;
    else if (parent.type == Type::Long)
        s64 value;
    else if (parent.type == Type::Float)
        float value;
    else if (parent.type == Type::Double)
        double value;
    else if (parent.type == Type::String) {
        string value;
    } else if (parent.type == Type::Array) {
        Array value;
    } else if (parent.type == Type::Map) {       
        MapElement value[while(true)];
    } else {
        std::error(std::format("Invalid tag {:02X}", TypeTag));
    }
};

Map RootMap@0x00;