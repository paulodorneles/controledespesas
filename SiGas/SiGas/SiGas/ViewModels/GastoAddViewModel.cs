using SiGas.Views;
using SiGas.BDLocal;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;
using System;

namespace SiGas.ViewModels
{
    public class GastoAddViewModel
    {
        public int TigCodigo { get; set; }
        public DateTime DataHora { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public ICommand OkCommand { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }

        public GastoAdd ParentPage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void InserirTipoGasto(int pTipoGasto)
        {
            TigCodigo = pTipoGasto;
        }

        public void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propriedade));
        }

        public GastoAddViewModel(GastoAdd pai)
        {
            ParentPage = pai;
            this.OkCommand = new Command(async () =>
            {
                // verifica se todos os campos foram informados
                if (ParentPage.DadosOk())
                {
                    // atualizar lista de eventos da aplicação, avisando
                    // a janela pai que dados foram informados
                    Models.GastoModel novo =
                    new Models.GastoModel(0, Descricao, DataHora, Valor, TigCodigo);
                    if (ParentPage.dadosGasto != null)
                        novo.Gas_Codigo = ParentPage.dadosGasto.Gas_Codigo;
                    MessagingCenter.Send<Application, Models.GastoModel>(
                    App.Current, "MntDados", novo);

                    // TipoGastoBD tp = new TipoGastoBD();
                    //  bool incluir = TipoGastoBD.InsertUpdateDados(0, "teste");
                    // encerrar tela
                    await pai.Navigation.PopAsync();
                }
            });
            this.DeleteCommand = new Command(async () =>
            {
                if (ParentPage.dadosGasto == null)
                    await ParentPage.DisplayAlert("Erro",
                   "Dados não podem ser eliminados", "OK");
                else
                {
                    var resposta =
                    await ParentPage.DisplayAlert("Elimina Registro",
                    "Confirma eliminação do registro?",
                    "Sim", "Não");
                    if (resposta)
                    {
                        MessagingCenter.Send<Application, Models.GastoModel>(
                       App.Current, "DeleteDados",
                       ParentPage.dadosGasto);
                        // encerrar tela
                        await pai.Navigation.PopAsync();
                    }
                }
            });
        }
    }
}
