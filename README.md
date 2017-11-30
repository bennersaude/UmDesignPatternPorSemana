## Um Design Pattern por semana

#### Planilha de apresentação


   1. Ler capítulo 7 do livro, pág 97.

   2. Precisamos calcular os valores de Frete de uma Loja Virtual seguindo as seguintes especificações:

   2.1 Fretes via PAC cuja distância seja menor que 100 km custam a quantidade de quilômetros * 0.15, fretes cuja distância seja maior custam a quantidade de quilômetros * 0.25

   2.2 Fretes via Sedex  cuja distância seja menor que 100 km custam a quantidade de quilômetros * 0.40, fretes cuja distância seja maior custam a quantidade de quilômetros * 0.70
   
   2.3 Fretes via Transportadora  cuja distância seja maior que 400 km custam a quantidade de quilômetros * 0.35, fretes cuja distância seja menor custam a quantidade de quilômetros * 0.30

   2.4 Fretes selecionados como Retirada no local não tem custo.

#### Precisamos escrever um algoritmo que receba a quantidade de km, o tipo de frete e retorne o custo. Para exercitar o que aprendemos os exercícios devem ser resolvidos através do TDD, escrevendo os testes primeiro e depois implementando o código que satisfaz estes testes.
