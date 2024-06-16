to install package
- .Net > nuget.org
- React > npm
- Flutter > pub.dev
---------------------------------
Packages
- to connect C# and database
  System.Data.SqlClient
- for using Dapper
  Dapper
- for using EFCore(Entity Framework)
  Microsoft.EntityFrameworkCore
  Microsoft.EntityFrameworkCore.SqlServer
- Convert JSon to C# vice versa
  Newtonsoft.Json
- for using RestClient
  Restsharp
- in vs code to run html
  live server
_________________________________
ORM - object relational mapping(works between tables in database and languages that converts C# code to SQL query)
Types of ORM
- Dapper
- EFCore
_________________________________
Dapper
- DTO > Data Transfer Object
_________________________________
EFCore
- Code First 
- Database First > ရှိပြီးသား database ကိုပြန်ယူသုံး

efcore commandline database first 
- https://www.entityframeworktutorial.net/efcore/create-model-for-existing-database-in-ef-core.aspx
- install entity frameworkcore.tools
- set as startup project
- Tools>package manager console(Run Command)
  Scaffold-DbContext "Server=RV-IT-LP-202;Database=DotNetTrainingBatch4;User Id=sa;Password=sa@12345;TrustServerCertificate = true;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context DotNetTrainingBatch4AppDbContext

  ___________________________________________________________________________________________________

  https port num - 443
  http port num - 80
  mssql port num - 1433