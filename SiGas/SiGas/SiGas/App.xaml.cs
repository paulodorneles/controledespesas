using SiGas.BDLocal;
using SiGas.Interfaces;
using SiGas.Views;
using Plugin.Connectivity;
using Plugin.Connectivity.Abstractions;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiGas
{
    public partial class App : Application
    {
        // banco de dados local
        private static ConexaoBD localDatabase;
        public static ConexaoBD BDLocal
        {
            get { return localDatabase; }
        }
        public App()
        {
            InitializeComponent();
            // conecta ao banco de dados local (e cria o BD se
            // ele ainda não existir)
            localDatabase = new ConexaoBD();
            // página inicial da aplicação (com barra de navegação)
            //  Views.AgendaMainPage pagInicial = new Views.AgendaMainPage();
            MostrarPaginaInicial();
        }

        public static async Task MostrarPaginaInicial()
        {
            var telaInicial = Application.Current.MainPage as Views.MasterDetailPrincipal;
            if (telaInicial == null)
            {
                telaInicial = new MasterDetailPrincipal();
                Application.Current.MainPage = telaInicial;
            }
            else
                await telaInicial.IrParaPaginaInicial();
        }

        public static async Task NavegarParaPagina(Page pagina)
        {
            var telaInicial = Application.Current.MainPage as Views.MasterDetailPrincipal;
            await telaInicial.PushAsync(pagina);
        }
    }
}