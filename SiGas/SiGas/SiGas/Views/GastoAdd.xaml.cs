using SiGas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SiGas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public sealed partial class GastoAdd : ContentPage
    {
        private GastoAddViewModel viewModel;
        public Models.GastoModel dadosGasto;
        public GastoAdd(Models.GastoModel gasto = null)
        {
            // salva dados corrente
            dadosGasto = gasto;
            InitializeComponent();
            viewModel = new GastoAddViewModel(this);
            this.BindingContext = viewModel;
            // mostra dados da agenda corrente
            if (gasto != null)
            {
                viewModel.Descricao = gasto.Gas_Descricao;
                viewModel.DataHora = gasto.Gas_DataHora;
                viewModel.TigCodigo = gasto.Gas_TigCodigo;
                viewModel.Valor = gasto.Gas_Valor;

                viewModel.InformaAlteracao("Descricao");
                viewModel.InformaAlteracao("DataHora");
                viewModel.InformaAlteracao("TigCodigo");
                viewModel.InformaAlteracao("Valor");
            }
            else
            {
                viewModel.DataHora = DateTime.Now;
                viewModel.InformaAlteracao("DataHora");
            }
        }

        private async void BtnBuscar_Clicked(object sender, EventArgs e)
        {
            await App.NavegarParaPagina(new ListarTipoGasto());
        }

            public bool DadosOk()
        {
            if (string.IsNullOrEmpty(viewModel.Descricao))
            {
                DisplayAlert("Erro", "Descricao não foi informado", "OK");
                txtDescricao.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(viewModel.Valor)))
            {
                DisplayAlert("Erro", "Valor não foi informado", "OK");
                txtData.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(viewModel.TigCodigo)))
            {
                DisplayAlert("Erro", "Tipo Gasto não foi informado", "OK");
                txtValor.Focus();
                return false;
            }
            if (string.IsNullOrEmpty(Convert.ToString(viewModel.DataHora)))
            {
                DisplayAlert("Erro", "Data não foi informado", "OK");
                txtCodTipoGasto.Focus();
                return false;
            }
            return true;
        }
    }
}
