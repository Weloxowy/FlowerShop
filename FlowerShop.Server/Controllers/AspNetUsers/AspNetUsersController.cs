using System.Security.Claims;
using FlowerShop.Server.Models.UserEntity;
using FlowerShop.Server.Persistence.AddressEntity;
using FlowerShop.Server.Persistence.CategoryEntity;
using FlowerShop.Server.Persistence.UserEntity;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
namespace FlowerShop.Server.Controllers.CategoryEntity
{
    [EnableCors("AllowAllOrigins")]
    [Route("api/[controller]")]
    [ApiController]

    public class AspNetUsersController : ControllerBase
    {
        
        private readonly UserEntityService _userEntityService = new UserEntityService();
        
        [HttpGet("info")]
        public async Task<IActionResult> GetUserInfo()
        {
            // Check if user is authenticated
            var user = HttpContext.User;
            if (user.Identity != null && user.Identity.IsAuthenticated)
            {
                // Retrieve user ID from claims
                var userIdClaim = user.FindFirst(ClaimTypes.NameIdentifier);
                if (userIdClaim == null)
                {
                    return BadRequest("User ID claim not found.");
                }

                // Parse user ID
                if (!Guid.TryParse(userIdClaim.Value, out Guid userId))
                {
                    return BadRequest("Invalid user ID format.");
                }

                // Retrieve user entity by ID
                using (var session = NHibernateHelper.OpenSession())
                {
                    var userEntity = session.Get<Models.UserEntity.AspNetUsers>(userIdClaim.Value);
                    if (userEntity == null)
                    {
                        return NotFound("User not found.");
                    }

                    return Ok(userEntity);
                }
            }
            else
            {
                // User is not authenticated
                return Unauthorized();
            }
        }
        
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
