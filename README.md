# EFTestData

Example project for easy and auto"magic" test data generation using Entity Framework 6.  For full details read my post on https://brosteins.com

## Running the Sample
To test the sample simply do one of the following:
* Build and run 
* Update-Database from your Package Manager Console

## Check the Database
After regenerating the database look for the EFTestData database in your LocalDB and run the following queries to review the test data that was created.

```
USE EFTestData
SELECT * FROM dbo.Orders
SELECT * FROM dbo.Products
SELECT * FROM dbo.Companies
SELECT * FROM dbo.Users
```

## Try It Out!
Go ahead and add another entity and TestDataFactory and test it out for yourself!
