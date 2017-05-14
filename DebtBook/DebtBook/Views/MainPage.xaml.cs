using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DebtBook.Views
{
	public partial class MainPage : ContentPage
	{
		public MainPage(ViewModelBase vm)
		{
			InitializeComponent();
            vm.Navigator = Navigation;
            BindingContext = vm;
        }
	}
}
