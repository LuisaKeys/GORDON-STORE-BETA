﻿using Modelo.Cadastro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace Modelo.Sistema
{
    public class Cart
    {
        public long CartId { get; set; }
        public Guid UserId { get; set; }
        public UsuarioAdm Usuario { get; set; }
        public virtual ICollection<Produto> ProdutosCarrinho { get; set; }
    }
}