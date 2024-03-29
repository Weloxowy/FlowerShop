using FlowerShop.Server.Models.UserEntity;
using FlowerShop.Server.Persistence.AddressEntity;
using FlowerShop.Server.Persistence.CategoryEntity;
using FlowerShop.Server.Persistence.UserEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FlowerShop.Server.Controllers.CategoryEntity
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class AspNetUsersController : ControllerBase
    {
        
        private readonly UserEntityService _userEntityService = new UserEntityService();
        [HttpGet]
        public ActionResult<IEnumerable<Models.UserEntity.AspNetUsers>> GetAll()
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var categoryEntities = session.Query<Models.UserEntity.AspNetUsers>().ToList();
                return Ok(categoryEntities);
            }
        }
        [HttpGet("id/{id}")]
        public ActionResult<Models.UserEntity.AspNetUsers> GetById(Guid id)
        {
            using (var session = NHibernateHelper.OpenSession())
            {
                var userEntity = session.Get<Models.UserEntity.AspNetUsers>(id);
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
        public ActionResult<Models.UserEntity.AspNetUsers> CreateKlientEntity([FromBody] Models.UserEntity.AspNetUsers testEntity)
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
                        var passwordHasher = new PasswordHasher<AspNetUsers>();
                        string hashedPassword = passwordHasher.HashPassword(null, testEntity.Password);
                        testEntity.PasswordHash = hashedPassword;

                        if (!_userEntityService.VerifyPassword(testEntity.Password))
                        {
                            return Conflict("Password is too short");
                        }
                        session.Save(testEntity);

                        if (testEntity.Email != null)
                            testEntity.NormalizedEmail = testEntity.Email.ToUpper();
                        if (testEntity.UserName != null)
                            testEntity.NormalizedUserName = testEntity.UserName.ToUpper();

                        transaction.Commit();
                        return CreatedAtAction(nameof(GetById), new { id = testEntity.Id }, testEntity);
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
                        var userEntity = session.Get<Models.UserEntity.AspNetUsers>(id);

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
    public ActionResult<Models.UserEntity.AspNetUsers> EditUserEntity([FromBody] Models.UserEntity.AspNetUsers userEntity)
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

                    var existingUser = session.Query<Models.UserEntity.AspNetUsers>().FirstOrDefault(u => u.Id == userEntity.Id);
                    if (existingUser == null)
                    {
                        return NotFound("User not found");
                    }

                    if (!_userEntityService.VerifyPassword(userEntity.Password))
                    {
                        return Conflict("Password is too short");
                    }


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
}
