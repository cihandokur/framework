using TeknikBilgi.Infrastructure.Interface;
using TeknikBilgi.Infrastructure.WebContext;

namespace TeknikBilgi.Business.Core.Implement
{
    public class ContextUserProvider : ContextUserProviderBase
    {
        public ContextUserProvider(ISessionManager sessionManager) : base(sessionManager)
        {
        }
    }
}
