using AppCotacao.Data.Mocks;
using AppCotacao.Data.Repositories;
using AppCotacao.Model;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppCotacao.ViewModels.Shared
{
    class MainAreaRestritaViewModel : BaseViewModel
    {
        public IMainAreaRestritaMenuItemRepository DataStore => DependencyService.Get<IMainAreaRestritaMenuItemRepository>() ?? new MainAreaRestritaMenuItemMock();

        public ObservableCollection<MainAreaRestritaMenuItemModel> MenuItems { get; set; }
        public Command LoadMenuItemsCommand { get; set; }

        public MainAreaRestritaViewModel()
        {
            MenuItems = new ObservableCollection<MainAreaRestritaMenuItemModel>();
            LoadMenuItemsCommand = new Command(async () => await ExecuteGetMenuItemsCommand());
        }

        async Task ExecuteGetMenuItemsCommand()
        {
            if (IsLoading)
                return;

            IsLoading = true;
            
            try
            {
                MenuItems.Clear();
                var items = await DataStore.GetAllAsync(true);
                var itemsOrdened = items.OrderBy(o => o.Order).ToList();
                foreach (var item in itemsOrdened)
                {
                    MenuItems.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsLoading = false;
            }
        }
    }
}
