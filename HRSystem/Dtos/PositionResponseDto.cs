namespace HRSystem.Dtos
{
    public class PositionResponseDto
    {
        public long Id { get; set; }
        
        public string Name { get; set; }

        public decimal Salary { get; set; }

        public int WorkingHoursPerWeek { get; set; }
    }
}