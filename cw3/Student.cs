namespace cw3;

public class Student : User
{
    private int year { get; set; }
    private String major { get; set; }
    
    public Student(string name, string surname, int id,  int year, String major) 
        : base(name, surname, id)
    {
        this.maxRented = 2;
        this.year = year;
        this.major = major;
    }

    public override String getUserType()
    {
        return "Student";
    }

    public override string ToString()
    {
        return "Student: " + name + ", " + surname + ", major: " + major + "year: " + year + ", id"  + id;
    }
}