using Microsoft.AspNetCore.Mvc;
using System.Linq;
using web_api_db.Models;

namespace web_api_db.Controllers{
    [Route("[controller]")]
    public class UsuariosController: Controller{
        private Conexion dbConexion;
        
        public UsuariosController(){

            dbConexion = Conectar.Create();
        }

        [HttpGet]
        public ActionResult Get(){
            return Ok(dbConexion.Usuarios.ToArray());
        }

        [HttpGet("{id}")]
        public ActionResult GetAction(int id){
            var usuarios = dbConexion.Usuarios.SingleOrDefault(a => a.id_usuario == id);
            if(usuarios != null){
                return Ok(usuarios);
            }else{
                return NotFound();
            }
    
        }

        [HttpPost]
        public ActionResult Post([FromBody] Usuarios usuarios){
            if(ModelState.IsValid){
                dbConexion.Usuarios.Add(usuarios);
                dbConexion.SaveChanges();
                return Ok();
            }else{
                return NotFound();
            }
        }

         [HttpPut]
        public ActionResult Put([FromBody] Usuarios usuarios){
            var v_usuarios = dbConexion.Usuarios.SingleOrDefault(a => a.id_usuario == usuarios.id_usuario);
            if(usuarios != null && ModelState.IsValid){
                dbConexion.Entry(v_usuarios).CurrentValues.SetValues(usuarios);
                dbConexion.SaveChanges(); 
                return Ok();
            }else{
                return NotFound("Fallo");
            }
            
        }

         [HttpDelete("{id}")]
        public ActionResult Delete(int id){
            var usuarios = dbConexion.Usuarios.SingleOrDefault(a => a.id_usuario == id);
            if(usuarios != null){
                dbConexion.Remove(usuarios);
                dbConexion.SaveChanges(); 
                return Ok();
            }else{
                return NotFound();
            }
    
        }


    }

}