using EntityFramework.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFramework.Domain.Entities
{
    public class LookingFor
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool NaoEspecificado
        {
            get
            {
                return Id == (int)LookingEnum.NotSpecified;
            }
        }
        public bool Friefriendship
        {
            get
            {
                return Id == (int)LookingEnum.Friefriendship;
            }
        }
        public bool Dating
        {
            get
            {
                return Id == (int)LookingEnum.Dating;
            }
        }
        public bool SeriousRelationship
        {
            get
            {
                return Id == (int)LookingEnum.SeriousRelationship;
            }
        }
    }
}
