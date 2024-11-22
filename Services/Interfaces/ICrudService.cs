namespace WebApplication2.Services.Interfaces
{
    public interface ICrudService<TRequest, TResponse>
        where TRequest : class
        where TResponse : class
    {
        Task<IEnumerable<TResponse>> GetAll();
        Task<TResponse> GetById(int id);                     
        Task Add(TRequest request);                          
        Task Update(int id, TRequest request);               
        Task Delete(int id);                                 
    }
}
