using DapperAsp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperAsp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {
        private static gadgetstore_dbContext gadgetstore_models = new gadgetstore_dbContext();

        [HttpPost]
        [Route("AddCategory")]
        public IResult AddCategory(string NameProduct)
        {
            var item = gadgetstore_models.Categories.FirstOrDefault(x => x.NameProduct.Equals(NameProduct));

            if (item == null)
            {
                gadgetstore_models.Add(new Gadget() { Name = NameProduct});
                gadgetstore_models.SaveChanges();
                return Results.Ok();
            }
            return Results.BadRequest();
        }

        [HttpPost]
        [Route("EditCategory")]
        public IResult EditGadget(int id, string NameProduct)
        {
            var item = gadgetstore_models.Categories.FirstOrDefault(x => x.Id.Equals(id));

            if (item != null)
            {
                gadgetstore_models.Remove(item);
                gadgetstore_models.Add(new Category() { NameProduct = NameProduct});
                gadgetstore_models.SaveChanges();
                return Results.Ok();
            }
            return Results.NotFound();
        }

        [HttpPost]
        [Route("DeleteCategory")]
        public IResult DelGadget(int id)
        {
            var item = gadgetstore_models.Categories.FirstOrDefault(x => x.Id.Equals(id));

            if (item != null)
            {
                gadgetstore_models.Remove(item);
                gadgetstore_models.SaveChanges();
                return Results.Ok();
            }
            return Results.NotFound();
        }

        [HttpGet]
        [Route("OutputCategory")]
        public List<Category> Get()
        {
            return gadgetstore_models.Categories.ToList();
        }
    }
}