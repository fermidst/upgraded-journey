namespace HRSystem.Infrastructure.Models
{
    public class Employee
    {
        public long Id { get; set; }

        public string FullName { get; set; }

        public string Department { get; set; }

        public long PositionId { get; set; }
    }
}