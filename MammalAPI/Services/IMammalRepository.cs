using System.Collections.Generic;
using System.Threading.Tasks;
using MammalAPI.Models;

namespace MammalAPI.Services
{
    public interface IMammalRepository
    {
        Task<List<Mammal>> GetAllMammals();
        Task<Mammal> GetMammalById(int id);

        Task<Mammal> GetMammalByLifeSpan(int lifespan);
    }
}
