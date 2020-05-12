﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MammalAPI.Models;

namespace MammalAPI.Services
{
    public interface IFamilyRepository
    {
        Task<List<Family>> GetFamilyByName(string name);
        Task<List<Family>> GetFamilyById(int id);

    }
}