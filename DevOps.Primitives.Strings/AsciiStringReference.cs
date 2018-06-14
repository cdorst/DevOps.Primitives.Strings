using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.String;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("AsciiStringReferences", Schema = "StringReferences")]
    public class AsciiStringReference : IUniqueListRecord
    {
        public AsciiStringReference() { }
        public AsciiStringReference(in string input)
            => Value = input ?? Empty;

        [Key]
        [ProtoMember(1)]
        public int AsciiStringReferenceId { get; set; }

        [Column(TypeName = "varchar(900)")]
        [ProtoMember(2)]
        public string Value { get; set; }
    }
}
