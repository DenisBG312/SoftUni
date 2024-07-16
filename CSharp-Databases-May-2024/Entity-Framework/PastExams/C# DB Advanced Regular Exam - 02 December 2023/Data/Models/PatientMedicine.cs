using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medicines.Data.Models
{
    public class PatientMedicine
    {
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; }
    }


    //•	PatientId – integer, Primary Key, foreign key(required)
    //•	Patient – Patient
    //•	MedicineId – integer, Primary Key, foreign key(required)
    //•	Medicine – Medicine

}
