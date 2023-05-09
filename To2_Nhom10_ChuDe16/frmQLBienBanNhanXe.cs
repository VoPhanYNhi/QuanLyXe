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
    public partial class frmQLBienBanNhanXe : Form
    {
        public frmQLBienBanNhanXe()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsBBNX");
        SqlDataAdapter daBBNX;
        SqlDataAdapter daXe;
        SqlDataAdapter daHopDong;

        private void frmQLBienBanNhanXe_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();
            HienThiDataGrid();

            // combobox xe
            string sQueryXe = @"select * from XE";
            daXe = new SqlDataAdapter(sQueryXe, conn);
            daXe.Fill(ds, "tblDSXe");
            cboTenXe.DataSource = ds.Tables["tblDSXe"];
            cboTenXe.DisplayMember = "TenXe";
            cboTenXe.ValueMember = "MaXe";
            
            //combobox hopdong
            string sQueryHopDong = @"select * from HOPDONG";
            daHopDong = new SqlDataAdapter(sQueryHopDong, conn);
            daHopDong.Fill(ds, "tblDSHopDong");
            cboTenHD.DataSource = ds.Tables["tblDSHopDong"];
            cboTenHD.DisplayMember = "TenHD";
            cboTenHD.ValueMember = "MaHD";

            //Command Them BBNX
            string sThemBBNX = @"insert into BIENBANNHANXE values(@mahd, @maxe, @ngaygiao, @trangthaive, @sucophatsinh, @tienphat, @ngaynhan)";
            SqlCommand cmThemBBNX = new SqlCommand(sThemBBNX, conn);
            cmThemBBNX.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmThemBBNX.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmThemBBNX.Parameters.Add("@ngaygiao", SqlDbType.SmallDateTime, 10, "NgayGiao");
            cmThemBBNX.Parameters.Add("@trangthaive", SqlDbType.NVarChar, 50, "TrangThaiVe");
            cmThemBBNX.Parameters.Add("@sucophatsinh", SqlDbType.NVarChar, 1000, "SuCoPhatSinh");
            cmThemBBNX.Parameters.Add("@tienphat", SqlDbType.Int, 10, "TienPhat");
            cmThemBBNX.Parameters.Add("@ngaynhan", SqlDbType.SmallDateTime, 10, "NgayNhan");

            daBBNX.InsertCommand = cmThemBBNX;

            //Command Sua BBNX
            string sSuaBBNX = @"update BIENBANNHANXE set NgayGiao=@ngaygiao, TrangThaiVe=@trangthaive, SuCoPhatSinh=@sucophatsinh, TienPhat=@tienphat, NgayNhan=@ngaynhan Where MaHD=@mahd and MaXe=@maxe";
            SqlCommand cmSuaBBNX = new SqlCommand(sSuaBBNX, conn);
            cmSuaBBNX.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmSuaBBNX.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");
            cmSuaBBNX.Parameters.Add("@ngaygiao", SqlDbType.SmallDateTime, 10, "NgayGiao");
            cmSuaBBNX.Parameters.Add("@trangthaive", SqlDbType.NVarChar, 50, "TrangThaiVe");
            cmSuaBBNX.Parameters.Add("@sucophatsinh", SqlDbType.NVarChar, 1000, "SuCoPhatSinh");
            cmSuaBBNX.Parameters.Add("@tienphat", SqlDbType.Int, 10, "TienPhat");
            cmSuaBBNX.Parameters.Add("@ngaynhan", SqlDbType.SmallDateTime, 10, "NgayNhan");

            daBBNX.UpdateCommand = cmSuaBBNX;

            //Command Xoa BBNX
            string sXoaBBNX = @"delete from BIENBANNHANXE where  MaHD=@mahd and MaXe=@maxe";
            SqlCommand cmXoaBBNX = new SqlCommand(sXoaBBNX, conn);
            cmXoaBBNX.Parameters.Add("@mahd", SqlDbType.NVarChar, 10, "MaHD");
            cmXoaBBNX.Parameters.Add("@maxe", SqlDbType.NVarChar, 10, "MaXe");

            daBBNX.DeleteCommand = cmXoaBBNX;

        }

        public void HienThiDataGrid()
        {
            string sQueryBBNX = @"Select b.TenHD, a.TenXe, n.*  From BienBanNhanXe n, XE a, HOPDONG b Where n.MaXe = a.MaXe and n.MaHD = b.MaHD ";
            daBBNX = new SqlDataAdapter(sQueryBBNX, conn);
            daBBNX.Fill(ds, "tblDSBBNX");
            dgDSBBNX.DataSource = ds.Tables["tblDSBBNX"];
            dgDSBBNX.Columns["MaXe"].Visible = false;
            dgDSBBNX.Columns["MaHD"].Visible = false;
            
            dgDSBBNX.Columns["TenHD"].HeaderText = "Tên Hợp Đồng";
            dgDSBBNX.Columns["TenHD"].Width = 80;
            dgDSBBNX.Columns["TenXe"].HeaderText = "Tên Xe";
            dgDSBBNX.Columns["TenXe"].Width = 200;
            dgDSBBNX.Columns["NgayGiao"].HeaderText = "Ngày Thanh Toán";
            dgDSBBNX.Columns["NgayGiao"].Width = 100;            
            dgDSBBNX.Columns["TrangThaiVe"].HeaderText = "Trạng Thái Về";
            dgDSBBNX.Columns["TrangThaiVe"].Width = 250;
            dgDSBBNX.Columns["SuCoPhatSinh"].HeaderText = "Sự Cố Phát Sinh";
            dgDSBBNX.Columns["SuCoPhatSinh"].Width = 250;
            dgDSBBNX.Columns["TienPhat"].HeaderText = "Tiền Phạt";
            dgDSBBNX.Columns["TienPhat"].Width = 100;
            dgDSBBNX.Columns["NgayNhan"].HeaderText = "Ngày Nhận";
            dgDSBBNX.Columns["NgayNhan"].Width = 100;
        }

        private void dgDSBBNX_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSBBNX.SelectedRows[0];
            cboTenHD.Text = dr.Cells["TenHD"].Value.ToString();
            cboTenXe.Text = dr.Cells["TenXe"].Value.ToString();
            dtpNgayGiao.Text = dr.Cells["NgayGiao"].Value.ToString();
            txtTrangThaiVe.Text = dr.Cells["TrangThaiVe"].Value.ToString();
            txtSuCoPhatSinh.Text = dr.Cells["SuCoPhatSinh"].Value.ToString();
            txtTienPhat.Text = dr.Cells["TienPhat"].Value.ToString();
            dtpNgayNhan.Text = dr.Cells["NgayNhan"].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                DataRow row = ds.Tables["tblDSBBNX"].NewRow();

                // //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSBBNX.RowCount - 1; i++)
                {
                    dr = dgDSBBNX.Rows[i];
                    if (cboTenHD.SelectedValue.Equals(dr.Cells["MaHD"].Value) && cboTenXe.SelectedValue.Equals(dr.Cells["MaXe"].Value))
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                }
                row["MaHD"] = cboTenHD.SelectedValue;
                row["MaXe"] = cboTenXe.SelectedValue;
                row["NgayGiao"] = dtpNgayGiao.Text;
                row["TrangThaiVe"] = txtTrangThaiVe.Text;
                row["SuCoPhatSinh"] = txtSuCoPhatSinh.Text;
                row["TienPhat"] = txtTienPhat.Text;
                row["NgayNhan"] = dtpNgayNhan.Text;
                row["TenHD"] = cboTenHD.Text;
                row["TenXe"] = cboTenXe.Text;

                ds.Tables["tblDSBBNX"].Rows.Add(row);
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgDSBBNX.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }
            if (KiemTra())
            {
                DataGridViewRow dr = dgDSBBNX.SelectedRows[0];
                dr.Cells["MaHD"].Value = cboTenHD.SelectedValue;
                dr.Cells["MaXe"].Value = cboTenXe.SelectedValue;
                dr.Cells["NgayGiao"].Value = dtpNgayGiao.Text;
                dr.Cells["TrangThaiVe"].Value = txtTrangThaiVe.Text;
                dr.Cells["SuCoPhatSinh"].Value = txtSuCoPhatSinh.Text;
                dr.Cells["TienPhat"].Value = txtTienPhat.Text;
                dr.Cells["NgayNhan"].Value = dtpNgayNhan.Text;
                dr.Cells["TenHD"].Value = cboTenHD.Text;
                dr.Cells["TenXe"].Value = cboTenXe.Text;
            }
               
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {           
            if (dgDSBBNX.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }
            DataGridViewRow dr = dgDSBBNX.SelectedRows[0];
            dgDSBBNX.Rows.Remove(dr);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daBBNX.Update(ds, "tblDSBBNX");
                MessageBox.Show("Đã lưu", "Thông báo");
                dgDSBBNX.Refresh();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo lỗi");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDSBBNX"].RejectChanges();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát????", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public bool KiemTra()
        {
            if (txtTrangThaiVe.Text == "")
            {
                MessageBox.Show("Nhập trạng thái về", "Thông báo");
                txtTrangThaiVe.Focus();
                return false;
            }
            if (txtSuCoPhatSinh.Text == "")
            {
                MessageBox.Show("Nhập sự cố phát sinh", "Thông báo");
                txtSuCoPhatSinh.Focus();
                return false;
            }
            if (txtSuCoPhatSinh.Text == "")
            {
                MessageBox.Show("Nhập sự cố phát sinh", "Thông báo");
                txtSuCoPhatSinh.Focus();
                return false;
            }
            if (!KetNoi.KiemTraSoLonHon0(txtTienPhat.Text))
            {
                MessageBox.Show("Nhập tiền phạt", "Thông báo");
                txtTienPhat.Focus();
                return false;
            }
            if (dtpNgayGiao.Value > dtpNgayNhan.Value)
            {
                MessageBox.Show("Ngày nhận không thể nhỏ hơn ngày giao", "Thông báo");
                return false;
            }
            return true;
        }
    }
}
