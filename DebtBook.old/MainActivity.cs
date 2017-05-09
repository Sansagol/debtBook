using Android.App;
using Android.Widget;
using Android.OS;
using Android;

namespace DebtBook
{
    [Activity(Label = "DebtBook", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            var addButton = FindViewById<Button>(Resource.Id.btnAddDebt);
            addButton.Click += AddButton_Click;

            var DebtorName = FindViewById<EditText>(Resource.Id.etxDebtorName);
            DebtorName.TextChanged += DebtorName_TextChanged;
        }

        private void AddButton_Click(object sender, System.EventArgs e)
        {
        }

        private void DebtorName_TextChanged(object sender, Android.Text.TextChangedEventArgs e)
        {

        }
    }
}

