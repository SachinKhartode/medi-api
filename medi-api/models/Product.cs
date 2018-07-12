using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medi_api.models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCategory { get; set; }
        public string Company { get; set; }
        public DateTime? PurchaseDate { get; set; }
        public DateTime? ManufacturingDate { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string Comments { get; set; }
        public bool Active { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }

    public class User
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }
}