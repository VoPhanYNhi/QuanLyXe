using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace To2_Nhom10_ChuDe16
{
    public partial class frmTaoTaiKhoan : Form
    {
        public frmTaoTaiKhoan()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsDANGNHAP");
        SqlDataAdapter daDangNhap;

        private void frmTaoTaiKhoan_Load(object sender, EventArgs e)
        {
            //Ket noi dang nhap
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            string sQueryDangNhap = @"Select * from DANGNHAP ";
            daDangNhap = new SqlDataAdapter(sQueryDangNhap, conn);
            daDangNhap.Fill(ds, "tblDSDangNhap");

            //command Them tai khoan
            string sThemTK = @"insert into DANGNHAP values(@tendangnhap,@matkhau,@loaitaikhoan)";
            SqlCommand cmThemTK = new SqlCommand(sThemTK, conn);
            cmThemTK.Parameters.Add("@tendangnhap", SqlDbType.VarChar, 20, "TenDangNhap");
            cmThemTK.Parameters.Add("@matkhau", SqlDbType.VarChar, 20, "MatKhau");
            cmThemTK.Parameters.Add("@loaitaikhoan", SqlDbType.VarChar, 10, "LoaiTaiKhoan");

            daDangNhap.InsertCommand = cmThemTK;
        }

        private void btnTao_Click(object sender, EventArgs e)
        {
            if (txtMatKhau.Text != txtMatKhau2.Text)
            {
                MessageBox.Show("Nhập lại mật khẩu");
                txtMatKhau.Clear();
                txtMatKhau.Focus();
                txtMatKhau2.Clear();
                return;
            }
            
            DataRow row = ds.Tables["tblDSDangNhap"].NewRow();
            row["TenDangNhap"] = txtTenTK.Text;
            row["MatKhau"] = txtMatKhau.Text;
            if (radThuong.Checked == true)
            {
                row["LoaiTaiKhoan"] = "thuong";
            }
            else
            {
                row["LoaiTaiKhoan"] = "admin";
            }

            ds.Tables["tblDSDangNhap"].Rows.Add(row);

            try
            {
                daDangNhap.Update(ds, "tblDSDangNhap");;
                MessageBox.Show("Đã thêm tài khoản", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }
    }
}
