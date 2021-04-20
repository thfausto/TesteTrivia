Feature: Trivia
	Simple calculator for adding two numbers

@mytag
Scenario: Realizar Busca por Questão
	Given acesso o site da Trivia
	And clica em browse
	When realiza busca 
	Then busca exibida com sucesso



Scenario: Realizar Busca por ID valido
	Given acesso o site da Trivia Teste
	And clica em browse de busca
	When realiza busca valida
	Then busca exibida realizada