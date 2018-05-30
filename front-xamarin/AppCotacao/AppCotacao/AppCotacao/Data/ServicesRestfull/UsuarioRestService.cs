using AppCotacao.Model;

namespace AppCotacao.Data.ServicesRestfull
{
    public class UsuarioRestService : BaseRestService<UsuarioModel>//, IUsuarioRestService
    {
        public UsuarioRestService(string apiMap) : base(apiMap) {}        
    }
}
