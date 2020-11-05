namespace HRSystem.Dtos
{
    public class EmployeeRequestDto
    {
        public string FullName { get; set; }
        
        public int PassportSeries { get; set; }

        public int PassportNumber { get; set; }

        public string OtherInfo { get; set; }

        public double LengthOfWork { get; set; }

        public string PreviousWorkPlace { get; set; }
        
        public long DepartmentId { get; set; }

        public long PositionId { get; set; }
    }
}