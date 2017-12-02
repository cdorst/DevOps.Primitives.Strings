using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("UnicodeStringReferences", Schema = "StringReferences")]
    public class UnicodeStringReference : IUniqueListRecord
    {
        public UnicodeStringReference() { }
        public UnicodeStringReference(string input)
        {
            if (input == null) input = string.Empty;
            Value = input;
        }
        [Key]
        [ProtoMember(1)]
        public int UnicodeStringReferenceId { get; set; }
        [ProtoMember(2)]
        public string Value { get; set; }
    }
}
