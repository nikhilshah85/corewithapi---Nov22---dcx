namespace DI_Demo.Models
{
    public class Products
    {
        public int pId { get; set; }
        public string pName { get; set; }
        public string pCategory { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }

        static List<Products> pList = new List<Products>()
        {
            new Products{ pId = 1, pCategory = "Cold-Drinks", pIsInStock=true, pName="Pepsi", pPrice=50},
            new Products{ pId = 2, pCategory = "Cold-Drinks", pIsInStock=true, pName="Coke", pPrice=50},
            new Products{ pId = 3, pCategory = "Cold-Drinks", pIsInStock=true, pName="Appy", pPrice=50},
            new Products{ pId = 4, pCategory = "Cold-Drinks", pIsInStock=true, pName="IPhone", pPrice=50},
            new Products{ pId = 5, pCategory = "Cold-Drinks", pIsInStock=true, pName="Puma", pPrice=50},
            new Products{ pId = 6, pCategory = "Cold-Drinks", pIsInStock=true, pName="Nike", pPrice=50},
        };

        public List<Products> GetAllProducts()
        {
            return pList;
        }
    }
}
