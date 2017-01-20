namespace TeknikBilgi.Infrastructure.Constraints.Enums
{
    namespace Status
    {
        public enum BaseStatusItem
        {
            Active = 1,
            Passive = 2,
            Deleted = 3,
            New = 4,
            None = 5,
            Error = 6,
            Abort = 7,
            Waiting = 71,
            Delivered = 72,
            NotDelivered = 73,
            InvalidEmail = 74,
            Empty = 100,
            Added = 120,
            Removed = 140,
            Modified = 150,
            NewspaperPublishWait = 190,
            Published = 200,
            UnPublished = 201,
            Locked = 210,
            PublishInProgress = 250,
            Ready = 290,
            Editing = 295,
            Temporary = 300
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