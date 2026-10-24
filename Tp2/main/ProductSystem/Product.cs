public class Product {
    public int? Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public EnumCategory? Category { get; set; }

    public override string ToString() {
        return $"Producto \n Id: { Id } \n Nombre: { Name }  \n Precio: $ { Price }  \n Categoría: { Category }";
    }
}