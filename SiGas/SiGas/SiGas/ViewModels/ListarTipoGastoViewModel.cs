using SiGas.Interfaces;
using SiGas.Models;
using SiGas.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace SiGas.ViewModels
{
    public partial class ListarTipoGastoViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<TipoGastoModel> listarTipoGasto { get; set; }

        public void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this, new
            PropertyChangedEventArgs(propriedade));
        }

        public ICommand IncluirCommand { protected set; get; }

        public ListarTipoGastoViewModel(ListarTipoGasto pai)
        {
            this.IncluirCommand = new Command(async () =>
            {
                // incluir nova entrada na agenda
                await pai.Navigation.PushAsync(new TipoGastoAdd());
            });
        }
    }
}
