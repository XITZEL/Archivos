class Product
{
    public string Code {get;set;}
    public string Description{get;set;}
    public Decimal Price{get;set;}


    public Product(string c, string d , decimal p)
    {
        Code= c;
        Description = d;
        Price = p;
    }

     
}
class ProductsDB
{
   public static void SaveProducts(List<Product>productos)
    {
        StreamWriter textOut=
            new StreamWriter(
                new FileStream("productos.txt",FileMode.Create,FileAccess.Write));
                    //El orden si importa va en el orden del Constructor
                foreach(var product in productos)
                {
                    textOut.Write(product.Code + "|");
                    textOut.Write(product.Description + "|");
                    textOut.WriteLine(product.Price);
                }
                textOut.Close();


    }


}
internal class Program
{
    private static void Main(string[] args)
    {
       //Lista de Productos
       List<Product>products= new List<Product>();
       //1er Producto
       products.Add(new Product("111", "Lapiz", 20));
       //Guardamos nuestra lista en un archivo
       ProductsDB.SaveProducts(products); 


       
    }
}