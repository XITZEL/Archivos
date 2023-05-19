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
    public static void SaveProducts(List<Product>products) 
     { 
         StreamWriter textOut= 
             new StreamWriter( 
                 new FileStream("productos.txt",FileMode.Create,FileAccess.Write)); 
                     //El orden si importa va en el orden del Constructor 
                 foreach(var product in products) 
                 { 
                     textOut.Write(product.Code + "|"); 
                     textOut.Write(product.Description + "|"); 
                     textOut.WriteLine(product.Price); 
                 } 
                 textOut.Close(); 
                 
     }
   public static List<Product> GetProducts()
     {
        StreamReader textIn = new StreamReader(
            new FileStream("productos.txt", FileMode.Open, FileAccess.Read));

            List<Product> products = new List<Product>();
            while (textIn.Peek() != -1)
            {
                string row = textIn.ReadLine();
                string[] columns = row.Split("|");
                Product product = new Product(columns[0], columns[1], Convert.ToDecimal(columns[2]));
                products.Add(product);
            }
            textIn.Close();
           return products;

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
        products.Add(new Product("112", "Coca", 16.50m));
        //Guardamos nuestra lista en un archivo 
        ProductsDB.SaveProducts(products);

         List<Product> pds = new ();
       pds = ProductsDB.GetProducts();
        foreach(var p in pds)
        {
          if (p.Price > 15m)
          {
               Console.WriteLine(p.Price);
          }
        } 
     }
     
 }