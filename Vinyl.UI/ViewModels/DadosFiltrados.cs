using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vinyl.UI.ViewModels
{
    public class DadosFiltrados
    {
        public DadosFiltrados(ParametrosPaginacao parametrosPaginacao)
        {
            rowCount = parametrosPaginacao.RowCount;
            current = parametrosPaginacao.Current;
        }
        /// <summary>
        ///  In lowercase because of Json, if would a normal class would be UpperCase the first letter
        /// </summary>
        public int current { get; set; }
        public int rowCount { get; set; }
        public int total { get; set; }
        public dynamic rows { get; set; }
    }
}