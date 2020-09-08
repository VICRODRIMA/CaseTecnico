using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Infra.Data.Repositories.Statements
{
    internal static class clienteStatement
    {
        public static string Atualizar = $@"
        UPDATE cliente SET
	        nomeCliente = @nomeCliente
        WHERE idCliente = @Id";

        public static string Inserir = $@"
        INSERT INTO clientes (nomeCliente)  VALUES  (
                    @nomeCliente
                            )";
    }
}
