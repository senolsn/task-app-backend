using Core.Entities.Abstract;
using System;

namespace Core.Entities.Concrete
{
    public class BaseEntity : IEntity,IEntityTimestamps
    {
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
