namespace cw3;

public class Rent
{

    public User user { get; }
    public DateTime RentDate { get; }
    private DateTime ReturnDate;
    public Equipment rentedEquipment { get; }
    private bool isReturned;
    
    public Rent(User user, DateTime rentDate, DateTime returnDate, Equipment rentedEquipment)
    {
        this.user = user;
        this.RentDate = rentDate;
        this.ReturnDate = returnDate;
        this.rentedEquipment = rentedEquipment;
    }

    public float ReturnEquipment(DateTime currDate)
    {
        isReturned = true;
        return rentedEquipment.pricePunish(ReturnDate.Day - currDate.Day);
       
    }

   
    public bool IsReturned()
    {
        return isReturned;
    }
}