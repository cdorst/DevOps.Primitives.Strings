using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.String;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("UnicodeStringReferences", Schema = "StringReferences")]
    public class UnicodeStringReference : IUniqueListRecord
    {
        public UnicodeStringReference() { }
        public UnicodeStringReference(in string input)
            => Value = input ?? Empty;

        [Key]
        [ProtoMember(1)]
        public int UnicodeStringReferenceId { get; set; }

        [ProtoMember(2)]
        [Column(TypeName = "nvarchar(450)")]
        public string Value { get; set; }
    }
}
