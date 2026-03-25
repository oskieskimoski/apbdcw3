

using cw3;


Service service = new Service();
      

        
            
            service.addLaptop(10, "Intel i7-12700H", 15.6f);
            service.addLaptop(10, "AMD Ryzen 7 5800H", 14.0f);
            service.addCamera(20, "Canon EOS 2000D", "18-55mm");
            service.addCamera(25, "Sony Alpha A7", "24-70mm");
            service.addProjektor(30, 1920, true);
            service.addProjektor(35, 3840, false);
   
            
            service.addEmployee("Jan", "Kowalski", 1, "Professor");
            service.addEmployee("Anna", "Nowak", 2, "Manager");
            service.addStudent("Piotr", "Wiśniewski", 3, 3, "Computer Science");
            service.addStudent("Maria", "Lewandowska", 4, 1, "Math");
            
       
            
  
            service.Rent(3, 1, DateTime.Now, DateTime.Now.AddDays(7));

            service.Rent(3, 3, DateTime.Now, DateTime.Now.AddDays(5));
            
            service.Rent(2, 5, DateTime.Now, DateTime.Now.AddDays(14));
            
            service.Rent(4, 2, DateTime.Now, DateTime.Now.AddDays(10));
            

            service.Rent(3, 4, DateTime.Now, DateTime.Now.AddDays(3));
            

            service.Rent(1, 1, DateTime.Now, DateTime.Now.AddDays(7));

            service.Rent(99, 1, DateTime.Now, DateTime.Now.AddDays(7));

            service.Rent(1, 99, DateTime.Now, DateTime.Now.AddDays(7));
            
            
            service.returnEquipment(1, DateTime.Now.AddDays(8));
            
            service.Rent(3, 3, DateTime.Now, DateTime.Now.AddDays(5));
            service.returnEquipment(3 ,DateTime.Now.AddDays(6) );


            service.raport();
        
     
        