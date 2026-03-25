namespace cw3;

public class Service
{

    public List<User> users { get; }
    public List<Equipment> equipment { get; }
    public List<Rent> rents { get; }
    public List<Rent> RentsArchive { get; }

    public Service()
    {
        users = new List<User>();
        equipment = new List<Equipment>();
        rents = new List<Rent>();
    }
    public List<Equipment> GetRentedEquipment()
    {
        return equipment;
    }
    public void addEmployee(string name, string surname, int id, String job)
    {
        users.Add(new Employee(name, surname, id, job) );
        
    }
    public void addStudent(string name, string surname, int id,  int year, String major)
    {
        users.Add(new Student(name, surname, id, year, major));
    }
    public void addLaptop(float pricePerDayPunish,  String cpuModel, float screeeSize ){

        if (equipment.Count == 0)
        {
            equipment.Add(new Laptop(pricePerDayPunish, 0, cpuModel, screeeSize));
        }
        else
        {
            equipment.Add(new Laptop(pricePerDayPunish, equipment[equipment.Count-1].GetId() + 1, cpuModel, screeeSize));
        }
    }

    public void addCamera( float pricePerDayPunish,  String model, String lens)
    {
        if (equipment.Count == 0)
        {
            equipment.Add(new Camera(pricePerDayPunish,   0, model, lens));
        }
        else
        {
            equipment.Add(new Camera(pricePerDayPunish,   equipment[equipment.Count-1].GetId() + 1, model, lens));   
        }
        
    } public void addProjektor( float pricePerDayPunish,  int resolution, bool batery )
    {
        if (equipment.Count == 0)
        {
            equipment.Add(new Projector(pricePerDayPunish,  0, resolution, batery));
        }
        else
        {
            equipment.Add(new Projector(pricePerDayPunish, equipment[equipment.Count - 1].GetId() + 1, resolution,
                batery));
        }
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

        Rent r = new Rent(foundUser, rentalDate, foundEquipment);
        r.ReturnDate =  returnDate;
        rents.Add(r);
        foundUser.currRented += 1;
       foundEquipment.IsRented = true;
        Console.WriteLine($"Pomyślnie wypożyczono '{foundEquipment}' dla {foundUser}");
    }

    public void returnEquipment(int personId, int itemId, DateTime currDate)
{
    
    Rent activeRent = null;
    
    foreach (var rent in rents)
    {
        if (rent.user.getId() == personId && 
            rent.rentedEquipment.GetId() == itemId && 
            !rent.IsReturned())
        {
            activeRent = rent;
            break;
        }
    }
    if (activeRent == null)
    {
        Console.WriteLine($"Nie znaleziono aktywnego wypożyczenia dla użytkownika ID: {personId} i sprzętu ID: {itemId}");
        return;
    }
    
    if (currDate < activeRent.RentDate)
    {
        Console.WriteLine("Błąd: Data zwrotu nie może być wcześniejsza niż data wypożyczenia");
        return;
    }
    RentsArchive.Add(activeRent);
    foreach (var e in equipment)
    {
        if (e.GetId() == itemId)
        {
            e.IsRented = false;
            break;
        }
    }
    foreach (var u in users)
    {
        if (u.getId() == personId)
        {
            u.currRented--;
        }
    }
    rents.Remove(activeRent);
    float m = activeRent.ReturnEquipment(currDate);
    if (m == 0)
    {
        Console.WriteLine("Zwrot dokonany pomyślnie");
    }
    else
    {
        Console.WriteLine($"Zwrot dokonany, należy zapłacić {m}");
    }
   
    
    
}
    
}