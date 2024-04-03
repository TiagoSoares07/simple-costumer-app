using Register;

namespace Repository;

public class CostumerRepository
{
    public List<Costumer> costumers = new();

    public void RegisterDataCostumer()
    {
        var json = System.Text.Json.JsonSerializer.Serialize(costumers);
        
        File.WriteAllText("clientes.txt", json);
    }

    public void ReadCostumerData()
    {
        if(File.Exists("clientes.txt"))
        {
            var data = File.ReadAllText("clientes.txt");
            
            var costumersData = System.Text.Json.JsonSerializer.Deserialize<List<Costumer>>(data);
            
            costumers.AddRange(costumersData);
        }
    }

    public void DeleteCostumer()
    {
        Console.Clear();
        Console.Write("Enter the costumer code: ");
        var costumerId = Console.ReadLine();

        var costumer = costumers.FirstOrDefault(p => p.Id == int.Parse(costumerId));

        if (costumer == null)
        {
            Console.WriteLine("Costumer not found! [Enter]");
            Console.ReadKey();
            return;
        }

        PrintCostumer(costumer);

        costumers.Remove(costumer);

        Console.WriteLine("Costumer removed successfully! [Enter]");

        Console.ReadKey();
    }
    
    public void EditCostumer()
    {
        Console.Clear();
        Console.Write("Enter the costumer code: ");
        var codigo = Console.ReadLine();

        var costumer = costumers.FirstOrDefault(p => p.Id == int.Parse(codigo));

        if (costumer == null)
        {
            Console.WriteLine("Costumer not found! [Enter]");
            Console.ReadKey();
            return;
        }

        PrintCostumer(costumer);

        Console.Write("Costumer name: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Born date: ");
        var bornDate = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Discount: ");
        var discount = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        costumer.Name = name;
        costumer.BornDate = bornDate;
        costumer.Discount = discount;
        costumer.RegisteredIn = DateTime.Now;


        Console.WriteLine("Costumer edited successfully! [Enter]");
        PrintCostumer(costumer);
        Console.ReadKey();
    }
    
    public void RegisterCostumer()
    {
        Console.Clear();

        Console.Write("Costumer namer: ");
        var name = Console.ReadLine();
        Console.Write(Environment.NewLine);

        Console.Write("Born date: ");
        var bornDate = DateOnly.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        Console.Write("Discount: ");
        var discount = decimal.Parse(Console.ReadLine());
        Console.Write(Environment.NewLine);

        var costumer = new Costumer();
        costumer.Id = costumers.Count + 1;
        costumer.Name = name;
        costumer.BornDate = bornDate;
        costumer.Discount = discount;
        costumer.RegisteredIn = DateTime.Now;

        costumers.Add(costumer);

        Console.WriteLine("Costumer successfully registered! [Enter]");
        PrintCostumer(costumer);
        Console.ReadKey();
    }
    
    public void PrintCostumer(Costumer costumer)
    {
        Console.WriteLine("ID.............: " + costumer.Id);
        Console.WriteLine("Name...........: " + costumer.Name);
        Console.WriteLine("Discount.......: " + costumer.Discount.ToString("0.00"));
        Console.WriteLine("Born date: " + costumer.BornDate);
        Console.WriteLine("Registered in..: " + costumer.RegisteredIn);
        Console.WriteLine("------------------------------------");
    }
 
    public void ShowCostumers()
    {
        Console.Clear();
        foreach (var costumer in costumers)
        {
            PrintCostumer(costumer);
        }

        Console.ReadKey();
    }
}