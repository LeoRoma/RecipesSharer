# RecipesSharerApi

## Description
- Recipes Sharer is an API that allows to a user to register/login, gives the possibilities to perform CRUD functionalities of Recipes, Image, Ingredient, Equipments and Steps.

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
#### /Users

Returns a list of users.

```curl "https://localhost:44330/Users"```

On success, the above command returns JSON structured like this:

```
[
    {
        "userId": 1,
        "username": "Leo",
        "email": "leo@gmail.com",
        "password": "vxFh7ubhh0Q=",
        "userRole": "admin",
        "recipes": []
    }
] 
```
#### /Users/{id}/recipes

Returns a list of a user's recipes

```curl "https://localhost:44330/Users/{id}/recipes"``` 

On success, the above command returns JSON structured like this:

```
[
    {
        "recipeId": 49,
        "recipeName": "lasagna",
        "description": "Best authentic Italian recipe, easy to prepare and you will impress your friends. Very good",
        "difficulty": "easy",
        "preparationTime": "10 mins",
        "cookingTime": "40 mins",
        "additionalTime": "30 mins",
        "servings": 4,
        "postDate": "2021-01-13T15:01:37.2451823",
        "userId": 1,
        "user": {
            "userId": 1,
            "username": "Leo",
            "email": "leo@gmail.com",
            "password": "vxFh7ubhh0Q=",
            "userRole": "admin",
            "recipes": []
        },
        "ingredients": [],
        "steps": [],
        "equipments": [],
        "image": {
            "id": "5e8d7b2e-866a-4ee5-7baa-08d8b7caeb89",
            "suffix": ".jpg",
            "recipeId": 49
        }
    }
]
```

#### /Recipes

Returns a list of recipes.

```curl "https://localhost:44330/Recipes"```

On success, the above command returns JSON structured like this:

```
[
    {
        "recipeId": 49,
        "recipeName": "lasagna",
        "description": "Best authentic Italian recipe, easy to prepare and you will impress your friends. Very good",
        "difficulty": "easy",
        "preparationTime": "10 mins",
        "cookingTime": "40 mins",
        "additionalTime": "30 mins",
        "servings": 4,
        "postDate": "2021-01-13T15:01:37.2451823",
        "userId": 1,
        "user": {
            "userId": 1,
            "username": "Leo",
            "email": "leo@gmail.com",
            "password": "vxFh7ubhh0Q=",
            "userRole": "admin",
            "recipes": []
        },
        "ingredients": [],
        "steps": [],
        "equipments": [],
        "image": {
            "id": "5e8d7b2e-866a-4ee5-7baa-08d8b7caeb89",
            "suffix": ".jpg",
            "recipeId": 49
        }
    },
]

```
#### /Recipes/{id}

Returns one particular recipe 

```curl "https://localhost:44330/Recipes/{id}"```

On success, the above command returns JSON structured like this:

```
{
    "recipeId": 49,
    "recipeName": "lasagna",
    "description": "Best authentic Italian recipe, easy to prepare and you will impress your friends. Very good",
    "difficulty": "easy",
    "preparationTime": "10 mins",
    "cookingTime": "40 mins",
    "additionalTime": "30 mins",
    "servings": 4,
    "postDate": "2021-01-13T15:01:37.2451823",
    "userId": 1,
    "user": {
        "userId": 1,
        "username": "Leo",
        "email": "leo@gmail.com",
        "password": "vxFh7ubhh0Q=",
        "userRole": "admin",
        "recipes": []
    },
    "ingredients": [
        {
            "ingredientId": 92,
            "ingredientName": "Meat mince",
            "amount": "500 gr",
            "recipeId": 49
        },
        {
            "ingredientId": 93,
            "ingredientName": "Tomato sauce",
            "amount": "500 gr",
            "recipeId": 49
        },
        {
            "ingredientId": 94,
            "ingredientName": "Carrot",
            "amount": "1 pc",
            "recipeId": 49
        },
        {
            "ingredientId": 95,
            "ingredientName": "Flour",
            "amount": "65 gr",
            "recipeId": 49
        },
        {
            "ingredientId": 96,
            "ingredientName": "Milk",
            "amount": "1 l",
            "recipeId": 49
        }
    ],
    "steps": [
        {
            "stepId": 40,
            "stepNumber": 1,
            "instruction": "Cook lasagna, put in the oven for 40 minutes at 180 degrees. After 40 minutes switch off the oven and let it rest for 30 minutes.\nBuon Appetito!",
            "recipeId": 49
        }
    ],
    "equipments": [
        {
            "equipmentId": 51,
            "equipmentName": "Change",
            "recipeId": 49
        },
        {
            "equipmentId": 52,
            "equipmentName": "Pot",
            "recipeId": 49
        },
        {
            "equipmentId": 54,
            "equipmentName": "Update",
            "recipeId": 49
        },
        {
            "equipmentId": 55,
            "equipmentName": "Oven",
            "recipeId": 49
        },
        {
            "equipmentId": 56,
            "equipmentName": "Laddle",
            "recipeId": 49
        }
    ],
    "image": {
        "id": "5e8d7b2e-866a-4ee5-7baa-08d8b7caeb89",
        "suffix": ".jpg",
        "recipeId": 49
    }
}
```

### POST
#### /Users
#### /Recipes
#### /Image
#### /Equipments
#### /Ingredients
#### /Steps
### PUT
#### /Recipes
#### /Equipments
#### /Ingredients
#### /Steps
### DELETE
#### /Recipes
#### /Image
#### /Equipments
#### /Ingredients
#### /Steps