dotnet ef migrations add Initialize_$(Get-Date -Format "ddMMyyyHHmmss") --project src/HackTest.Infrastructure --startup-project src/HackTest.API --output-dir Persistence/Migrations