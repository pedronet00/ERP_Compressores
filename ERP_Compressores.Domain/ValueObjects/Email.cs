using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.ValueObjects;

public class Email
{
    public string Endereco { get; private set; }

    protected Email() { }

    public Email(string endereco)
    {
        if (!Validar(endereco))
            throw new ArgumentException("Email inválido");

        Endereco = endereco.Trim().ToLower();
    }

    private static bool Validar(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        // regra básica: deve ter "@" e "."
        if (!email.Contains('@') || !email.Contains('.'))
            return false;

        // opcional: validação com Regex
        return System.Text.RegularExpressions.Regex.IsMatch(
            email,
            @"^[^@\s]+@[^@\s]+\.[^@\s]+$",
            System.Text.RegularExpressions.RegexOptions.IgnoreCase
        );
    }
}
