namespace cw3;

public class Rent
{

    private User user;
    private DateTime RentDate;
    public DateTime? ReturnDate { get; set; }
    private Equipment rentedEquipment;
    private bool isReturned;
    
    public Rent(User user, DateTime rentDate, Equipment rentedEquipment)
    {
        this.user = user;
        this.RentDate = rentDate;
        this.rentedEquipment = rentedEquipment;
        this.isReturned = true;
        this.ReturnDate = null;
        
    }

    public float ReturnEquipment(DateTime currDate)
    {
        int daysLate = (currDate - ReturnDate.Value).Days; 
    
        if ((currDate - ReturnDate.Value).Days > 0)
        {
            return rentedEquipment.pricePunish(daysLate);
        }
        return 0;
    }
    public bool IsReturned()
    {
        return isReturned;
    }

    public override String ToString()
    {
        return "User: " + user + "Equipment "+  " Rent Date: " + RentDate + " Return Date: " + ReturnDate;
    }
}