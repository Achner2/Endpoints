using API.Dto.Request;
using API.Dto.Response;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models.Entity;
using WebApplication2.Services;
using WebApplication2.Services.Interfaces;

namespace WebApplication2.Controllers


{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICrudService<UserRequest, UserResponse> _uService;
            
        public UserController(ICrudService<UserRequest, UserResponse> uService)
        {
            _uService = uService;
        }


        // GET: api/User-----------------------------------------------------------------
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserResponse>>> GetAll()
        {
            var users = await _uService.GetAll();
            return Ok(users);
        }

        // GET: api/User/{id}------------------------------------------------------------
        [HttpGet("{id}")]
        public async Task<ActionResult<UserResponse>> GetById(int id)
        {
            try
            {
                var user = await _uService.GetById(id);
                return Ok(user);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // POST: api/User------------------------------------------------------------------
        [HttpPost]
        public async Task<ActionResult> Add([FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _uService.Add(request);

            // Nota: No podemos devolver un Id directamente desde el request, ya que se genera en el backend.
            return Ok(new { message = "Usuario creado exitosamente." });
        }


        // PUT: api/User/{id}---------------------------------------------------------------
            [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _uService.Update(id, request);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        // DELETE: api/User/{id}-----------------------------------------------------------
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _uService.Delete(id);
                return NoContent();
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }

        }
    }
}
