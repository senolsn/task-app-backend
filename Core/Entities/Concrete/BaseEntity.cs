using Core.Entities.Abstract;
using System;

namespace Core.Entities.Concrete
{
    public class BaseEntity : IEntity,IEntityTimestamps
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
