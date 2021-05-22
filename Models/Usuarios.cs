using System.ComponentModel.DataAnnotations;
namespace web_api_db.Models{

    public class Usuarios{
        [Key]
        public int id_usuario {get;set;}
        public string nombre {get;set;}
        public string correo {get;set;}
        public string token {get;set;}
        public string id_form {get;set;}
    }
}