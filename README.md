# Archivos
Clase de POO: Archivos
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
   /*public static void SaveProducts(List<Product>productos)
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

public  List<Product> GetProducts()
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
        */

    public static void SaveProductsbinary(List<Product>productos)
    {
        BinaryWriter binOut=
        new BinaryWriter(
            new FileStream("productos.txt",FileMode.Create,FileAccess.Write));

            foreach(var product in productos)
            {
                    binOut.Write(product.Code);
                    binOut.Write(product.Description);
                    binOut.Write(product.Price);

            }
        binOut.Close();
    }
        
        public  static List<Product> GetProductsBinary()
        {
                BinaryReader binaryIn=
                new BinaryReader(
                    new FileStream("productos.txt",FileMode.OpenOrCreate,FileAccess.Read));
                    while(binaryIn.PeekChar()!=-1)
                    {
                        Product product= new Product(binaryIn.ReadString(),binaryIn.ReadString(),binaryIn.ReadDecimal());
                        ProductsDB.Add(product);
                    }
                    binaryIn.Close();
                    return GetProductsBinary();
                
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
       ProductsDB.SaveProductsbinary(products); 



       
       //Leemos nuestros productos
       List<Product> pds = new();
       pds=ProductsDB.GetProductsBinary();
       foreach(Product p in pds)
       {
        Console.WriteLine(p.Price);
       }
       


       
    }
