using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERP_Compressores.Domain.Constants;

public class DataAnnotationMessages
{
    public const string REQUIRED = "O campo {0} é obrigatório.";
    public const string STRLENGTH = "O campo {0} deve ter entre {2} e {1} caracteres.";
    public const string RANGE = "O campo {0} deve estar entre {1} e {2}.";
    public const string EMAIL = "O campo {0} deve ser um endereço de e-mail válido.";
    public const string COMPARE = "Os campos {0} e {1} devem ser iguais.";
    public const string REGEX = "O campo {0} não corresponde ao formato esperado.";
    public const string MAXLEN = "O campo {0} não pode ter mais de {1} caracteres.";
    public const string MINLEN = "O campo {0} deve ter pelo menos {1} caracteres.";
}
