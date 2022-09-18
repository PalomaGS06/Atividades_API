using APIMaisEventos.Models;
using System.Collections.Generic;

namespace APIMaisEventos.Interfaces
{
    public interface IUsuarioRepository
    {
        //CRUD
        //Read
        ICollection<Usuario> GetAll();
        
        Usuario GetById(int id);

        //CREATE
        Usuario Insert(Usuario usuario);

        //UPDATE
        Usuario Update(int id, Usuario usuario);

        //DELETE
        Usuario Delete(int id);
    }
}
