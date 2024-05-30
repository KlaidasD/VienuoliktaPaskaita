using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VienuoliktaPaskaita.Models;

namespace VienuoliktaPaskaita.Repositories
{
    public interface IDatabaseRepository
    {
        void AddAutomobilis(Automobilis automobilis);
        void UpdateAutomobilis(Automobilis automobilis);
        Automobilis GetAutomobilisById(int id);
        IEnumerable<Automobilis> GetAllAutomobiliai();
        void DeleteAutomobilis(int id);
        void RentAutomobilis(Nuoma nuoma);
        IEnumerable<Nuoma> GetAllNuomos();
    }
}

