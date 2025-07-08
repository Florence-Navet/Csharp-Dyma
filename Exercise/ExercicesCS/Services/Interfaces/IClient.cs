using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IClient
    {
       
        int Id { get; }
        string NomComplet { get; }
        string Adresse { get; set; }
    }
}

