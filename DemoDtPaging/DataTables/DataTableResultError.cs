using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Web;

namespace DemoDtPaging.DataTables
{
    [Serializable]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class DataTableResultError : DataTableResultSet
    {
        public string error;
    }
}