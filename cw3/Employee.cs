namespace cw3;

public class Employee : User
{
    private String job {get; set;}
    public Employee (string name, string surname, int id, String job) 
    : base(name, surname, id)
    {
        this.job = job;
    }

    public override String getUserType()
    
    {
        return "Employee";
    }

    public override String ToString()
    {
        return "Employee: " + name + ", " + surname + ", job: " + job + ", id"  + id;
    }
    

}