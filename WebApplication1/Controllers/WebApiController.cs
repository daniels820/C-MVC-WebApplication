using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DAL.EF.EntityFrameworkContext;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class WebApiController : Controller
    {
        private ContextManager _contextManager;

        //C'tor
        public WebApiController(ContextManager contextManager)
        {
            _contextManager = contextManager;
        }


        // [HttpGet]
        //[Route("/api/device")]
        //public JsonResult GetAllDevices()
        //{
        //    var db1 = new ContextManager();
        //    var db = db1._context;
        //    var query = (from Devices in db.Devices
        //                 join Owners in db.Owners on Devices.DeviceId equals Owners.OwnerId

        //                 select new { Devices.DeviceId, Devices.Name, Devices.Created, Devices.OwnerId, Owners.FullName }).ToList();

        //    return Json(db.Devices.ToList());
        //}

        //[Route("/api/DeviceByOwnerId")]
        //public JsonResult DeviceByOwnerId()
        //{
        //    var db1 = new ContextManager();
        //    var db = db1._context;

        //    var query = (from Devices in db.Devices
        //                 join Owners in db.Owners on Devices.DeviceId equals Owners.OwnerId

        //                 select new { Devices.DeviceId, Devices.Name, Devices.Created, Devices.OwnerId, Owners.FullName }).ToList();

        //    return Json(query);

        //}





















        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
