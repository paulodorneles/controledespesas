using SiGas.Interfaces;
using SiGas.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiGas.ViewModels
{
    public class MenuViewModel : INotifyPropertyChanged
    {
        public string Nome { get; set; }
        public object Foto { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void InformaAlteracao(string propriedade)
        {
            PropertyChanged?.Invoke(this,
            new PropertyChangedEventArgs(propriedade));
        }
        public ICommand MenuTapped { protected set; get; }
        public MenuViewModel(Views.Menu menu)
        {            
            this.MenuTapped = new Command<string>(async (id) =>
            {
                switch (id)
                {                   
                    // Sincronizar Rotas
                    case "tipogasto":
                        await App.NavegarParaPagina(new TipoGasto());
                        break;

                    case "gasto":
                        await App.NavegarParaPagina(new Gasto());
                        break;

                    case "sair":
                        DependencyService.Get<IDeviceSpecific>().CloseApplication();                        
                        break;  
                }
            });
        }
    }
}
