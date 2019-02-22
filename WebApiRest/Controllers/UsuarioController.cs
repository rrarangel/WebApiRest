using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApiRest.Models;

namespace WebApiRest.Controllers
{
    public class UsuarioController : ApiController
    {
        private static List<Usuario> listUser = new List<Usuario>();

        
        [AcceptVerbs("POST")]
        [Route("CadastrarUsuario")]
        public string CadastrarUsuario(Usuario u)
        {
            listUser.Add(u);

            return "Usuário cadastrado com sucesso!";
        }

        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarioPorCodigo/{codigo}")]
        public Usuario ConsultaUsuarioPorCodigo(int codigo)
        {
            return
                listUser.Where(u => u.codigo == codigo).Select(u => u).FirstOrDefault();
        }

        [AcceptVerbs("DELETE")]
        [Route("ExcluirUsuario/{codigo}")]
        public string ExcluirUsuario(int codigo)
        {
                listUser.Remove(listUser.Where(u => u.codigo == codigo).Select(u => u).FirstOrDefault());
            
            return "Registro excluido com sucesso!";
        }

        [AcceptVerbs("PUT")]
        [Route("AlterarUsuario")]
        public string AlterarUsuario(Usuario usuario)
        {
            listUser.Where(u => u.codigo == usuario.codigo)
                         .Select(s =>
                         {
                             s.codigo = usuario.codigo;
                             s.login = usuario.login;
                             s.nome = usuario.nome;

                             return s;

                         }).ToList();
            
            return "Usuário alterado com sucesso!";
        }


        [AcceptVerbs("GET")]
        [Route("ConsultarUsuarios")]
        public List<Usuario> ConsultarUsuarios()
        {
            return listUser;
        }

    }
}
