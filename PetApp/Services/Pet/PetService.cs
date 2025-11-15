using Microsoft.EntityFrameworkCore;
using PetApp.Data;
using PetApp.ViewModel;

namespace PetApp.Services.Pet
{
    public class PetService : IPetService
    {
        private readonly PetAppContext _context;

        public PetService(PetAppContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public List<Models.Pet> GetPets()
        {
            return _context.Pet.AsNoTracking()
              .OrderBy(p => p.Name)
              .ToList();
        }
    }
}
