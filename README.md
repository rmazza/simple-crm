Shout out to [Jayson Taylor's Clean Architecture](https://github.com/jasontaylordev/CleanArchitecture) for project structure and helpful ideas to implement.

# Simple CRM

## Entity Framework Core Commands

`dotnet ef migrations add "InitalCreate" --project .\Simcrm.Infrastructure --startup-project .\Simcrm.Api --output-dir Persistence\Migrations`

`dotnet ef migrations remove --project .\Simcrm.Infrastructure --startup-project .\Simcrm.Api`

`dotnet ef database update --project .\Simcrm.Infrastructure --startup-project .\Simcrm.Api`
