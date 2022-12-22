using DapperAsp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace DapperAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GadgetsController : ControllerBase
    {
       private static gadgetstore_dbContext gadgetstore_models = new gadgetstore_dbContext();

        [HttpPost]
        [Route("Insert")]
        public IResult AddGadget(Gadget gadget)
        {
            //var item = gadgetstore_models.Gadgets.FirstOrDefault(x => x.Name.Equals(Name) && x.Price.Equals(Price));

            //if (item == null)
            //{
            //   gadgetstore_models.Add(new Gadget() { Name = Name, Price = Price});
            //   gadgetstore_models.SaveChanges();
            //    return Results.Ok();
            //}
            //return Results.BadRequest();

            

            var item = gadgetstore_models.Gadgets.FirstOrDefault(x => x.Name.Equals(gadget.Name) && x.Price.Equals(gadget.Price));

            //var header = Request.Headers["gadget"].ToString().Split(",");

            if (item == null)
            {
                var gadgets = new Gadget()
                {
                    Name = gadget.Name,
                    Price = gadget.Price,
                };
                gadgetstore_models.Add(gadgets);
                gadgetstore_models.SaveChanges();
                return Results.StatusCode(200);
            }
            return Results.BadRequest();
        }

        [HttpPost]
        [Route("Edit")]
        public IResult EditGadget(int id, string Name, float Price)
        {
            var item = gadgetstore_models.Gadgets.FirstOrDefault(x => x.Id.Equals(id));

            if (item != null)
            {
                gadgetstore_models.Remove(item);
                gadgetstore_models.Add(new Gadget() { Name = Name, Price = Price });
                gadgetstore_models.SaveChanges();
                return Results.Ok();
            }
            return Results.BadRequest();
        }

        [HttpPost]
        [Route("Delete")]
        public IResult DelGadget(int id)
        {
           var item = gadgetstore_models.Gadgets.FirstOrDefault(x => x.Id.Equals(id));

            if (item != null)
            {
                gadgetstore_models.Remove(item);
                gadgetstore_models.SaveChanges();
                return Results.Ok();
            }
            return Results.BadRequest();
        }

        [HttpGet]
        [Route("Output")]
        public IResult Get()
        {
            return Results.Json(gadgetstore_models.Gadgets);
        }
    }
}