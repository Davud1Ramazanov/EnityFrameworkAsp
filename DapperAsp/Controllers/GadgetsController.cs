using DapperAsp.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DapperAsp.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class GadgetsController : ControllerBase
    {
       private static gadgetstore_dbContext gadgetstore_models = new gadgetstore_dbContext();

        [HttpPost]
        [Route("Insert")]
        public IResult AddGadget(string Name, float Price)
        {
            var item = gadgetstore_models.Gadgets.FirstOrDefault(x => x.Name.Equals(Name) && x.Price.Equals(Price));

            if (item == null)
            {
               gadgetstore_models.Add(new Gadget() { Name = Name, Price = Price});
               gadgetstore_models.SaveChanges();
                return Results.Ok();
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
        public List<Gadget> Get()
        {
            return gadgetstore_models.Gadgets.ToList();
        }
    }
}