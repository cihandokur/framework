using System;

namespace TeknikBilgi.Data.Core.Entity.Application
{
    public class Application
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int StatusId { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? ModifyDate { get; set; }        

        public int? OrderNumber { get; set; }
    }
}