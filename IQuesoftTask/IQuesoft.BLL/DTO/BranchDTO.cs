
using System.Collections.Generic;

namespace IQuesoftTask.Bll.DTO
{
    public class BranchDto
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
        public string Address { get; set; }
        public decimal MonthRevenue { get; set; }
        public decimal QuartalRevenue { get; set; }
        public ICollection<SellerDto> Sellers { get; set; }
    }
}