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
#### /Users/{userId}/recipes

Returns a list of a user's recipes

```curl "https://localhost:44330/Users/{userId}/recipes"``` 

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

#### /Users/{userId}/recipes

Return a user's recipe

```curl "https://localhost:44330/Users/{userId}/recipe/{recipeId}"```

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
#### /Recipes/{recipeId}

Returns one particular recipe 

```curl "https://localhost:44330/Recipes/{recipeId}"```

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

Creates a new user.

```
curl "https://localhost:44330/Users"

-X POST \
-H "Content-Type: application/json" \
-D {
        username: username,
        email: email,
        password: password,
        userRole: "user"
    }
```

On success, the above command returns JSON structured like this:

```
    {
        userId: 1, 
        username: "Leo", 
        email: "Leo@gmail.com", 
        password: "vxFh7ubhh0Q=", 
        userRole: "user"
    }
```
#### /Login

Creates a new session, giving you a userId and token required to perform actions on behalf of the user (e.g. posting, updating and deleting recipes, ingredients, equipment, steps, images).

```
curl "https://localhost:44330/Login"
-X POST \
-H "Content-Type: application/json" \
-D {
        email: email,
        password: password,
    }

```
On success, the above command returns JSON structured like this:

```
{
    token: "a valid token"
    userDetails:{
        email: "leo@gmail.com"
        password: "vxFh7ubhh0Q="
        recipes: []
        userId: 1
        userRole: "admin"
        username: "Leo"
    }

}
```

#### /Recipes
Create a new Recipe

This endpoint requires a userId and a given token in the authorization header.

``` 
curl "https://localhost:44330/Recipes/post
-X POST \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D  {
        recipeName: recipeName,
        description: description,
        difficulty: difficulty,
        preparationTime: preparationTime,
        cookingTime: cookingTime,
        additionalTime: additionalTime,
        servings: servings,
        userId: userId
    }
```

On success, the above command returns JSON structured like this:

```
{
    recipeId: recipeId
    recipeName: "recipeName"
    description: "description"
    difficulty: "difficulty"
    preparationTime: "preparationTime"
    cookingTime: "cookingTime"
    additionalTime: "additionalTime"
    postDate: "0000-01-01T00:00:00.0000000+00:00"
    servings: 5
    equipments: []
    image: null
    ingredients: []
    steps: []
    user: null
    userId: 1
}
```

#### /Image
Create a new Image

This endpoint requires a recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Image/post/{recipeId}"
-X POST \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D body: form_data
```

On success, the above command returns JSON structured like this:

```
    {   
        file: "blob:http://localhost:3000/image_id"
        image: File
        lastModified: 1593540411925
        lastModifiedDate: Tue Jun 30 2020 19:06:51 GMT+0100 (British Summer Time) {}
        name: "yourImage.jpg"
        size: 130938
        type: "image/jpeg"
        webkitRelativePath: ""
    }
```

#### /Equipment
Create a new Equipment

This endpoint requires a recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Equipments/post"
-X POST \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D {
      equipmentName: equipmentName,
      recipeId: recipeId
}
```

On success, the above command returns JSON structured like this:

```
{
    equipmentId: equipmentId
    equipmentName: "equipmentName"
    recipe: null
    recipeId: recipeId
}
```

#### /Ingredients
Create a new Ingredient

This endpoint requires a recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Ingredients/post"
-X POST \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D {
        ingredientName: ingredientName,
        amount: amount,
        recipeId: recipeId
    }
```

On success, the above command returns JSON structured like this:

```
{
    ingredientId: ingredientId, 
    ingredientName: "ingredientName", 
    amount: "amount", 
    recipeId: recipeId, 
    recipe: null
}
```

#### /Steps
Create a new Step

This endpoint requires a recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Steps/post"
-X POST \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D {
        stepNumber: stepNumber,
        instruction: instruction,
        recipeId: recipeId
    }
```

On success, the above command returns JSON structured like this:

```
{
    stepId: stepId, 
    stepNumber: "ingredientName", 
    amount: "amount", 
    recipeId: recipeId, 
    recipe: null
}
```

### PUT
#### /Recipes/{recipeId}/user/{userId}
Gives the opportunity to update one or more recipe's field/s

This endpoint requires a recipeId, userId and a given token in the authorization header.

```
curl "https://localhost:44330/Recipes/{recipeId}/user/{userId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D {
        recipeName: recipeName,
        description: description,
        difficulty: difficulty,
        preparationTime: preparationTime,
        cookingTime: cookingTime,
        additionalTime: additionalTime,
        servings: servings,
        userId: userId
   }
```

The above command returns a 204: No Content response on success.

#### /Equipments/equipmentId/user/userId
Gives the opportunity to update one or more equipment's field/s

This endpoint requires a equipmentId, recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Equipments/{equipmentId}/recipe/{recipeId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D  {
        equipmentId: equipmentId,
        equipmentName: equipmentName,
        recipeId: recipeId
    }
```

The above command returns a 204: No Content response on success.

#### /Ingredients/{ingredientId}/user/{userId}
Gives the opportunity to update one or more equipment's field/s


This endpoint requires a ingredientId, recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Ingredients/{ingredientId}/recipe/{recipeId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D  {
        ingredientId: ignredientId,
        ingredientName: ingredientName,
        amount: amount,
        recipeId: recipeId
    }
```

The above command returns a 204: No Content response on success.

#### /Steps/{stepId}/user/{userId}
Gives the opportunity to update one or more equipment's field/s

This endpoint requires a stepId, recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Steps/{stepId}/recipe/{recipeId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
-D  {
        stepId: stepId,
        stepNumber: stepNumber,
        stepName: stepName,
        recipeId: recipeId
    }
```

The above command returns a 204: No Content response on success.

### DELETE
#### /Recipes{recipeId}
Delete a Recipe

This endpoint requires a recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Recipes/{recipeId}"
-X PUT \
-H  "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
```

The above command returns a 204: No Content response on success.

#### /Image/delete/{recipeId}
Delete an Image

This endpoint requires a recipeId and a given token in the authorization header.

```
curl "https://localhost:44330/Image/delete/{recipeId}"
-X PUT \
-H  "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
```

The above command returns a 204: No Content response on success.

#### /Equipments/{equipmentId}
Delete an Equipment

This endpoint requires a equipmentId and a given token in the authorization header.

```
curl "https://localhost:44330/Equipments/{equipmentId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
```

The above command returns a 204: No Content response on success.


#### /Ingredients
Delete an Equipment

This endpoint requires a equipmentId and a given token in the authorization header.

```
curl "https://localhost:44330/Equipments/{equipmentId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
```
The above command returns a 204: No Content response on success.

#### /Steps
Delete a Step

This endpoint requires a stepId and a given token in the authorization header.

```
curl "https://localhost:44330/Steps/{stepId}"
-X PUT \
-H "Content-Type': 'application/json",
    "Authorization': "Bearer " + token"
```
The above command returns a 204: No Content response on success.
