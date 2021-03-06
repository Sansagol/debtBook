﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DebtBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DebtorsList : ContentPage
    {
        public ViewModelBase VM { get; set; }

        public DebtorsList(ViewModelBase vm)
        {
            vm.Navigator = Navigation;
            BindingContext = VM = vm;

            InitializeComponent();
        }
    }
}