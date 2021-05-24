using System;
using FluentValidation;

namespace Payments.Domain.Entities
{
    public abstract class Base<T> : AbstractValidator<T>
    {
        public int Id { get; protected set; }
        public DateTime CreateDate { get; set; }
        public DateTime? EditDate { get; set; }
        public DateTime? DeleteDate { get; set; }

    }
}