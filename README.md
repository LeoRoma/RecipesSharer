# RecipesSharerApi

## Tech Stack
- Asp.Net web API
- Database SQL

## Additional Packages
- Microsoft.AspNetCore.Authentication.JwtBearer Version = 3.1.8
- Microsoft.AspNetCore.Mvc.NewtonsoftJson Version = 3.1.8
- Microsoft.EntityFrameworkCore Version = 5.0.1 
- Microsoft.EntityFrameworkCore.Sqlite Version = 5.0.1 
- Microsoft.EntityFrameworkCore.SqlServer Version = 5.0.1  
- Microsoft.EntityFrameworkCore.Tools Version = 5.0.1
- Microsoft.VisualStudio.Web.CodeGeneration.Design Version = 3.1.4 
- Newtonsoft.Json Version = 12.0.3 
- Swashbuckle.AspNetCore Version = 5.6.3
- Swagger

## Approach
I have started first to create the Models: Users, Recipes, Ingredients, Equipments, Steps and Image. <br />
From the Models I have used Entity Framework by using a connection string in Startup.js file to create my database and the relative tables. <br />
The relationship between the tables are: from Users to Recipes one to many, from Recipes to Ingredients, Equipments and Steps one to many, and finally Recipes with Image one to one. <br />
Once I had my database connected with the Models, I have created different Controllers for each Models. In each Controller there are CRUD functionality which for the API
are GET, POST, PUT and DELETE. <br />
I have also created a Login Controller where does the User Authentication, once the User has been authenticated generates a Token that I have set up with JWT Bearer. The Token generated is going to be used to access to the different functionality of the API, such as POST, PUT and DELETE Recipes, Ingredients, Steps, Equipments and Images.

## API Docs
### GET
#### Users
#### Recipes

### POST
#### Users
#### Recipes
#### Image
#### Equipments
#### Ingredients
#### Steps
### PUT
#### Recipes
#### Equipments
#### Ingredients
#### Steps
### DELETE
