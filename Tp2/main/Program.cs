class Program
{
    static void Main(string[] args)
    {
        var manager = new ProductManager();
        string? input;
        do
        {
            Menu.ShowMenu();

            Console.WriteLine("");
            Console.WriteLine("Seleccione una opción del menú");
            input = Console.ReadLine();

            switch (input) {

                case "1":
                    Menu.RunSubMenu("Catálogo productos", "Agregar nuevo producto", () => Menu.AddProductMenu(manager));
                    break;

                case "2":
                    Menu.RunSubMenu("Búsqueda productos","Buscar un producto", () => Menu.SearchProductMenu(manager));
                    break;

                case "3": 
                    Menu.RunSubMenu("Cálculo precio final", "Calcular precio final del producto", () => Menu.CalculatePriceMenu(manager));
                    break;

                case "4":
                    Console.WriteLine("");
                    Console.WriteLine("Saliendo del programa...");
                    Console.WriteLine("");
                    break;

                default:
                    Console.WriteLine("");
                    Console.WriteLine("Debe seleccionar una opción válida");
                    Console.WriteLine("");
                    break;
            } 
    
        } while (input != "4");
    }
}
