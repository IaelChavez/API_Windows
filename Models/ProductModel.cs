namespace API_Windows.Models
{
    public class ProductModel
    {
        // Variables locales
        private static List<ProductModel> Products = new List<ProductModel>();

        public int ID { get; set; }
        public string Model { get; set; }
        public string Category { get; set; }
        public float Price { get; set; }
        public string Picture { get; set; }
        public string? Description { get; set; }
        public string Designer { get; set; }

        public ProductModel()
        {
            Model = String.Empty;
            Category = String.Empty;
            Picture = String.Empty; 
            Designer = String.Empty;

            //Products = new List<ProductModel>();
        }

        //Funciones CRUD

        public ProductModel Get(int id)
        {
            return Products.Find(p => p.ID == id);
        }

        public List<ProductModel> GetAll()
        {
            return Products;
        }

        public int Add(ProductModel model)
        {
            model.ID = Products.Count + 1;
            Products.Add(model);
            return model.ID;
        }

        public void Update(ProductModel model)
        {
            foreach(ProductModel item in Products)
            {
                if(item.ID == model.ID)
                {
                    item.Price = model.Price;
                    item.Picture = model.Picture;
                    item.Description = model.Description;
                    item.Designer = model.Designer;
                    item.Category = model.Category;
                    item.Model = model.Model;
                    break;
                }
            }
        }
        public void Delete(int id)
        {
            Products.Remove(Get(id));
        }
    }
}

