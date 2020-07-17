# Dotvvm

A simple web application using some of the latest technologies to login, register, activate accounts using email confirmation links and role based authorization.

The project is a good demonstration of the MVVM design pattern as each layer is abstracted and encapsulated by mapping to and from service and view models.


Some of the latest technologies include; .NET Core, .NET Identity, EF Core & Migrations and DOTVVM.

# Get Started
After cloning the project, ensure your connection string is correct in `appsettings.json` then run:

`Update-Database` in the package manager console or `dotnet ef database update` in .NET Core CLI

Now your ready you can use the following credentials to login as an admin user:
```
Username: admin
Password: Admin12345!
```
