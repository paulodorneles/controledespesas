using SiGas.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiGas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Menu : ContentPage
    {
        public MenuViewModel viewModel = null;
        public Menu()
        {
            InitializeComponent();
            viewModel = new MenuViewModel(this);
            BindingContext = viewModel;
        }
    }
}
