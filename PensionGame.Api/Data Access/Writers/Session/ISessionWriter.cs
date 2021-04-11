using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.Session
{
    public interface ISessionWriter : IWriter
    {
        Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear, string Name);
    }
}
