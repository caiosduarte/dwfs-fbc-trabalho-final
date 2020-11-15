using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Inventario.Modelo;

namespace Inventario.ViewModel
{
    public class ItemViewModel
    {


        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Número do patrimônio")]
        [StringLength(7, MinimumLength = 7, ErrorMessage = "Deve ser no formato XXX-XXX")]
        public string Numero { get; set; }

        [Required]
        [Display(Name = "Descrição")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "A descrição deve ter entre 5 e 30 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Localização")]
        [StringLength(10, ErrorMessage = "Deve ter no máximo 10 caracteres")]
        public string Localizacao { get; set; }

        [Required]
        [Display(Name = "Custo de aquisição")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal Custo { get; set; }

        [Display(Name = "Valor residual")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal? ValorResidual { get; set; }

        [Required]
        [Display(Name = "Ano(s) de vida útil")]
        [Range(1, 999, ErrorMessage ="Ano tem que ser maior que zero")]
        public int Anos { get; set; }

        [Display(Name = "Depreciação padrão %")]
        [Column(TypeName = "money")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal? Depreciacao { get; set; }

        [Display(Name = "Criado em")]
        [DisplayFormat(DataFormatString = "dd/MM/yyyy hh:mm:ss")]
        public DateTime CriadoEm { get; set; }

        [Display(Name = "Atualizado em")]
        //[DisplayFormat(DataFormatString = "{dd/MM/yyyy hh:mm:ss}")]
        [DisplayFormat(DataFormatString = "mm/dd/yyyy")]
        public DateTime AtualizadoEm { get; set; }

        [DisplayFormat(NullDisplayText = "Item vazio")]
        public Item item { get; set; }
    }
}
