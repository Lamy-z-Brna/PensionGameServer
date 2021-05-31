# Pension Game
A game simulating saving for pension.

## Project structure
The app consists of ASP.NET Core Web API server (`PensionGame.Host`) and Blazor web app (`PensionGame.Web`). These communicate via REST interface. The data is saved in MongoDB database.

## Gameplay
When creating your game, you specify your income and expenses. In each game step (one step = one year), you decide how to distribute your cashflow - you can choose stocks and bond investments, saving account, or even take a loan. Beware - the economic conditions are always changing. You may even become unemployed from time to time.

How much can you save for your pension?
