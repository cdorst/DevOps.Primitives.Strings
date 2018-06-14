using Common.EntityFrameworkServices;
using Common.EntityFrameworkServices.Factories;
using ProtoBuf;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("AsciiStringReferenceLists", Schema = "StringReferences")]
    public class AsciiStringReferenceList : IUniqueList<AsciiStringReference, AsciiStringReferenceListAssociation>
    {
        [Key]
        [ProtoMember(1)]
        public int AsciiStringReferenceListId { get; set; }

        [ProtoMember(2)]
        public AsciiStringReference ListIdentifier { get; set; }
        [ProtoMember(3)]
        public int ListIdentifierId { get; set; }

        [ProtoMember(4)]
        public List<AsciiStringReferenceListAssociation> AsciiStringReferenceListAssociations { get; set; }

        public List<AsciiStringReferenceListAssociation> GetAssociations() => AsciiStringReferenceListAssociations;

        public void SetRecords(in List<AsciiStringReference> records)
        {
            AsciiStringReferenceListAssociations = UniqueListAssociationsFactory<AsciiStringReference, AsciiStringReferenceListAssociation>.Create(records);
            ListIdentifier = new AsciiStringReference(
                UniqueListIdentifierFactory<AsciiStringReference>.Create(records, r => r.AsciiStringReferenceId));
        }
    }
}
