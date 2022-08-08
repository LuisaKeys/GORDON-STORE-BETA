using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
/*
 Modos de se fazer:
    1.Coloca o carrinho diretamente no pedido, então para cada produto coloco no carrinho na verdade iria para a lista do pedido.(método escolhido)
    2.Coloca os produtos no carrinhos e depois copiar essa lista no pedido.(método original)
    3.    
 */
namespace GORDON_STORE_BETA.Models
{
    public class Pedido
    {
        
        public IList<int> id_produto;
        public long? clienteID;
        [Display(Name = "Código do pedido")]
        public long pedidoID { get; set; }
        [Display(Name = "Data da compra")]
        public DateTime Data_compra { get; set; }
        [Display(Name = "Dia do pagamento")]
        public DateTime Data_pagamento { get; set; }
        [Display(Name = "Data de entrega")]
        public DateTime Data_Envio { get; set; }
        [Display(Name = "Valor total da compra")]
        public double valor_compra { get; set; }
        public Avaliação avalicao { get; set; }
    }
}