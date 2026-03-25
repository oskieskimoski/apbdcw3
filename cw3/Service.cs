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
        RentsArchive = new List<Rent>();
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
            equipment.Add(new Laptop(pricePerDayPunish, equipment[equipment.Count-1].id + 1, cpuModel, screeeSize));
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
            equipment.Add(new Camera(pricePerDayPunish,   equipment[equipment.Count-1].id + 1, model, lens));   
        }
        
    } public void addProjektor( float pricePerDayPunish,  int resolution, bool batery )
    {
        if (equipment.Count == 0)
        {
            equipment.Add(new Projector(pricePerDayPunish,  0, resolution, batery));
        }
        else
        {
            equipment.Add(new Projector(pricePerDayPunish, equipment[equipment.Count - 1].id + 1, resolution,
                batery));
        }
    }
    public void Rent(int personId, int itemId, DateTime rentalDate, DateTime returnDate)
    {
        User foundUser = null;
        Equipment foundEquipment = null;
    
      
        foreach (var user in users) 
        {
            if (user.id == personId)
            {
                foundUser = user;
                break;
            }
        }
        foreach (var e in equipment)
        {
            if (e.id == itemId)
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
            Console.WriteLine($"Sprzęt '{foundEquipment.id}' jest już wypożyczony");
            return;
        }
        if (!foundUser.canRent())
        {
            Console.WriteLine("Użytkownik przekroczył limit wypożyczeń");
            return;
        }

        Rent r;
        if (rents.Count == 0)
        {
             r = new Rent( 0 ,foundUser, rentalDate, returnDate,foundEquipment);
        }
        else
        {
             r = new Rent( rents[ rents.Count - 1].id +1 ,foundUser, rentalDate, returnDate, foundEquipment );
        }
        
        
        rents.Add(r);
        foundUser.currRented += 1;
       foundEquipment.IsRented = true;
        Console.WriteLine($"Pomyślnie wypożyczono '{foundEquipment}' dla {foundUser}, wypożyczenie ma id: " + r.id);
    }

    public void returnEquipment(int id, DateTime currDate)
    {
        Rent activeRent = null;
        foreach (var rent in rents)
        {
            if (rent.id == id)
            {
                activeRent = rent;
                break;
            }
        }
        if (activeRent == null)
        {
            Console.WriteLine($"Nie znaleziono aktywnego wypożyczenia o ID: {id}");
            return;
        }
    
       
    
        if (currDate < activeRent.RentDate)
        {
            Console.WriteLine("Błąd: Data zwrotu nie może być wcześniejsza niż data wypożyczenia");
            return;
        }
        rents.Remove(activeRent);
        activeRent.RealReturnDate = currDate;
        RentsArchive.Add(activeRent);
        activeRent.rentedEquipment.IsRented = false;
        activeRent.user.currRented--;
        
        
        float m = activeRent.price(currDate);
        if (m == 0)
        {
            Console.WriteLine("Zwrot dokonany pomyślnie");
        }
        else
        {
            Console.WriteLine($"Zwrot dokonany, należy zapłacić {m}");
        }
    }
    public void raport()
    {
        Console.WriteLine("Currently active rents: " );
        foreach (var e in rents)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("Achived rents:");
        foreach (var e in RentsArchive)
        {
            Console.WriteLine(e);
        }

        Console.WriteLine("Users: ");
        foreach (var u in users)
        {
            Console.WriteLine(u);
        }

        Console.WriteLine("Equipment: ");
        foreach (var e in equipment)
        {
            Console.WriteLine(e);
        }
    }
    
    
}