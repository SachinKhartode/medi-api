using medi_api.dataStore;
using medi_api.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace medi_api.Services
{
    public class ProductService
    {
        mediEntities context = new mediEntities();

        public List<Product> GetAllProducts()
        {
            List<Product> lst= null;
            try
            {
                lst = (from e in context.tblProductMasters
                       where e.Active == true
                        select new Product
                        {
                            ProductID = e.ProductID,
                            ProductName = e.ProductName,
                            ProductCategory = e.Category,
                            Company = e.Company,
                            PurchaseDate = e.PurchaseDate,
                            ManufacturingDate = e.ManufacturingDate,
                            Comments = e.Comments,
                            ExpiryDate = e.ExpiryDate
                        }).ToList();

            }
            catch (Exception ex)
            {
            }
            return lst;
        }

        public Product GetProduct(int id)
        {
            Product lst = null;
            try
            {
                lst = (from e in context.tblProductMasters
                          where e.ProductID == id
                          select new Product
                          {
                              ProductID = e.ProductID,
                              ProductName = e.ProductName,
                              ProductCategory = e.Category,
                              Company = e.Company,
                              PurchaseDate = e.PurchaseDate,
                              ManufacturingDate = e.ManufacturingDate,
                              ExpiryDate = e.ExpiryDate,
                              Comments = e.Comments,
                          }).FirstOrDefault();

            }
            catch (Exception ex)
            {
            }
            return lst;
        }

        public List<Product> GetExpiryProduct(int id)
        {//Id will contain number of day
            List<Product> lst = null;
            try
            {
                DateTime fromDate = DateTime.Now.Date;
                DateTime toDate = DateTime.Now.AddDays(id+1).Date;

                lst = (from e in context.tblProductMasters
                       where (e.ExpiryDate >= fromDate && e.ExpiryDate <= toDate)
                       select new Product
                       {
                           ProductID = e.ProductID,
                           ProductName = e.ProductName,
                           ProductCategory = e.Category,
                           Company = e.Company,
                           PurchaseDate = e.PurchaseDate,
                           ManufacturingDate = e.ManufacturingDate,
                           ExpiryDate = e.ExpiryDate,
                           Comments = e.Comments,
                       }).ToList();

            }
            catch (Exception ex)
            {

            }
            return lst;
        }

        public int SaveProduct(Product p)
        {
            int success = 0;
            try
            {
                tblProductMaster obj = new tblProductMaster();
                obj.ProductID = p.ProductID;
                obj.ProductName = p.ProductName;
                obj.Category = p.ProductCategory;
                obj.Company = p.Company;
                obj.PurchaseDate = p.PurchaseDate;
                obj.ManufacturingDate = p.ManufacturingDate;
                obj.ExpiryDate= p.ExpiryDate;
                obj.Comments = p.Comments;
                obj.CreatedOn = DateTime.Now;
                obj.Active = true;

                context.tblProductMasters.Add(obj);
                success = context.SaveChanges();
            }
            catch (Exception ex)
            {

            }
            return success;
        }

        public int UpdateProduct(int ID, Product p)
        {
            int success = 0;
            try
            {
                tblProductMaster obj = new tblProductMaster();

                obj = context.tblProductMasters.Single(x => x.ProductID == ID);

                if (obj != null)
                {
                    obj.ProductName = p.ProductName;
                    obj.Category = p.ProductCategory;
                    obj.Company = p.Company;
                    obj.PurchaseDate = p.PurchaseDate;
                    obj.ManufacturingDate = p.ManufacturingDate;
                    obj.ExpiryDate = p.ExpiryDate;
                    obj.Comments = p.Comments;
                    obj.ModifyOn = DateTime.Now;

                    context.Entry(obj).State = System.Data.Entity.EntityState.Modified;
                }

                success = context.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
            return success;
        }

        public int DeActivateProduct(int Id)
        {
            int deactivatedProdID = 0;
            try
            {
                tblProductMaster obj = new tblProductMaster();
                obj = context.tblProductMasters.Single(oc => oc.ProductID == Id);
                if (obj != null)
                {
                    context.Entry(obj).State = System.Data.Entity.EntityState.Deleted;
                }

                deactivatedProdID = context.SaveChanges();

            }
            catch (Exception ex)
            {

            }
            return deactivatedProdID;
        }

    }
}