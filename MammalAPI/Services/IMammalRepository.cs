using System.Collections.Generic;
using System.Threading.Tasks;
using MammalAPI.DTO;
using MammalAPI.Models;

namespace MammalAPI.Services
{
    public interface IMammalRepository
    {
        Task<List<Mammal>> GetAllMammals();
        Task<Mammal> GetMammalById(int id);
        Task<List<IdNameDTO>> GetMammalsByHabitat(string habitatName);
        Task<List<IdNameDTO>> GetMammalsByHabitatId(int id);
        Task<List<MammalLifespanDTO>> GetMammalsByLifeSpan(int fromYear, int toYear);
        Task<List<IdNameDTO>> GetMammalsByFamily(string familyName);
        Task<List<IdNameDTO>> GetMammalsByFamilyId(int id);
    }
}
