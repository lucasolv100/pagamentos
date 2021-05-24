using System;
using System.Collections.Generic;
using FluentValidation;

namespace Payments.Domain.Entities
{
    public class Account : Base<Account>
    {
        public Account(string name, string document, bool isLegalPerson)
        {
            Name = name;
            Document = document;
            IsLegalPerson = isLegalPerson;
            CreateDate = DateTime.Now;

            RuleFor(x => x.Name).NotEmpty().WithMessage("O nome deve ser preenchido");
            RuleFor(x => x.Document).NotEmpty().WithMessage("O documento deve ser preenchido");
            RuleFor(x => x.Name).Length(3, 50).WithMessage("O nome deve conter de 3 a 50 caracteres");

            if (Document.Length == 11)
            {
                RuleFor(x => x.Document).Must(x => IsCpf(Document)).WithMessage("O nome cpf não parece válido");
            }
            if (Document.Length == 14)
            {
                RuleFor(x => x.Document).Must(x => IsCnpj(Document)).WithMessage("O nome cnpj não parece válido");
            }
        }

        private Account()
        {

        }


        public string Name { get; private set; }
        public string Document { get; private set; }
        public bool IsLegalPerson { get; private set; }
        public IEnumerable<AccountMovement> Movements { get; private set; }

        bool IsCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        bool IsCnpj(string cnpj)
        {
            int[] multiplicador1 = new int[12] { 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[13] { 6, 5, 4, 3, 2, 9, 8, 7, 6, 5, 4, 3, 2 };
            int soma;
            int resto;
            string digito;
            string tempCnpj;
            cnpj = cnpj.Trim();
            cnpj = cnpj.Replace(".", "").Replace("-", "").Replace("/", "");
            if (cnpj.Length != 14)
                return false;
            tempCnpj = cnpj.Substring(0, 12);
            soma = 0;
            for (int i = 0; i < 12; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador1[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCnpj = tempCnpj + digito;
            soma = 0;
            for (int i = 0; i < 13; i++)
                soma += int.Parse(tempCnpj[i].ToString()) * multiplicador2[i];
            resto = (soma % 11);
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cnpj.EndsWith(digito);
        }

    }
}