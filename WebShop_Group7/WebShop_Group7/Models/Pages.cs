using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace WebShop_Group7.Models
{
    public class Pages
    {
        DBConnection db = new DBConnection();
        public DataTable ListAllPages()
        {
            try
            {
                db.OpenConnection();

                using (DataTable dt = new DataTable("Page"))
                {
                    dt.Columns.AddRange(new DataColumn[2] { new DataColumn("ID"), new DataColumn("Name")});

                    string sql = "Select * From tbl_Page";
                    SqlCommand myCommand = new SqlCommand(sql, db._connection);




                    using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                    {

                        while (myDataReader.Read())
                        {
                            var id = int.Parse(myDataReader["ID"].ToString());
                            var name = myDataReader["Name"].ToString();
                           




                            dt.Rows.Add(id, name);
                        }
                    }
                    myCommand.ExecuteNonQuery();
                    return dt;
                }

            }
            catch
            {
                return null;
            }
            finally
            {
                db.CloseConnection();
            }
        }

        internal PageObject GetStartPage()
        {
            PageObject page = new PageObject();
            try
            {
                db.OpenConnection();

                string sql = $"Select * From tbl_Page WHERE Name = 'Startpage'";
                SqlCommand myCommand = new SqlCommand(sql, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        page.pageId = int.Parse(myDataReader["ID"].ToString());
                        page.name = myDataReader["Name"].ToString();
                        page.content = myDataReader["HTMLContent"].ToString();

                    }
                }



            }
            catch
            {
                return null;
            }
            finally
            {
                db.CloseConnection();
            }



            return page;
        }

        internal void DeletePage(int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"DELETE FROM tbl_Page WHERE id = '{id}'";
                SqlCommand insertCmd = new SqlCommand(sql, db._connection);
                insertCmd.ExecuteNonQuery();

            }
            catch
            {
                //TODO exeption
            }
            finally
            {
                db.CloseConnection();
            }
        }

        internal void UppdatePage(PageObject page, int id)
        {
            try
            {
                db.OpenConnection();

                string sql = $"UPDATE tbl_Page SET Name = '{page.name}', HTMLContent = '{page.content}' WHERE ID = '{id}'";

                SqlCommand insertCmd = new SqlCommand(sql, db._connection);
                insertCmd.ExecuteNonQuery();

            }
            catch
            {
                //TODO Exeption
            }
            finally
            {
                db.CloseConnection();
            }
        }

        internal PageObject GetPageById(int id)
        {
            PageObject page = new PageObject();
            try
            {
                db.OpenConnection();

                string sql = $"Select * From tbl_Page WHERE ID = '{id}'";
                SqlCommand myCommand = new SqlCommand(sql, db._connection);

                using (SqlDataReader myDataReader = myCommand.ExecuteReader())
                {

                    while (myDataReader.Read())
                    {
                        page.pageId = int.Parse(myDataReader["ID"].ToString());
                        page.name = myDataReader["Name"].ToString();
                        page.content = myDataReader["HTMLContent"].ToString();
                        
                    }
                }



            }
            catch
            {
                return null;
            }
            finally
            {
                db.CloseConnection();
            }



            return page;
        }

        internal void AddPage(PageObject page)
        {
            try
            {
                db.OpenConnection();

                string sql = $"Insert Into tbl_Page (Name, HTMLContent ) Values('{page.name}', '{page.content}')";

                SqlCommand insertCmd = new SqlCommand(sql, db._connection);
                insertCmd.ExecuteNonQuery();

            }
            catch
            {
                //TODO exeption
            }
            finally
            {
                db.CloseConnection();
            }
        }
    }
}