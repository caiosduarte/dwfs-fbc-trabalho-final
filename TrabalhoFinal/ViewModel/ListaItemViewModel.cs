using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Modelo;

namespace Inventario.ViewModel
{
    public class ListaItemViewModel
    {

        [DisplayFormat(NullDisplayText = "Sem itens cadastrados")]
        public IEnumerable<Item> Itens { get; set; }


        [Display(Name = "Número")]
        public string Numero { get; set; }


        [Display(Name = "Descrição")]
        public string Descricao { get; set; }


        [Display(Name = "Custo")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal Custo { get; set; }


        [Display(Name = "Valor residual")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal ValorResidual { get; set; }


        [Display(Name = "Ano(s)")]
        public int Anos { get; set; }

     
        [Display(Name = "Depreciação padrão %")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal Depreciacao { get; set; }

        [Display(Name = "Depreciação calculada R$")]
        [Column(TypeName = "money")]
        public Decimal DepreciacaoCalculada { get; set; }

        [Display(Name = "Quantidade de itens")]
        public int Quantidade { get; set; }

        [Display(Name = "Custo de aquisições total")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal CustoTotal { get; set; }

        [Display(Name = "Valor residual total")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal ValorResidualTotal { get; set; }

    }
}
