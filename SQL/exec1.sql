/*
  Com base no modelo acima, escreva um comando SQL que liste a quantidade de registros por
 Status com sua descrição. 
 */


SELECT COUNT(1) AS ContadorDeRegistros, b.dsStatus AS Descricao
FROM tb_Processo a
    INNER JOIN tb_Status b on a.idStatus = b.idStatus
GROUP BY b.dsStatus
ORDER BY ContadorDeRegistros DESC