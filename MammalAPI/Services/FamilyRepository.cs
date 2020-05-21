﻿using System.Threading.Tasks;
using MammalAPI.Models;
using MammalAPI.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using MammalAPI.DTO;
using Microsoft.Extensions.Logging;





namespace MammalAPI.Services
{
    public class FamilyRepository : Repository, IFamilyRepository
    {
        public FamilyRepository(DBContext DBContext, ILogger<FamilyRepository> logger) : base (DBContext, logger)
        { }

        public async Task<FamilyDTO> GetFamilyByName(string name)
        {
            _logger.LogInformation($"Getting mammal family by { name }.");
            var query = _dBContext.Families.Where(s => s.Name == name)
                .Select(s => new FamilyDTO
                {
                    FamilyID = s.FamilyId,
                    Name = s.Name
                });

            if (query == null) throw new System.Exception($"Not found {name}");

            return await query.FirstOrDefaultAsync();
        }

        public async Task<FamilyDTO> GetFamilyById(int id)
        {
            _logger.LogInformation($"Getting mammal family by { id }.");
            var query = _dBContext.Families.Where(s => s.FamilyId == id)
                .Select(s => new FamilyDTO
                {
                    FamilyID = s.FamilyId,
                    Name = s.Name
                });

            if (query == null) throw new System.Exception($"Mammal family not found on id: {id}");

            return await query.FirstOrDefaultAsync();              
        }

        public async Task<List<FamilyDTO>> GetAllFamilies()
        {
            _logger.LogInformation($"Getting all families");
            var query = _dBContext.Families
                .Select(x => new FamilyDTO
                {
                    FamilyID = x.FamilyId,
                    Name = x.Name
                });
            if (query == null) throw new System.Exception($"Something went wrong.");


            return await query.ToListAsync();
        }
    }
}
