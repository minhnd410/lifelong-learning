## Entity Framework

```bash
# Create migration
dotnet ef migrations add InitialCreate --context ApplicationDbContext --startup-project Web --project Persistence --output-dir Migrations/ApplicationDb
dotnet ef migrations add InitialCreate --context IdentityDbContext --startup-project Web --project Persistence --output-dir Migrations/IdentityDb

# Remove specific migrations
dotnet ef migrations remove --context ApplicationDbContext --startup-project Web --project Persistence

# drop db
dotnet ef database drop --context IdentityDbContext --startup-project Web --project Persistence

# Remove initial migrations
dotnet ef migrations remove

# Update migration
dotnet ef database update --context ApplicationDbContext --startup-project Web --project Persistence
dotnet ef database update --context IdentityDbContext --startup-project Web --project Persistence
```