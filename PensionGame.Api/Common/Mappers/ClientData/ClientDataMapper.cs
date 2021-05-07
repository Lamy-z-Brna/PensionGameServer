using PensionGame.Api.Common.Mappers.Holdings;

namespace PensionGame.Api.Common.Mappers.ClientData
{
    public sealed class ClientDataMapper : IClientDataMapper
    {
        private readonly IIncomeDataMapper _incomeDataMapper;
        private readonly IExpenseDataMapper _expenseDataMapper;
        private readonly IClientHoldingsMapper _clientHoldingsMapper;

        public ClientDataMapper(IIncomeDataMapper incomeDataMapper, 
            IExpenseDataMapper expenseDataMapper,
            IClientHoldingsMapper clientHoldingsMapper)
        {
            _incomeDataMapper = incomeDataMapper;
            _expenseDataMapper = expenseDataMapper;
            _clientHoldingsMapper = clientHoldingsMapper;
        }

        public Domain.Resources.ClientData.ClientData Map(Core.Domain.ClientData.ClientData clientData)
        {
            return new(
                IncomeData: _incomeDataMapper.Map(clientData.IncomeData),
                ExpenseData: _expenseDataMapper.Map(clientData.ExpenseData),
                ClientHoldings: _clientHoldingsMapper.Map(clientData.ClientHoldings)
                );
        }

        public Core.Domain.ClientData.ClientData Map(Domain.Resources.ClientData.ClientData clientData)
        {
            return new(
                IncomeData: _incomeDataMapper.Map(clientData.IncomeData),
                ExpenseData: _expenseDataMapper.Map(clientData.ExpenseData),
                ClientHoldings: _clientHoldingsMapper.Map(clientData.ClientHoldings)
                );
        }
    }
}
