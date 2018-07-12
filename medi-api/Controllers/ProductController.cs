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
    public class ProductController : ApiController
    {
        ProductService objProdService = new ProductService();
        // GET api/values
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse<List<Product>>(HttpStatusCode.OK, objProdService.GetAllProducts());
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            return Request.CreateResponse<Product>(HttpStatusCode.OK, objProdService.GetProduct(id));
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]Product product)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objProdService.SaveProduct(product));
        }

        // PUT api/values/5
        public HttpResponseMessage Put(int id, [FromBody]Product product)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objProdService.UpdateProduct(id, product));
        }

        // DELETE api/values/5
        public HttpResponseMessage Delete(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, objProdService.DeActivateProduct(id));
        }
    }
}
