using System;

namespace LayeredArchitectureProject.Entity.Domain
{
    public class AuditableEntity
    {
        public AuditableEntity()
        {
            this.CreateTime = DateTime.UtcNow.AddHours(3);
        }

        public DateTime CreateTime { get; set; }
    }
}
