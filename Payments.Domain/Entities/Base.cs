using System;
using FluentValidation;

namespace Payments.Domain.Entities
{
    public abstract class Base<T> : AbstractValidator<T>
    {
        public int Id { get; protected set; }
        public DateTime CreateDate { get; protected set; }
        public DateTime? EditDate { get; protected set; }
        public DateTime? DeleteDate { get; protected set; }

    }
}