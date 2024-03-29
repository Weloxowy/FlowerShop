using FlowerShop.Server.Persistence.OrderDetailsEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.OrderDetailsEntity
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsEntityController : ControllerBase
    {
        private readonly OrderDetailsEntityService _orderDetailsEntityService = new OrderDetailsEntityService();

        [HttpGet]
        public ActionResult<IEnumerable<Models.OrderDetailsEntity.OrderDetailsEntity>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var orderDetailsEntities = session.Query<Models.OrderDetailsEntity.OrderDetailsEntity>().ToList();
                return Ok(orderDetailsEntities);
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<Models.OrderDetailsEntity.OrderDetailsEntity> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var orderDetailsEntity = session.Get<Models.OrderDetailsEntity.OrderDetailsEntity>(id);
                if (orderDetailsEntity == null)
                {
                    return NotFound();
                }

                return Ok(orderDetailsEntity);
            }
        }

        [HttpPost]
        public ActionResult<Models.OrderDetailsEntity.OrderDetailsEntity> CreateOrderDetailsEntity([FromBody] Models.OrderDetailsEntity.OrderDetailsEntity orderDetailsEntity)
        {
            if (orderDetailsEntity == null)
            {
                return BadRequest("Invalid data");
            }

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(orderDetailsEntity);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = orderDetailsEntity.id }, orderDetailsEntity);
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
        public ActionResult DeleteOrderDetailsEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var orderDetailsEntity = session.Get<Models.OrderDetailsEntity.OrderDetailsEntity>(id);

                        if (orderDetailsEntity == null)
                        {
                            return NotFound();
                        }


                        session.Delete(orderDetailsEntity);


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

