/*
Com base no modelo acima, construa um comando SQL que liste a maior data de andamento 
por número de processo, com processos encerrados no ano de 2013. 
 */


SELECT B.dtAndamento, a.nroProcesso
FROM tb_Processo a
  INNER JOIN tb_Andamento b ON B.idProcesso = A.idProcesso
WHERE YEAR(DtEncerramento) = 2013
ORDER BY B.dtAndamento ASC