namespace cw3;

public class Rent
{

    public User user { get; }
    public DateTime RentDate{get; private set;}
    public DateTime? ReturnDate { get; set; }
    public Equipment rentedEquipment { get; }
    public int id { get; set; }
   

    public Rent(int id , User user, DateTime rentDate, Equipment rentedEquipment)
    {
        this.id = id;
        this.user = user;
        this.RentDate = rentDate;
        this.rentedEquipment = rentedEquipment;

        this.ReturnDate = null;
        
    }

    public float price(DateTime currDate)
    {
        int daysLate = (currDate - ReturnDate.Value).Days; 
        if ((currDate - ReturnDate.Value).Days > 0)
        {
            return rentedEquipment.pricePunish(daysLate);
        }
        return 0;
    }
   

    public override String ToString()
    {
        return "User: " + user + "Equipment "+  " Rent Date: " + RentDate + " Return Date: " + ReturnDate + ", id: " + id;
    }
}