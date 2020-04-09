using EntityFramework.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class RelationshipStatus
    {
        public int Id { get; set; }
        public string  Description { get; set; }
        public bool NotSpecified { get { return Id == (int)RelationshipStatusEnum.NotSpecified; } }
        public bool Married { get { return Id == (int)RelationshipStatusEnum.Married; } }
        public bool Single { get { return Id == (int)RelationshipStatusEnum.Single; } }
        public bool InSeriousRelationship { get { return Id == (int)RelationshipStatusEnum.InSeriousRelationship; } }
    }
}
