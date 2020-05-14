using System;
using Xunit;
using System.Collections.Generic;
using System.Linq;
using MammalAPI;
using MammalAPI.Models;
using MammalAPI.Controllers;
using MammalAPI.Services;
using Microsoft.AspNetCore.Mvc;
using MammalAPI.Context;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.EntityFrameworkCore;

namespace XUnitTest
{
    public class HabitatRepositoryTest
    {
        [Fact]
        public void GetHabitatByName_FourDifferentHabitats_NameIsEast()
        {
            // Arrange
            var habitatName = "East";
            var habitats = GetMoqHabitats();
            var contextMock = new Mock<DBContext>();
            contextMock.Setup(h => h.Habitats).ReturnsDbSet(habitats);
            var logger = Mock.Of<ILogger<HabitatRepository>>();
            
            var habitatRepository = new HabitatRepository(contextMock.Object, logger);

            // Act
            var testResult = habitatRepository.GetHabitatByName(habitatName);

            // Assert
            Assert.Equal(habitatName, testResult.Result.Name);
        }

        private List<Mammal> GetTestSessions()
        {
            var sessions = new List<Mammal>();
            sessions.Add(new Mammal()
            {
                MammalId = 1,
                Name = "Test Mammal One",
                LatinName = "Bapa latin apa"
            });
            sessions.Add(new Mammal()
            {
                MammalId = 2,
                Name = "Test Mammal Two",
                LatinName = "Latin kanske med"
            });
            return sessions;
        }

        private IList<Habitat> GetMoqHabitats()
        {
            var habitats = new List<Habitat>();
            habitats.Add(new Habitat
            {
                HabitatID = 1,
                Name = "North",
                MammalHabitats = null
            });
            habitats.Add(new Habitat
            {
                HabitatID = 2,
                Name = "East",
                MammalHabitats = null
            });
            habitats.Add(new Habitat
            {
                HabitatID = 3,
                Name = "South",
                MammalHabitats = null
            });
            habitats.Add(new Habitat
            {
                HabitatID = 4,
                Name = "West",
                MammalHabitats = null
            });
            return habitats;
        }

    }
}