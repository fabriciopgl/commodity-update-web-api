# CommoditiesUpdate.WebApi

**A simple C# ASP.NET API to update the daily currency for a specific commodity list.**

**Main features include:**

- [ ] One controller with three routes:
    - [ ] One for update the daily value of the commodities;
    - [ ] One for retrieving all currency values of commodities;
    - [ ] One for retrieving the currency value of a specific commodity and date;
- [ ] Entity Framework Core, used for creating the DbContext and all operations with databases (uncoupled, so you can use any Database);
- [ ] Dependency injection for repositories, HTTP client, external services and others;
- [ ] JSON serialize and deserialize using JsonSerializerOptions services;
- [ ] Using interfaces to separate concrete and abstract implementations;
- [ ] Using EF migrations to create and update the database;
- [ ] Using Csharp Functional Extensios to return the results of tasks and use notifications for objects to communicate with each other;
- [ ] Using Domain Driven Design techniques;
- [ ] Using LINQ expressions;
- [ ] Using asynchronous programing tecnhiques.

**How it works?**

- [ ] The idea behind this API is for it to be executed to automate the task of fetching commodity data and saving the values in your database, ensuring you have an updated database with the necessary values automatically. Additionally, you can make requests to the existing endpoints to retrieve data if needed;

- [ ] The standard "localhost" for this API is configured to "http://localhost:5100" or "http://localhost:7100";

- [ ] We need to split this simple API into three parts an explain what its routes do:
    - [ ] **GET (all data)** - http://your-localhost:your-port/api/commodities/ -> Return all commodities written in the database, of any date, any currency and any commodity;

    - [ ] **GET (specific data)** - http://your-localhost:your-port/api/commodities/commodityCode/dateToSearch -> When sending these two parameters to the above endpoint, you will receive a payload containing all the data of the respective commodity if it exists in your database. If it doesn't exist, you will receive a NotFound message; 

- [ ] **POST (insert/update commodities data )** 
    - [ ] Endpoint -> http://your-localhost:your-port/api/commodities/update/commodityCode (without body), you don't need to 
send the body beacause the data will come from another external API
    - [ ] For this API, you can send one of these codes :
        **1** - Commodity aluminum;
        **2** - Commodity copper;
        **3** - Commodity Zinc;
        **4** - Commodity Nickel;
        **5** - Commodity lead;
        **6** - Commodity dollar;
        **7** - Commodity Tin.
    - [ ] If you send any another commodityCode, you will receive a message warning that the commodity in question is not supported by the API
    - [ ] Since the data for updating commodities comes from an external API, it's important to note that not all dates are available for updating. The data returned by this API is always from 1 month and a few days in the past. That's why the API I created will **always fetch data from 'today - 1 day' since the external API updates its data only at the end of the day.** If you try to retrieve data for 'today' by modifying the period in the API, you will receive a message stating that there is no data to return. If you need to change the number of days in the past to fetch the data, simply modify the 'SearchDataRange' variable in the 'CommodityFactory' class.

**How to configure first use and create tables:**

- [ ] If you don´t have dotnet-ef tools installed on your environment, first of all open your IDE terminal and type "dotnet tool install --global dotnet-ef";
- [ ] After install dotnet-ef tools, you need to go to "CommoditiesUpdate.WebApi" path, using the command "cd CommoditiesUpdate.WebApi";
- [ ] Then, you need to run the "dotnet-ef database update" to apply the migrations to your database. This will create all tables you need to run the API;
