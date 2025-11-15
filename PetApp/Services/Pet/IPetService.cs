using PetApp.ViewModel;

namespace PetApp.Services.Pet
{
    public interface IPetService
    {
        public List<Models.Pet> GetPets();
    }
}
