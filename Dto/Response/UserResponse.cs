using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.Dto.Response
{
    public class UserResponse
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string? Phone { get; set; }
    }
}
