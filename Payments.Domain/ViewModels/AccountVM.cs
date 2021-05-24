using System;

namespace Payments.Domain.ViewModels
{
    public class AccountVM
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public bool IsLegalPerson { get; set; }
    }
}