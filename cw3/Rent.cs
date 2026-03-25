namespace cw3;

public class Rent
{

    public User user { get; }
    public DateTime RentDate{get; private set;}
    public DateTime ReturnDate { get; set; }
    public DateTime? RealReturnDate{get; set;}
    public Equipment rentedEquipment { get; }
    public int id { get; set; }
   

    public Rent(int id , User user, DateTime rentDate, DateTime returnDate , Equipment rentedEquipment)
    {
        this.id = id;
        this.user = user;
        this.RentDate = rentDate;
        this.rentedEquipment = rentedEquipment;

        this.ReturnDate = returnDate;
        RealReturnDate = null;
    }

    public float price(DateTime currDate)
    {
        int daysLate = (currDate - RealReturnDate.Value).Days; 
        if ((currDate - RealReturnDate.Value).Days > 0)
        {
            return rentedEquipment.pricePunish(daysLate);
        }
        return 0;
    }
   

    public override String ToString()
    {
        return "User: " + user + " Equipment "+  " Rent Date: " + RentDate + " Return Date: " + ReturnDate + " Real return date: "+ RealReturnDate + ", id: " + id;
    }
}