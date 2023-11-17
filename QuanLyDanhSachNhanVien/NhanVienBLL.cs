using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyDanhSachNhanVien
{
    class NhanVienBLL
    {
        private XmlDocument doc = new XmlDocument();
        private XmlElement root;
        private XDocument xdoc;
        private string filename = @"../../DanhSachNhanVien.xml";

        public NhanVienBLL()
        {
            doc.Load(filename);
            root = doc.DocumentElement;
            xdoc = XDocument.Load(filename);
        }
        public void ThemNV(NhanVien_DTO nv)
        {
            XmlNode NhanVien = doc.CreateElement("NhanVien");

            //tao cac nut con cua NhanVien
            XmlElement maNV = doc.CreateElement("MaNhanVien");
            maNV.InnerText = nv.maNV1; //gan gia tri cho ma nhan vien
            NhanVien.AppendChild(maNV); // them nut con maNV vaof nut  NhanVien

            XmlElement tenNV = doc.CreateElement("TenNhanVien");
            tenNV.InnerText = nv.tenNV1; //gan gia tri cho ma nhan vien
            NhanVien.AppendChild(tenNV); // them nut con maNV vaof nut  NhanVien

            XmlElement gioiTinh = doc.CreateElement("GioiTinh");
            gioiTinh.InnerText = nv.gioiTinh1; //gan gia tri cho ma nhan vien
            NhanVien.AppendChild(gioiTinh); // them nut con maNV vaof nut  NhanVien

            XmlElement diaChi = doc.CreateElement("DiaChi");
            diaChi.InnerText = nv.diaChi1; //gan gia tri cho ma nhan vien
            NhanVien.AppendChild(diaChi); // them nut con maNV vaof nut  NhanVien

            XmlElement sdt = doc.CreateElement("SDT");
            sdt.InnerText = nv.sdt1; //gan gia tri cho ma nhan vien
            NhanVien.AppendChild(sdt); // them nut con maNV vaof nut  NhanVien

            // sau khi them nut NhanVien thi them vao nut Goc
            root.AppendChild(NhanVien);
            doc.Save(filename); // luu vao file xml 


        }
        public void Xoa(NhanVien_DTO nv)
        {
            XmlNode NhanVienXoa = root.SelectSingleNode("NhanVien[MaNhanVien ='" + nv.maNV1 + "']");
            if (NhanVienXoa != null)
            {
                root.RemoveChild(NhanVienXoa);
                doc.Save(filename);
            }
        }
        public void Sua(NhanVien_DTO nv)
        {
            // lay vi tri nhan vien can sua trong node
            XmlNode NhanVienSua = root.SelectSingleNode("NhanVien[MaNhanVien = '" + nv.maNV1 + "']");

            if (NhanVienSua != null)
            {
                XmlNode NhanVienSuaMoi = doc.CreateElement("NhanVien");

                //tao nut con cua nhanvien
                XmlElement maNV = doc.CreateElement("MaNhanVien");
                maNV.InnerText = nv.maNV1; //gan gia tri cho ma nhan vien
                NhanVienSuaMoi.AppendChild(maNV); // them nut con maNV vaof nut  NhanVien

                XmlElement tenNV = doc.CreateElement("TenNhanVien");
                tenNV.InnerText = nv.tenNV1; //gan gia tri cho ma nhan vien
                NhanVienSuaMoi.AppendChild(tenNV); // them nut con maNV vaof nut  NhanVien

                XmlElement gioiTinh = doc.CreateElement("GioiTinh");
                gioiTinh.InnerText = nv.gioiTinh1; //gan gia tri cho ma nhan vien
                NhanVienSuaMoi.AppendChild(gioiTinh); // them nut con maNV vaof nut  NhanVien

                XmlElement diaChi = doc.CreateElement("DiaChi");
                diaChi.InnerText = nv.diaChi1; //gan gia tri cho ma nhan vien
                NhanVienSuaMoi.AppendChild(diaChi); // them nut con maNV vaof nut  NhanVien

                XmlElement sdt = doc.CreateElement("SDT");
                sdt.InnerText = nv.sdt1; //gan gia tri cho ma nhan vien
                NhanVienSuaMoi.AppendChild(sdt); // them nut con maNV vaof nut  NhanVien

                //thay the nhanvien cu thanh nv moi
                root.ReplaceChild(NhanVienSuaMoi, NhanVienSua);
                doc.Save(filename);
            }

        }
        public void HienThi(DataGridView dgv)
        {
            dgv.Rows.Clear();
            dgv.ColumnCount = 5;

            XmlNodeList ds = root.SelectNodes("NhanVien");
            int sd = 0;//lưu chỉ số dòng
            foreach (XmlNode item in ds)
            {
                dgv.Rows.Add();
                dgv.Rows[sd].Cells[0].Value = item.SelectSingleNode("MaNhanVien").InnerText;
                dgv.Rows[sd].Cells[1].Value = item.SelectSingleNode("TenNhanVien").InnerText;
                dgv.Rows[sd].Cells[2].Value = item.SelectSingleNode("GioiTinh").InnerText;
                dgv.Rows[sd].Cells[3].Value = item.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[sd].Cells[4].Value = item.SelectSingleNode("SDT").InnerText;       
                sd++;
            }
        }
        public void TimKiem(string content, string node, DataGridView dgv)
        {
            dgv.Rows.Clear();
            int rowCount = 0; // Số lượng hàng đã thêm vào DataGridView

            XmlNodeList nodeList = root.SelectNodes("NhanVien[" + node + "='" + content + "']");
            foreach (XmlNode nodeItem in nodeList)
            {
                dgv.Rows.Add(); // Thêm một dòng mới cho mỗi kết quả

                dgv.Rows[rowCount].Cells[0].Value = nodeItem.SelectSingleNode("MaNhanVien").InnerText;
                dgv.Rows[rowCount].Cells[1].Value = nodeItem.SelectSingleNode("TenNhanVien").InnerText;
                dgv.Rows[rowCount].Cells[2].Value = nodeItem.SelectSingleNode("GioiTinh").InnerText;
                dgv.Rows[rowCount].Cells[3].Value = nodeItem.SelectSingleNode("DiaChi").InnerText;
                dgv.Rows[rowCount].Cells[4].Value = nodeItem.SelectSingleNode("SDT").InnerText;

                rowCount++;
            }
        }


    }
}
