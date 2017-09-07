using System;
using System.Collections.Specialized;
using System.Linq;

namespace Vinyl.UI.ViewModels
{
    public class ParametrosPaginacao
    {
        public ParametrosPaginacao(NameValueCollection dados)
        {
            string campoChave = dados.AllKeys.Where(k => k.StartsWith("sort")).First();
            string ordem = dados[campoChave];
            string campo = campoChave.Replace("sort[", String.Empty).Replace("]", String.Empty);

            CampoOrdenado = string.Format("{0} {1}", campo, ordem);

            Current = int.Parse(dados["current"]);
            RowCount = int.Parse(dados["rowCount"]);
            SearchPhrase = dados["searchPhrase"];
        }

        public int Current { get; set; }
        public int RowCount { get; set; }
        public string SearchPhrase { get; set; }
        public string CampoOrdenado { get; set; }
    }
}