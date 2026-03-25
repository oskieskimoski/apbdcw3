namespace cw3;

public class Laptop : Equipment
{
    private String cpuModel;
    private float screeeSize;
    
    public Laptop(float pricePerDayPunish, int id, String cpuModel, float screeeSize ) : base(pricePerDayPunish, id)
    {
        this.cpuModel = cpuModel;
        this.screeeSize = screeeSize;
    }
    
    
}