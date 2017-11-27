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
    public sealed partial class Gasto : ContentPage
    {
        private GastoViewModel viewModel;
        public Gasto()
        {
            this.InitializeComponent();
            viewModel = new GastoViewModel(this);
            this.BindingContext = viewModel;
            MostraDados();

            MessagingCenter.Subscribe<Application, Models.GastoModel>(this,
            "MntDados", (sender, arg) =>
            {
                // atualiza dados no banco de dados local
                GastoBD.InsertUpdateDados(arg.Gas_Codigo, arg.Gas_Descricao, arg.Gas_DataHora, arg.Gas_Valor, arg.Gas_TigCodigo);
                // atualiza lista
                MostraDados();
            });
            // usuário eliminou um registro
            MessagingCenter.Subscribe<Application, Models.GastoModel>(this,
            "DeleteDados", (sender, arg) =>
            {
                // apaga evento no banco de dados local
                GastoBD.EliminaRegistro(arg.Gas_Codigo);
                // atualiza lista
                MostraDados();
            });
        }

        public void MostraDados()
        {
            List<GastoModel> lista = GastoBD.GetGasto();
            if (lista == null)
                viewModel.gasto = new ObservableCollection<GastoModel>();
            else
                viewModel.gasto = new ObservableCollection<GastoModel>(lista);

            viewModel.InformaAlteracao("gasto");
            viewModel.InformaAlteracao("Gas_Descricao");
        }

        async void Agenda_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            // obtem item selecionado
            GastoModel item = (GastoModel)e.Item;
            if (item == null)
                return;
            // abrir view para edição do item selecionado
            await Navigation.PushAsync(new GastoAdd(item));
        }
    }
}
