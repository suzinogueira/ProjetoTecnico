using System;
using System.Linq;
using TesteVaiVoa.Models;

namespace TesteVaiVoa.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario Read(string email);

        void Create (Usuario usuario);
    }

    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context){
            _context = context;
        }
        public void Create(Usuario usuario)
        {
            usuario.Id = Guid.NewGuid();
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public Usuario Read(string email)
        {
            return _context.Usuarios.SingleOrDefault(
                usuario => usuario.Email == email
            );
        }
    }
}