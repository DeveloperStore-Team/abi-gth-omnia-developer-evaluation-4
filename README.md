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
## 📡 Configuração de Redes e Portas

Os serviços utilizam a rede `ambev_network`, que deve ser criada antes de rodar os `docker-compose`. Abaixo estão as portas principais de cada serviço:

- **Backend (.NET)**
  - API de vendas
  - Porta: `8080 (HTTP)`, `8081 (HTTPS)`

- **Frontend (React)**
  - Interface de monitoramento em tempo real
  - Porta: `3000`

- **RabbitMQ**
  - Serviço de mensageria
  - Porta: `5672 (AMQP)`, `15672 (Management UI)`

- **PostgreSQL**
  - Banco de dados para persistência das vendas
  - Porta: `5432`

## 📌 Configurando o Docker Compose**
O projeto inclui um **docker-compose.yml** para facilitar a configuração dos serviços.  
Para subir toda a infraestrutura (API, Banco de Dados e RabbitMQ), execute:

```sh
docker-compose up -d
```
### Conectar os containers manualmente à rede
Pode ser necessária a configuração manual de um docker network para permitir que os conteiner se comuuniquem. Se os containers já foram iniciados, mas não estão na rede, você pode conectá-los manualmente:
```sh
docker network connect ambev_network ambev_developer_evaluation_webapi
docker network connect ambev_network ambev_developer_evaluation_database
docker network connect ambev_network rabbitmq
```
Verifique o network novamente e corfime a presença dos conteineres:
```sh
docker network inspect ambev_network
```

## Teste com Swagger

- Após iniciar os conteineres, acesse http://localhost:8081/swagger para acessar a API. 
- Teste um cadastro com o endpoint POST [/api/Sales]. Pode usar o exemplo abaixo:
```Javascript
    {
      "consumer": "Diogo Camilo Santos",
      "agency": "Teste Agência",
      "items": [
        {
          "product": "PS5",
          "quantity": 7,
          "price": 500
        }
      ]
    }
```
   Ao finalizar o cadastro, deve aparecer um retorno igual a esse:
```Javascript 
{
  "data": {
    "saleNumber": "4015563",
    "consumer": "Diogo Camilo Santos",
    "totalValue": 3150,
    "discounts": 350
  },
  "success": true,
  "message": "Venda criada com sucesso",
  "errors": []
}
```

O número da Venda (saleNumber) pode ser utilizado para testar os requests seguintes.

Certifique-se de que essas portas não estejam ocupadas antes de iniciar a aplicação. 🚀
