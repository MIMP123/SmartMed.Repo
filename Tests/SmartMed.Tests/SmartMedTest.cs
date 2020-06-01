using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SmartMed.Controllers;
using SmartMed.Models.Models;
using SmartMed.Models.Repositories;
using SmartMed.Tests.Fakes;
using Xunit;

namespace SmartMed.Tests
{
    public class SmartMedTest
    {
        MedicationsController _controller;
        IMedicationRepository _medicationRepository;

        public SmartMedTest()
        {
            _medicationRepository = new MedicationRepositoryFake();
            _controller = new MedicationsController(_medicationRepository);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsOkResult()
        {
            // Act
            var okResult = await _controller.GetMedications();

            // Assert
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public async Task Get_WhenCalled_ReturnsAllItemsAsync()
        {
            // Act
            var okResult = await _controller.GetMedications();

            // Assert
            var items = Assert.IsType<List<Medication>>(okResult.Value);
            Assert.Equal(3, items.Count);
        }
    }
}
