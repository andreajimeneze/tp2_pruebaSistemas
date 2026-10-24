namespace Tp2;

public class ProductManagerTest
{
    private ProductManager manager;
    private string name;
    private decimal price;
    private EnumCategory category;


    [SetUp]
    public void Setup()
    {
        manager = new ProductManager();
        name = "Televisor";
        price = 45000.50m;
        category = EnumCategory.Electronica;
    }

    [Test]
    public void CreateProductTest()
    {
        Product? product = manager.CreateProduct(name, price, category);

        Assert.That(product, Is.Not.Null);
        Assert.That(product.Id, Is.EqualTo(1));
        Assert.That(product.Name, Is.EqualTo(name));
    }

    [TestCase("Televisor", 45000.50, EnumCategory.Electronica)]
    [TestCase("Mouse", 1500, EnumCategory.Electronica)]
    [TestCase("Notebook", 900000, EnumCategory.Electronica)]
    public void AddProductTest(string productName, double productPrice, EnumCategory productCategory)
    {
        Product? product = manager.CreateProduct(productName, (decimal)productPrice, productCategory);
        bool isTrue = manager.AddProduct(product);

        Assert.That(isTrue, Is.True);
    }

    [Test]
    public void SearchProductTest()
    {
        Product? product = manager.CreateProduct(name, price, category);
        manager.AddProduct(product);

        Product? foundProduct = manager.FindProductByName(name);

        Assert.That(foundProduct, Is.Not.Null);
        Assert.That(foundProduct.Name, Is.EqualTo(name), "El nombre del producto debió ser Televisor");
    }

    [Test]
    public void SearchNotFoundProductTest()
    {
        Product? product = manager.FindProductByName(name);

        Assert.That(product, Is.Null);
    }

    [Test]
    public void CalculatePriceElectronicaTest()
    {
        Product? product = manager.CreateProduct(name, price, category);
        manager.AddProduct(product);

        int quantity = 3;

        decimal? totalPrice = manager.CalculateTotalPrice(name, quantity);

        Assert.That(totalPrice, Is.EqualTo(148501.65));
    }

    [Test]
    public void CalculatePriceAlimentosTest()
    {
        name = "Leche";
        price = 1690;
        category = EnumCategory.Alimentos;

        Product? product = manager.CreateProduct(name, price, category);
        manager.AddProduct(product);

        int quantity = 3;

        decimal? totalPrice = manager.CalculateTotalPrice(name, quantity);

        Assert.That(totalPrice, Is.EqualTo(5323.5));
    }

    [Test]
    public void CreateProductWithNegativePriceTest()
    {
        price = -55000m;
            
        Product? product = manager.CreateProduct(name, price, category);

        Assert.That(product, Is.Null);
    }

    [Test]
    public void AddProductWithNotFoundCategoryTest()
    {

        category = (EnumCategory)99;

        Product? product = manager.CreateProduct(name, price, category);

        
        bool? isTrue = manager.AddProduct(product);

        Assert.That(isTrue, Is.False);
    }
}
