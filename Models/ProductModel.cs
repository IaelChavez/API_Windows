using MySql.Data.MySqlClient;

namespace API_Windows.Models
{
    public class ProductModel
    {
        // Variables locales

        private string ConnectionString = "Server=localhost; Port=3306; Database=amazon_seler; User ID=root; Password=Conchudo1";
        
        //Memoria
        //private static List<ProductModel> Products = new List<ProductModel>();

        public int ID { get; set; }
        public string? Model { get; set; }
        public string? Category { get; set; }
        public float Price { get; set; }
        public string? Picture { get; set; }
        public string? Description { get; set; }
        public string? Designer { get; set; }

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
            //Memoria
            //return Products.Find(p => p.ID == id);

            //MySQL
            ProductModel model = new ProductModel();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    string tsql = "SELECT * FROM product WHERE IDproduct = @ID";
                    using (MySqlCommand cmd = new MySqlCommand(tsql, con))
                    {
                        cmd.Parameters.AddWithValue("@ID", id);

                        //Ejecutar la consulta
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                model = new ProductModel()
                                {
                                    ID = int.Parse(reader["IDproduct"].ToString()),
                                    Model = reader["Model"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    Price = float.Parse(reader["Price"].ToString()),
                                    Description = reader["Description"].ToString(),
                                    Picture = reader["Picture"].ToString(),
                                    Designer = reader["Designer"].ToString()
                                };
                             
                            }
                        }
                    }
                }
                //Devolvemos el modelo
                return model;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ProductModel> GetAll()
        {
            //Memoria
            //return Products;

            //MySQL

            List<ProductModel> col = new List<ProductModel>();
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    string tsql = "SELECT * FROM product";
                    using (MySqlCommand cmd = new MySqlCommand(tsql, con))
                    {
                        //Ejecutar la consulta
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                col.Add(new ProductModel()
                                {
                                    ID = int.Parse(reader["IDproduct"].ToString()),
                                    Model = reader["Model"].ToString(),
                                    Category = reader["Category"].ToString(),
                                    Price = float.Parse(reader["Price"].ToString()),
                                    Description = reader["Description"].ToString(),
                                    Picture = reader["Picture"].ToString(),
                                    Designer = reader["Designer"].ToString()
                                });

                            }
                        }
                    }
                }
                //Devolvemos una coleccion
                return col;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public int Add(ProductModel model)
        {
            //Memoria

            /*
            model.ID = Products.Count + 1;
            Products.Add(model);
            return model.ID;*/

            //MySQL

            try
            {
                object newID;
                using(MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    string tsql = "INSERT INTO product " +
                                  "(Model, " +
                                  "Category, " +
                                  "Price, " +
                                  "Picture, " +
                                  "Description, " +
                                  "Designer) " +
                                  "VALUES " +
                                  "(@Model, " +
                                  "@Category, " +
                                  "@Price, " +
                                  "@Picture, " +
                                  "@Description, " +
                                  "@Designer);" +
                                  "SELECT LAST_INSERT_ID();";
                    using(MySqlCommand cmd = new MySqlCommand(tsql, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Model", model.Model);
                        cmd.Parameters.AddWithValue("@Category", model.Category);
                        cmd.Parameters.AddWithValue("@Price", model.Price);
                        cmd.Parameters.AddWithValue("@Picture", model.Picture);
                        cmd.Parameters.AddWithValue("@Description", model.Description);
                        cmd.Parameters.AddWithValue("@Designer", model.Designer);

                        newID = cmd.ExecuteScalar();//Nos debe de devolver el nuevo ID

                        if(newID != null && newID.ToString().Length > 0)
                        {
                            return int.Parse(newID.ToString());
                        }
                    }
                }
                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(ProductModel model)
        {
            //Memoria
            /*foreach(ProductModel item in Products)
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
            }*/

            //MySQL
            try
            {
             
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    string tsql = "UPDATE product SET Model = @Model, Category = @Category, Price = @Price, Picture = @Picture, Description = @Description, Designer = @Designer " +
                                  "WHERE IDproduct = @IDproduct";

                    using (MySqlCommand cmd = new MySqlCommand(tsql, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@Model", model.Model);
                        cmd.Parameters.AddWithValue("@Category", model.Category);
                        cmd.Parameters.AddWithValue("@Price", model.Price);
                        cmd.Parameters.AddWithValue("@Picture", model.Picture);
                        cmd.Parameters.AddWithValue("@Description", model.Description);
                        cmd.Parameters.AddWithValue("@Designer", model.Designer);
                        cmd.Parameters.AddWithValue("@IDproduct", model.ID);

                        cmd.ExecuteNonQuery();
                    }
                }
                
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void Delete(int id)
        {
            //Memoria
            //Products.Remove(Get(id));

            //MySQL

            try
            {

                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    string tsql = "DELETE FROM product WHERE IDproduct = @IDproduct";

                    using (MySqlCommand cmd = new MySqlCommand(tsql, con))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Parameters.AddWithValue("@IDproduct", id);
                        cmd.ExecuteNonQuery();
                    }
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}

