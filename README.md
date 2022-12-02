# IATuber-Api
Api para iniciar processo de novo vídeo e consultar o andamento dos processamentos

Requisitos:
- .NET 6
- Docker
- MySql Workbench

Para iniciar:
- Execute "docker-compose up -d" na raiz do projeto, para iniciar os containers do MySQL e do RabbitMQ
- Conecte o MySql Workbench aos container do MySql. As informações de conexão local, estão no AppSettings de Develop.
- Execute o script de criação de tabela que se encontra em /StartFiles/CreateTableScript.txt
