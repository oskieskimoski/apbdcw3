namespace cw3;

public abstract class User
{
    public String name { get; set; }
    public String  surname { get; set; }
    public int id { get; set; }
    public int currRented { get; set; }
    public int maxRented { get; set; }

    public bool canRent()
    {
        if (this.currRented >= this.maxRented)
        {
            return false;
        }
        return true;
    }

    public int getId(){return id;}
    public User(String name, String surname, int id )
    {
        this.name = name;
        this.surname = surname;
        this.id = id;
    }
    public abstract String getUserType();
    
    

}