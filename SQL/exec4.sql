/*

Com base no modelo acima, construa um comando SQL que liste a quantidade de Data de 
Encerramento agrupada por ela mesma com a quantidade da contagem seja maior que 5. 
 */



SELECT *
FROM ( SELECT count(1) QtdEncerramento, a.DtEncerramento
  FROM tb_Processo a
  GROUP BY DtEncerramento		) A
WHERE A.QtdEncerramento > 5

