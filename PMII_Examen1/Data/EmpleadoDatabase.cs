using System;
using SQLite;
using PMII_Examen1.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMII_Examen1.Data
{
    //Maneja todas las operaciones de base de datos para empleados
    public class EmpleadoDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public EmpleadoDatabase(string dbPath) { 
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Empleado>().Wait();
        }

        //Obtener todos los empleados de la base de datos
        public Task<List<Empleado>> ObtenerEmpleadosAsync() { 
            return _database.Table<Empleado>().ToListAsync();
        }

        public Task<Empleado> ObtenerEmpleadoPorIdAsync(int id) {
            return _database.Table<Empleado>()
                            .Where(e => e.Id == id)
                            .FirstOrDefaultAsync();
        }
        
        //Guardar empleado en caso de que ya existe actualizar info y de caso contrario insertar como un nuevo empleado
        public Task<int> GuardarEmpleadoAsync(Empleado empleado) {
            if (empleado.Id != 0)
            {
                return _database.UpdateAsync(empleado);
            }
            else { 
                return _database.InsertAsync(empleado);
            }
        }

        //Eliminar empleado
        public Task<int> EliminarEmpleadoAsync(Empleado empleado) { 
            return _database.DeleteAsync(empleado); 
        }
    }
}
