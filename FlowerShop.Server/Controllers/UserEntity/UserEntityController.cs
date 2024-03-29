using FlowerShop.Server.Models.UserEntity;
using FlowerShop.Server.Persistence.User;
using FlowerShop.Server.Persistence.UserEntity;
using Microsoft.AspNetCore.Authorization;
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
                    var existingUser = session.Query<UserEntity>().FirstOrDefault(u => u.EmailAddress == testEntity.EmailAddress);
                    if (existingUser != null)
                    {
                        return Conflict("Email address already exists");
                    }
                    //UserEntityService userEntityService = new UserEntityService();
                    if (!_userEntityService.VerifyEmail(testEntity.EmailAddress))
                    {
                        return Conflict("Email address is wrong");
                    }
                    if (!_userEntityService.VerifyPassword(testEntity.Password))
                    {
                        return Conflict("Password is too short");
                    }
                    session.Save(testEntity);
                   
                    testEntity.Password = _userEntityService.HashPassword(testEntity.Password, 16);
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
    [HttpPut]
    public ActionResult<Models.UserEntity.UserEntity> EditUserEntity([FromBody] Models.UserEntity.UserEntity userEntity)
    {
        if (userEntity == null)
        {
            return BadRequest("Invalid data");
        }

        using (var session = NHibernateHelper.OpenSession())
        {
            using (var transaction = session.BeginTransaction())
            {
                try
                {

                    var existingUser = session.Query<Models.UserEntity.UserEntity>().FirstOrDefault(u => u.id == userEntity.id);
                    if (existingUser == null)
                    {
                        return NotFound("User not found");
                    }

                   
                    var userWithSameEmail = session.Query<Models.UserEntity.UserEntity>().FirstOrDefault(u => u.EmailAddress == userEntity.EmailAddress && u.id != userEntity.id);
                    if (userWithSameEmail != null)
                    {
                        return Conflict("Email address already exists");
                    }


                    if (!_userEntityService.VerifyEmail(userEntity.EmailAddress))
                    {
                        return Conflict("Email address is wrong");
                    }
                    if (!_userEntityService.VerifyPassword(userEntity.Password))
                    {
                        return Conflict("Password is too short");
                    }


                    existingUser.EmailAddress = userEntity.EmailAddress;
                    existingUser.Password = _userEntityService.HashPassword(userEntity.Password, 16);


                    session.Update(existingUser);
                    transaction.Commit();

                    return Ok(existingUser);
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

