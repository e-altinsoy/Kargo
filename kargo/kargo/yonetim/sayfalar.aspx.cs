using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace kargo.yonetim
{
    public partial class sayfalar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["giris"] != "evet")
                Response.Redirect("default.aspx");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedRowIndex;
            selectedRowIndex = GridView1.SelectedIndex;
            GridViewRow row = GridView1.Rows[selectedRowIndex];
            string id = row.Cells[0].Text.ToString();
            Response.Redirect("sayfaduzenle.aspx?id=" + id);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int selectedRowIndex;
            selectedRowIndex = e.RowIndex;
            GridViewRow row = GridView1.Rows[selectedRowIndex];
            string sid = row.Cells[0].Text.ToString();
            string veritabani = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Kargo_Otomasyonu;Integrated Security=True";
            // Bağlantı nesnemizi tanımlıyoruz.
            SqlConnection baglanti = new SqlConnection(veritabani);
            // Sorgu nesnemizi tanımlıyoruz.
            SqlCommand sorgu = new SqlCommand();
            // Sorgumuzu baglanti nesnesine bağlıyoruz.
            sorgu.Connection = baglanti;
            baglanti.Open();
            // Güncelleme işlemini bu sorgudaki gibi gerçekleştiriyoruz.
            sorgu.CommandText = "delete from tbl_sayfalar WHERE sayfaid=" + sid;
            sorgu.ExecuteNonQuery();
            baglanti.Close();
            Response.Redirect("sayfalar.aspx");
        }
    }
}