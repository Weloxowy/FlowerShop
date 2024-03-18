using FlowerShop.Server.Persistence.User;
using FlowerShop.Server.Persistence.UserEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.User;
[EnableCors("AllowAllOrigins")]
[Route("api/[controller]")]
    [ApiController]

    public class UserEntityController : ControllerBase
    {
    private readonly UserEntityService _userEntityService = new UserEntityService();

    [HttpGet]
    public ActionResult<IEnumerable<Models.UserEntity.UserEntity>> GetAll() 
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var userEntities = session.Query<Models.UserEntity.UserEntity>().ToList();
            return Ok(userEntities);
        }
    }

    [HttpGet("id/{id}")]
    public ActionResult<Models.UserEntity.UserEntity> GetById(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            var userEntity = session.Get<Models.UserEntity.UserEntity>(id);
            UserEntityService user = new UserEntityService();
            Console.WriteLine(user.VerifyPassword("[tu wpisz haslo]", userEntity.Password));
            if (userEntity == null)
            {
                return NotFound();
            }

            return Ok(userEntity);
        }
    }

    [HttpPost]
    public ActionResult<Models.UserEntity.UserEntity> CreateKlientEntity([FromBody] Models.UserEntity.UserEntity testEntity)
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
                    
                    UserEntityService userEntityService = new UserEntityService();
                    testEntity.Password = userEntityService.HashPassword(testEntity.Password, 16);
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
    public ActionResult DeleteUserEntity(Guid id)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {
                    var userEntity = session.Get<Models.UserEntity.UserEntity>(id);

                    if (userEntity == null)
                    {
                        return NotFound();
                    }


                    session.Delete(userEntity);


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
    [HttpGet("users/login/{login}")]
    public ActionResult<Models.UserEntity.UserEntity> LoginVerification(string login, string password)
    {
        using (var session = NHibernateHelper.OpenSession())
        {
            try {
                var userEntity = session.QueryOver<Models.UserEntity.UserEntity>()
                                    .Where(u => u.Login == login)
                                    .SingleOrDefault();

                if (userEntity == null)
                {
                    Console.WriteLine("Brak dopasowania");
                    return NotFound();
                }

                UserEntityService user = new UserEntityService();
                bool passwordVerified = user.VerifyPassword(password, userEntity.Password);

                if (!passwordVerified)
                {
                    Console.WriteLine("Nieprawidłowe hasło");
                    return Unauthorized();
                }

                Console.WriteLine("Działa");
                return Ok(userEntity);
                }
            catch (Exception ex)
            {
                return Unauthorized();
            }
        }
    }


}

