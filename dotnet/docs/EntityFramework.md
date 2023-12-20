## Basic commands

```bash
dotnet ef migrations add InitialCreate --context ApplicationDbContext --startup-project Web --project Infrastructure --output-dir Migrations 


dotnet ef database update --context ApplicationDbContext --startup-project Web --project Infrastructure
```