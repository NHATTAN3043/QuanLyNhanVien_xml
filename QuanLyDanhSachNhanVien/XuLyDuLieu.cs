using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyDanhSachNhanVien
{
    class XuLyDuLieu
    {
        SqlConnection conn = new SqlConnection("Data Source=localhost;Initial Catalog=QLNhanVien;Persist Security Info=True;User ID=sa;Password=Tan0369463503@");

        public void BackUpData()
        {
            BackUpData("DanhSachNhanVien", "tbNhanVien", "NhanVien");
        }

        String toString(XElement elm)
        {
            String result = "";
            foreach (XElement x in elm.Elements())
            {
                if (x == elm.LastNode)
                    result += "N'" + x.Value + "'";
                else
                {
                    result += "N'" + x.Value + "',";
                }
            }
            return "(" + result + "),\n";
        }
        private void BackUpData(String XMLFileName, String tableNameSql, String nutGoc)
        {

            XDocument XDoc = XDocument.Load("..\\..\\" + XMLFileName + ".xml");
            conn.Open();
            SqlCommand command;
            // Tạo chuỗi câu lệnh
            string query = "DELETE FROM " + tableNameSql + " \n insert into " + tableNameSql + " values\n";


            foreach (XElement x in XDoc.Descendants(nutGoc))
            {
                toString(x);
                query += toString(x);
            }
            MessageBox.Show(query);
            // Tạo xong là chạy như bình thường như chạy 1 câu trong ssms
            command = new SqlCommand(query.Substring(0, query.Length - 2), conn);
            command.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Sao lưu dữ liệu thành công!", "Chúc mừng");
            //try
            //{

            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show(e.Message);
            //    conn.Close();
            //}


        }
    }
}
