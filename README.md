
# Blog

Assignment for ASP .Net Core.

  

## How to configure the application

Copy the **.env_example** file to **.env** file and set the **ConnectionStrings__BlogConnectionString** and **JWT__Key** parameters to your values.

  

## How to run the application

Go to the Blog.API directory and run the following command:

  

dotnet ef database update

dotnet run --launch-profile https

Now open your browser and navigate to the **https://localhost:7216/swagger** URL.

  

To authenticate a user use the /api/Auth/Login end point with the following credentials:

  
First user:
- username: example_user_1

- password: !QAZxsw2

  
Second user:
- username: example_user_2

- password: !QAZxsw2

  

If the authentication is successful you will be returned with a token. You can use this token for authorization inside the application. To do so click on the **[Authorize]** button in the swagger interface. Then as a value enter:

  

Bearer **## TOKEN_VALUE ##**

  

Now test the end points by trying to create, update or delete a blog post, or by trying to access the user profile.