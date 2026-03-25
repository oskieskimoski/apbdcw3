namespace cw3;

public class Rent
{

    private User user;
    private DateTime RentDate;
    private DateTime ReturnDate;
    private Equipment rentedEquipment;
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
        return rentedEquipment.pricePunish(ReturnDate.Day - currDate.Day);
    }
    public bool IsReturned()
    {
        return isReturned;
    }
    
    
}