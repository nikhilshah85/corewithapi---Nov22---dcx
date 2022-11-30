namespace shoppingAPPMVC.Models
{
    public class ProductsModel
    {
        #region Properties
        public int pId { get; set; }
        public string pName { get; set; }
        public double pPrice { get; set; }
        public bool pIsInStock { get; set; }
        public int pDiscountRate { get; set; }
        #endregion

        #region Data
        static List<ProductsModel> pList = new List<ProductsModel>()
        {
            new ProductsModel(){ pId =101, pName="Pepsi", pPrice =50, pDiscountRate=5, pIsInStock=true},
            new ProductsModel(){ pId =102, pName="Appy", pPrice =75, pDiscountRate=10, pIsInStock=true},
            new ProductsModel(){ pId =103, pName="Iphone", pPrice =150000, pDiscountRate=5, pIsInStock=false},
            new ProductsModel(){ pId =104, pName="Dell", pPrice =85000, pDiscountRate=20, pIsInStock=true},
            new ProductsModel(){ pId =105, pName="Air Pods", pPrice =26000, pDiscountRate=0, pIsInStock=true},
            new ProductsModel(){ pId =106, pName="Maggie", pPrice =125, pDiscountRate=0, pIsInStock=true},
            new ProductsModel(){ pId =107, pName="Pasta", pPrice =250, pDiscountRate=10, pIsInStock=true},
            new ProductsModel(){ pId =108, pName="Nike", pPrice =16000, pDiscountRate=50, pIsInStock=false},
            new ProductsModel(){ pId =109, pName="Puma", pPrice =12599, pDiscountRate=30, pIsInStock=true},
        };
        #endregion


        public List<string> GetCategories()
        {
            List<string> categories = new List<string>()
           {
               "Cold-Drinks", "Shoes", "Electronics","Furniture","Accessories"
           };
            return categories;
        }

        public List<ProductsModel> GetProductsModels()
        {
            return pList;
        }


        public ProductsModel GetProductsById(int id)
        {
            var p = pList.Find(pr => pr.pId == id);
            return p;
        }

    };
}
