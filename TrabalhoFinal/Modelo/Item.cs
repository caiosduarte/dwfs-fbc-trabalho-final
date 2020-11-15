using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Inventario.Modelo
{
    public class Item
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Numero { get; set; }

        [Required]
        public string Descricao { get; set; }


        public string Localizacao { get; set; }

 
        [Column(TypeName = "money")]
        public Decimal? Custo { get; set; }


        [Column(TypeName = "money")]
        public Decimal? ValorResidual { get; set; }
        
        public int? Anos { get; set; }

        [Column(TypeName = "money")]
        //[EnumDataType(Depreciacao, ErrorMessage = "Escolha os elementos da lista")]
        public Decimal? Depreciacao { get; set; }
        
        public DateTime CriadoEm { get; set; }

        public DateTime AtualizadoEm { get; set; }

        [DataType(DataType.Currency)]        
        public Decimal CalculaDepreciacaoAnual() {
            Decimal resultado = new Decimal(0); 

            // Depreciação anual calculada(Custo de aquisição – Valor residual) / Anos de vida útil =
            if (!Equals(Custo, null) && !Equals(Anos, null) && Anos > 0) {
                resultado = (decimal)((Custo - (Equals(ValorResidual, null) ? 0 : ValorResidual)) / Anos);
            } 

            return resultado;
        }

    }
}
