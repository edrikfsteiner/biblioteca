# Arquitetura de Software - Microsserviços 

### Equipe:
- Edrik Fontana Steiner 
- Rafael Ronsoni Gaidzinski
- Mateus Araldi

<br>
  
## Sistema para Bibliotecas

### Objetivos do sistema:
- Um software para em que será possível cadastrar livros, aluguéis de livros e
  automaticamente será realizado o cadastro das transações de aluguel de livros
  em uma sistema de auditoria. O sistema tem o objetivo de proporcionar um melhor
  controle do estoque e das retiradas e devoluções dos livros.

<br>

### Usuários do sistema:
- Atendente da Biblioteca
- Gerente da Biblioteca

<br>

### Requisitos Funcionais do sistema:

- O sistema deve permitir o cadastro de novos livros na biblioteca com os seguintes dados:
  título, autor, ISBN, número de cópias disponíveis e status do livro.
- O sistema deve permitir a consulta dos livros cadastrados na biblioteca.
- O sistema deve permitir consultar e atualizar a disponibilidade de aluguel dos livros cadastrados na biblioteca.
- O sistema deve permitir o cadastro de aluguel de livro com os seguintes dados:
  nome do usuário, livro emprestado
- O sistema deve permitir consultar os aluguéis de livros realizados.
- O sistema deve permitir ao usuário verificar todos os registros dos aluguéis já realizados utilizando o sistema.

<br>

### Integrações entre os Microsserviços:

- A primeira busca de dados será do serviço de Aluguel que irá verificar a disponibilidade do livro ao consultar o microsserviço de Livros


![Captura de tela 2024-12-06 231139](https://github.com/user-attachments/assets/eb757a38-32f3-45d0-846a-37443f766e5d)

- A primeira transação de dados será no microsserviço de Aluguel que após verificar a disponibilidade de aluguel do livro, irá decrementar a
  quantidade de livros disponíveis para aluguel no microsserviço de Livros.

- A segunda transação de alteração de dados será no microsserviço de Aluguel, onde após o aluguel ser realizado será inserido um registro desse aluguel
  no microsserviço de Auditoria.

![Captura de tela 2024-12-06 231439](https://github.com/user-attachments/assets/f3b82360-acda-4a8b-b2a0-d12bf0ede0b2)


### Ferramentas utilizadas no Projeto
- Visual Studio: IDE utilizada para realizar o desenvolvimento do projeto.
- Github: para desenvolver o projeto simultaneamente com os demais integrantes da equipe, realizar o versionamento e armazenar os códigos do projeto.
  
<br>

### Tecnologias utilizadas no Desenvolvimento do Projeto

#### Backend:
- C# e .NET - Utilizados para o desenvolvimento de cada um dos microsserviços

#### Banco de Dados:
- SQLite - Banco de dados relacional incorporado diretamente na aplicação para armazenamento dos dados 

<br>

## Endpoints da API do Microsserviço de Livros
<br>

![Captura de tela 2024-12-06 230913](https://github.com/user-attachments/assets/77336605-8425-4230-b412-daf248b49a85)

<br>

## Endpoints da API do Microsserviço de Aluguel

<br>

![Captura de tela 2024-12-06 230935](https://github.com/user-attachments/assets/11f7c5a0-6150-44ce-beaf-61751a4c4983)

<br>

## Endpoints da API do Microsserviço de Auditoria

<br>

![Captura de tela 2024-12-06 230956](https://github.com/user-attachments/assets/5d150b34-d915-4730-8bde-01cdad4ce185)

<br>
