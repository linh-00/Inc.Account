# Account 🏆

## 📌 Sobre o Projeto
**Account** é um aplicativo desenvolvido em **C#** com **SQL Server** para a criação e gerenciamento de contas de usuário. Ele permite armazenar informações do perfil, incluindo foto, e possibilita a reutilização da conta em diferentes aplicativos que exigem autenticação.

## 🔹 Principais Recursos
- ✅ Criação de contas com dados personalizados
- ✅ Upload e armazenamento de foto de perfil
- ✅ Banco de dados seguro e estruturado em **SQL Server**
- ✅ API para integração com múltiplos aplicativos
- ✅ Gerenciamento de usuários de forma eficiente

## 🏗 **Arquitetura**  
Este projeto segue o padrão de **Arquitetura Onion (Cebola)** para garantir melhor organização, desacoplamento e manutenção do código. Ele é estruturado em módulos:

- **API** - Responsável pela exposição dos endpoints
- **Application** - Contém regras de negócio e serviços
- **DAL (Data Access Layer)** - Gerenciamento do acesso ao banco de dados
- **Domain** - Definição das entidades e regras de domínio
- **IoC (Inversion of Control)** - Gerenciamento de injeção de dependência
- **Shared** - Componentes compartilhados entre camadas

## 💡 **Boas Práticas e Melhorias de Desempenho**  
- **Uso de `Guid` para IDs** - Evita colisões e melhora a escalabilidade
- **Uso de `Record` para DTOs** - Fornece imutabilidade e melhor performance
- **Injeção de dependência via IoC** - Facilita a manutenção e testes
- **Padrão Repository** - Organiza melhor o acesso aos dados

## 💻 Tecnologias Utilizadas
- **C# (.NET)** – Backend robusto e seguro
- **SQL Server** – Armazenamento eficiente e confiável
- **Entity Framework** – ORM para facilitar operações com o banco de dados
- **ASP.NET API** – Para integração com outros aplicativos

## 🚀 Como Usar?
### 1️⃣ Clonar o Repositório
```bash
git clone https://github.com/linh-00/Inc.Account.git
```

### 2️⃣ Configurar o Banco de Dados
1. Criar um banco de dados no **SQL Server**.
2. Configurar a string de conexão no arquivo `appsettings.json`.

### 3️⃣ Executar o Projeto
```bash
dotnet run
```

O servidor estará rodando e pronto para receber requisições!

## 🤝 Contribuição
Contribuições são bem-vindas! Para contribuir:
1. Faça um **fork** do repositório.
2. Crie um **branch** para sua feature/fix: `git checkout -b minha-feature`
3. Faça as alterações e commit: `git commit -m "feat: minha nova funcionalidade"`
4. Envie um **pull request**.

## 📧 Contato
alinnelauren@hotmail.com
Se tiver dúvidas ou sugestões, entre em contato! 🚀

