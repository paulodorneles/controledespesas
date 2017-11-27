using SiGas.BDLocal;
using SiGas.Models;
using SiGas.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiGas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class ListarTipoGasto : ContentPage
    {
        private ListarTipoGastoViewModel viewModel;
        public ListarTipoGasto()
        {
            this.InitializeComponent();
            viewModel = new ListarTipoGastoViewModel(this);
            this.BindingContext = viewModel;
            MostraDados();
            
        }

        public void MostraDados()
        {
            List<TipoGastoModel> lista = TipoGastoBD.GetTipoGasto();
            if (lista == null)
                viewModel.listarTipoGasto = new ObservableCollection<TipoGastoModel>();
            else
                viewModel.listarTipoGasto = new ObservableCollection<TipoGastoModel>(lista);

            viewModel.InformaAlteracao("listarTipoGasto");
            viewModel.InformaAlteracao("Tig_Descricao");
        }

        async void Gasto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // obtem item selecionado
            TipoGastoModel item = (TipoGastoModel)e.Item;                 
            if (item == null)
                return;
            // abrir view para edição do item selecionado

            // await Navigation.PushAsync(new GastoAdd(item));
          //  GastoAddViewModel g = new GastoAddViewModel();
          //  g.InserirTipoGasto(item.Tig_Codigo);
            await this.Navigation.PopAsync();
        }
    }
}
