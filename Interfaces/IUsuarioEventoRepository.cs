using APIMaisEventos.Models;

namespace APIMaisEventos.Interfaces
{
    public interface IUsuarioEventoRepository
    {
        UsuarioEvento GetAll();

      UsuarioEvento GetById(int id);

        //CREATE
        UsuarioEvento Insert(UsuarioEvento usuarioEvento);

        //UPDATE
        UsuarioEvento Update(int id, UsuarioEvento usuarioEvento);

        //DELETE
        UsuarioEvento Delete(int id);
    }
}
