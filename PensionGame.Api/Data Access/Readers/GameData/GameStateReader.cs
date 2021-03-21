using Microsoft.EntityFrameworkCore;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.GameData
{
    public class GameStateReader : IGameStateReader
    {
        private readonly PensionGameDbContext _context;

        public GameStateReader(PensionGameDbContext context)
        {
            _context = context;
        }
        public async Task<GameState> Get(SessionId sessionId, int year)
        {
            var gameStateModel = await _context.GameStates.FirstOrDefaultAsync(g => g.SessionId == FromGuid(sessionId.Id) && g.Year == year);
            if (gameStateModel == null)
            {
                throw new ArgumentNullException();
            }

            return Map(gameStateModel);
        }

        public async Task<IEnumerable<GameState>> Get(SessionId sessionId)
        {
            //var gameStateModels = await _context.GameStates.All(g => g.SessionId == FromGuid(sessionId.Id));
            throw new NotImplementedException();
        }

        public async Task<GameState> Get(int gameStateId) 
        {
            var gameStateModel = await _context.GameStates.FirstOrDefaultAsync(g => g.Id == gameStateId);
            if (gameStateModel == null)
            {
                throw new ArgumentNullException();
            }

            return Map(gameStateModel);
        }

        public async Task<GameState> GetCurrentGameState(SessionId sessionId)
        {
            if (_context.GameStates == null)
            {
                throw new ArgumentNullException();
            }
            var gameStateModel = await _context.GameStates
                .Where(g => g.SessionId == FromGuid(sessionId.Id))
                .OrderByDescending(g => g.Id)
                .FirstOrDefaultAsync();
            return Map(gameStateModel);
        }

        private int FromGuid(Guid value)
        {
            byte[] b = value.ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }

        private GameState Map(DataAccess.Data_Objects.GameData.GameState gameStateModel)
        {
            var bonds = new BondHoldings(new List<BondHolding>());
            var loans = new LoanHoldings(new List<LoanHolding>());
            var savingsAccount = new SavingsAccountHoldings(0);
            var stocks = new StockHolding(0, 0);
            var clientHoldings = new ClientHoldings(stocks, bonds, savingsAccount, loans);

            var expenseData = new ExpenseData();
            var incomeData = new IncomeData();
            var clientData = new Domain.Resources.ClientData.ClientData(incomeData, expenseData, clientHoldings);

            if (gameStateModel.ClientData != null)
            {
                if (gameStateModel.ClientData.ClientHoldings != null)
                {
                    var clientHoldingsModel = gameStateModel.ClientData.ClientHoldings;
                    if (clientHoldingsModel.Bonds != null)
                    {
                        bonds = new BondHoldings(clientHoldingsModel.Bonds.Select(b => new BondHolding(b.YearlyPayment, b.YearsToExpiration)));
                    }
                    if (clientHoldingsModel.Loans != null)
                    {
                        loans = new LoanHoldings(clientHoldingsModel.Loans.Select(l => new LoanHolding(l.Amount, l.InterestRate)));
                    }
                    if (clientHoldingsModel.SavingsAccount != null)
                    {
                        savingsAccount = new SavingsAccountHoldings(clientHoldingsModel.SavingsAccount.Amount);
                    }
                    if (clientHoldingsModel.Stocks != null)
                    {
                        stocks = new StockHolding(clientHoldingsModel.Stocks.UnitPrice, clientHoldingsModel.Stocks.UnitsHeld);
                    }
                    clientHoldings = new ClientHoldings(stocks, bonds, savingsAccount, loans);
                }

                if (gameStateModel.ClientData.ExpenseData != null)
                {
                    var expenseDataModel = gameStateModel.ClientData.ExpenseData;
                    expenseData = new ExpenseData
                    {
                        LifeExpenses = expenseDataModel.LifeExpenses,
                        LoanExpenses = expenseDataModel.LoanExpenses,
                        Rent = expenseDataModel.Rent,
                        ChildrenExpenses = expenseDataModel.ChildrenExpenses,
                        ExtraExpenses = expenseDataModel.ExtraExpenses
                    };
                }

                if (gameStateModel.ClientData.IncomeData != null)
                {
                    var incomeDataModel = gameStateModel.ClientData.IncomeData;
                    incomeData = new IncomeData
                    {
                        Salary = incomeDataModel.Salary,
                        BondInterest = incomeDataModel.BondInterest,
                        SavingsAccountInterest = incomeDataModel.SavingsAccountInterest,
                        ExtraIncome = incomeDataModel.ExtraIncome
                    };
                }

                clientData = new Domain.Resources.ClientData.ClientData(incomeData, expenseData, clientHoldings);
            }

            var marketData = new Domain.Resources.MarketData.MarketData
                (
                    new MacroEconomicData
                    (
                        IsCrisis: false,
                        InflationRate: 0.03,
                        UnemploymentRate: 0.07,
                        InterestRate: 0.02
                    ),
                    new ReturnData
                    (
                        StockRate: 0.06,
                        BondRate: 0.03,
                        BondDefaultRate: 0.02,
                        SavingsAccountRate: 0.01,
                        LoanRate: 0.09
                    )
                );
            return new GameState(gameStateModel.Year, clientData, marketData, false, gameStateModel.IsFinished);
        }
    }
}
