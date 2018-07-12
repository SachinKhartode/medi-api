using medi_api.dataStore;
using medi_api.models;
using medi_api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace medi_api.Controllers
{
    public class ExpiryProductController : ApiController
    {
        ProductService objProdService = new ProductService();
        //// GET api/values
        //public HttpResponseMessage Get()
        //{
        //    return Request.CreateResponse<List<Product>>(HttpStatusCode.OK, objProdService.GetAllProducts());
        //}

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse<List<Product>>(HttpStatusCode.OK, objProdService.GetExpiryProduct(id));
        }

         
    }
}
