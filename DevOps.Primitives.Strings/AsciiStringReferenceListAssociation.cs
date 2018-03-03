using Common.EntityFrameworkServices;
using ProtoBuf;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("AsciiStringReferenceListAssociations", Schema = "StringReferences")]
    public class AsciiStringReferenceListAssociation : IUniqueListAssociation<AsciiStringReference>
    {
        [ProtoMember(1)]
        public int AsciiStringReferenceListAssociationId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference AsciiStringReference { get; set; }
        [ProtoMember(3)]
        public int AsciiStringReferenceId { get; set; }

        [ProtoMember(4)]
        public AsciiStringReferenceList AsciiStringReferenceList { get; set; }
        [ProtoMember(5)]
        public int AsciiStringReferenceListId { get; set; }

        public AsciiStringReference GetRecord() => AsciiStringReference;

        public void SetRecord(AsciiStringReference record)
        {
            AsciiStringReference = record;
            AsciiStringReferenceId = AsciiStringReference.AsciiStringReferenceId;
        }
    }
}
