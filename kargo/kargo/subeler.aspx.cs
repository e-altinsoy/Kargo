using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace kargo
{
    public partial class subeler : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string CS = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Kargo_Otomasyonu;Integrated Security=True";
            SqlConnection con = new SqlConnection(CS);
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from tbl_subeler", con);
            Repeater1.DataSource = cmd.ExecuteReader();
            Repeater1.DataBind();
            con.Close();
        }
    }
}