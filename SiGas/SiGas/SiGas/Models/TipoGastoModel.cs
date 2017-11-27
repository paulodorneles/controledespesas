using System;
using System.Collections.Generic;
using System.Text;

namespace SiGas.Models
{
    public class TipoGastoModel : IComparable<TipoGastoModel>
    {
        public int Tig_Codigo { get; set; }
        public string Tig_Descricao { get; set; }        
        public TipoGastoModel(int tig_Codigo, string tig_Descricao)
        {
            Tig_Codigo = tig_Codigo;
            Tig_Descricao = tig_Descricao;            
        }
        public int CompareTo(TipoGastoModel other)
        {
            return this.Tig_Descricao.CompareTo(other.Tig_Descricao);
        }
    }
}
