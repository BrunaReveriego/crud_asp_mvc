﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContatoWeb.Models
{
    public class Contato
    {
        public int IdContato { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}