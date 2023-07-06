using GeradorDeTestes.Dominio.ModuloDisciplina;
using GeradorDeTestes.Dominio.ModuloMateria;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDeTestes.Dominio.ModuloDisciplina
{
    public class Disciplina : EntidadeBase<Disciplina>
    {
        public string nome;
       public List<Materia> materias = new List<Materia>();
        public List<Disciplina> disciplina = new List<Disciplina>();
        public Disciplina()
        {
           

        }

        public Disciplina(string nome)
        {
            this.nome = nome;
           
        }

        public Disciplina(int id, string nome)
        {
            this.id = id;
            this.nome = nome;
           
        }

        public override void AtualizarInformacoes(Disciplina registroAtualizado)
        {
            this.id = registroAtualizado.id;
            this.nome = registroAtualizado.nome;
            this.materias = registroAtualizado.materias;
          
        }

        public override string[] Validar()
        {
            List<string> erros = new List<string>();
            

            if (string.IsNullOrEmpty(nome))
                erros.Add("O campo nome é obrigatório");


            if (nome.Count() < 4)
                erros.Add("O campo nome deve ter 4 caracteres");


            return erros.ToArray();
        }

        public override string ToString()
        {
            return $"{nome}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Disciplina disciplina &&
                   id == disciplina.id &&
                   nome == disciplina.nome &&
                   EqualityComparer<List<Materia>>.Default.Equals(materias, disciplina.materias);
        }
    }
}
