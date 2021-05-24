using Payments.Domain.Enums;

namespace Payments.Domain.ViewModels
{
    public class RegisterOperationVM
    {
        public int AccountId { get; set; }
        public decimal Value { get; set; }
        public MovementTypeEnum Type { get; set; }
    }
}