# NVBS Name Value Binary Structure

## Type Prefixes

| Type   | ID     | Length in Bytes |
| ------ | ------ | --------------- |
| End    | `0xFF` | 0               |
| String | `0xAA` | ...             |
| Array  | `0xBB` | ...             |
| Map    | `0xCC` | ...             |
| Int    | `0x11` | 4               |
| Byte   | `0x22` | 1               |
| Short  | `0x33` | 2               |
| Long   | `0x44` | 8               |
| Float  | `0x55` | 4               |
| Double | `0x66` | 8               |

- All Data in its simplest form does not inlcude its prefix 
## Special Type Structure

### Map/Dictionary

- The root should NOT be a prefixed Map.
- A Map does not prefix its length unlike an Array.
- Keys are a String.
- A Map is trailed with the End `0xFF` Byte.
- Each Map element is prefiexed with its type then its key.

### Map Entry

|              | Type        | Key              | Value                  |
| ------------ | ----------- | ---------------- | ---------------------- |
| Psudo Data   | `String : ` | `("Key")`        | `String(4,"Hello")`    |
| Actual Bytes | `AA`        | `03 00 4b 65 79` | `05 00 48 65 6c 6c 6f` |

### Array

- Array elements are not prefiex with thier type
- The Array object itself should be prefiexed with a Byte denoting the type of its contents and 2 bBtes (Short) denoting the length

|              | Type     | Length (Unsigned) | Value                   |
| ------------ | -------- | ------------------| ----------------------- |
| Psudo Data   | `<Byte>` | `4`               | `Byte[]= {1,2,3,4,...}` |
| Actual Bytes | `22`     | `04 00`           | `01 02 03 04`           |

### String

- All Strings are encoded with `UTF-8` and should be prefixed with 2 Bytes (Short) denoting the length

|              | Length(Unsigned)  | Value            |
| ------------ | ----------------- | ---------------- |
| Psudo Data   | `5`               | `"Hello"`        |
| Actual Bytes | `05 00`           | `48 65 6c 6c 6f` |

## Examples

```json
RootMap()
  { 
    String : (5,"Hello"), (5,"World"),
    Array<Byte> : (7,"Numbers"), ({ 1,2,3,4,5,6,7,8,9,10,11,12 }),
    Array<Map> : (4,"Maps"),  ({
      {
        Byte : (5,"Byte"), (0),
        String : (8,"Example1"), (7,"example"),
        End()
      },
      {
        Byte : (5,"Byte2"), (255),
        String : (8,"Example2"), (7,"exampled"),
        End()
      }
    })
    End()
  }
```

```hex
AA 05 00 48 65 6C 6C 6F 05 00 57 6F 72 6C 64 BB
07 00 4E 75 6D 62 65 72 73 22 0C 00 01 02 03 04
05 06 07 08 09 0A 0B 0C BB 04 00 4D 61 70 73 CC
02 00 22 04 00 42 79 74 65 00 AA 08 00 45 78 61
6D 70 6C 65 31 07 00 65 78 61 6D 70 6C 65 FF 22
04 00 42 79 74 65 FF AA 08 00 45 78 61 6D 70 6C
65 32 08 00 65 78 61 6D 70 6C 65 64 FF FF 
```
