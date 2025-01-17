﻿using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLVT
{
    
    
    public partial class frmNhanvien : DevExpress.XtraEditors.XtraForm
    {
        int undo=0;
        int vitri = 0;
         String macn="";
        public frmNhanvien()
        {
            InitializeComponent();

            WindowState = FormWindowState.Maximized;

            
            
            
            // This line of code is generated by Data Source Configuration Wizard

        }


       

        private void nhanVienBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }
        private SqlConnection conn_publisher = new SqlConnection();
        private void LayDSPM(String cmd)
        {
            DataTable dt = new DataTable();
            if (conn_publisher.State == ConnectionState.Closed) conn_publisher.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd, conn_publisher);
            da.Fill(dt);
            conn_publisher.Close();
            Program.bds_dspm.DataSource = dt;
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER";



        }

        private int KetNoi_CSDLGOC()
        {
            if (conn_publisher != null && conn_publisher.State == ConnectionState.Open)
            {
                conn_publisher.Close();
            }
            try
            {
                conn_publisher.ConnectionString = Program.constr_publisher;
                conn_publisher.Open();
                return 1;
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi kết nối về CSDL gốc. \nBạn xem lại Tên Server của Publisher và tên CSDL trong chuỗi kết nối.\n" + e.Message);
                return 0;
            }
        }
        [System.ComponentModel.Browsable(false)]
        public int FirstDisplayedScrollingRowIndex { get; set; }
        private void frmNhanvien_Load(object sender, EventArgs e)
        {

            
            this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
            this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

            this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);

            this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
            this.datHangTableAdapter.Fill(this.dS.DatHang);

            this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
            this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);

           /* // TODO: This line of code loads data into the 'dS.CTPN' table. You can move, or remove it, as needed.
            this.cTPNTableAdapter.Fill(this.dS.CTPN);
            // TODO: This line of code loads data into the 'DS.Kho' table. You can move, or remove it, as needed.
            this.khoTableAdapter.Fill(this.dS.Kho);
            // TODO: This line of code loads data into the 'DS.ChiNhanh' table. You can move, or remove it, as needed.
            this.chiNhanhTableAdapter.Fill(this.dS.ChiNhanh);
            // TODO: This line of code loads data into the 'DS.CTDDH' table. You can move, or remove it, as needed.
            this.cTDDHTableAdapter.Fill(this.dS.CTDDH);*/
            macn = ((DataRowView)bdsNV[0])["MACN"].ToString();
            
            cmbChiNhanh.DataSource = Program.bds_dspm;
            cmbChiNhanh.DisplayMember = "TENCN";
            cmbChiNhanh.ValueMember = "TENSERVER"; 
            cmbChiNhanh.SelectedIndex = Program.mchiNhanh;
            if (Program.mGroup == "CONGTY") {
             
                cmbChiNhanh.Enabled = true;
               btnCCN.Enabled= btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled =btnHieuChinh.Enabled= btnCCN.Enabled = false;
            }
           
            else
            { 
                
              
                    cmbChiNhanh.Enabled = false;
                    btnThem.Enabled = btnXoa.Enabled = btnGhi.Enabled = btnPhucHoi.Enabled = btnHieuChinh.Enabled = btnTaiLai.Enabled = btnThoat.Enabled =btnCCN.Enabled= true;
                
            }


           



        }

        private void gcNV_Click(object sender, EventArgs e)
        {
            
        }

        private void nhanVienBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.bdsNV.EndEdit();
            this.tableAdapterManager.UpdateAll(this.dS);

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void gcNV_Click_1(object sender, EventArgs e)
        {
           
        }

        private void grTTNV_Paint(object sender, PaintEventArgs e)
        {

        }

        private void gcNV_Click_2(object sender, EventArgs e)
        {
            
        }
        private void frm_menu_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        private void dateTimeNV_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void barButtonItem8_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        

        private void grChiNhanh_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            grTTNV.Enabled = true;
            bdsNV.AddNew();
            
            txtMACN.Text = macn;
            DateNV.EditValue = "";
            btnThem.Enabled = btnXoa.Enabled =btnHieuChinh.Enabled= btnTaiLai.Enabled = btnThoat.Enabled =btnCCN.Enabled=false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcNV.Enabled = false; 
        }

        private void btnPhucHoi_ItemClick(object sender, ItemClickEventArgs e)
        {
            bdsNV.CancelEdit();
            if (btnThem.Enabled == false) bdsNV.Position = vitri;
            gcNV.Enabled = true;
            grTTNV.Enabled = false;
            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled =btnHieuChinh.Enabled= btnCCN.Enabled = true;
            btnGhi.Enabled = btnPhucHoi.Enabled = false;
           
        }

        private void btnHieuChinh_ItemClick(object sender, ItemClickEventArgs e)
        {
            vitri = bdsNV.Position;
            grTTNV.Enabled = true;
            btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = btnHieuChinh.Enabled = btnCCN.Enabled = false;
            btnGhi.Enabled = btnPhucHoi.Enabled = true;
            gcNV.Enabled = false;
        }

        private void btnTaiLai_ItemClick(object sender, ItemClickEventArgs e)
        {
            try
            {

                this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi Reload" + ex.Message, "", MessageBoxButtons.OK);
                return;
            }
        }

        private void btnGhi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (txtMANV.Text.Trim() == "")
            {
                MessageBox.Show("Mã nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtMANV.Focus();
                return;
            }
            if (txtHo.Text.Trim() == "")
            {
                MessageBox.Show("Họ nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtHo.Focus();
                return;
            }
            if (txtTen.Text.Trim() == "")
            {
                MessageBox.Show("Tên nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                txtTen.Focus();
                return;
            }
            
            if (DateNV.Text.Trim() == "")
            {
                MessageBox.Show("Ngày sinh nhân viên không được thiếu!", "", MessageBoxButtons.OK);
                DateNV.Focus();
                return;
            }
            if (float.Parse(SpinLuong.Text) < 4000000)
            {
                MessageBox.Show("Số lương nhân viên không hợp lệ!", "", MessageBoxButtons.OK);
                SpinLuong.Focus();
                return;
            }

            //Kiểm tra mã nv trên các phân mảnh
            if (ValidateChildren(ValidationConstraints.Enabled))
            {

                string manv = txtMANV.Text.Trim();
                // == Query tìm MANV ==
                Program.conn = new SqlConnection(Program.constr);
                Program.conn.Open();
                String query_MANV = "DECLARE	@return_value int " +
                               "EXEC @return_value = [dbo].[sp_TIM_MANV] " +
                               "@MANV " +
                               "SELECT 'Return Value' = @return_value";
                SqlCommand sqlCommand = new SqlCommand(query_MANV, Program.conn);
                sqlCommand.Parameters.AddWithValue("@MANV", manv);
                SqlDataReader dataReader = null;

                try
                {
                    dataReader = sqlCommand.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Thực thi database thất bại!\n" + ex.Message, "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                // Đọc và lấy result
                dataReader.Read();
                int result_value_MANV = int.Parse(dataReader.GetValue(0).ToString());
                dataReader.Close();

                int indexMaNV = bdsNV.Find("MANV", txtMANV.Text);

                int indexCurrent = bdsNV.Position;
                if (result_value_MANV == 1 && (indexMaNV != indexCurrent))
                {
                    MessageBox.Show("Mã nhân viên đã tồn tại!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    try
                    {
                        bdsNV.EndEdit();
                        bdsNV.ResetCurrentItem();
                        this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
                        this.nhanVienTableAdapter.Update(this.dS.NhanVien);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi ghi nhân viên\n" + ex.Message, "", MessageBoxButtons.OK);
                        return;
                    }
                    gcNV.Enabled = true;
                    btnThem.Enabled = btnXoa.Enabled = btnTaiLai.Enabled = btnThoat.Enabled = btnHieuChinh.Enabled = btnCCN.Enabled = true;
                    btnGhi.Enabled = btnPhucHoi.Enabled = false;
                    grTTNV.Enabled = false;
                }
            }
        }

        private void btnXoa_ItemClick(object sender, ItemClickEventArgs e)
        {
            Int32 maNV=0 ;
            if (trangThaiXoaCheckBox.Checked == true)
            {
                MessageBox.Show("Nhân viên đã bị xóa, đang ở chi nhánh khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (BDSDH.Count>0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập đơn đặt hàng ", "", MessageBoxButtons.OK);
                return;
            }
            if(BDSPN.Count>0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu nhập ", "", MessageBoxButtons.OK);
                return;
            }
            if (BDSPX.Count > 0)
            {
                MessageBox.Show("Không thể xóa nhân viên này vì đã lập phiếu xuất ", "", MessageBoxButtons.OK);
                return;
            }
             if (Program.maNV == int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString()))
            {
                MessageBox.Show("Không thể xóa Nhân viên đang đăng nhập !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            if (MessageBox.Show("Bạn có thực sự muốn xóa nhân viên này không?","Xác Nhận", MessageBoxButtons.OKCancel) == DialogResult.OK){
                try
                {
                    maNV = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                    bdsNV.RemoveCurrent();
                    this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
                    this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                    //xóa login nhân viên đó
                    Program.conn = new SqlConnection(Program.constr);
                    Program.conn.Open();
                    SqlCommand cmd = new SqlCommand("Xoa_Login", Program.conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@USRNAME", maNV));
                    SqlDataReader myReader = null;
                    try
                    {
                        myReader = cmd.ExecuteReader();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    this.nhanVienTableAdapter.Update(this.dS.NhanVien);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Lỗi xóa nhân viên.Bạn hãy xóa lại\n" + ex.Message, "", MessageBoxButtons.OK);
                    this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                    bdsNV.Position = bdsNV.Find("MANV", maNV);
                    return;
                }
            }
            if (bdsNV.Count == 0) btnXoa.Enabled = false;

        }

        private void cmbChiNhanh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChiNhanh.SelectedValue.ToString() == "System.Data.DataRowView") 
                return;
            Program.servername = cmbChiNhanh.SelectedValue.ToString();
            if(cmbChiNhanh.SelectedIndex !=Program.mchiNhanh)
            {
                Program.mlogin = Program.remotelogin;
                Program.password = Program.remotepassword;
            }
            else
            {
                Program.mlogin = Program.mloginDN;
                Program.password = Program.passwordDN;
            }
            if(Program.KetNoi()==0)
            {
                MessageBox.Show("Lỗi kết nối về chi nhánh mới", "", MessageBoxButtons.OK);

            }
            else
            {
                this.nhanVienTableAdapter.Connection.ConnectionString = Program.constr;
                this.nhanVienTableAdapter.Fill(this.dS.NhanVien);

                this.phieuXuatTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuXuatTableAdapter.Fill(this.dS.PhieuXuat);

                this.datHangTableAdapter.Connection.ConnectionString = Program.constr;
                this.datHangTableAdapter.Fill(this.dS.DatHang);

                this.phieuNhapTableAdapter.Connection.ConnectionString = Program.constr;
                this.phieuNhapTableAdapter.Fill(this.dS.PhieuNhap);
                if (bdsNV.Count > 0)
                {
                    macn = ((DataRowView)bdsNV[0])["MACN"].ToString();

                }
                else
                    return;
            }
        }

        private void bdsNV_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnThoat_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
            
        }
        private Form CheckExists(Type ftype)
        {
            foreach (Form f in this.MdiChildren)
                if (f.GetType() == ftype)
                    return f;
            return null;
        }

        private void btnCCN_ItemClick(object sender, ItemClickEventArgs e)

        {

            
            int manvnow = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
            if (trangThaiXoaCheckBox.Checked == true)
            {
               
                MessageBox.Show("Nhân viên đã bị xóa hoặc đang ở chi nhánh khác", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else if (Program.maNV == manvnow)
            {
                MessageBox.Show("Không thể chuyển Nhân viên đang đăng nhập !", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            else if(trangThaiXoaCheckBox.Checked == false)
            {
                Form form = this.CheckExists(typeof(SubForm.FormCCN));
                if (form != null) form.Activate();
                else
                {
                    SubForm.FormCCN f = new SubForm.FormCCN();
                    Program.frmChinh.Enabled = false;
                    f.ShowDialog();
                    if (Program.eventClick == 1)
                    {


                        Int32 maNV = 0;
                        maNV = int.Parse(((DataRowView)bdsNV[bdsNV.Position])["MANV"].ToString());
                        Program.conn = new SqlConnection(Program.constr);
                        Program.conn.Open();
                        SqlCommand cmd = new SqlCommand("SP_CCN", Program.conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@MANV", maNV));
                        SqlDataReader myReader = null;

                        try
                        {
                            vitri = bdsNV.Position;
                            myReader = cmd.ExecuteReader();
                            this.nhanVienTableAdapter.Update(this.dS.NhanVien);

                            




                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            return;
                        }
                        this.nhanVienTableAdapter.Fill(this.dS.NhanVien);
                        bdsNV.Position = vitri;
                        Program.eventClick = 0;
                        f.Close();
                        if ((MessageBox.Show("Chuyển chi nhánh thành công ! ", "", MessageBoxButtons.OK) == DialogResult.OK))
                        {
                            Program.frmChinh.Enabled = true;
                        }

                    }

                }

                
            }    
        }
    }
    }
