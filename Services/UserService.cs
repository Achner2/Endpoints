using API.Dto.Request;
using API.Dto.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models.DB;
using WebApplication2.Models.Entity;
using WebApplication2.Services.Interfaces;
namespace WebApplication2.Services


{
    public class UserService : ICrudService<UserRequest,UserResponse>
    {
        //Inyeccion de dependencias
        private readonly BaseDatos _context;
        private readonly DbSet<User> _userDbSet;
        private readonly IMapper _iMapper;

        public UserService(BaseDatos context, IMapper iMapper)
        {
            _context = context;
            _userDbSet = _context.Set<User>();
            _iMapper = iMapper;
        }
        //_______________________________________________________________
        public async Task Add(UserRequest request)
        {
            if (request == null)
            {throw new ArgumentNullException(nameof(request));}
            var user = _iMapper.Map<User>(request);
            await _userDbSet.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        //_______________________________________________________________

        public async Task Delete(int id)
        {
            var user = await _userDbSet.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID {id} not found.");
            }
            _userDbSet.Remove(user);
            await _context.SaveChangesAsync();
        }
        //______________________________________________________________
        public async Task<IEnumerable<UserResponse>> GetAll()
        {
            var users = await _userDbSet.ToListAsync();
            return _iMapper.Map<IEnumerable<UserResponse>>(users);
        }
        //______________________________________________________________
        public async Task<UserResponse> GetById(int id)
        {
            var user = await _userDbSet.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"user not found with {id} :(");
            }

            return _iMapper.Map<UserResponse>(user);
        }

        public async Task Update(int id, UserRequest request)
        {
            var user = await _userDbSet.FindAsync(id);
            if (user == null)
            {
                throw new KeyNotFoundException($"User with {id} not found");
            }
            _iMapper.Map(request, user);

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
        
    }
}
