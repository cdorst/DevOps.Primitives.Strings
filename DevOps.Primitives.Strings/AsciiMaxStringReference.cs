using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("AsciiMaxStringReferences", Schema = "StringReferences")]
    public class AsciiMaxStringReference : IMaxStringReference
    {
        public AsciiMaxStringReference() { }
        public AsciiMaxStringReference(in string input) { Value = input; }

        [Key]
        [ProtoMember(1)]
        public int AsciiMaxStringReferenceId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference Hash { get; set; }
        [ProtoMember(3)]
        public int HashId { get; set; }

        [Column(TypeName = "varchar(max)")]
        [ProtoMember(4)]
        public string Value { get; set; }
    }
}
