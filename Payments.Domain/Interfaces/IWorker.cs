using System.Threading.Tasks;
using Payments.Domain.DTOs;

namespace Payments.Domain.Interfaces
{
    public interface IWorker<T> where T : class
    {
         Task<APIResponseDTO> Add(T model);
         Task<APIResponseDTO> Update(int id, T model);
         Task<APIResponseDTO> Delete(int id);
    }
}