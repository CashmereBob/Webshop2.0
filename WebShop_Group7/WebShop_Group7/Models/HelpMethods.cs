using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebShop_Group7.Models
{
    class HelpMethods
    {
        public string StringToSql(string strToSql)
        {
            string sqlToString=string.Empty;
            if (strToSql.Contains("'") )
            {
                sqlToString = strToSql.Replace("'", "''");
            }
            return sqlToString;
        }
    }
}
