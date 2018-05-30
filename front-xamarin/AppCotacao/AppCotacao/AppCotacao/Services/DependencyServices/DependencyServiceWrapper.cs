using Xamarin.Forms;

namespace AppCotacao.Services.DependencyServices
{
    public class DependencyServiceWrapper : IDependencyService
    {
        public T Get<T>() where T : class
        {
            // The wrapper will simply pass everything through to the real Xamarin.Forms DependencyService class when not unit testing
            return DependencyService.Get<T>();
        }

        public void Register<T>(T impl) where T : class
        {
            throw new System.NotImplementedException();
        }
    }
}
