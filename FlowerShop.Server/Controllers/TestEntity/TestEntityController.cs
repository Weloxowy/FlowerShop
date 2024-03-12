using System;
using System.Collections.Generic;
using System.Linq;
using FlowerShop.Server.Persistence.TestEntity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.TestEntity;
[Route("api/[controller]")]
[ApiController]
public class TestEntityController : ControllerBase
{
    private readonly TestEntityService _testEntityService = new TestEntityService();
    [HttpGet]
    public ActionResult<IEnumerable<Models.TestEntity>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var testEntities = session.Query<Models.TestEntity>().ToList();
            return Ok(testEntities);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Models.TestEntity> GetById(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var testEntity = session.Get<Models.TestEntity>(id);

            if (testEntity == null)
            {
                return NotFound();
            }

            return Ok(testEntity);
        }

    }
    [HttpPost]
    public ActionResult<Models.TestEntity> CreateKlientEntity([FromBody] Models.TestEntity testEntity)
    {
        if (testEntity == null)
        {
            return BadRequest("Invalid data");
        }
        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(testEntity);
                    transaction.Commit();
                    return CreatedAtAction(nameof(GetById), new { id = testEntity.id }, testEntity);
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
    public ActionResult DeleteKlientEntity(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var testEntity = session.Get<Models.TestEntity>(id);

                    if (testEntity == null)
                    {
                        return NotFound();
                    }


                    session.Delete(testEntity);


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