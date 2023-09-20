# Database Migrator
As the system and the development team are continue to grow it can be difficult to keep track and audited manual database scripts, views, and stored procedures.

So why don’t we keep all database scripts in source control like pieces of software code?

## Set up

Create your SQL script file inside the Scripts folder.

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