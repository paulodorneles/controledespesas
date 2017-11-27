using SiGas.Interfaces;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiGas.Views
{
    public class MasterDetailPrincipal : MasterDetailPage
    {
        public NavigationPage navegacao = null;
        public MasterDetailPrincipal()
        {
            navegacao = new NavigationPage(new PaginaInicial());
            Detail = navegacao;
            Master = new Menu();
        }
        public async Task PushAsync(Page pagina)
        {
            IsPresented = false;
            await navegacao.PushAsync(pagina);
        }
        public async Task PopAsync()
        {
            await navegacao.PopAsync();
        }
        public async Task IrParaPaginaInicial()
        {
            if (navegacao != null)
                await navegacao.PopToRootAsync();
        }
        protected override bool OnBackButtonPressed()
        {
            var md = Xamarin.Forms.Application.Current.MainPage as
            MasterDetailPage;
            if (md != null && !md.IsPresented &&
            (!(md.Detail is NavigationPage) ||
            ((NavigationPage)md.Detail).Navigation.NavigationStack.
            Count == 1))
            {
                // encerra a aplicação
                var closer = DependencyService.Get<IDeviceSpecific>();
                if (closer != null)
                    closer.CloseApplication();
            }
            else
            {
                base.OnBackButtonPressed();
            }
            return true;
        }
    }
}
