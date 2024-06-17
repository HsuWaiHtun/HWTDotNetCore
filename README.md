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

____________________________________________________________________________________________________
  
jQuery Plugins

- SweetAlert
 https://sweetalert2.github.io/
- Notiflix (Notify, Report, Confirm, Loading, Block)
 https://www.jsdelivr.com/package/npm/notiflix
 https://notiflix.github.io/
- DataTable
 https://datatables.net/examples/index
 https://datatables.net/download/
- Date Picker
 https://github.com/fengyuanchen/datepicker/blob/master/README.md
 https://github.com/fengyuanchen/datepicker/releases/tag/v1.0.10
- Ladda Button
 https://cdnjs.com/libraries/ladda-bootstrap
 https://github.com/msurguy/ladda-bootstrap
- iCheckbox (Radio, CheckBox)
https://cdnjs.com/libraries/icheck-bootstrap
https://github.com/bantikyan/icheck-bootstrap
https://penguin-arts.com/how-to-check-if-a-checkbox-is-checked-using-icheck-library/
- Toast
https://github.com/apvarun/toastify-js/blob/master/README.md