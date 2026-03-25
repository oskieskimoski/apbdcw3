namespace cw3;

public abstract class User
{
    private String name { get; set; }
    private String  surname { get; set; }
    private int id { get; set; }
    public int currRented { get; set; }
    private int maxRented { get; set; }

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