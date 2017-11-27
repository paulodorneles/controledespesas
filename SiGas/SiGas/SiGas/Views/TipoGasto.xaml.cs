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
    public sealed partial class TipoGasto : ContentPage
    {
        private TipoGastoViewModel viewModel;
        public TipoGasto()
        {
            this.InitializeComponent();
            viewModel = new TipoGastoViewModel(this);
            this.BindingContext = viewModel;
            MostraDados();

            MessagingCenter.Subscribe<Application, Models.TipoGastoModel>(this,
            "MntDados", (sender, arg) =>
            {
                // atualiza dados no banco de dados local
                TipoGastoBD.InsertUpdateDados(arg.Tig_Codigo, arg.Tig_Descricao);
                // atualiza lista
                MostraDados();
            });
            // usuário eliminou um registro
            MessagingCenter.Subscribe<Application, Models.TipoGastoModel>(this,
            "DeleteDados", (sender, arg) =>
            {
                // apaga evento no banco de dados local
                TipoGastoBD.EliminaRegistro(arg.Tig_Codigo);
                // atualiza lista
                MostraDados();
            });
        }

        public void MostraDados()
        {
             List<TipoGastoModel> lista = TipoGastoBD.GetTipoGasto();
            if (lista == null)
                 viewModel.tipoGasto = new ObservableCollection<TipoGastoModel>();
             else
                 viewModel.tipoGasto = new ObservableCollection<TipoGastoModel>(lista);

             viewModel.InformaAlteracao("tipoGasto");
             viewModel.InformaAlteracao("Tig_Descricao");  
        }

        async void Gasto_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // obtem item selecionado
            TipoGastoModel item = (TipoGastoModel)e.Item;
            if (item == null)
                return;
            // abrir view para edição do item selecionado
            await Navigation.PushAsync(new TipoGastoAdd(item));   
        }
    }
}
