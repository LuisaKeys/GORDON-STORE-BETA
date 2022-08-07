using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 Modos de se fazer:
    1.Coloca o carrinho diretamente no pedido, então para cada produto coloco no carrinho na verdade iria para a lista do pedido.
    2.Coloca os produtos no carrinhos e depois copiar essa lista no pedido.(método original)
    3.    
 */
namespace GORDON_STORE_BETA.Models
{
    public class Pedido
    {
        public long id { get; set; }
        public DateTime Data_compra { get; set; }
        public DateTime Data_pagamento { get; set; }
        public DateTime Data_Envio { get; set; }
        public double valor_compra { get; set; }
        public Carrinho lista_compra { get; set; }
        public Avaliação avalicao { get; set; }
    }
}