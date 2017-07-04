using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoDtPaging.DataTables
{
    public class DataTableColumn
    {
        public int Data;
        public string Name;
        public bool Orderable;
        public bool Searchable;
        public bool SearchRegex;
        public string SearchValue;

        private DataTableColumn()
        {
        }

        /// <summary>
        /// Retrieve the DataTables Columns dictionary from a JSON parameter list
        /// </summary>
        /// <param name="input">JToken object</param>
        /// <returns>Dictionary of Column elements</returns>
        public static Dictionary<int, DataTableColumn> Get(JToken input)
        {
            return (
                (JArray)input["columns"])
                .Select(col => new DataTableColumn
                {
                    Data = (int)col["data"],
                    Name =
                        new string(
                            ((string)col["name"]).Where(
                                c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray()),
                    Searchable = (bool)col["searchable"],
                    Orderable = (bool)col["orderable"],
                    SearchValue =
                        new string(
                            ((string)col["search"]["value"]).Where(
                                c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-').ToArray()),
                    SearchRegex = (bool)col["search"]["regex"]
                })
                .ToDictionary(c => c.Data);
        }
    }
}