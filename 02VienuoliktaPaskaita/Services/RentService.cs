using VienuoliktaPaskaita.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienuoliktaPaskaita.Models;

namespace VienuoliktaPaskaita.Services
{
    public class NuomaService : IDatabaseRepository
    {
        private readonly IDatabaseRepository _repository;

        public NuomaService(IDatabaseRepository repository)
        {
            _repository = repository;
        }

        public void RegistruotiAutomobilis(NaftosKuroAutomobilis automobilis)
        {
            _repository.AddAutomobilis(automobilis);
        }

        public void RegistruotiAutomobilis(Elektromobilis automobilis)
        {
            _repository.AddAutomobilis(automobilis);
        }

        public void AtnaujintiAutomobilis(Automobilis automobilis)
        {
            _repository.UpdateAutomobilis(automobilis);
        }

        public void IstrintiAutomobilis(int id)
        {
            _repository.DeleteAutomobilis(id);
        }

        public IEnumerable<Automobilis> GautiAutomobiliai()
        {
            return _repository.GetAllAutomobiliai();
        }

        public void IsnuomotiAutomobili(Nuoma nuoma)
        {
            var existingRentals = _repository.GetAllNuomos()
                .Where(r => r.AutomobilisId == nuoma.AutomobilisId &&
                            ((r.Nuo <= nuoma.Nuo && r.Iki >= nuoma.Nuo) ||
                             (r.Nuo <= nuoma.Iki && r.Iki >= nuoma.Iki)));

            if (existingRentals.Any())
            {
                throw new InvalidOperationException("Automobilis jau isnuomotas pasirinktu laikotarpiu.");
            }

            _repository.RentAutomobilis(nuoma);
        }

        public IEnumerable<Nuoma> GautiNuomos()
        {
            return _repository.GetAllNuomos();
        }

        public void AddAutomobilis(Automobilis automobilis)
        {
            _repository.AddAutomobilis(automobilis);
        }

        public void UpdateAutomobilis(Automobilis automobilis)
        {
            _repository.UpdateAutomobilis(automobilis);
        }

        public Automobilis GetAutomobilisById(int id)
        {
            return _repository.GetAutomobilisById(id);
        }

        public IEnumerable<Automobilis> GetAllAutomobiliai()
        {
            return _repository.GetAllAutomobiliai();
        }

        public void DeleteAutomobilis(int id)
        {
            _repository.DeleteAutomobilis(id);
        }

        public void RentAutomobilis(Nuoma nuoma)
        {
            _repository.RentAutomobilis(nuoma);
        }

        public IEnumerable<Nuoma> GetAllNuomos()
        {
            return _repository.GetAllNuomos();
        }
    }
}
