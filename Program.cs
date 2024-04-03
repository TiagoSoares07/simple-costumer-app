using System.Globalization;
using Repository;

namespace AppClientes;

class Program
{
    static CostumerRepository _costumerRepository = new CostumerRepository();

    static void Main(string[] args)
    {
        //var cultura = new CultureInfo("pt-BR");
        //Thread.CurrentThread.CurrentCulture = cultura;
        //Thread.CurrentThread.CurrentUICulture = cultura;

        _costumerRepository.ReadCostumerData();

        while(true)
        {
            Menu();

            Console.ReadKey();
        }
    }

    static void Menu()
    {
        Console.Clear();

        Console.WriteLine("System Menu");
        Console.WriteLine("--------------------");
        Console.WriteLine("1 - Register costumer");
        Console.WriteLine("2 - Show costumers");
        Console.WriteLine("3 - Edit costumers");
        Console.WriteLine("4 - Delete costumer");
        Console.WriteLine("5 - Exit");
        Console.WriteLine("--------------------");

        ChooseOption();
    }

    
    static void ChooseOption()
    {
        Console.Write("Choose an option: ");

        var option = Console.ReadLine();

        switch (int.Parse(option))
        {
            case 1:
                {
                    _costumerRepository.RegisterCostumer();
                    Menu();
                    break;
                }
            case 2:
                {
                    _costumerRepository.ShowCostumers();
                    Menu();
                    break;
                }
            case 3:
                {
                    _costumerRepository.EditCostumer();
                    Menu();
                    break;
                }
            case 4:
                {
                    _costumerRepository.DeleteCostumer();
                    Menu();
                    break;
                }
            case 5:
                {
                    _costumerRepository.RegisterDataCostumer();
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.Clear();
                    Console.WriteLine("Invalid Option!"); 
                    break;
                }
        }
    }
}
