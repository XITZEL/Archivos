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

public static  List<Product> GetProducts()
{
    StreamReader textln=
    new StreamReader(
        new FileStream("productos.txt",FileMode.Open,FileAccess.Read));
        List<Product>Products= new List<Product>();
        while (textln.Peek()!=-1)
        {
            string row = textln.ReadLine();
            string[] columns = ReaderWriterLock.Split("|");
            Product Product = new Product (columns[0],columns[1],Convert.ToDecimal(columns[2]));
            ProductsDB.Add(Product);            
        }
        textln.Close();
        return Product();
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
       products.Add(new Product("112", "Sacapuntas", 78));
       //Guardamos nuestra lista en un archivo
       ProductsDB.SaveProducts(products); 



       
       //Leemos nuestros productos
       List<Product> pds = new();
       pds=ProductsDB.GetProducts();
       foreach(Product p in pds)
       {
        Console.WriteLine(p.Price);
       }
       


       
    }
}