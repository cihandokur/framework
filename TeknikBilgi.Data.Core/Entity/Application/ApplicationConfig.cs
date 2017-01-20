using System;

namespace TeknikBilgi.Data.Core.Entity.Application
{
    public class ApplicationConfig
    {
        public int Id { get; set; }

        public int ApplicationId { get; set; }

        public string ApplicationMode { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }

    }
}