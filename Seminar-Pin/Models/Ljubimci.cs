using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Seminar_Pin.Models
{
    public class Ljubimci
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Vrsta { get; set; }
        [DataType(DataType.Date)]
        public DateTime DatumRodenja { get; set; }
    }
}
