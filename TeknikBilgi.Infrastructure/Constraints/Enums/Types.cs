namespace TeknikBilgi.Infrastructure.Constraints.Enums
{
    namespace Types
    {
        public enum TempDataMessage
        {
            Success,
            Info,
            Warning,
            Error,
        }

        public enum Applications
        {
            Console = 1,
            Web = 2,
            Mobile = 3,
            Api = 4
        }

        public enum PlatformType
        {
            Web = 1,
            Mobile = 2,
            Api = 3,
            Application = 4
        }
    }
}