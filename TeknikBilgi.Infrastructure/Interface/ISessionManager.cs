using System.Web;

namespace TeknikBilgi.Infrastructure.Interface
{
    public interface ISessionManager
    {
        HttpSessionStateBase SessionStateBase { get; }

        object Get(string sessionName);

        T Get<T>(string sessionName);

        T? Get<T>(string sessionName, bool isValue) where T : struct;

        bool Check(string sessionName);

        void Set(string sessionName, object obj);

        void Remove(string sessionName);
    }
}