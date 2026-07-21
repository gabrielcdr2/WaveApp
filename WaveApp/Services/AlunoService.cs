using System;
using System.Collections.Generic;
using System.Text;
using WaveApp.Data;
using Wave.Core.Models;
using System.Linq;

namespace WaveApp.Services
{
    public class AlunoService
    {
        private readonly AppDbContext _db;
        public AlunoService(AppDbContext db)
        {
            _db = db;
        }

        public void CadastrarAluno(AlunoModel aluno)
        {
            aluno.DataMatricula = DateTime.Now;
            _db.Alunos.Add(aluno);
            _db.SaveChanges();
        }

        public void AtualizarAluno(int id, string nome, string cpf, string email, string telefone, DateTime dataNascimento)
        {
            var aluno = _db.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno is null) return;
            aluno.Name = nome;
            aluno.Cpf = cpf;
            aluno.Email = email;
            aluno.Telefone = telefone;
            aluno.DataNascimento = dataNascimento;
            _db.SaveChanges();
        }

        public void DeletarAluno(int id)
        {
            var aluno = _db.Alunos.FirstOrDefault(a => a.Id == id);
            if (aluno is null) return;
            _db.Alunos.Remove(aluno);
            _db.SaveChanges();
        }

        public List<AlunoModel> ListarAlunos()
        {
            return _db.Alunos.ToList();
        }

    }  
}
