using Xamarin.Forms;

namespace AppCotacao.Services.ValidatorsBehaviors
{
    class RequiredValidatorBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool?), typeof(PasswordValidatorBehavior), null);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool? IsValid
        {
            get { return (bool?)base.GetValue(IsValidProperty); }
            set { base.SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += bindable_TextChanged;
        }

        private void bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (e.OldTextValue == null)
                IsValid = null;
            else
            {
                IsValid = e.NewTextValue.Length > 0;
                ((Entry)sender).TextColor = IsValid.Value ? Color.Default : Color.Red;
            }            
        }

        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= bindable_TextChanged;
        }
    }
}
