using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Models;

namespace Login.Models
{
     public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Cpf { get; set; }
        public double? Preferencia { get; set; }
        public string Tipo { get; set; }
        public string SenhaSalt {  get; set; }
        public string SenhaHash { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }
}
