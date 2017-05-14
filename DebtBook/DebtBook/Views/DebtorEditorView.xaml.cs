using DebtBook.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DebtBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebtorEditorView : ContentPage, IViewedPage
    {
        public ViewModelBase VM { get; set; }

        public DebtorEditorView(ViewModelBase vm)
        {
            InitializeComponent();
            vm.Navigator = Navigation;
            BindingContext = VM = vm;
        }
    }
}
