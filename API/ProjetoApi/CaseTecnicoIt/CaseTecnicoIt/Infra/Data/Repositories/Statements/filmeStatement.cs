﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CaseTecnicoIt.Infra.Data.Repositories.Statements
{
    internal static class filmeStatement
    {
        public static string Atualizar = $@"
        UPDATE filmes SET
	        nomeFilme = @nomeFilme,
            anolancamento = @anoLancamento
        WHERE idFilme = @idFilme";

        public static string Inserir = $@"
        INSERT INTO filmes (nomeFilme, AnoLancamento)  VALUES  (
                    @nomeCliente, @anoLancamento
                            )";
    }
}
