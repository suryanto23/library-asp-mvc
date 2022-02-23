# Library MVC

Library project made with ASP with MVC scaffolding mechanism.

## Features
- Book CRUD (Create, Read, Update, Delete)
- Stock calculation
- Book renting
- Transaction list 

## Tech
- [Visual Studio Community](https://visualstudio.microsoft.com/)
- [ASP MVC](https://dotnet.microsoft.com/en-us/apps/aspnet/mvc)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Microsoft SQL Server Management Studio (SSMS)](https://docs.microsoft.com/en-us/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
- [Bootstrap](https://getbootstrap.com/)

## How To Run
I recommend for using [Visual Studio Community](https://visualstudio.microsoft.com/) as the text editor.

Open appsettings.json file, change "ConnectionStrings" value to your corresponding database configuration:
- Data Source=YOUR_SERVER_NAME
- Initial Catalog=YOUR_DATABASE_NAME
- User Id=(OUR_DBMS_USERNAME
- Pwd=YOUR_DBMS_PASSWORD

Afterward, run these commands in Package Manager Console (in case if you can't find the console, it located in Tools -> NuGet Package Manager -> Package Manager Console).

Adding migration to your DBMS (SQL):

```sh
 update-database
```

Finally, start running the project by clicking the run button on your text editor toolbar (or pressing Ctrl+F5).
