﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LanchesMac.Models
{
    public class Pedido
    {
        //[BindNever]
        public int PedidoId { get; set; }
        public List<PedidoDetalhe> PedidoItens { get; set; }
        [Required(ErrorMessage = "Informe o nome")]
        [Display(Name = "Nome")]
        [StringLength(50)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o sobrenome")]
        [Display(Name="Sobrenome")]
        [StringLength(50)]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "Informe o endereço")]
        [Display(Name = "Endereço")]
        [StringLength(100)]
        public string Endereco1 { get; set; }
        [Required(ErrorMessage = "Informe o complemento do endereço")]
        [Display(Name = "Complemento")]
        [StringLength(100)]
        public string Endereco2 { get; set; }
        [Required(ErrorMessage = "Informe o CEP")]
        [Display(Name = "CEP")]
        [StringLength(10), MinLength(8)]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Informe o estado")]
        [Display(Name = "Estado")]
        [StringLength(10)]
        public string Estado { get; set; }
        [StringLength(50)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Informe o seu telefone")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Telefone")]        
        public string Telefone { get; set; }
        [Required(ErrorMessage = "Informe o seu e-mail")]
        [StringLength(80)]
        [DataType(DataType.EmailAddress)]
        /*[RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+\=?")]*/
        [Display(Name = "E-mail")]
        public string Email { get; set; }
        [BindNever]
        [ScaffoldColumn(false)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal PedidoTotal { get; set; }
        //[BindNever]
        //[ScaffoldColumn(false)]
        [Display(Name = "Data/Hora de Recebimento do Pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime PedidoEnviado { get; set; }
        [Display(Name = "Data/Hora da Entrega do Pedido")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString ="{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode =true)]
        public DateTime? PedidoEntregueEm { get; set; }

    }
}
