using ProtoBuf;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("UnicodeMaxStringReferences", Schema = "StringReferences")]
    public class UnicodeMaxStringReference
    {
        public UnicodeMaxStringReference() { }
        public UnicodeMaxStringReference(string input) { Value = input; }
        public UnicodeMaxStringReference(StringBuilder stringBuilder)
        {
            Value = stringBuilder?.ToString()
                ?? throw new ArgumentNullException(nameof(stringBuilder));
        }

        [Key]
        [ProtoMember(1)]
        public int UnicodeMaxStringReferenceId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Hash { get; set; }
        [ProtoMember(3)]
        public int HashId { get; set; }

        [Column(TypeName = "nvarchar(max)")]
        [ProtoMember(4)]
        public string Value { get; set; }
    }
}
