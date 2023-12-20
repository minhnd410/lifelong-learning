## Entity Framework

```bash
# Create migration
dotnet ef migrations add InitialCreate --context ApplicationDbContext --startup-project Web --project Infrastructure --output-dir Migrations 

# Update migration
dotnet ef database update --context ApplicationDbContext --startup-project Web --project Infrastructure
```