namespace TeknikBilgi.Infrastructure.Constraints.Enums
{
    namespace Status
    {
        public enum BaseStatusItem
        {
            None = 0,
            Active = 1,
            Passive = 2,
            Deleted = 3,
            New = 4,
            Editing = 5,
            Error = 6,
            Abort = 7
        }
        public enum AdminStatus
        {
            Active = BaseStatusItem.Active,
            Passive = BaseStatusItem.Passive
        }
        public enum Application
        {
            Active = BaseStatusItem.Active,
            Passive = BaseStatusItem.Passive,
            Deleted = BaseStatusItem.Deleted
        }
        public enum ApplicationConfig
        {
            Active = BaseStatusItem.Active,
            Passive = BaseStatusItem.Passive,
            Deleted = BaseStatusItem.Deleted
        }
    }
}