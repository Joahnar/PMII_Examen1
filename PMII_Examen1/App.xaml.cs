using PMII_Examen1.Data;

namespace PMII_Examen1
{
    public partial class App : Application
    {
        
        private static EmpleadoDatabase _database;

        public static EmpleadoDatabase Database
        {
            get {
                
                if (_database == null) { // si es null crear una base de datos
                    string dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "empleados.db3"
                        );
                    _database = new EmpleadoDatabase(dbPath);
                }
                return _database;
            }
        }
        
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }
    }
}