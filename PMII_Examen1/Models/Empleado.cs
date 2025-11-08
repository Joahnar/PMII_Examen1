using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace PMII_Examen1.Models
{
    public class Empleado {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200), NotNull]
        public string Nombre { get; set; }

        public DateTime Fecha_Ingreso { get; set; }

        [MaxLength(100), NotNull]
        public string Puesto { get; set; }

        [MaxLength(100)]
        public string Correo { get; set; }

        public string Foto { get; set; }

        public string FechaIngresoFormateada => Fecha_Ingreso.ToString("dd/MM/yyyy");

        public Empleado(){
            Fecha_Ingreso = DateTime.Now;
            
        }
    }
}
