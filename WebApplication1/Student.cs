namespace WebApplication1
{
    public class Student
    {
        public string Id { get; set; }
        public Name Name { get; set; }
        public List<Subject> Subjects { get; set; }
    }

    public class Name
    {
        public string FName { get; set; }
        public string LName { get; set; }
    }

    public class Subject
    {
        public string SubjectId { get; set; }
        public string Name { get; set; }
    }
}
