using Aluno.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aluno.Application.ViewModel
{
    public class AlunoViewModel
    {
        public AlunoViewModel(string name, string email, StatusAluno status)
        {
            Name = name;
            Email = email;
            Status = status;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public StatusAluno Status { get; private set; }
    }
}
