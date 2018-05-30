using AppCotacao.Views.Shared;
using System;
using Xamarin.Forms;

namespace AppCotacao.Model
{

    public class MainAreaRestritaMenuItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; }        
        public string StyleId { get; set; }
        public int Order { get; set; }
        public Type TargetType { get; set; }
        public ImageSource Icon { get; internal set; }

        public MainAreaRestritaMenuItemModel()
        {
            TargetType = typeof(MainAreaRestrita);
        }
    }
}