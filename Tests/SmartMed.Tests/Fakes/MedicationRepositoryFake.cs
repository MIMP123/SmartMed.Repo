using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SmartMed.Models.Models;
using SmartMed.Models.Repositories;

namespace SmartMed.Tests.Fakes
{
   public class MedicationRepositoryFake : IMedicationRepository
    {
        #region Variables

        private readonly List<Medication> _medications;

        #endregion

        #region Constructor

        public MedicationRepositoryFake()
        {
            _medications = new List<Medication>()
            {
                new Medication() { Id = 10, Name = "Aspirina", Quantity =0.2, CreationDate = DateTime.Now }
            };
        }

        #endregion

        #region Methods

        public IQueryable<Medication> GetAll()
        {
            return _medications?.AsQueryable();
        }

        public Task<Medication> GetByAsync(int id)
        {
            return Task.FromResult(_medications.FirstOrDefault(x => x.Id == id));
        }

        public Task<Medication> AddAsync(Medication cliente)
        {
            _medications.Add(cliente);
            return Task.FromResult(cliente);
        }

        public Task DeleteAsync(int id)
        {
            var exists = _medications.FirstOrDefault(x => x.Id == id);
            if (exists != null)
                _medications.Remove(exists);
            
            return Task.CompletedTask;
        }

        #endregion
    }
}
