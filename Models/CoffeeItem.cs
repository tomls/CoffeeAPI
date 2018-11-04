namespace CoffeeApi.Models
{
    public class CoffeeItem
    {
        public long Id { get; set; }
        public string ImageURL {get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}