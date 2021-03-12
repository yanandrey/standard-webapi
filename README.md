# standard-webapi

Just an example of Web Api, aiming at the development of good practices and better learning the language technologies.

#### Main Nuget Packages:
- AutoMapper
- AutoMapper.Extensions.Microsoft.DependencyInjection
- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.Tools
- FluentValidation.AspNetCore

>Before starting the application, you must execute a Entity Framework migration using the following commands:
> - **dotnet ef migrations add {name}** to create a migration.
> - **dotnet ef migrations script** to see the SQL script.
> - **dotnet ef migrations remove** if you want to remove the migration.
> 
>With a configured database connection:
> - **dotnet ef database update** to update the database.


#### References:
- https://docs.automapper.org/en/stable/index.html
- https://docs.microsoft.com/en-us/ef/
- https://docs.fluentvalidation.net/en/latest/