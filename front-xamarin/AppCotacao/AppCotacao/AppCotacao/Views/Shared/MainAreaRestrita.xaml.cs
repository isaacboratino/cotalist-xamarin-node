using AppCotacao.Views.Fornecedor;
using AppCotacao.Model;
using AppCotacao.ViewModels.Shared;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCotacao.Views.Shared
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainAreaRestrita : MasterDetailPage
    {
        MainAreaRestritaViewModel viewModel;

        public MainAreaRestrita()
        {
            BindingContext = viewModel = new MainAreaRestritaViewModel();

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(
                App.CurrentTipoApp.Equals(TipoAppModel.FORNECEDOR) ? new MainPageFornecedor() : new MainPageFornecedor());

            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainAreaRestrita_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            MainAreaRestritaMenuItemModel item = e.SelectedItem as MainAreaRestritaMenuItemModel;
            if (item != null)
            {
                if (item.StyleId.Equals("deslogar"))
                {
                    App.ApiToken = string.Empty;
                    App.IsUsuarioLogado = false;
                    Navigation.PopToRootAsync();
                }
                else
                {
                    Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType));
                    MenuListView.SelectedItem = null;
                    IsPresented = false;
                }                
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.MenuItems.Count == 0)
                viewModel.LoadMenuItemsCommand.Execute(null);
        }
    }
}