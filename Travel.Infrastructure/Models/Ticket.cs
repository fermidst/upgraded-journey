using System;
using System.Collections.Generic;

namespace Travel.Infrastructure.Models
{
    public class Ticket
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string OtherInfo { get; set; }

        public virtual List<Buyer> Buyers { get; set; }
    }
}