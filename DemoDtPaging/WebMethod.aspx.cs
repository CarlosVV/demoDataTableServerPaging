//This snkppet shows the webmethod to use
// Permission to use this code for any purpose and without fee is hereby granted.
// No warrantles.

using DemoDtPaging.DataTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DemoDtPaging
{
    public partial class WebMethod : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //https://social.technet.microsoft.com/wiki/contents/articles/23811.paging-a-query-with-sql-server.aspx
        [WebMethod(Description = "Server Side DataTables support", EnableSession = true)]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public static void Data(object parameters)
        {
            var req = DataTableParameters.Get(parameters);
            //...

            var resultSet = new DataTableResultSet();
            resultSet.draw = req.Draw;

            SqlConnection con = new SqlConnection("Data Source = localhost; Initial Catalog = test; Persist Security Info = True; User ID = sa; Password = sa");

            con.Open();

            var cmdCount = new SqlCommand("SELECT count(1) FROM systblRegCountries", con);
            var total = int.Parse(
                cmdCount.ExecuteScalar().ToString());

            var sql = string.Format(@"DECLARE @start AS INT, @length AS INT
            SET @start = {0}
            SET @length = {1} 
            SELECT * FROM (
                         SELECT ROW_NUMBER() OVER(ORDER BY Abbrev) AS Numero,
                                Abbrev, Country  FROM Countries
                           ) AS TBL
            WHERE Numero BETWEEN @start AND @start + @length - 1
            ORDER BY Abbrev", req.Start, req.Length);
            SqlCommand cmdQuery = new SqlCommand(sql, con);
            DataTable queryDb = new DataTable();
            queryDb.Load(cmdQuery.ExecuteReader());
            resultSet.recordsTotal = total; /* total number of records in table */
            resultSet.recordsFiltered = total; /* number of records after search - box filtering is applied */

            foreach (DataRow recordFromDb in queryDb.Rows)
            { /* this is pseudocode */
                var columns = new List<string>();
                columns.Add(recordFromDb[0].ToString());
                columns.Add(recordFromDb[1].ToString());
                columns.Add(recordFromDb[2].ToString());
                resultSet.data.Add(columns);
            }

            SendResponse(HttpContext.Current.Response, resultSet);
        }

        private static void SendResponse(HttpResponse response, DataTableResultSet result)
        {
            response.Clear();
            response.Headers.Add("X-Content-Type-Options", "nosniff");
            response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
            response.ContentType = "application/json; charset=utf-8";
            response.Write(result.ToJSON());
            response.Flush();
            response.End();
        }
    }
}