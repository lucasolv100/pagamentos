using Payments.Domain.Enums;

namespace Payments.Domain.Entities
{
    public class AccountMovement : Base<AccountMovement>
    {
        public AccountMovement(decimal value, int accountId, MovementTypeEnum movementType)
        {
            Value = value;
            AccountId = accountId;
            MovementType = movementType;
        }

        private AccountMovement() //CTOR para atender requisitos do EF
        {
            
        }

        public decimal Value { get; private set; }
        public int AccountId { get; private set; }
        public MovementTypeEnum MovementType { get; private set; }
        public Account Account { get; private set; }
    }
}