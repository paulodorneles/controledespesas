using SiGas.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace SiGas.BDLocal
{
    [Table("gas_gasto")]
    public class GastoBD
    {
        [PrimaryKey, AutoIncrement, Column("Gas_Codigo")]
        public int Gas_Codigo { get; set; }       

        [MaxLength(80), Column("Gas_Descricao")]
        public string Gas_Descricao { get; set; }

        [Column("Gas_DataHora")]
        public DateTime Gas_DataHora { get; set; }

        [Column("Gas_Valor")]
        public double Gas_Valor { get; set; }

        [Column("Gas_TigCodigo")]
        public int Gas_TigCodigo { get; set; }

        static public List<GastoModel> GetGasto()
        {
            try
            {
                string strQuery = "SELECT * FROM [gas_gasto]";
                List<GastoBD> lst =
                App.BDLocal.DBConnection.Query<GastoBD>(strQuery);
                if (lst.Count == 0)
                    return null;
                GastoModel novo;
                List<GastoModel> lstModel = new List<GastoModel>();
                foreach (GastoBD g in lst)
                {
                    novo = new GastoModel(g.Gas_Codigo, g.Gas_Descricao, g.Gas_DataHora, g.Gas_Valor, g.Gas_TigCodigo);
                    lstModel.Add(novo);
                }
                // ordena a lista em ordem alfabética
                lstModel.Sort();
                return lstModel;
            }
            catch (Exception)
            {
                return null;
            }
        }

        static public bool InsertUpdateDados(int codigo, string descricao, DateTime datahora, double valor, int tigCodigo)
        {
            try
            {
                GastoBD gas = new GastoBD();
                gas.Gas_Codigo = codigo;
                gas.Gas_DataHora = datahora;
                gas.Gas_Descricao = descricao;
                gas.Gas_TigCodigo = tigCodigo;
                gas.Gas_Valor = valor;               
                
                if (codigo == 0)
                    App.BDLocal.DBConnection.Insert(gas);
                else
                    App.BDLocal.DBConnection.Update(gas);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        static public bool EliminaRegistro(int id)
        {
            try
            {
                string strQuery = "DELETE FROM [gas_gasto] where Gas_Codigo = " +
                id.ToString();
                App.BDLocal.DBConnection.Execute(strQuery);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
