using System;
using System.Collections.Generic;
using System.Text;
using SiGas.Interfaces;
using SQLite;
using Xamarin.Forms;


namespace SiGas.BDLocal
{
    public class ConexaoBD
    {
        public SQLiteConnection DBConnection { get; set; }
        public ConexaoBD()
        {
            // conecta ao banco de dados local
            // (ou cria, caso ele ainda não exista)
            DBConnection = DependencyService.Get<ISQLiteConnection>().DBConnection();
            // cria ou altera as tabelas, se for necessário
            DBConnection.CreateTable<GastoBD>();
            DBConnection.CreateTable<TipoGastoBD>();
            DBConnection.CreateTable<UsuariosBD>();
        }

        public int GetLastRowId(string tabela, string chave)
        {
            SQLiteCommand cmd = DBConnection.CreateCommand("SELECT last_insert_rowid()");
            int i = cmd.ExecuteScalar<int>();
            cmd.CommandText = "SELECT " + chave + " FROM " + tabela +
            " WHERE rowid = " + i.ToString();
            i = cmd.ExecuteScalar<int>();
            return i;
        }
    }
}
