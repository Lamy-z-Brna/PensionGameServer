# Pension Game
A game simulating saving for pension. This is currently hosted on https://pensiongame.azurewebsites.net/, where you can enjoy a game playthrough.

## Solution structure
The app consists of ASP.NET Core Web API server (`PensionGame.Host`) and Blazor web app (`PensionGame.Web`). These communicate via REST services. The data is saved in MongoDB database. The solution is divided into several projects:

### `PensionGame.Common`
A project dedicated to useful helper functions to improve code writing experience. Includes Union class implementing a discriminated union (https://en.wikipedia.org/wiki/Tagged_union). 

### `PensionGame.Core`
This project includes the business logic of the application, including next game step calculations, generation of events and returns and some balance logic. This project should not use external resources like database or services, instead all the required data should be passed through parameters.

### `PensionGame.Api`
Here is where all the command/query handlers are located and this project works as a glue between database, business logic and domain models. 

### `PensionGame.Api.Domain`
This project is for sharing data objects and validators for both host and web, reducing the need to use more advanced solutions of sharing data objects between service consumer and Rest API host.

### `PensionGame.Host`
Project containing the necessary configurations and hosting the services. 

### `PensionGame.Web`
Blazor application containing all the razor components and UI configuration.

### `PensionGame.Tests`
The project responsible for automated unit testing.

## Gameplay
When creating your game, you specify your income and expenses. In each game step (one step = one year), you decide how to distribute your available income - you can choose stocks and bond investments, saving account, or even take a loan. Beware - the economic conditions are always changing. You may even become unemployed from time to time.

### Starting a new game
Select a New Session on the right menu. You can name your game and select the yearly income/expenses so that you can simulate your financial journey. Once you've successfully created the game, you can always find it in the Game Sessions menu. 

### Browsing existing games
Go to Game Sessions page by clicking on the right navigation bar. All the sessions are public and shared, you can return to your game anytime.

### Playing the game
The game takes you through a simulated journey of your life. Your income and expenses are changed based on current inflation rate and the difference between these quantities is what you're allowed to invest. Always remember to save up some money, you're not guaranteed to always have money at your disposal!

You can then select an investment by buying stocks or bonds, or you could leave extra cash in your savings account or even take out a loan if you're in red. When you're happy with how you've decided to invest, press Submit button and you'll be forwarded one year into the future! Continue investing your money and watch your portfolio grow.

### Finishing the game
Once you've reached the retirement age, you'll see how much you've saved up and some nice statistics about your playthrough. Can you save up more next time? 
