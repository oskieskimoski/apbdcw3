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

    public override string ToString()
    {
        return "Projector , resolution: " + resolution + ", is portable: " + (batery ? "Yes" : "No") + ", id: " + id;
    }

}