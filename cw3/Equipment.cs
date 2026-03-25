namespace cw3;

public abstract class Equipment
{
    private float pricePerDayPunish;
    public bool IsRented {get; set;}
    public int id { get; }

    public Equipment(float pricePerDayPunish, int id)
    {
        this.pricePerDayPunish = pricePerDayPunish;
        this.id = id;
    }

 

  
    public float pricePunish(int days)
    {
        if (days > 5)
        {
            return  1.2f * pricePerDayPunish * days;
        }
        return pricePerDayPunish * days;
    }
    
}