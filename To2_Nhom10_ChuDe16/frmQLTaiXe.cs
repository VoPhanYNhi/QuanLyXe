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
    public partial class frmQLTaiXe : Form
    {
        public frmQLTaiXe()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection();
        DataSet ds = new DataSet("dsTAIXE");
        SqlDataAdapter daTaiXe;
        SqlDataAdapter daXe;

        private void frmQLTaiXe_Load(object sender, EventArgs e)
        {
            conn.ConnectionString = KetNoi.ChuoiKetNoi();

            HienThiDataGrid();
            
            //Combobox Xe
            string sQueryXe = @"select * from XE ";
            daXe = new SqlDataAdapter(sQueryXe, conn);            
            daXe.Fill(ds, "tblDSXe");            
            cboTenXe.DataSource = ds.Tables["tblDSXe"];
            cboTenXe.DisplayMember = "TenXe";
            cboTenXe.ValueMember = "MaXe";        
            
            //Command Them TaiXe
            string sThemTaiXe = @"insert into TAIXE values(@mataixe, @hoten, @ngaysinh, @gioitinh, @sdt, @cmnd, @diachi, @ngaybatdaulam, @xedangchay, @luong)";
            SqlCommand cmThemTaiXe = new SqlCommand(sThemTaiXe, conn);
            cmThemTaiXe.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");
            cmThemTaiXe.Parameters.Add("@hoten", SqlDbType.NVarChar, 50, "HoTen");
            cmThemTaiXe.Parameters.Add("@ngaysinh", SqlDbType.Date, 10, "NgaySinh");
            cmThemTaiXe.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10, "GioiTinh");
            cmThemTaiXe.Parameters.Add("@sdt", SqlDbType.Char, 10, "SDT");
            cmThemTaiXe.Parameters.Add("@cmnd", SqlDbType.Char, 9, "CMND");
            cmThemTaiXe.Parameters.Add("@diachi", SqlDbType.NVarChar, 100, "DiaChi");
            cmThemTaiXe.Parameters.Add("@ngaybatdaulam", SqlDbType.Date, 10, "NgayBatDauLam");
            cmThemTaiXe.Parameters.Add("@xedangchay", SqlDbType.NVarChar, 10, "XeDangChay");
            cmThemTaiXe.Parameters.Add("@luong", SqlDbType.Int, 10, "Luong");

            daTaiXe.InsertCommand = cmThemTaiXe;

            //Command Sua Tai Xe
            string sSuaTaiXe = @"update TAIXE set HoTen=@hoten, NgaySinh=@ngaysinh, GioiTinh=@gioitinh, SDT=@sdt, CMND=@cmnd, DiaChi=@diachi, NgayBatDauLam=@ngaybatdaulam, XeDangChay=@xedangchay, Luong=@luong where MaTaiXe=@mataixe";
            SqlCommand cmSuaTaiXe = new SqlCommand(sSuaTaiXe, conn);
            cmSuaTaiXe.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");
            cmSuaTaiXe.Parameters.Add("@hoten", SqlDbType.NVarChar, 50, "HoTen");
            cmSuaTaiXe.Parameters.Add("@ngaysinh", SqlDbType.Date, 10, "NgaySinh");
            cmSuaTaiXe.Parameters.Add("@gioitinh", SqlDbType.NVarChar, 10, "GioiTinh");
            cmSuaTaiXe.Parameters.Add("@sdt", SqlDbType.Char, 10, "SDT");
            cmSuaTaiXe.Parameters.Add("@cmnd", SqlDbType.Char, 9, "CMND");
            cmSuaTaiXe.Parameters.Add("@diachi", SqlDbType.NVarChar, 50, "DiaChi");
            cmSuaTaiXe.Parameters.Add("@ngaybatdaulam", SqlDbType.Date, 10, "NgayBatDauLam");
            cmSuaTaiXe.Parameters.Add("@xedangchay", SqlDbType.NVarChar, 10, "XeDangChay");
            cmSuaTaiXe.Parameters.Add("@luong", SqlDbType.Int, 10, "Luong");

            daTaiXe.UpdateCommand = cmSuaTaiXe;

            //Command Xoa Tai Xe
            string sXoaTaiXe = @"delete from TAIXE where MaTaiXe=@mataixe";
            SqlCommand cmXoaTaiXe = new SqlCommand(sXoaTaiXe, conn);
            cmXoaTaiXe.Parameters.Add("@mataixe", SqlDbType.NVarChar, 10, "MaTaiXe");

            daTaiXe.DeleteCommand = cmXoaTaiXe;

            //An button luu va huy
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        public void HienThiDataGrid()
        {
            //string sQueryTaiXe = @"select n.*, c.TenXe from TaiXe n, Xe c where n.XeDangChay=c.MaXe";
            string sQueryTaiXe = @"select * from TAIXE";
            daTaiXe = new SqlDataAdapter(sQueryTaiXe, conn);
            daTaiXe.Fill(ds, "tblDSTaiXe");
            dgDSTaiXe.DataSource = ds.Tables["tblDSTaiXe"];
            dgDSTaiXe.Columns["XeDangChay"].HeaderText = "Mã Xe Đang Chạy";
            dgDSTaiXe.Columns["XeDangChay"].Width = 100;
            dgDSTaiXe.Columns["MaTaiXe"].HeaderText = "Mã Tài Xế";
            dgDSTaiXe.Columns["MaTaiXe"].Width = 80;
            dgDSTaiXe.Columns["HoTen"].HeaderText = "Họ Tên";
            dgDSTaiXe.Columns["HoTen"].Width = 200;
            dgDSTaiXe.Columns["NgaySinh"].HeaderText = "Ngày Sinh";
            dgDSTaiXe.Columns["NgaySinh"].Width = 80;
            dgDSTaiXe.Columns["GioiTinh"].HeaderText = "Giới Tính";
            dgDSTaiXe.Columns["GioiTinh"].Width = 50;
            dgDSTaiXe.Columns["SDT"].HeaderText = "SĐT";
            dgDSTaiXe.Columns["SDT"].Width = 100;
            dgDSTaiXe.Columns["CMND"].HeaderText = "CMND";
            dgDSTaiXe.Columns["CMND"].Width = 100;
            dgDSTaiXe.Columns["DiaChi"].HeaderText = "Địa Chỉ";
            dgDSTaiXe.Columns["DiaChi"].Width = 250;
            dgDSTaiXe.Columns["NgayBatDauLam"].HeaderText = "Ngày Bắt Đầu Làm";
            dgDSTaiXe.Columns["NgayBatDauLam"].Width = 100;
            dgDSTaiXe.Columns["Luong"].HeaderText = "Lương";
            dgDSTaiXe.Columns["Luong"].Width = 100;
        }

        private void dgDSTaiXe_Click(object sender, EventArgs e)
        {
            DataGridViewRow dr = dgDSTaiXe.SelectedRows[0];
            txtMaTaiXe.Text = dr.Cells["MaTaiXe"].Value.ToString();
            txtHoTen.Text = dr.Cells["HoTen"].Value.ToString();
            dtpNgaySinh.Text = dr.Cells["NgaySinh"].Value.ToString();

            if (dr.Cells["GioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;

            txtSDT.Text = dr.Cells["SDT"].Value.ToString();
            txtCMND.Text = dr.Cells["CMND"].Value.ToString();
            txtDiaChi.Text = dr.Cells["DiaChi"].Value.ToString();
            dtpNgayLam.Text = dr.Cells["NgayBatDauLam"].Value.ToString();
            if (dr.Cells["XeDangChay"].Value.ToString() == "")
            {
                radKhong.Checked = true;
            }
            else
            {
                radCo.Checked = true;
                cboTenXe.SelectedValue = dr.Cells["XeDangChay"].Value.ToString();
            }                
            txtLuong.Text = dr.Cells["Luong"].Value.ToString();
        }

        private void radCo_CheckedChanged(object sender, EventArgs e)
        {
            if (radCo.Checked == true)
            {
                cboTenXe.Enabled = true;
            }
            if (radKhong.Checked == true)
            {
                cboTenXe.Enabled = false;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (KiemTra())
            {
                //Kiem tra ma trung trong DataGridView
                DataGridViewRow dr;
                for (int i = 0; i < dgDSTaiXe.RowCount - 1; i++)
                {
                    dr = dgDSTaiXe.Rows[i];
                    if (txtMaTaiXe.Text == dr.Cells["MaTaiXe"].Value.ToString())
                    {
                        MessageBox.Show("Mã vừa nhập đã bị trùng!!!!", "Thông báo");
                        return;
                    }
                    if (cboTenXe.SelectedValue.Equals(dr.Cells["XeDangChay"].Value) && radCo.Checked == true)
                    {
                        MessageBox.Show("Xe đã có người khác lái!!!!", "Thông báo");
                        return;
                    }
                }

                DataRow row = ds.Tables["tblDSTaiXe"].NewRow();
                row["MaTaiXe"] = txtMaTaiXe.Text;
                row["HoTen"] = txtHoTen.Text;
                row["NgaySinh"] = dtpNgaySinh.Text;

                if (radNam.Checked == true)
                {
                    row["GioiTinh"] = "Nam";
                }
                else
                {
                    row["GioiTinh"] = "Nữ";
                }

                row["SDT"] = txtSDT.Text;
                row["CMND"] = txtCMND.Text;
                row["DiaChi"] = txtDiaChi.Text;
                row["NgayBatDauLam"] = dtpNgayLam.Text;

                if (radCo.Checked == true)
                {
                    row["XeDangChay"] = cboTenXe.SelectedValue;

                    foreach (DataRow r in ds.Tables["tblDSXe"].Rows)
                    {
                        if (r["MaXe"] == cboTenXe.SelectedValue)
                        {

                            r["TinhTrang"] = "Đã thuê";
                        }
                    }
                }
                else
                {
                    row["XeDangChay"] = null;
                }
                row["Luong"] = txtLuong.Text;

                ds.Tables["tblDSTaiXe"].Rows.Add(row);

                //Cho phep luu hoac huy
                btnLuu.Enabled = true;
                btnHuy.Enabled = true;
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if (dgDSTaiXe.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            if (KiemTra())
            {
                //Kiem tra xe da co ng lai chua
                DataGridViewRow dr2 = dgDSTaiXe.SelectedRows[0];
                if (!cboTenXe.SelectedValue.Equals(dr2.Cells["XeDangChay"].Value))
                for (int i = 0; i < dgDSTaiXe.RowCount - 1; i++)
                {
                    if (radKhong.Checked == true)
                        continue;
                    dr2 = dgDSTaiXe.Rows[i];
                    if (cboTenXe.SelectedValue.Equals(dr2.Cells["XeDangChay"].Value))
                    {
                        MessageBox.Show("Xe đã có người khác lái!!!!", "Thông báo");
                        return;
                    }
                }

                DataGridViewRow dr = dgDSTaiXe.SelectedRows[0];
                //Kiem tra ma tai xe co thay doi khong neu co -> khong cho phep sua
                if (txtMaTaiXe.Text == dr.Cells["MaTaiXe"].Value.ToString())
                {
                    dgDSTaiXe.BeginEdit(true);
                    dr.Cells["MaTaiXe"].Value = txtMaTaiXe.Text;
                    dr.Cells["HoTen"].Value = txtHoTen.Text;
                    dr.Cells["NgaySinh"].Value = dtpNgaySinh.Text;

                    if (radNam.Checked == true)
                    {
                        dr.Cells["GioiTinh"].Value = "Nam";
                    }
                    else
                    {
                        dr.Cells["GioiTinh"].Value = "Nữ";
                    }

                    dr.Cells["SDT"].Value = txtSDT.Text;
                    dr.Cells["CMND"].Value = txtCMND.Text;
                    dr.Cells["DiaChi"].Value = txtDiaChi.Text;
                    dr.Cells["NgayBatDauLam"].Value = dtpNgayLam.Text;

                    if (radCo.Checked == true)
                    {
                        dr.Cells["XeDangChay"].Value = cboTenXe.SelectedValue;
                    }
                    else
                    {
                        dr.Cells["XeDangChay"].Value = null;
                    }

                    dr.Cells["Luong"].Value = txtLuong.Text;

                    //Cho phep luu hoac huy
                    btnLuu.Enabled = true;
                    btnHuy.Enabled = true;
                }
                else
                    MessageBox.Show("Không thể sửa mã tài xế!!!", "Thông báo");

            }
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            //Kiem tra dong duoc chon
            if (dgDSTaiXe.SelectedRows[0].IsNewRow)
            {
                MessageBox.Show("Vui lòng chọn 1 dòng", "Thông báo");
                return;
            }

            DataGridViewRow dr = dgDSTaiXe.SelectedRows[0];
            dgDSTaiXe.Rows.Remove(dr);

            //Cho phep luu hoac huy
            btnLuu.Enabled = true;
            btnHuy.Enabled = true;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                daTaiXe.Update(ds, "tblDSTaiXe");
                MessageBox.Show("Đã lưu", "Thông báo");
                dgDSTaiXe.Refresh();

                //An button luu va huy
                btnLuu.Enabled = false;
                btnHuy.Enabled = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Thông báo");
                return;
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            ds.Tables["tblDSTaiXe"].RejectChanges();

            //An button luu va huy
            btnLuu.Enabled = false;
            btnHuy.Enabled = false;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Thoát????", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)

            {
                this.Close();
            }
        }

        //Ham kiem tra
        public bool KiemTra()
        {
            if (dtpNgaySinh.Value > DateTime.Parse("31/12/2001"))
            {
                MessageBox.Show("Ngày sinh không thể lớn hơn 31/12/2001", "Thông báo");
                return false;
            }
            if (txtMaTaiXe.Text == "")
            {
                MessageBox.Show("Nhập mã tài xế", "Thông báo");
                txtMaTaiXe.Focus();
                return false;
            }
            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Nhập họ tên", "Thông báo");
                txtHoTen.Focus();
                return false;
            }
            if (txtSDT.Text.Length!=10)
            {
                MessageBox.Show("Nhập số diện thoại", "Thông báo");
                txtSDT.Focus();
                return false;
            }
            if (txtCMND.Text.Length!=9)
            {
                MessageBox.Show("Nhập CMND", "Thông báo");
                txtCMND.Focus();
                return false;
            }
            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Nhập Địa chỉ nhân viên", "Thông báo");
                txtDiaChi.Focus();
                return false;
            }
            if (dtpNgayLam.Value<dtpNgaySinh.Value)
            {
                MessageBox.Show("Ngày làm không thể nhỏ hơn ngày sinh", "Thông báo");
                return false;
            }
            if (!KetNoi.KiemTraSoLonHon0(txtLuong.Text))
            {
                MessageBox.Show("Nhập lại lương", "Thông báo");
                txtLuong.Focus();
                return false;
            }
            return true;
        }

    }
}
