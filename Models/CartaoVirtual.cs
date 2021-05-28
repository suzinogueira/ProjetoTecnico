using System;
using System.ComponentModel.DataAnnotations;

namespace TesteVaiVoa.Models{

    public class CartaoVirtual{
        public Guid Id{get; set; }

        [Required]
        public String EmailUsuario{get; set;}

        public String NovoNumero{get; set; }

        public String CVV{get; set; }

        public String dataVenc{get; set; }
    }

}