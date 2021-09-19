using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
//using System.Web.Mvc;
using System.Web.Http;
using productAPI.Models;

namespace productAPI.Controllers
{
    //using System.Web.Http;

    [RoutePrefix("api/product")]
    public class ProductController : ApiController
    {

        productdbEntities _context = new productdbEntities();

        //GET api/GetAllProducts
        [Route("GetAllProducts")]
        [HttpGet]
        public IEnumerable<productItem> GetAllProducts()
        {
            return _context.productItems;
        }
        //GET api/get/pid
        [Route("get/{pid}")]
        [HttpGet]
        public productItem Get(int pid)
        {
            productItem getItem = _context.productItems.Where(w => w.productid == pid).FirstOrDefault();
            return getItem;
        }

        //POST api/post/name/price/type/active
        [Route("post/{name}/{price}/{type}/{active}")]
        [HttpGet]
        public string Post(string name, decimal price, string type, bool active)
        {
            string return_value = string.Empty;

            productItem pItem = new productItem();

            pItem.name = name;
            pItem.price = price;
            pItem.type = type;
            pItem.active = active;

            _context.productItems.Add(pItem);

            return_value = _context.SaveChanges().ToString();

            return return_value;

        }

        //DELETE api/delete/pid
        [Route("delete/{pid}")]
        [HttpGet]
        public string Delete(int pid)
        {
            string return_value = string.Empty;

            productItem pItem = _context.productItems.Find(pid);

            _context.productItems.Remove(pItem);

            return_value = _context.SaveChanges().ToString();

            return return_value;
        }

        //UPDATE api/update/pid/name/price/type/active
        [Route("update/{pid}/{name}/{price}/{type}/{active}")]
        [HttpGet]
        public string Update(int pid, string name, decimal price, string type, bool active)
        {
            string return_value = string.Empty;

            productItem pItem = _context.productItems.Find(pid);

            pItem.name = name;
            pItem.price = price;
            pItem.type = type;
            pItem.active = active;

            _context.Entry(pItem).State = EntityState.Modified;

            return_value = _context.SaveChanges().ToString();

            return return_value;
        }

        // GET: Product
        /**public ActionResult Index()
        {
            return View();
        }**/
    }
}