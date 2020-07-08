using IQuesoftTask.Bll.DTO;
using System.Collections.Generic;

namespace IQuesoft.BLL.BusinessModels.ResponseModel
{
    class ListOpionalModel
    {
        public List<BranchDto> Branches { get; set; }
        public List<ProductDto> Products { get; set; }
        public List<PurchaseDto> Purchases { get; set; }
        public List<SellerDto> Sellers { get; set; }
    }
}
