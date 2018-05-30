using AppCotacao.Views.Shared;
using AppCotacao.Model;
using Xamarin.Forms;

namespace AppCotacao
{
    public partial class App : Application
	{
        public const string BASE_API_URL = "http://192.168.0.3:2017";

        #region Cliente
        /**/
        public const string NAME_APP = "Cota Li$ta";
        public const string ICON_ANDROID = "@drawable/iconcliente";
        public static int CurrentTipoApp = TipoAppModel.CLIENTE;

        #endregion

        #region Fornecedor
        /*
        public const string NAME_APP = "Fornecedor - Cota Li$ta";
        public const string ICON_ANDROID = "@drawable/iconfornecedor";
        public static int CurrentTipoApp = TipoAppModel.FORNECEDOR;
        */
        #endregion

        public static string ApiToken { get; set; }
        public static bool IsUsuarioLogado { get; set; }

        public App ()
		{
			InitializeComponent();
            ApplyStyleByTypeApp();

            //MainPage = new MainMenuSlide();
            MainPage = new NavigationPage(new Login());
        }

        private void ApplyStyleByTypeApp()
        {
            var tipoAppPrefix = CurrentTipoApp.Equals(TipoAppModel.FORNECEDOR) ? "Fornecedor_" : "Cliente_";

            string[] StylesChangeByAppList =
            {
                "PrimaryBackColor",
                "PrimaryTextColor",
                "SecondaryBackColor",
                "ImageLogoSquare",
                "ImageIcone",
                "LabelSectionTitleBackColor",
                "LabelSectionTitleTextColor"
            };

            for (int i = 0; i < StylesChangeByAppList.Length; i++)
            {
                App.Current.Resources[StylesChangeByAppList[i]] = App.Current.Resources[tipoAppPrefix + StylesChangeByAppList[i]];
            }
        }

        protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}        
	}
}
