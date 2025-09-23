using System;

namespace Core.Entities.Concrete
{
    public class OperationClaim:BaseEntity
    {
        public Guid OperationClaimId { get; set; }
        public string OperationName { get; set; }
    }
}
