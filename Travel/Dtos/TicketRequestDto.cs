using System;

namespace Travel.Dtos
{
    public class TicketRequestDto
    {
        public string Name { get; set; }

        public string Country { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string OtherInfo { get; set; }
    }
}