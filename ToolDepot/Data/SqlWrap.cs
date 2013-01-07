using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace ToolDepot.Data
{
    public  class SqlWrap
    {


        private string commandText;
        private List<SqlParameter> parameters =new List<SqlParameter>();


        public SqlWrap(string spName)
        {
            commandText = spName;
        }

        public SqlWrap AddParam(string fieldName, object value)
        {
            return AddParam(fieldName, value, false);
        }
        public SqlWrap AddParam(string fieldName, object value, bool isOutputType)
        {
            SqlParameter parameter = new SqlParameter(string.Format("@{0}", fieldName) , value);

            {
                parameter.Direction = ParameterDirection.Output;

            }
            if (value == null)
                parameter.Value = System.DBNull.Value;

            parameters.Add(parameter);

            return this;
        }



        public string Sql
        {
            get
            {

                var queryString = commandText;

                Parameters.ForEach(x => queryString = string.Format("{0} {1},", queryString, x.ParameterName));
                return queryString.TrimEnd(',');
            
            
            }
        }

        public  List<SqlParameter> Parameters { get { return parameters; } }

    }	
}