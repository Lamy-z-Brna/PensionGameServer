using MathNet.Numerics;
using MathNet.Numerics.RootFinding;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators.Holdings
{
    public sealed class PortfolioReturnRateCalculator : IPortfolioReturnMapperCalculator
    {
        private readonly IPortfolioValueCalculator _finishedGamePortfolioValueCalculator;

        public PortfolioReturnRateCalculator(IPortfolioValueCalculator finishedGamePortfolioValueCalculator)
        {
            _finishedGamePortfolioValueCalculator = finishedGamePortfolioValueCalculator;
        }

        public PortfolioReturnRate? Calculate(PortfolioReturnRateRequiredData requiredData)
        {
            var gameStates = requiredData.GameStates;

            if (!gameStates.Any())
                return null;

            double valueOfEquation(double interestRate) => ValueOfEquation(_finishedGamePortfolioValueCalculator, gameStates, interestRate);
            double valueOfDerivative(double interestRate) => ValueOfDerivative(gameStates, interestRate);

            try
            {
                var result = NewtonRaphson.FindRootNearGuess(valueOfEquation, valueOfDerivative, 1, accuracy: 0.0001, maxIterations: 10000);

                return new PortfolioReturnRate(result);
            }
            catch (NonConvergenceException)
            {
                return null;
            }
        }

        private static double ValueOfEquation(IPortfolioValueCalculator finishedGamePortfolioValueCalculator, Dictionary<int, Domain.GameData.GameState> gameStates, double interestRate)
        {
            var firstYear = gameStates.Keys.Min();
            var lastYear = gameStates.Keys.Max();

            var result = 0d;

            for (var year = firstYear; year < lastYear; year++)
            {
                result += NetIncome(gameStates[year]) * Math.Pow(interestRate, lastYear - year);
            }

            var finishedGameValue = finishedGamePortfolioValueCalculator.Calculate(new(gameStates[lastYear]));
            result -= finishedGameValue.Value;

            return result;
        }

        private static double ValueOfDerivative(Dictionary<int, Domain.GameData.GameState> gameStates, double interestRate)
        {
            var firstYear = gameStates.Keys.Min();
            var lastYear = gameStates.Keys.Max();

            var result = 0d;

            for (var year = firstYear; year < lastYear; year++)
            {
                result += (lastYear - year) * NetIncome(gameStates[year]) * Math.Pow(interestRate, lastYear - year - 1);
            }

            return result;
        }

        private static double NetIncome(Domain.GameData.GameState gameState)
        {
            return gameState.ClientData.IncomeData.ActualSalary + gameState.ClientData.IncomeData.ExtraIncome
                - gameState.ClientData.ExpenseData.LifeExpenses - gameState.ClientData.ExpenseData.ExtraExpenses
                - gameState.ClientData.ExpenseData.Rent - gameState.ClientData.ExpenseData.ChildrenExpenses;
        }
    }
}
