﻿namespace PensionGame.Api.Resources.ClientData
{
    public record ExpenseData
    {
        public int LifeExpenses { get; init; }

        public int Rent { get; init; }

        public int ChildrenExpenses { get; init; }

        public int ExtraExpenses { get; init; }

        public int TotalExpenses => LifeExpenses + Rent + ChildrenExpenses + ExtraExpenses;
    }
}
