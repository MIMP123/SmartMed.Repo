using SmartMed.Models.Models;

namespace SmartMed.Models.Repositories
{
    public class MedicationRepository : GenericRepository<Medication>, IMedicationRepository
    {
        #region variables

        private readonly SmartMedContext _context;

        #endregion

        public MedicationRepository(SmartMedContext Context)
        : base(Context)
        {

        }
    }
}
