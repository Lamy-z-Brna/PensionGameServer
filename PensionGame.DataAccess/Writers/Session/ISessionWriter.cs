using PensionGame.DataAccess.Data_Objects.Session;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Writers.Session
{
    public interface ISessionWriter : IWriter
    {
        Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear);
    }
}
