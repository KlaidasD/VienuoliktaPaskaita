using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VienuoliktaPaskaita.Models
{
    public class Nuoma
    {
        public int Id { get; set; }
        public int AutomobilisId { get; set; }
        public int KlientasId { get; set; }
        public DateTime Nuo { get; set; }
        public DateTime Iki { get; set; }
    }
}
