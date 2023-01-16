using TodoApi.Model;
using TodoApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Annotations;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("Obter todos os usuarios")]
        [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest,  nameof(HttpStatusCode.BadRequest))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError))]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{id}")]
        [Route("Obter usuario pelo id")]
        [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest,  nameof(HttpStatusCode.BadRequest))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError))]

        public async Task<ActionResult<User>> GetUsers(int id) => await _userRepository.Get(id);
        
        [HttpPost]
        [Route("Criar usuario")]
        [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest,  nameof(HttpStatusCode.BadRequest))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError))]
        public async Task<ActionResult<User>> PostUsers([FromBody] User user)
        {
            try
            {

                var newUser = await _userRepository.Create(user);
                return CreatedAtAction(nameof(GetUsers), new {id = newUser.Id});

            }
            catch (Exception e)
            {

                throw new ArgumentException("Não foi possivel adcionar um novo usuario, email ou cpf ja cadastrado!",
                    e);
            }

        }

        [HttpDelete("{Id}")]
        [Route("Deletar usuario")]
        [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest,  nameof(HttpStatusCode.BadRequest))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError))]

        public async Task<ActionResult> Delete(int Id)
        {
            var userToDelete = await _userRepository.Get(Id);

            if (userToDelete == null)
                return NotFound();

            await _userRepository.Delete(userToDelete.Id);
            return NoContent();

        }

        [HttpPut]
        [Route("Atualizar usuario")]
        [SwaggerResponse((int)HttpStatusCode.OK, nameof(HttpStatusCode.OK))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest,  nameof(HttpStatusCode.BadRequest))]
        [SwaggerResponse((int)HttpStatusCode.InternalServerError, nameof(HttpStatusCode.InternalServerError))]
        public async Task<ActionResult> PutUsers(int Id, [FromBody] User user)
        {
            try
            {

                if (Id != user.Id)
                    return BadRequest();

                await _userRepository.Update(user);

                return NoContent();

            }
            catch (Exception e)
            {

                throw new Exception("Nao foi possivel atualiar o dados do usuario!", e);
            }
        }
    }
}
    
