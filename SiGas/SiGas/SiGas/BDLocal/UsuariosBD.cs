using SQLite;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SiGas.BDLocal
{
    [Table("usuarios")]
    public class UsuariosBD
    {
        // email de identificação do usuário
        [PrimaryKey, Column("email")]
        public string Email { get; set; }
        // nome do usuário
        [MaxLength(80), Column("nome")]
        public string Nome { get; set; }
        // tipo do login
        [Column("login")]
        public int Login { get; set; }
        // foto do usuário
        [Column("foto")]
        public byte[] Foto { get; set; }
        // URL do Web Service de sincronização
        [Column("ws_url")]
        public string WSUrl { get; set; }
        // indicador se gravação da rota será automática
        [Column("grava_aut")]
        public int Grava { get; set; }
        // indicador se conexão com Web Service será feita só via Wi-Fi
        [Column("so_wifi")]
        public int WiFi { get; set; }
    }
}
