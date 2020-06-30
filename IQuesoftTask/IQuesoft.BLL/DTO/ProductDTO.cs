using System;

namespace IQuesoftTask.Bll.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime DateManufacture { get; set; }
        public decimal Price { get; set; }
        public int? BranchId { get; set; }
        public BranchDto BranchDTO { get; set; }
    }
}