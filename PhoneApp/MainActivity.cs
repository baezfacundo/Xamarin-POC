using Android.App;
using Android.Widget;
using Android.OS;

namespace PhoneApp
{
    [Activity(Label = "PhoneApp", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            var phoneNumberText = FindViewById<EditText>(Resource.Id.phoneNumberText);
            var btnTranslate = FindViewById<Button>(Resource.Id.btnTranslator);
            var btnCall = FindViewById<Button>(Resource.Id.btnCall);

            btnCall.Enabled = false;
            var translatedNumber = string.Empty;

            btnTranslate.Click += (object sender, System.EventArgs ev)=> {
                var translator = new PhoneTranslator();
                translatedNumber = translator.ToNumber(phoneNumberText.Text);
                if (string.IsNullOrWhiteSpace(translatedNumber))
                {
                    btnCall.Enabled = false;
                    btnCall.Text = "Llamar";
                } else
                {
                    btnCall.Enabled = true;
                    btnCall.Text = $"Llamar al {translatedNumber}";
                }
            };

            btnCall.Click += (object sender, System.EventArgs ev) =>
            {
                var calldialog = new AlertDialog.Builder(this);
                calldialog.SetMessage($"Llamar al numero {translatedNumber}");
                calldialog.SetNeutralButton("Llamar", delegate {
                var callintent = new Android.Content.Intent(Android.Content.Intent.ActionCall);
                    callintent.SetData(Android.Net.Uri.Parse($"tel:{translatedNumber}"));
                    StartActivity(callintent);
                });
                calldialog.SetNegativeButton("Cancelar", delegate { });
                calldialog.Show();
            };
        }
    }
}

