using SiGas.Views;
using SiGas.BDLocal;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiGas.ViewModels
{
    public partial class TipoGastoAddViewModel
    {
        public string Descricao { get; set; }
        public ICommand OkCommand { protected set; get; }
        public ICommand DeleteCommand { protected set; get; }

        public TipoGastoAdd ParentPage { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propriedade));
        }

        public TipoGastoAddViewModel(TipoGastoAdd pai)
        {
            ParentPage = pai;
            this.OkCommand = new Command(async () =>
            {
                // verifica se todos os campos foram informados
                if (ParentPage.DadosOk())
                {
                    // atualizar lista de eventos da aplicação, avisando
                    // a janela pai que dados foram informados
                    Models.TipoGastoModel novo =
                    new Models.TipoGastoModel(0, Descricao);
                    if (ParentPage.dadosTipoGasto != null)
                        novo.Tig_Codigo = ParentPage.dadosTipoGasto.Tig_Codigo;
                    MessagingCenter.Send<Application, Models.TipoGastoModel>(
                    App.Current, "MntDados", novo);

                    // TipoGastoBD tp = new TipoGastoBD();
                  //  bool incluir = TipoGastoBD.InsertUpdateDados(0, "teste");
                    // encerrar tela
                    await pai.Navigation.PopAsync();
                }
            });
            this.DeleteCommand = new Command(async () =>
            {
                if (ParentPage.dadosTipoGasto == null)
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
                        MessagingCenter.Send<Application, Models.TipoGastoModel>(
                       App.Current, "DeleteDados",
                       ParentPage.dadosTipoGasto);
                        // encerrar tela
                        await pai.Navigation.PopAsync();
                    }
                }
            });
        }
    }
}
