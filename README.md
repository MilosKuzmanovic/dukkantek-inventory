# Dukkantek inventory

This project represents an inventory.

There are 3 APIs which serve end-user:
  1. Get count of products grouped by product status (Sold, InStock, Damaged)
  2. Change product status
  3. Sell product

API documentation could be found at url: {baseUrl}/swagger

Also, there is a postman collection in the repository root which can be also used for a quick test of project API.

The project is runned by .NET Core 6, EntityFramework 6, and SqlServer. It has database migrations for the database as well as data seeds, so everyone can start with some dummy data in its database. It is a well organized and done by using the best practices.

# Please follow these steps in order to run the project API: 
  1. Navigate to the root folder of the project and open the terminal
  2. Navigate to .\Dukkantek.Inventory.Infrastructure\
  3. run 'dotnet ef database update -s ..\Dukkantek.Inventory.API\Dukkantek.Inventory.API.csproj'
  4. Navigate to .\Dukkantek.Inventory.API\
  5. run 'dotnet run'

Base url by default is: http://localhost:4000

Open the postman or swagger and test its API.

# Enjoy :)
