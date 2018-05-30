using AppCotacao.Services.Utils;
using Xamarin.Forms;

namespace AppCotacao.Services.ValidatorsBehaviors
{
    class EmailValidatorBehavior : Behavior<Entry>
    {        
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool?), typeof(NumberValidatorBehavior), null);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool? IsValid
        {
            get {
                return (bool?)base.GetValue(IsValidProperty);
            }
            set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
        }


        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue == null)
                IsValid = null;
            else
            {
                IsValid = (ValidationsUtil.IsEmailValid(e.NewTextValue));
                ((Entry)sender).TextColor = IsValid.Value ? Color.Default : Color.Red;
            }            
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;

        }
    }
}
