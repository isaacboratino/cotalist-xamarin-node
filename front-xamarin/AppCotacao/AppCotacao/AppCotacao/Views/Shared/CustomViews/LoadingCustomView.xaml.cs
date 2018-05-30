using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppCotacao.Views.Shared.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoadingCustomView : AbsoluteLayout
	{        
        public static readonly BindableProperty IsLoadingProperty = BindableProperty.Create(
                                                         propertyName: "IsLoading",
                                                         returnType: typeof(bool),
                                                         declaringType: typeof(LoadingCustomView),
                                                         defaultValue: false,
                                                         defaultBindingMode: BindingMode.TwoWay,
                                                         propertyChanged: IsLoadingPropertyChanged);

        public bool IsLoading
        {
            get { return (bool)base.GetValue(IsLoadingProperty); }
            set { base.SetValue(IsLoadingProperty, value); }
        }

        private static void IsLoadingPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (LoadingCustomView)bindable;
            bool isLoading = (bool)newValue;

            control.activityIndicator.IsRunning = isLoading;
            control.activityIndicator.IsVisible = isLoading;
            control.IsVisible = isLoading;
        }

        public LoadingCustomView ()
		{
			InitializeComponent ();
            this.activityIndicator.IsRunning = IsLoading;
            this.activityIndicator.IsVisible = IsLoading;
            this.IsVisible = IsLoading;
        }
    }
}