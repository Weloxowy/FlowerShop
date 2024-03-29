using FlowerShop.Server.Persistence.CompanyEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.CompanyEntity;
[EnableCors("AllowAllOrigins")]
[Route("api/[controller]")]
[ApiController]
public class CompanyEntityController : ControllerBase
{
    private readonly CompanyEntityService _companyEntityService = new CompanyEntityService();
    [HttpGet]
    public ActionResult<IEnumerable<Models.CompanyEntity.CompanyEntity>> GetAll()
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var companyEntities = session.Query<Models.CompanyEntity.CompanyEntity>().ToList();
            return Ok(companyEntities);
        }
    }
    [HttpGet("{id}")]
    public ActionResult<Models.CompanyEntity.CompanyEntity> GetById(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var companyEntity = session.Get<Models.CompanyEntity.CompanyEntity>(id);

            if (companyEntity == null)
            {
                return NotFound();
            }

            return Ok(companyEntity);
        }

    }
    [HttpPost]
    public ActionResult<Models.CompanyEntity.CompanyEntity> CreateCompanyEntity([FromBody] Models.CompanyEntity.CompanyEntity companyEntity)
    {
        if (companyEntity == null)
        {
            return BadRequest("Invalid data");
        }
        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    session.Save(companyEntity);
                    transaction.Commit();
                    return CreatedAtAction(nameof(GetById), new { id = companyEntity.id }, companyEntity);
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
    public ActionResult DeleteCompanyEntity(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var companyEntity = session.Get<Models.CompanyEntity.CompanyEntity>(id);

                    if (companyEntity == null)
                    {
                        return NotFound();
                    }


                    session.Delete(companyEntity);


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
