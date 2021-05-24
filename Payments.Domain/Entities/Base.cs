using System;

namespace Payments.Domain.Entities
{
    public abstract class Base
    {
        public int Id { get; protected set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        
    }
}