static class ConsoleInput {
    public static string EnterProductName () {

        string? name = "";
        do {  
            Console.WriteLine("Ingrese el nombre del producto");
            name = Console.ReadLine();
        } while (string.IsNullOrWhiteSpace(name));

         return name.Trim();
    }

    public static decimal EnterPriceProduct ( string name ) {
        decimal price = 0;
        bool isValid;

        do {
            Console.WriteLine($"Ingrese el precio del producto { name }");
            string? priceInput = Console.ReadLine();
            isValid = decimal.TryParse(priceInput, out price);
            if( !isValid ) {
                Console.WriteLine("");
                Console.WriteLine($"Debe ingresar un precio válido para el producto { name }");
                Console.WriteLine("");              
            } else if ( price <= 0 ) {
                Console.WriteLine("");
                Console.WriteLine("Precio debe ser mayor a 0");
                Console.WriteLine("");
            }
        } while ( !isValid || price <= 0);

        return price;
    }

    public static EnumCategory SelectCategory ( string name ) {
       EnumCategory category = EnumCategory.Electronica;
       bool isValid;

        do {
            Console.WriteLine("Seleccione una categoría al producto. E para electronica y A para alimentos");
            string? inputCategory = Console.ReadLine();
            Console.WriteLine("");
            isValid = true;
            

            switch(inputCategory?.Trim().ToUpper()) {
                case "E":
                    category = EnumCategory.Electronica;
                    break;
                case "A":
                    category = EnumCategory.Alimentos;
                    break;
                default:
                    Console.WriteLine("Debe seleccionar una categoría válida");
                    isValid = false;
                    break;                    
            }
        } while ( !isValid );

        return category;
    }

    public static int EnterQuantity ( string name )
    {
        int quantity = 0;
        bool isValid;

        do {
            Console.WriteLine($"Ingrese cantidad del producto { name }");
            string? priceInput = Console.ReadLine();
            Console.WriteLine("");
            isValid = int.TryParse(priceInput, out quantity);
            if( !isValid ) {
                Console.WriteLine($"Debe ingresar una cantidad válida de productos { name }");
                
            } else if ( quantity <= 0 ) {
                Console.WriteLine("Cantidad debe ser mayor a 0");
            }
        } while ( !isValid || quantity <= 0);

        return quantity;
    }
}

   