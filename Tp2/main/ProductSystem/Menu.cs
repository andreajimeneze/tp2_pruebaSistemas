static class Menu
{

    public static void ShowMenu()
    { 
        Console.WriteLine("------------------");
        Console.WriteLine("GRAN TIENDA ONLINE");
        Console.WriteLine("------------------");

        Console.WriteLine("");
        Console.WriteLine("~ ~ ~ MENÚ ~ ~ ~");
        Console.WriteLine("");

        Console.WriteLine("1. Agregar productos al catálogo");
        Console.WriteLine("2. Buscar productos");
        Console.WriteLine("3. Calcular precio de un producto");
        Console.WriteLine("4. Salir del programa");
        Console.WriteLine("");
    }

    public static void RunSubMenu( string title, string label, Action action )
    {
        Console.WriteLine("");
        Console.WriteLine($"~ ~ ~ { title } ~ ~ ~");
        Console.WriteLine("");

         string? option;

            do { 
                Console.WriteLine($"1. { label }");
                Console.WriteLine("2. Volver a menú");
                Console.WriteLine("");
                Console.WriteLine("Seleccione una opción");
                option = Console.ReadLine();

                switch(option)
            {
                case "1":
                    Console.WriteLine("");
                    action();
                    break;
                case "2":
                    break;
                default:
                    Console.WriteLine("Debe seleccionar una opción válida");
                    break;
            }

            } while(option != "2");
    }
    public static void AddProductMenu( ProductManager manager )
    {
        string name = ConsoleInput.EnterProductName();
        Console.WriteLine("");
        decimal price = ConsoleInput.EnterPriceProduct( name );
        Console.WriteLine("");
        EnumCategory category = ConsoleInput.SelectCategory( name );
        Product? product = manager.CreateProduct(name, price, category);
        manager.AddProduct(product);
    }

    public static void SearchProductMenu(ProductManager manager)
    {
        Console.WriteLine("");
        string findingProduct = ConsoleInput.EnterProductName();
        Product? existingProduct = manager.FindProductByName(findingProduct);

        if( existingProduct != null )
        {
            Console.WriteLine("");
            Console.WriteLine("------------------------");
            Console.WriteLine(existingProduct.ToString());
            Console.WriteLine("------------------------");
            Console.WriteLine("");
        } else
        {
            Console.WriteLine("");
            Console.WriteLine("----------------------");
            Console.WriteLine("Producto no encontrado");
            Console.WriteLine("----------------------");
            Console.WriteLine("");
        }
    }

    public static void CalculatePriceMenu( ProductManager manager )
    {
        Console.WriteLine("");
        string productName = ConsoleInput.EnterProductName();
        Product? productToCalculate  = manager.FindProductByName(productName);

        if( productToCalculate != null )
            {
                Console.WriteLine("");
                int quantity = ConsoleInput.EnterQuantity( productName );
                decimal? totalPrice = manager.CalculateTotalPrice(productName, quantity );
                Console.WriteLine($"El precio final es de { totalPrice } pesos");
                Console.WriteLine("");
            } else
            {
                Console.WriteLine("");
                Console.WriteLine("----------------------");
                Console.WriteLine("Producto no encontrado");
                Console.WriteLine("----------------------");
                Console.WriteLine("");
            }
    }


}