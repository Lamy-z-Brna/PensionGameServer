using PensionGame.Api.Domain.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Writers.Session
{
    public interface ISessionWriter : IWriter
    {
        Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear);
    }
}
