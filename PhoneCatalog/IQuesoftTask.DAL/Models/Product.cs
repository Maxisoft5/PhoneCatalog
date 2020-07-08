using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IQuesoftTask.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ManufacturerName { get; set; }
        public DateTime DateManufacture { get; set; }
        public decimal Price { get; set; }
        public int? BranchId { get; set; }
        public Branch Branch { get; set; }
    }
}