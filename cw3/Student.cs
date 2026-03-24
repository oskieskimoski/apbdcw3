namespace cw3;

public class Student : User
{
    private int year { get; set; }
    public Student(string name, string surname, int id, string studentId, int year) 
        : base(name, surname, id)  
    {
        this.year = year;
    }

    public override String getUserType()
    {
        return "Student";
    }
    
}