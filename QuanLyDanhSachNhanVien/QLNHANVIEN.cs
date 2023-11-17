using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyDanhSachNhanVien
{
    public partial class QLNHANVIEN : Form
    {
        private XDocument xmldoc;
        private NhanVienBLL nvBLL = new NhanVienBLL();
        private NhanVien_DTO nvDTO = new NhanVien_DTO();
        private DataTable dataTable;

        public QLNHANVIEN()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void QLNHANVIEN_Load(object sender, EventArgs e)
        {
            xmldoc = XDocument.Load(@"../../DanhSachNhanVien.xml");
            nvBLL.HienThi(dataGridView1);
            LoadComboBoxTK();
       
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text.Trim() != null)
            {
                // gan du lieu vao dto
                nvDTO.maNV1 = txtMaNV.Text;
                nvDTO.tenNV1 = txtTenNV.Text;
                nvDTO.gioiTinh1 = txt_Gioitinh.Text;
                nvDTO.diaChi1 = txt_Diachi.Text;
                nvDTO.sdt1 = txt_sdt.Text;
           
                // goi NhanVien BLL de them
                nvBLL.ThemNV(nvDTO);
                // hien thi lai danh sach
                MessageBox.Show("Them thanh cong !");
                nvBLL.HienThi(dataGridView1);

            }
            else
            {
                MessageBox.Show("Vui long nhap ma Nhan Vien de them !");
            }
        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            if (txtMaNV.Text.Trim() != null)
            {
                // gan du lieu vao dto
                nvDTO.maNV1 = txtMaNV.Text;
                nvDTO.tenNV1 = txtTenNV.Text;
                nvDTO.gioiTinh1 = txt_Gioitinh.Text;
                nvDTO.diaChi1 = txt_Diachi.Text;
                nvDTO.sdt1 = txt_sdt.Text;

                // goi NhanVien BLL de them
                nvBLL.Sua(nvDTO);
                // hien thi lai danh sach
                MessageBox.Show("Sua thanh cong !");
                nvBLL.HienThi(dataGridView1);

            }
            else
            {
                MessageBox.Show("Vui long nhap ma Nhan Vien de sua !");
            }
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            if(txtMaNV.Text.Trim() != null)
            {
                nvDTO.maNV1 = txtMaNV.Text;

                nvBLL.Xoa(nvDTO);
                MessageBox.Show("Xoa thanh cong !");
                nvBLL.HienThi(dataGridView1);
            }
            else
            {
                MessageBox.Show("Nhap ma Nhan Vien de xoa !");
            }
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private void LoadComboBoxTK()
        {
            foreach(DataGridViewColumn column in dataGridView1.Columns)
            {
                comboBox1.Items.Add(column.DataPropertyName);
            }
        }
        private void LoadDataColumn()
        {
            string data = null;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                if(column.HeaderText == "Mã Nhân viên")
                data = column.DataPropertyName;
            }
            MessageBox.Show(data);
            
        }
        private void btn_tim_Click(object sender, EventArgs e)
        {
            if(txtTimKiem.Text.Trim() != ""){
                string txt = txtTimKiem.Text;
                string nodetxt = comboBox1.SelectedItem.ToString();
                nvBLL.TimKiem(txt,nodetxt,dataGridView1);
                //khác null là tìm thấy, thực hiện bind lên ui
            
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_saoluu_Click(object sender, EventArgs e)
        {
            XuLyDuLieu data = new XuLyDuLieu();
            data.BackUpData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
             nvBLL.HienThi(dataGridView1);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                dataGridView1.CurrentRow.Selected = true;
                txtMaNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Column1"].FormattedValue.ToString();
                txtTenNV.Text = dataGridView1.Rows[e.RowIndex].Cells["Column2"].FormattedValue.ToString();
                txt_Gioitinh.Text = dataGridView1.Rows[e.RowIndex].Cells["Column3"].FormattedValue.ToString();
                txt_Diachi.Text = dataGridView1.Rows[e.RowIndex].Cells["Column4"].FormattedValue.ToString();
                txt_sdt.Text = dataGridView1.Rows[e.RowIndex].Cells["Column5"].FormattedValue.ToString();
       

            }
        }
    }
}
