using MongoDB.Driver;
using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.DataAccess;
using PensionGame.DataAccess.Data_Objects.ClientData;
using PensionGame.DataAccess.Data_Objects.Holdings;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.GameData
{
    public class GameStateWriter : IGameStateWriter
    {
        //private readonly PensionGameDbContext _context;
        //private readonly IMongoDatabase _database;
        private readonly GameStateDatabase _gameStateDatabase;

        public GameStateWriter(PensionGameDbContext context, GameStateDatabase gameStateDatabase)
        {
            //_context = context;
            _gameStateDatabase = gameStateDatabase;
            //var client = new MongoClient("mongodb+srv://pension-game-admin:Brno123@cluster0.2fb3r.mongodb.net/PensionGameDb?retryWrites=true&w=majority");
            //_database = client.GetDatabase("PensionGameDb");

        }
        public async Task Create(SessionId sessionId, GameState gameState)
        {
            await _gameStateDatabase.Create(sessionId.Id, gameState);

            // client holdings
            //var bondHoldings = new List<BondHolding>();
            //foreach (var bondHolding in gameState.ClientData.ClientHoldings.Bonds)
            //{
            //    bondHoldings.Add(new BondHolding(bondHolding.YearlyPayment, bondHolding.YearsToExpiration));
            //}

            //var loanHoldings = new List<LoanHolding>();
            //foreach (var loanHolding in gameState.ClientData.ClientHoldings.Loans)
            //{
            //    loanHoldings.Add(new LoanHolding(loanHolding.Amount, loanHolding.InterestRate));
            //}

            //var savingsAccountHolding = new SavingsAccountHolding(gameState.ClientData.ClientHoldings.SavingsAccount.Amount);
            //var stockHolding = new StockHolding(gameState.ClientData.ClientHoldings.Stocks.UnitPrice, gameState.ClientData.ClientHoldings.Stocks.UnitsHeld);
            //var clientHoldings = new ClientHoldings(bondHoldings, loanHoldings, savingsAccountHolding, stockHolding);

            //// client data
            //var incomeData = gameState.ClientData.IncomeData;
            //var incomeDataModel = new IncomeData(incomeData.Salary, incomeData.BondInterest, incomeData.SavingsAccountInterest, incomeData.ExtraIncome);

            //var expenseData = gameState.ClientData.ExpenseData;
            //var expenseDataModel = new ExpenseData(expenseData.LifeExpenses, expenseData.LoanExpenses, expenseData.Rent, expenseData.ChildrenExpenses, expenseData.ExtraExpenses);

            //var clientDataModel = new DataAccess.Data_Objects.ClientData.ClientData(incomeDataModel, expenseDataModel, clientHoldings);

            //// game state
            //var gameStateModel = new DataAccess.Data_Objects.GameData.GameState(FromGuid(sessionId.Id), gameState.Year, gameState.IsFinished, clientDataModel);

            //_context.Add(gameStateModel);
            //await _context.SaveChangesAsync();
            //return gameStateModel.Id;
        }

        private int FromGuid(Guid value)
        {
            byte[] b = value.ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }
    }
}
