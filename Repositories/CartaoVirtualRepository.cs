using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TesteVaiVoa.Models;

namespace TesteVaiVoa.Repositories
{

    public interface ICartaoVirtualRepository
    {
        List<CartaoVirtual> Read(String email);

        void Create(CartaoVirtual cartaovirtual);

        void Delete(Guid id);

        CartaoVirtual ReadSingle();

       // void Update(CartaoVirtual cartaoVirtual);
    }

    public class CartaoVirtualRepository : ICartaoVirtualRepository
    {
        private readonly DataContext _context;

        public CartaoVirtualRepository(DataContext context){
            _context = context;
        }
        public void Create(CartaoVirtual cartaovirtual)
        {
            cartaovirtual.Id = Guid.NewGuid();

            Random random = new Random();
            Random numRandom = random;
            String cartao = "";
            for(int i = 0; i < 4; i++)
            {
                cartao += "" + numRandom.Next(1000,10001)+" ";
            }
            cartaovirtual.NovoNumero = cartao;

            String cvv = ""+numRandom.Next(100, 1001);
            cartaovirtual.CVV = cvv;

             int ano = DateTime.Now.Year + 4;
             int mes = numRandom.Next(1,12);
            var novaData = new DateTime(ano, mes, 1);
            cartaovirtual.dataVenc = novaData.ToString("MM/yy");

            _context.CartaoVirtual.Add(cartaovirtual);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var cartaoVirtual = _context.CartaoVirtual.Find(id);
            _context.Entry(cartaoVirtual).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public List<CartaoVirtual> Read(String email)
        {
            //return _context.CartaoVirtual.ToList();
            return _context.CartaoVirtual.Where(cartao => cartao.EmailUsuario == email).ToList();
        }

        public CartaoVirtual ReadSingle() 
        {
            return _context.CartaoVirtual.Last();
        }

        
    }
}