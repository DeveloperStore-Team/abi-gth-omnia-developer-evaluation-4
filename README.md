# Desafio Ambev - API de Gestão de Vendas

Um teste de desenvolvimento para avaliação em processo seletivo. Obeservar habilidades com desenvolvimento de software, organização de código, boas práticas e solução de problemas técnicos.

> API desenvolvida como parte do processo seletivo, aplicando **DDD**, **CQRS**, **FluentValidation**, **AutoMapper**, **Entity Framework Core** e **mensageria**.

## **📌 Visão Geral**
Esta API foi desenvolvida para **gerenciar registros de vendas**, incluindo informações sobre clientes, produtos e agências. Além do CRUD tradicional, implementamos regras de negócio para cálculo de descontos e eventos de mensageria para acompanhar o ciclo de vida das vendas.

## **🛠️ Tecnologias Utilizadas**
- **.NET 8** - Framework principal
- **Entity Framework Core** - ORM para persistência de dados
- **PostgreSQL** - Banco de dados relacional
- **MediatR** - Implementação do padrão CQRS
- **FluentValidation** - Validações de entrada
- **AutoMapper** - Mapeamento entre DTOs e Entidades
- **Docker** - Conteinerização para ambiente de desenvolvimento
- **RabbitMQ** (Mensageria) - Publicação de eventos de vendas (diferencial)
- **XUnit e Moq** - Testes unitários

---

## **📖 Regras de Negócio**
A API aplica as seguintes regras de **desconto automático** nas vendas:
1. **4 a 9 itens iguais** → **10% de desconto**
2. **10 a 20 itens iguais** → **20% de desconto**
3. **Acima de 20 itens** → 🚫 **Venda não permitida**
4. **Cancelamento de venda** disponível via **soft delete**

---

## **📦 Estrutura do Projeto**
```plaintext
📂 src
 ├── 📁 Ambev.DeveloperEvaluation.WebApi       # Camada de exposição da API
 ├── 📁 Ambev.DeveloperEvaluation.Application  # Casos de uso (CQRS, Handlers)
 ├── 📁 Ambev.DeveloperEvaluation.Domain       # Entidades e Regras de Negócio (DDD)
 ├── 📁 Ambev.DeveloperEvaluation.Infrastructure # Persistência e Repositórios
 ├── 📁 Ambev.DeveloperEvaluation.ORM          # Configuração do EF Core
 ├── 📁 Tests                                  # Testes unitários e de integração
 ├── docker-compose.yml   

```

## **📺 Teste com o Monitor**
[Link do Repositório do Monitor](https://github.com/DeveloperStore-Team/developer-store-monitor)

A proposta deste segundo projeto é acompanhar em tempo real as ocorrências relacionados a Venda; a fim de testar os recursos de messaging e eventos.
