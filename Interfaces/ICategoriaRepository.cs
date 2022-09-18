using APIMaisEventos.Models;
using System.Collections.Generic;

namespace APIMaisEventos.Interfaces
{
    public interface ICategoriaRepository
    {
        ICollection<Categorias> GetAll();

        // Procurar por Id
        Categorias GetById(int id);

        //CREATE
       Categorias Insert(Categorias categoria);

        //UPDATE
       Categorias Update(int id,Categorias categoria );

        //DELETE
        Categorias Delete(int id);
    }
}
