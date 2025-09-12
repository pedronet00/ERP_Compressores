using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.ValueObjects;

public class Cpf
{
    public string Valor { get; private set; }

    protected Cpf() { }

    public Cpf(string numero)
    {
        if (!Validar(numero))
            throw new ArgumentException("CPF inválido");

        Valor = Limpar(numero);
    }

    private static string Limpar(string cpf) =>
        cpf.Replace(".", "").Replace("-", "").Trim();

    private static bool Validar(string cpf)
    {
        cpf = Limpar(cpf);

        if (cpf.Length != 11 || cpf.All(c => c == cpf[0]))
            return false;

        var multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        var multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf = cpf[..9];
        int soma = 0;

        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        int resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        string digito = resto.ToString();
        tempCpf += digito;
        soma = 0;

        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        resto = resto < 2 ? 0 : 11 - resto;
        digito += resto.ToString();

        return cpf.EndsWith(digito);
    }
}
