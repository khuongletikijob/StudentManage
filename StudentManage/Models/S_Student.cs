namespace StudentManage.Models
{
    public class S_Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Class { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
