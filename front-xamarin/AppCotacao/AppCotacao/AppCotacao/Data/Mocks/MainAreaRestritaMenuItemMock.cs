using AppCotacao.Views.Fornecedor;
using AppCotacao.Model;
using AppCotacao.Data.Repositories;
using AppCotacao.Views.Shared;
using System.Collections.Generic;
using Xamarin.Forms;

namespace AppCotacao.Data.Mocks
{
    public class MainAreaRestritaMenuItemMock : BaseGenericDataStore<MainAreaRestritaMenuItemModel>, IMainAreaRestritaMenuItemRepository
    {
        public MainAreaRestritaMenuItemMock()
        {
            items = new List<MainAreaRestritaMenuItemModel>();

            items = new List<MainAreaRestritaMenuItemModel>
            {
                new MainAreaRestritaMenuItemModel() { Title = "Principal", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconeprincipal.png"), TargetType = typeof(MainPageFornecedor), Order = 1 },
                new MainAreaRestritaMenuItemModel() { Title = "Dados Empresa", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconeempresa.png"), TargetType = typeof(DadosEmpresa), Order = 2 },                
                new MainAreaRestritaMenuItemModel() { Title = "Chat", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconechat.png"), TargetType = typeof(Chat), Order = 97 },
                new MainAreaRestritaMenuItemModel() { Title = "Configurações", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconeconfig.png"), TargetType = typeof(Configuracoes), Order = 98 },
                new MainAreaRestritaMenuItemModel() { Title = "Sair", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconesair.png"), TargetType = null, StyleId = "deslogar", Order = 99 }
            };

            if (App.CurrentTipoApp.Equals(TipoAppModel.FORNECEDOR))
            {
                items.Add(new MainAreaRestritaMenuItemModel() { Title = "Produtos", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconeproduto.png"), TargetType = typeof(Produtos), Order = 4 });
                items.Add(new MainAreaRestritaMenuItemModel() { Title = "Cotacoes", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconecotacao.png"), TargetType = typeof(Cotacoes), Order = 5 });
                items.Add(new MainAreaRestritaMenuItemModel() { Title = "Clientes", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconecliente.png"), TargetType = typeof(Clientes), Order = 6 });
            }
            else if (App.CurrentTipoApp.Equals(TipoAppModel.CLIENTE))
            {
                items.Add(new MainAreaRestritaMenuItemModel() { Title = "Cotacoes", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconecotacao.png"), TargetType = typeof(Login), Order = 4 });
                items.Add(new MainAreaRestritaMenuItemModel() { Title = "Fornecedores", Icon = ImageSource.FromResource("AppCotacao.Assets.Images.iconefornecedor.png"), TargetType = typeof(Login), Order = 5 });               
            }
        }
    }
}
