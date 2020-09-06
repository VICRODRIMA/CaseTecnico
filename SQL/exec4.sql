/*
Possuímos um número de identificação do processo, onde o mesmo contem 12 caracteres 
com zero à esquerda, contudo nosso modelo e dados ele é apresentado como bigint. Como 
fazer para apresenta-lo com 12 caracteres considerando os zeros a esquerda? 
  */


SELECT REPLICATE('0', 12 - LEN(nroProcesso)) + CONVERT(VARCHAR(12), nroProcesso)
FROM tb_Processo