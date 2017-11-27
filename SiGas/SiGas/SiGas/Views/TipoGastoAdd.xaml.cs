using SiGas.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace SiGas.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TipoGastoAdd : ContentPage
    {
        private TipoGastoAddViewModel viewModel;
        public Models.TipoGastoModel dadosTipoGasto;
        public TipoGastoAdd(Models.TipoGastoModel tipoGasto = null)
        {
            // salva dados corrente
            dadosTipoGasto = tipoGasto;
            InitializeComponent();
            viewModel = new TipoGastoAddViewModel(this);
            this.BindingContext = viewModel;
            // mostra dados da agenda corrente
            if (tipoGasto != null)
            {
                viewModel.Descricao = tipoGasto.Tig_Descricao;                
                viewModel.InformaAlteracao("Descricao");                
            }
        }

        public bool DadosOk()
        {
            if (string.IsNullOrEmpty(viewModel.Descricao))
            {
                DisplayAlert("Erro", "Descricao não foi informado", "OK");
                txtNome.Focus();
                return false;
            }            
            return true;
        }
    }
}
