using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Script.Services;


/// <summary>
/// Summary description for WebService
/// </summary>
[ScriptService]
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {
    [WebMethod]
    public string[] GetTenCV(string prefixText)
    {
        SqlConnection BaoVe = new SqlConnection("server=(local)\\SQLEXPRESS;uid=sa;pwd=123456;database=QuanLyCongVan");
        SqlCommand Lenh = new SqlCommand("CongVan_TimTheoTen", BaoVe);
        Lenh.CommandType = CommandType.StoredProcedure;
        SqlParameter ThamSo = new SqlParameter();
        ThamSo = Lenh.Parameters.AddWithValue("@TenCV", prefixText);
        DataTable ThungChua = new DataTable();
        SqlDataReader DocDL;
        BaoVe.Open();//mở kết nối đến CSDL
        DocDL = Lenh.ExecuteReader(CommandBehavior.CloseConnection);
        ThungChua.Load(DocDL);
        BaoVe.Close();
        int i = 0;
        string[] cntName = new string[ThungChua.Rows.Count];
        foreach (DataRow row in ThungChua.Rows)
        {
            cntName.SetValue(row["TenCV"].ToString(), i);
            i++;
        }
        return cntName;
    }
    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    
}
