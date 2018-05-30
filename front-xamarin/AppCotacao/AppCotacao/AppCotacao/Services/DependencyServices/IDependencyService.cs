namespace AppCotacao.Services.DependencyServices
{
    public interface IDependencyService
    {
        void Register<T>(T impl) where T : class ;
        T Get<T>() where T : class;
    }
}
