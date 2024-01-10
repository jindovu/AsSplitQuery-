# AsSplitQuery-
AsSplitQuery not working with sort string.Join

1. Change connection in LocalDbContext to your database
     optionsBuilder.UseSqlServer("Server=VNLAP01\\HNOIT;Database=Demo_Test;user id=demo;password=4W&[SRz75uhY';MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False", b => b.MigrationsAssembly("Demo"));
2. Change connection in appsettings.json your database
    "SQLConnection": "Server=VNLAP01\\HNOIT;Database=Demo_Test;user id=demo;password=4W&[SRz75uhY;MultipleActiveResultSets=True;TrustServerCertificate=True;Encrypt=False"
   
=> run migration

 a. dotnet ef migrations add new

 b. dotnet ef database update

3. Run project
        
