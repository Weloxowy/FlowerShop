using FlowerShop.Server.Persistence.OrderEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.OrderEntity
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class OrderEntityController : ControllerBase
    {

        private readonly OrderEntityService _orderEntityService = new OrderEntityService();

        [HttpGet]
        public ActionResult<IEnumerable<Models.OrderEntity.OrderEntity>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var orderEntities = session.Query<Models.OrderEntity.OrderEntity>().ToList();
                return Ok(orderEntities);
            }
        }

        [HttpGet("id/{id}")]
        public ActionResult<Models.OrderEntity.OrderEntity> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var orderEntity = session.Get<Models.OrderEntity.OrderEntity>(id);
                if (orderEntity == null)
                {
                    return NotFound();
                }

                return Ok(orderEntity);
            }
        }

        [HttpPost]
        public ActionResult<Models.OrderEntity.OrderEntity> CreateOrderEntity([FromBody] Models.OrderEntity.OrderEntity orderEntity)
        {
            if (orderEntity == null)
            {
                return BadRequest("Invalid data");
            }

            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        session.Save(orderEntity);
                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = orderEntity.id }, orderEntity);
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
        public ActionResult DeleteOrderEntity(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    try
                    {
                        var orderEntity = session.Get<Models.OrderEntity.OrderEntity>(id);

                        if (orderEntity == null)
                        {
                            return NotFound();
                        }


                        session.Delete(orderEntity);


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

