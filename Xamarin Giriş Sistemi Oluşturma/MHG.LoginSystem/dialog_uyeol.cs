using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;
using System;

namespace MHG.LoginSystem
{
    class dialog_uyeol : DialogFragment
    {
        EditText txtAd;
        EditText txtSoyad;
        EditText txtTelefon;
        EditText txtEposta;
        Button btnKaydet;
        public event EventHandler<OnUyeOlEventArgs> UyeOlTamamlandi;

        public class OnUyeOlEventArgs : EventArgs
        {
            public string Ad { get; set; }

            public string Soyad { get; set; }

            public string Eposta{ get; set; }

            public string Telefon { get; set; }

            public OnUyeOlEventArgs(string ad, string soyad, string eposta, string telefon)
            {
                Ad = ad;
                Soyad = soyad;
                Telefon = telefon;
                Eposta = eposta;
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            //Dialog olarak gösterilmesini istediğimiz dialog_uye_ol adlı layout dosyasını parametre olarak veriyoruz.
            var view = inflater.Inflate(Resource.Layout.dialog_uye_ol, container, false);

            btnKaydet = view.FindViewById<Button>(Resource.Id.btnKaydet);
            txtAd = view.FindViewById<EditText>(Resource.Id.txtAd);
            txtSoyad = view.FindViewById<EditText>(Resource.Id.txtSoyad);
            txtEposta = view.FindViewById<EditText>(Resource.Id.txtEposta);
            txtTelefon = view.FindViewById<EditText>(Resource.Id.txtTelefon);

            btnKaydet.Click += BtnKaydet_Click;

            return view;
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            //UyeOlTamamlandi adlı eventhandler'imizi çalıştırıyoruz MainActivity.cs içerisindeki event'imiz böylelikle tetiklenmiş oluyor ve formda girdiğimiz verilere erişmiş oluyor.
            UyeOlTamamlandi.Invoke(this, new OnUyeOlEventArgs(txtAd.Text, txtSoyad.Text, txtEposta.Text, txtTelefon.Text));
            this.Dismiss();
        }

        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            //Başlık çubuğunu gizliyoruz.
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle);
            base.OnActivityCreated(savedInstanceState);
            //Oluşturmuş olduğumuz animasyonların tanımlarının yer aldığı xml style dosyasını atıyoruz.
            Dialog.Window.Attributes.WindowAnimations = Resource.Style.dialog_animation;
        }
    }
}