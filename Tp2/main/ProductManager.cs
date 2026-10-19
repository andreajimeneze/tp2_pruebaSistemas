public class ProductManager {
    
    private List<Product> productList = new List<Product>();
    private int nextId = 0;


    public Product? CreateProduct( string name, decimal price, EnumCategory category )
    {
        Product? existingProduct = FindProductByName( name );

        if(!Enum.IsDefined(typeof(EnumCategory), category))
        {
            return null;
        } else if(price <= 0)
        {
            return null;
        } else if(existingProduct != null)
        {
            return null;
        } 

        nextId++;
       
        return new Product{ Id = nextId, Name = name, Price = price, Category = category };
    }
    public bool AddProduct ( Product? product ) {
       if(product == null)
        {
            return false;
        }
        productList.Add(product);
        return true;
    }

    public decimal CalculateTotalPrice ( string name, int quantity ) {


       Product? existingProduct = FindProductByName( name );
       
       
       if( existingProduct != null ) { 

            switch ( existingProduct.Category ) {
                case EnumCategory.Electronica:
                    return (existingProduct.Price + (existingProduct.Price * 0.10m)) * quantity;
                case EnumCategory.Alimentos:
                    return (existingProduct.Price + (existingProduct.Price * 0.05m)) * quantity;
                default:
                    throw new ArgumentException("Categoría no existe");                
            }
       } else
        {
            throw new ArgumentException("Producto no existe");
        }
    }

    public Product? FindProductByName ( string name ) {
        foreach( Product product in productList ) {
            if( string.Equals(product.Name, name, StringComparison.OrdinalIgnoreCase) ) {
                return product;
            } 
        }
        return null;
    }
}