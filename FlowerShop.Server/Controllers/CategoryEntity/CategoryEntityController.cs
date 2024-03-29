using FlowerShop.Server.Persistence.AddressEntity;
using FlowerShop.Server.Persistence.CategoryEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.CategoryEntity
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class CategoryEntityController : ControllerBase
    {
        private readonly CategoryEntityService _categoryEntityService = new CategoryEntityService();

        [HttpGet]
        public ActionResult<IEnumerable<Models.CategoryEntity.CategoryEntity>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var categoryEntities = session.Query<Models.CategoryEntity.CategoryEntity>().ToList();
                return Ok(categoryEntities);
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<Models.CategoryEntity.CategoryEntity> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var categoryEntity = session.Get<Models.CategoryEntity.CategoryEntity>(id);
                if (categoryEntity == null)
                {
                    return NotFound();
                }

                return Ok(categoryEntity);
            }
        }

        [HttpPost]
        public ActionResult<Models.CategoryEntity.CategoryEntity> CreateCategoryEntity([FromBody] Models.CategoryEntity.CategoryEntity categoryEntity)
        {
            if (categoryEntity == null)
            {
                return BadRequest("Invalid data");
            }

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(categoryEntity);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = categoryEntity.id }, categoryEntity);
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
        public ActionResult DeleteCategoryEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var categoryEntity = session.Get<Models.CategoryEntity.CategoryEntity>(id);

                        if (categoryEntity == null)
                        {
                            return NotFound();
                        }


                        session.Delete(categoryEntity);


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
