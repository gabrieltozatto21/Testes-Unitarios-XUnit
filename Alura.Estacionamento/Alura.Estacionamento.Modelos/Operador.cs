﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Estacionamento.Modelos
{
    public class Operador
    {
        private string _matricula { get; set; }
        private string _nome { get; set; }


        public string Matricula { get=> _matricula; set=> _matricula=value; }
        public string Nome { get=> _nome; set=> _nome=value; }

        public Operador()
        {
            Matricula = new Guid().ToString().Substring(0,5);
        }
    }
}
