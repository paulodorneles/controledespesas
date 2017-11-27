using SiGas.Models;
using SQLite;
using System;
using System.Collections.Generic;

namespace SiGas.BDLocal
{
    [Table("tig_tipogasto")]
    public class TipoGastoBD
    {
        [PrimaryKey, AutoIncrement, Column("Tig_Codigo")]
        public int Tig_Codigo { get; set; }
       
        [MaxLength(80), Column("Tig_Descricao")]
        public string Tig_Descricao { get; set; }

        static public List<TipoGastoModel> GetTipoGasto()
        {
            try
            {
                string strQuery = "SELECT * FROM [tig_tipogasto]";
                List<TipoGastoBD> lst =
                App.BDLocal.DBConnection.Query<TipoGastoBD>(strQuery);
                if (lst.Count == 0)
                    return null;
                TipoGastoModel novo;
                List<TipoGastoModel> lstModel = new List<TipoGastoModel>();
                foreach (TipoGastoBD t in lst)
                {
                    novo = new TipoGastoModel(t.Tig_Codigo, t.Tig_Descricao);
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

        static public bool InsertUpdateDados(int id, string descricao)
        {
            try
            {
                TipoGastoBD tig = new TipoGastoBD();
                tig.Tig_Codigo = id;
                tig.Tig_Descricao = descricao;                
                if (id == 0)
                    App.BDLocal.DBConnection.Insert(tig);
                else
                    App.BDLocal.DBConnection.Update(tig);
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
                string strQuery = "DELETE FROM [tig_tipogasto] where Tig_Codigo = " +
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
