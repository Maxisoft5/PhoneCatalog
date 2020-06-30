
namespace IQuesoftTask.DAL.Models
{
    public class Seller 
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal MonthRevenue { get; set; }
        public decimal QuartalRevenue { get; set; }
        public Product Product { get; set; }
        public int? ProductId { get; set; }
    }
}