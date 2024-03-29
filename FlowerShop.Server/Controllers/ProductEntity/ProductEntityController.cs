using FlowerShop.Server.Models.ProductEntity;
using FlowerShop.Server.Persistence.ProductEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.ProductEntity
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductEntityController : ControllerBase
    {
        private readonly ProductEntityService _productEntityService = new ProductEntityService();
        private readonly ProductEntityRepository _productEntityRepository = new ProductEntityRepository();
        [HttpGet]
        public ActionResult<IEnumerable<Models.ProductEntity.ProductEntity>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var productEntities = session.Query<Models.ProductEntity.ProductEntity>().ToList();
                return Ok(productEntities);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Models.ProductEntity.ProductEntity> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var productEntity = session.Get<Models.ProductEntity.ProductEntity>(id);

                if (productEntity == null)
                {
                    return NotFound();
                }

                return Ok(productEntity);
            }

        }
        [HttpPost]
        public ActionResult<Models.ProductEntity.ProductEntity> CreateProductEntity([FromBody] Models.ProductEntity.ProductEntity productEntity)
        {
            if (productEntity == null)
            {
                return BadRequest("Invalid data");
            }
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(productEntity);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = productEntity.id }, productEntity);
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }

        }
        [HttpDelete("{id}")]
        public ActionResult DeleteProductEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var productEntity = session.Get<Models.ProductEntity.ProductEntity>(id);

                        if (productEntity == null)
                        {
                            return NotFound();
                        }


                        session.Delete(productEntity);


                        transaction.Commit();

                        return NoContent();
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
                    }
                }
            }
        }
    }
}
