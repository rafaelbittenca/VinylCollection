using System.Web;
using System.Web.Mvc;
using Vinyl.UI.ViewModels;

namespace Vinyl.UI.Infra
{
    public class ParametrosPaginacaoModelBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpRequestBase request = controllerContext.HttpContext.Request;

            ParametrosPaginacao paramPagination = new ParametrosPaginacao(request.Form);

            return paramPagination;
        }
    }
}