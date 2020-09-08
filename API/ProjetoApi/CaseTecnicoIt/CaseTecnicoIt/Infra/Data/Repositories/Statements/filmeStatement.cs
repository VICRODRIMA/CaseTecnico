using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Infra.Data.Repositories.Statements
{
    internal static class filmeStatement
    {
        public static string Atualizar = $@"
        UPDATE filme SET
	        nomeFilme = @Title,
            anoLancamento = @anoLancamento
        WHERE idFilme = @Id";
    }
}
