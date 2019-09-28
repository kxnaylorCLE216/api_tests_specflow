namespace api_specflow.Model
{
    public class Products
    {
        public int id { get; set; }
        public string name { get; set; }
        public double cost { get; set; }
        public int quantity { get; set; }
        public int locationId { get; set; }
        public int groupId { get; set; }
    }
}