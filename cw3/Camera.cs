namespace cw3;

public class Camera : Equipment
{
    private String model;
    private String lens;
    public Camera(float pricePerDayPunish, int id, String model, String lens) : base(pricePerDayPunish, id)
    {
        this.model = model;
        this.lens = lens;
    }

    public override string ToString()
    {
        return "Camera, model: " + model + ", lens: " + lens + ", id: " + id;
    }

}