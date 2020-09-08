using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Infra.Data.Repositories.Statements
{
    public class locacaoStatement
    {
        public static string Atualizar = $@"
        UPDATE locacao SET
	        nomeCliente = @nomeCliente
        WHERE idCliente = @idCliente";

        public static string Inserir = $@"
        INSERT INTO locacao (nomeCliente)  VALUES  (
                    @nomeCliente
                            )";
    }
}
