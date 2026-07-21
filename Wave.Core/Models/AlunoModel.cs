using System;
using System.Collections.Generic;
using System.Text;

namespace Wave.Core.Models
{
    public class AlunoModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime? DataMatricula {  get; set; }
        public DateTime? DataVencimento { get; set; }
    }
}
