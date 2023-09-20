# .NET Core Database Migrations
Welcome to the .NET Core Database Migrations project! This repository provides a set of tools and templates to help you manage database migrations effectively in your .NET Core applications. Whether you're starting a new project or adding database migration capabilities to an existing one, this project will make the process smoother and more manageable.

## Introduction

Managing database schema changes over time is a crucial part of developing robust and scalable applications. This project leverages the power of Entity Framework Core and .NET Core to simplify the process of creating, applying, and versioning database migrations.

## Features

- **Simplified Migration Creation**: Easily create new database migration scripts with a few simple commands.
- **Version Control**: Keep track of your database schema changes using versioned migration scripts.
- **Apply Migrations**: Apply migrations to your database to update the schema to the latest version.

## Getting Started

### Clone the Repository:

```shell
git clone https://github.com/tkaeophian/db-migrator-sample.git
cd db-migrator-sample
```

### Install .NET Core SDK:
If you haven't already, install the [.NET Core SDK](https://dotnet.microsoft.com/en-us/download) for your platform.

### Build and Run the Project:

```shell
dotnet build
```
### Create Your First Migration:
To create your initial migration script simply add your SQL script file inside the Scripts folder. 
Recommended file format (but not mandatory):

```shell
{date}-{time}-{action}-{ table or SP or View }-{changes}.sql
```

for example:

```shell
2023-01-04-16-27-add-isActive-to-customers-table.sql
```

Enter your sql script as you would normally do, for example:

```shell
use test 
GO

ALTER TABLE Customers ADD IsActive bit;
```

PS - The solution tracks which SQL scripts have been run already, and runs the change scripts that are needed to get your database up to date. The migration data are stored in dbo.SchemaVersions

## Contributing
We welcome contributions from the community! 

## License

This project is licensed under the MIT License. Feel free to fork, modify, and use it in your projects.

Happy coding! 🚀