namespace ContosoUniversity.Models
{
    public enum Grade
    {
        A, B, C, D, F
    }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }

        //A Course entity can be related to any number of Enrollment entities.
        public virtual Course Course { get; set; }

        //A Student entity can be related to any number of Enrollment entities.
        public virtual Student Student { get; set; }
    }
}