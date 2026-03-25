namespace cw3;

public abstract class Equipment
{
    private float pricePerDayPunish;
    private bool IsRented;

    private int id;
    public Equipment(float pricePerDayPunish, int id)
    {
        this.pricePerDayPunish = pricePerDayPunish;
        this.id = id;
    }

    public float GetPricePerDayPunish()
    {
        return pricePerDayPunish;
    }

    public bool isRented(){
        return IsRented;
        
    }

    public int GetId()
    {
        return id;
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