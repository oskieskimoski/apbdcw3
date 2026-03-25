namespace cw3;

public class Projector : Equipment
{
    private int resolution;
    private bool batery;
    public Projector(float pricePerDayPunish, int id, int resolution, bool batery ) : base(pricePerDayPunish, id )
    {
        this.resolution = resolution;
        this.batery = batery;
    }

}