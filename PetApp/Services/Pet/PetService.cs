using System;
using System.Collections.Generic;
using System.Linq;
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
            return _context.Pet
                .AsNoTracking()
                .OrderBy(p => p.Name)
                .ToList();
        }

        public Models.Pet? GetPetById(int id)
        {
            // Use Find to get a tracked entity for editing.
            return _context.Pet.Find(id);
        }

        public void UpdatePet(Models.Pet pet)
        {
            if (pet is null) throw new ArgumentNullException(nameof(pet));

            // Attach/update and persist changes.
            _context.Pet.Update(pet);
            _context.SaveChanges();
        }
    }
}
