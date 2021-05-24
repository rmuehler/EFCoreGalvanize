namespace EFCoreGalvanize
{
    public class Grade
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string CourseName { get; set; }
        public float Score { get; set; } //cannot be name of Class, assume this is Grade
    }
}