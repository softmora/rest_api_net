using Microsoft.EntityFrameworkCore;

namespace web_api_db.Models{
    
    //Crear clase con herencia a la conexion
    class Conexion : DbContext{
        public Conexion (DbContextOptions<Conexion> options) : base (options){}

        //Creación de Entidad para Usuarios//Creación de Entidad para Usuarios
        public DbSet<Usuarios> Usuarios {get;set;}

        //Creación de Entidad para Bitacora

    }

    class Conectar{
        private const string cadenaConexion = "server=softmora.com;port=3306;database=unifet;userid=unifet;pwd=jDn8o7*6";

        //Crear metodo para abrir la conexion
        
        public static Conexion Create(){
            //crear constructor
            var constructor = new DbContextOptionsBuilder<Conexion>();
            //Se abre la conexion
 
            constructor.UseMySQL(cadenaConexion);

            var cn = new Conexion(constructor.Options);
            return cn;

        }
    }
}
