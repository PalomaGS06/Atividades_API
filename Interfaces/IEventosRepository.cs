using APIMaisEventos.Models;
using System.Collections.Generic;

namespace APIMaisEventos.Interfaces
{
    public interface IEventosRepository
    {
        ICollection<Eventos> GetAll();

        Eventos GetById(int id);

        //CREATE
        Eventos Insert(Eventos eventos);

        //UPDATE
        Eventos Update(int id, Eventos eventos);

        //DELETE
        Eventos Delete(int id);
    }
}
