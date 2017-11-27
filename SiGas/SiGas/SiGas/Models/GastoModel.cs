using System;
using System.Collections.Generic;
using System.Text;

namespace SiGas.Models
{
    public class GastoModel : IComparable<GastoModel>
    {     
        public int Gas_Codigo { get; set; }
        public string Gas_Descricao { get; set; }
        public DateTime Gas_DataHora { get; set; }
        public double Gas_Valor { get; set; }
        public int Gas_TigCodigo { get; set; }

        public GastoModel(int gas_Codigo, string gas_Descricao, DateTime gas_DataHora, double gas_Valor, int gas_TigCodigo)
        {
            Gas_Codigo = gas_Codigo;
            Gas_Descricao = gas_Descricao;
            Gas_DataHora = gas_DataHora;
            Gas_Valor = gas_Valor;
            Gas_TigCodigo = gas_TigCodigo;
        }
        public int CompareTo(GastoModel other)
        {
            return this.Gas_Descricao.CompareTo(other.Gas_Descricao);
        }
    }
}
