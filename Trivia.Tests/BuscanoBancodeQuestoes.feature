Feature: Buscano Bancode Questoes
	Simple calculator for adding two numbers

@cn01
Scenario: Busca por questão inexistente
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca
	| busca | 
	| Science: Computers | 	
	When clico no botão de buscar 
	Then visualizo uma mensagem de erro com o texto 'No questions found.'

@cn02
Scenario: Realizar Contagem de Listagem
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca e tipo de busca
	| busca              | tipobusca |
	| Science: Computers | Category |
	When clico no botão de buscar 
	Then contagem com sucesso

@cn03
Scenario: Realizar Busca válida por Questão
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca
	| busca | 
	| What language does Node.js use? | 
	When clico no botão de buscar 
	Then busca completa exibida com sucesso 


@cn04
Scenario: Realizar Busca inválida por Questão
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca
	| busca | 
	| What language does Node.js use??? |
	When clico no botão de buscar 
	Then busca não exibida question


@cn05
Scenario: Realizar Busca válida por Categoria
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca e tipo de busca
	| busca              | tipobusca |
	| Science: Computers | Category |
	When clico no botão de buscar 
	Then busca exibida com sucesso


@cn06
Scenario: Realizar Busca inválida por Categoria
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca e tipo de busca
	| busca              | tipobusca |
	| Science: Computerss | Category |
	When clico no botão de buscar 
	Then busca não exibida category


@cn07
Scenario: Realizar Busca válida por User
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca e tipo de busca
	| busca | tipobusca |
	| Karen | User |
	When clico no botão de buscar 
	Then busca exibida com sucesso


@cn08
Scenario: Realizar Busca inválida por User
	Given que navego para a página de busca do banco de questões
	And digito no campo de busca e tipo de busca
	| busca | tipobusca |
	| Karenn | User |
	When clico no botão de buscar 
	Then busca não exibida user
	



