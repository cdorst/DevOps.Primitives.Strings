﻿using ProtoBuf;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevOps.Primitives.Strings
{
    [ProtoContract]
    [Table("AsciiStringReferences", Schema = "StringReferences")]
    public class AsciiStringReference
    {
        public AsciiStringReference() { }
        public AsciiStringReference(string input)
        {
            if (input == null) input = string.Empty;
            Value = input;
        }
        [Key]
        [ProtoMember(1)]
        public int AsciiStringReferenceId { get; set; }
        [Column(TypeName = "varchar(450)")]
        [ProtoMember(2)]
        public string Value { get; set; }
    }
}