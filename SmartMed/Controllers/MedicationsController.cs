using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartMed.Models;
using SmartMed.Models.Models;
using SmartMed.Models.Repositories;

namespace SmartMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicationsController : ControllerBase
    {
        #region variables

        private readonly IMedicationRepository _medicationRepository;

        #endregion

        #region Constructors

        public MedicationsController(IMedicationRepository medicationRepository)
        {
            _medicationRepository = medicationRepository;
        }

        #endregion

        #region Methods

        // GET: api/Medications
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Medication>>> GetMedications()
        {
            return await _medicationRepository.GetAll()?.ToListAsync();
        }

        // GET: api/Medications/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Medication>> GetMedication(int id)
        {
            var medication = await _medicationRepository.GetByAsync(id);

            if (medication == null)
                return NotFound();

            return medication;
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Medication>> PostMedication([FromBody]Medication medication)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var _medication = await _medicationRepository.AddAsync(medication);

            return CreatedAtAction("GetMedication", new { id = _medication.Id }, _medication);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Medication>> DeleteMedication(int id)
        {
            var medication = await _medicationRepository.GetByAsync(id);
            if (medication == null)
                return NotFound();

            await _medicationRepository.DeleteAsync(id);

            return Ok(medication);
        }

        #endregion
    }
}
