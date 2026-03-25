namespace cw3;

public class Service
{

    private List<User> users;
    private List<Equipment> equipment;
    private List<Rent> rents;
    public Service()
    {
        
    }
    public List<Equipment> GetRentedEquipment()
    {
        return equipment;
    }
    public void AddEmployee(string name, string surname, int id, String job)
    {
        users.Add(new Employee(name, surname, id, job) );
        
    }
    public void AddStudent(string name, string surname, int id,  int year, String major)
    {
        users.Add(new Student(name, surname, id, year, major));
    }
    public void AddLaptop(float pricePerDayPunish, int id, String cpuModel, float screeeSize ){
        
        equipment.Add(new Laptop(pricePerDayPunish, equipment[equipment.Count-1].GetId() + 1, cpuModel, screeeSize));
    }

    public void addCamera( float pricePerDayPunish, int id, String model, String lens)
    {
       equipment.Add(new Camera(pricePerDayPunish,   equipment[equipment.Count-1].GetId() + 1, model, lens));
    }
    public void addProjektor( float pricePerDayPunish, int id, int resolution, bool batery )
    {
        equipment.Add(new Projector(pricePerDayPunish, equipment[equipment.Count-1].GetId() + 1, resolution, batery));
    }

    public void Rent(int personId, int itemId, DateTime rentalDate, DateTime returnDate)
    {
        User foundUser = null;
        Equipment foundEquipment = null;
    
      
        foreach (var user in users) 
        {
            if (user.getId() == personId)
            {
                foundUser = user;
                break;
            }
        }
        foreach (var e in equipment)
        {
            if (e.GetId() == itemId)
            {
                foundEquipment = e;
                break;
            }
        }
        if (foundUser == null)
        {
            Console.WriteLine($"Nie znaleziono użytkownika o ID: {personId}");
            return;
        }
    
        if (foundEquipment == null)
        {
            Console.WriteLine($"Nie znaleziono sprzętu o ID: {itemId}");
            return;
        }
    
        if (foundEquipment.IsRented)
        {
            Console.WriteLine($"Sprzęt '{foundEquipment.GetId()}' jest już wypożyczony");
            return;
        }
        if (!foundUser.canRent())
        {
            Console.WriteLine("Użytkownik przekroczył limit wypożyczeń");
            return;
        }
        rents.Add(new Rent(foundUser, rentalDate, returnDate, foundEquipment));
        foundUser.currRented += 1;
       foundEquipment.IsRented = true;
        Console.WriteLine($"Pomyślnie wypożyczono '{foundEquipment}' dla {foundUser}");
    }
}