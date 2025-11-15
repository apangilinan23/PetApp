using System.Collections.Generic;
using PetApp.ViewModel;

namespace PetApp.Services.Pet
{
    public interface IPetService
    {
        List<Models.Pet> GetPets();
        Models.Pet? GetPetById(int id);
        void UpdatePet(Models.Pet pet);
    }
}
