using QuanLyNhaHang.DAO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhaHang
{
    public partial class fMana : Form
    {

        DataProvider provider = new DataProvider(); 
        public fMana()
        {
            InitializeComponent();
            //loadMonAn();
        }

        private void fMana_Load(object sender, EventArgs e)
        {
            btn_ban1_Click(sender, e);
            btn_ban10_Click(sender, e);
            btn_ban11_Click(sender, e);
            btn_ban12_Click(sender, e);
            btn_ban2_Click(sender, e);
            btn_ban3_Click(sender, e);
            btn_ban4_Click(sender, e);
            btn_ban5_Click(sender, e);
            btn_ban6_Click(sender, e);
            btn_ban7_Click(sender, e);
            btn_ban8_Click(sender, e);
            btn_ban9_Click(sender, e);
        }
        public void loadMonAn()
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[MonAn]";
            dgv_monAn.DataSource = provider.ExecuteQuery(query);
            dgv_monAn.Columns[0].HeaderText = "Mã món ăn";
            dgv_monAn.Columns[1].HeaderText = "Tên món ăn";
            dgv_monAn.Columns[2].HeaderText = "Giá";
            dgv_monAn.Columns[3].HeaderText = "Mô tả";
            dgv_monAn.Columns[1].Width = 100;
            dgv_monAn.Columns[3].Width = 300;
        }
        

        private void btn_hienThi_Click(object sender, EventArgs e)
        {
           loadMonAn();
        }

        

        private void dgv_monAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maMonAn.Text = dgv_monAn[0, e.RowIndex].Value.ToString();
            txb_tenMonAn.Text = dgv_monAn[1, e.RowIndex].Value.ToString();
            txb_gia.Text = dgv_monAn[2, e.RowIndex].Value.ToString();
            txb_moTa.Text = dgv_monAn[3, e.RowIndex].Value.ToString();
        }

        private void btn_them_Click(object sender, EventArgs e)
        {
            string mma = txb_maMonAn.Text;
            string tma = txb_tenMonAn.Text;
            decimal gia = decimal.Parse(txb_gia.Text);
            string mota = txb_moTa.Text;

            string query = "insert into MonAn(MonAnID,TenMonAn,Gia,MoTa)" +
                            "values ('" + mma+"',N'"+ tma+"','" +gia+"',N'"+mota+"' )";
            dgv_monAn.DataSource = provider.ExecuteNonQuery(query);
            loadMonAn();

        }

        private void btn_sua_Click(object sender, EventArgs e)
        {
            string mma = txb_maMonAn.Text;
            string tma = txb_tenMonAn.Text;
            decimal gia = decimal.Parse(txb_gia.Text);
            string mota = txb_moTa.Text;

            string query = "update MonAn set ";
            query += "TenMonAn = N'" + tma + "',";
            query += "Gia = '" + gia + "',";
            query += "MoTa = N'" + mota+ "'";
            query += "Where MonAnID = '" + mma + "'";
            dgv_monAn.DataSource = provider.ExecuteNonQuery(query);
            loadMonAn();
        }

        private void btn_timKiem_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[MonAn] where TenMonAn like N'%" + txb_timKiem.Text+ "%'";
            dgv_monAn.DataSource = provider.ExecuteQuery(query);
            dgv_monAn.Columns[0].HeaderText = "Mã món ăn";
            dgv_monAn.Columns[1].HeaderText = "Tên món ăn";
            dgv_monAn.Columns[2].HeaderText = "Giá";
            dgv_monAn.Columns[3].HeaderText = "Mô tả";
            dgv_monAn.Columns[1].Width = 100;
            dgv_monAn.Columns[3].Width = 300;
        }

        private void btn_xoa_Click(object sender, EventArgs e)
        {
            string mma = txb_maMonAn.Text;
            string query_CTHD = $"DELETE FROM ChiTietHoaDon WHERE MonAnID = '{mma}'";
            dgv_monAn.DataSource = provider.ExecuteNonQuery(query_CTHD);
           
            string query = $"DELETE MonAn WHERE MonAnID = '{mma}'";
            dgv_monAn.DataSource = provider.ExecuteNonQuery(query);
            loadMonAn();

            txb_maMonAn.Text = "";
            txb_tenMonAn.Text = "";
            txb_gia.Text = "";
            txb_moTa.Text = "";
        }

        private void ms_logout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn đăng xuất không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        //-------------------------------------------------Nhan VIennnn------------------------------------------------------------------
        public void loadNhanVien()
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[NhanVien]";
            dgvNhanVien.DataSource = provider.ExecuteQuery(query);
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Email";
            dgvNhanVien.Columns[6].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[7].HeaderText = "Lương";

        }
        private void btn_themNv_Click(object sender, EventArgs e)
        {
            string query = "insert into NhanVien(NhanVienID,HoTen,GioiTinh,NgaySinh,SoDienThoai,Email,ChucVu,Luong)"
                            + "values ('" + txb_maNv.Text + "',N'" + txb_tenNv.Text + "',N'" + cb_gioiTinh.Text + "',N'" + txb_ngaySinh.Text + "',N'" + txb_sdt.Text + "',N'" + txb_email.Text + "',N'" + txb_chucVu.Text + "',N'" + txb_Luong.Text + "' )";
            dgvNhanVien.DataSource = provider.ExecuteNonQuery(query);
            loadNhanVien();
            txb_maNv.Clear();
            txb_tenNv.Clear();
            cb_gioiTinh.Items.Clear();
            txb_ngaySinh.Clear();
            txb_sdt.Clear();
            txb_email.Clear();
            txb_chucVu.Clear();
            txb_Luong.Clear();
        }

        private void btn_hienNv_Click(object sender, EventArgs e)
        {
            loadNhanVien();
        }

        private void dgvNhanVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maNv.Text = dgvNhanVien[0, e.RowIndex].Value.ToString();
            txb_tenNv.Text = dgvNhanVien[1, e.RowIndex].Value.ToString();
            cb_gioiTinh.Text = dgvNhanVien[2, e.RowIndex].Value.ToString();
            txb_ngaySinh.Text = dgvNhanVien[3, e.RowIndex].Value.ToString();
            txb_sdt.Text = dgvNhanVien[4, e.RowIndex].Value.ToString();
            txb_email.Text = dgvNhanVien[5, e.RowIndex].Value.ToString();
            txb_chucVu.Text = dgvNhanVien[6, e.RowIndex].Value.ToString();
            txb_Luong.Text = dgvNhanVien[7, e.RowIndex].Value.ToString();
        }

        private void btn_suaNv_Click(object sender, EventArgs e)
        {
            string query = "update NhanVien set ";    
            query += "HoTen = N'" + txb_tenNv.Text + "',";
            query += "GioiTinh = N'" + cb_gioiTinh.Text + "',";
            query += "NgaySinh = '" + txb_ngaySinh.Text + "',";
            query += "SoDienThoai = N'" + txb_sdt.Text + "',";
            query += "Email = N'" + txb_email.Text + "',";
            query += "ChucVu = N'" + txb_chucVu.Text + "',";
            query += "Luong = N'" + decimal.Parse(txb_Luong.Text) + "'";
            query += "Where NhanVienID = '" + txb_maNv.Text + "'";
            dgvNhanVien.DataSource = provider.ExecuteNonQuery(query);
            loadNhanVien();
        }

        private void btn_xoaNV_Click(object sender, EventArgs e)
        {
            string manv = txb_maNv.Text;
            string updateHoaDonQuery = $"UPDATE HoaDon SET NhanVienID = NULL WHERE NhanVienID = '{manv}'";
            string deleteLichLamViecQuery = $"DELETE FROM LichLamViec WHERE NhanVienID = '{manv}'";
            string deleteDatBanQuery = $"DELETE FROM DatBan WHERE NhanVienID = '{manv}'";
            string query = $"DELETE FROM NhanVien WHERE NhanVienID = '{manv}'";

            dgvNhanVien.DataSource = provider.ExecuteNonQuery(deleteLichLamViecQuery);
            dgv_HoaDon.DataSource = provider.ExecuteNonQuery(updateHoaDonQuery);
            //dgv_DatBan.DataSource = provider.ExecuteNonQuerydeleteDatBanQuery);
            dgvNhanVien.DataSource = provider.ExecuteNonQuery(query);

            loadNhanVien();
            txb_maNv.Clear();
            txb_tenNv.Clear();
            cb_gioiTinh.Items.Clear();
            txb_ngaySinh.Clear();
            txb_sdt.Clear();
            txb_email.Clear();
            txb_chucVu.Clear();
            txb_Luong.Clear();
        }

        public void loadNguyenLieu()
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[NguyenLieu]";
            dgv_nguyenLieu.DataSource = provider.ExecuteQuery(query);
            dgv_nguyenLieu.Columns[0].HeaderText = "Mã nguyên liệu";
            dgv_nguyenLieu.Columns[1].HeaderText = "Tên nguyên liệu";
            dgv_nguyenLieu.Columns[2].HeaderText = "Số lượng";
            dgv_nguyenLieu.Columns[3].HeaderText = "Hạn sử dụng";
           
        }

        private void btn_themNl_Click(object sender, EventArgs e)
        {
            string mnl = txb_maNl.Text;
            string tnl = txb_tenNl.Text;
            int soLuong = int.Parse(txb_soluong.Text);
            string hsd = txb_hsd.Text;

            string query = "insert into NguyenLieu(NguyenLieuID,TenNguyenLieu,SoLuong,HanSuDung)" +
                            "values ('" + mnl + "',N'" + tnl + "','" + soLuong + "',N'" + hsd + "' )";
            dgv_nguyenLieu.DataSource = provider.ExecuteNonQuery(query);
            loadNguyenLieu();
        }

        private void btn_hienThiNl_Click(object sender, EventArgs e)
        {
            loadNguyenLieu();
        }

        private void btn_suaNl_Click(object sender, EventArgs e)
        {
            string mnl = txb_maMonAn.Text;
            string tnl = txb_tenMonAn.Text;
            int soluong = int.Parse(txb_soluong.Text);
            string hsd = txb_hsd.Text;

            string query = "update NguyenLieu set ";
            query += "TenNguyenLieu = N'" + tnl + "',";
            query += "SoLuong = '" + soluong + "',";
            query += "HanSuDung = N'" + hsd + "'";
            query += "Where NguyenLieuID = '" + mnl + "'";
            dgv_nguyenLieu.DataSource = provider.ExecuteNonQuery(query);
            loadNguyenLieu() ;
        }

        private void btn_xoaNl_Click(object sender, EventArgs e)
        {
            string mnl = txb_maNl.Text;
            string query = $"DELETE NguyenLieu WHERE NguyenLieuID = N'{mnl}'";
            dgv_nguyenLieu.DataSource = provider.ExecuteNonQuery(query);
            loadNguyenLieu();

            txb_maNl.Text = "";
            txb_tenNl.Text = "";
            txb_soluong.Text = "";
            txb_hsd.Text = "";
        }

        private void btn_timKiemNl_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[NguyenLieu] where TenNguyenLieu like N'%" + txb_timkiemNl.Text + "%'";
            dgv_nguyenLieu.DataSource = provider.ExecuteQuery(query);
            dgv_nguyenLieu.Columns[0].HeaderText = "Mã nguyên liệu";
            dgv_nguyenLieu.Columns[1].HeaderText = "Tên nguyên liệu";
            dgv_nguyenLieu.Columns[2].HeaderText = "Số lượng";
            dgv_nguyenLieu.Columns[3].HeaderText = "Hạn sử dụng";
        }

        private void dgv_nguyenLieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maNl.Text = dgv_nguyenLieu[0, e.RowIndex].Value.ToString();
            txb_tenNl.Text = dgv_nguyenLieu[1, e.RowIndex].Value.ToString();
            txb_soluong.Text = dgv_nguyenLieu[2, e.RowIndex].Value.ToString();
            txb_hsd.Text = dgv_nguyenLieu[3, e.RowIndex].Value.ToString();
        }

        //-----------------------------------------------Hóa đơn------------------------------------------------------------------

        public void loadHoaDon()
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[HoaDon]";
            dgv_HoaDon.DataSource = provider.ExecuteQuery(query);
            dgv_HoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dgv_HoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgv_HoaDon.Columns[2].HeaderText = "Ngày lập";
            dgv_HoaDon.Columns[3].HeaderText = "Mã Khách Hàng";
            dgv_HoaDon.Columns[4].HeaderText = "Tổng tiền"; 
        }
        private void btn_hienThiHD_Click(object sender, EventArgs e)
        {
            loadHoaDon();
        }

        private void dgv_HoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maHD.Text = dgv_HoaDon[0, e.RowIndex].Value.ToString();
            txb_maNV_HD.Text = dgv_HoaDon[1, e.RowIndex].Value.ToString();
            txb_ngayLap.Text = dgv_HoaDon[2, e.RowIndex].Value.ToString();
            txb_maKH_HD.Text = dgv_HoaDon[3, e.RowIndex].Value.ToString();
            txb_tongTienHD.Text = dgv_HoaDon[4, e.RowIndex].Value.ToString();
            // in ra thông tin chi tiết hóa đơn tương ứng với mã của dòng được click nè
            string query = "SELECT * FROM ChiTietHoaDon WHERE HoaDonID = '"+ dgv_HoaDon.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
            dgv_ChiTietHD.DataSource = provider.ExecuteQuery(query);
        }

        private void btn_themHD_Click(object sender, EventArgs e)
        {
            string maHD = txb_maHD.Text;
            string maNV = txb_maNV_HD.Text;
            string ngayLap = txb_ngayLap.Text;
            string maKH = txb_maKH_HD.Text;
            decimal tongTien = decimal.Parse(txb_tongTienHD.Text);
          
            string query = "insert into HoaDon (HoaDonID, NhanVienID, NgayLap, KhachHangID, TongTien)" +
                            " values ('" + maHD + "',N'" + maNV + "','" + ngayLap + "','" + maKH + "','"+ tongTien +"' )";
            string query1 = "insert into KhachHang(KhachHangID,HoTen,GioiTinh,NgaySinh,SoDienThoai,Email,DiaChi)"
                            + " values ('" + maKH + "',NULL,NULL,NULL,NULL,NULL,NULL)";
            dtg_danhsach.DataSource = provider.ExecuteNonQuery(query1);
            dgv_HoaDon.DataSource = provider.ExecuteNonQuery(query);
            loadHoaDon();
        }

        private void btn_suaHD_Click(object sender, EventArgs e)
        {
            string maHD = txb_maHD.Text;
            string maNV = txb_maNV_HD.Text;
            string ngayLap = txb_ngayLap.Text;
            string maKH = txb_maKH_HD.Text;
            decimal tongTien = decimal.Parse(txb_tongTienHD.Text);

            string query = "update HoaDon set ";
            query += "NhanVienID = '" + maNV + "',";
            query += "NgayLap = '" + ngayLap + "',";
            query += "KhachHangID = '" + maKH + "',";
            query += "TongTien = '" + tongTien + "'";
            query += "Where HoaDonID = '" + maHD + "'";
            dgv_HoaDon.DataSource = provider.ExecuteNonQuery(query);
            loadHoaDon();
        }

        private void btn_xoaHD_Click(object sender, EventArgs e)
        {
            string maHD = txb_maHD.Text;
            string query = $"DELETE HoaDon WHERE HoaDonID = '{maHD}'";
            dgv_HoaDon.DataSource = provider.ExecuteNonQuery(query);
            loadHoaDon() ;

            txb_maHD.Clear();
            txb_maNV_HD.Clear();
            txb_ngayLap.Clear();
            txb_maKH_HD.Clear();
            txb_tongTienHD.Clear();
        }












        //-----------------------------------------------feedback---------------------------------------
        public void loadfb()
        {

            string query = "SELECT * FROM [QL_NhaHang].[dbo].[Feedback]";
            dtg_fb.DataSource = provider.ExecuteQuery(query);
            dtg_fb.Columns[0].HeaderText = "Mã Feedback";
            dtg_fb.Columns[1].HeaderText = "Mã Khách hàng gửi";
            dtg_fb.Columns[2].HeaderText = "Nội dung";
            dtg_fb.Columns[3].HeaderText = "Ngày gửi";
            dtg_fb.Columns[4].HeaderText = "Đánh Giá";

        }
        private void btn_hienthifb_Click(object sender, EventArgs e)
        {
            loadfb();
        }

        private void btn_xoafb_Click(object sender, EventArgs e)
        {
            string mafb = txt_mafb.Text;
            string query = $"DELETE FROM Feedback WHERE FeedbackID = N'{mafb}'";
            dtg_fb.DataSource = provider.ExecuteNonQuery(query);

            loadfb();
            txt_mafb.Clear();
            txt_tenkhfb.Clear();
            txt_nd.Clear();
            txt_ngaygui.Clear();
            cb_rate.Items.Clear();

            string makh = txt_tenkhfb.Text;
            string query1 = $"SELECT * FROM [QL_NhaHang].[dbo].[KhachHang] WHERE KhachHangID = N'{makh}'";
            dtg_cuthe.DataSource = provider.ExecuteQuery(query1);
        }

        private void btn_suafb_Click(object sender, EventArgs e)
        {
            string query = "update Feedback set ";
            query += "NoiDung = N'" + txt_nd.Text + "',";
            query += "NgayGui = N'" + txt_ngaygui.Text + "',";
            query += "DanhGia = N'" + cb_rate.Text + "'";
            query += "Where FeedbackID = '" + txt_mafb.Text + "' AND KhachHangID = '" + txt_tenkhfb.Text + "'";
            dtg_fb.DataSource = provider.ExecuteNonQuery(query);
            loadfb();
        }

        private void btn_themfb_Click(object sender, EventArgs e)
        {
            string query = "insert into Feedback(FeedbackID,KhachHangID,NoiDung,NgayGui,DanhGia)"
                    + "values ('" + txt_mafb.Text + "',N'" + txt_tenkhfb.Text + "',N'" + txt_nd.Text + "','" + txt_ngaygui.Text + "',N'" + cb_rate.Text + "')";
            dtg_fb.DataSource = provider.ExecuteNonQuery(query);
            loadfb();
            txt_mafb.Clear();
            txt_tenkhfb.Clear();
            txt_nd.Clear();
            txt_ngaygui.Clear();
        }

        private void dtg_fb_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_mafb.Text = dtg_fb[0, e.RowIndex].Value.ToString();
            txt_tenkhfb.Text = dtg_fb[1, e.RowIndex].Value.ToString();
            txt_nd.Text = dtg_fb[2, e.RowIndex].Value.ToString();
            txt_ngaygui.Text = dtg_fb[3, e.RowIndex].Value.ToString();
            cb_rate.Text = dtg_fb[4, e.RowIndex].Value.ToString();

            string makh = txt_tenkhfb.Text;
            string query = $"SELECT * FROM [QL_NhaHang].[dbo].[KhachHang] WHERE KhachHangID = N'{makh}'";
            dtg_cuthe.DataSource = provider.ExecuteQuery(query);
            dtg_cuthe.Columns[0].HeaderText = "Mã Khách hàng";
            dtg_cuthe.Columns[1].HeaderText = "Tên Khách hàng";
            dtg_cuthe.Columns[2].HeaderText = "Giới tính";
            dtg_cuthe.Columns[3].HeaderText = "Ngày sinh";
            dtg_cuthe.Columns[4].HeaderText = "Số điện thoại";
            dtg_cuthe.Columns[5].HeaderText = "Email";
            dtg_cuthe.Columns[6].HeaderText = "Địa chỉ";
            dtg_cuthe.AllowUserToAddRows = false;
        }

        private void btn_tkfb_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[Feedback] where FeedbackID like N'%" + txt_tkfb.Text + "%'";
            dtg_fb.DataSource = provider.ExecuteQuery(query);
            dtg_fb.Columns[0].HeaderText = "Mã Feedback";
            dtg_fb.Columns[1].HeaderText = "Mã Khách hàng gửi";
            dtg_fb.Columns[2].HeaderText = "Nội dung";
            dtg_fb.Columns[3].HeaderText = "Ngày gửi";
            dtg_fb.Columns[4].HeaderText = "Đánh Giá";
        }
        //-------------------------------------------Khach Hang------------------------------------------------------
        public void loadKH()
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[KhachHang]";
            dtg_danhsach.DataSource = provider.ExecuteQuery(query);
            dtg_danhsach.Columns[0].HeaderText = "Mã Khách hàng";
            dtg_danhsach.Columns[1].HeaderText = "Tên Khách hàng";
            dtg_danhsach.Columns[2].HeaderText = "Giới tính";
            dtg_danhsach.Columns[3].HeaderText = "Ngày sinh";
            dtg_danhsach.Columns[4].HeaderText = "Số điện thoại";
            dtg_danhsach.Columns[5].HeaderText = "Email";
            dtg_danhsach.Columns[6].HeaderText = "Địa chỉ";

        }
        private void btn_hienthikh_Click(object sender, EventArgs e)
        {
            loadKH();
        }

        private void btn_xoakh_Click(object sender, EventArgs e)
        {
            string makh = txt_makh.Text;
            string query1 = $"DELETE FROM Feedback WHERE KhachHangID = N'{makh}'";
            dtg_fb.DataSource = provider.ExecuteNonQuery(query1);
            string query = $"DELETE FROM KhachHang WHERE KhachHangID = '{makh}'";
            dtg_danhsach.DataSource = provider.ExecuteNonQuery(query);

            loadKH();
            txt_makh.Clear();
            txt_tenkh.Clear();
            combo_gt.Items.Clear();
            txt_date.Clear();
            txt_sdt.Clear();
            txt_mail.Clear();
            txt_dc.Clear();
        }

        private void btn_suakh_Click(object sender, EventArgs e)
        {
            string query = "update KhachHang set ";
            query += "HoTen = N'" + txt_tenkh.Text + "',";
            query += "GioiTinh = N'" + combo_gt.Text + "',";
            query += "NgaySinh = N'" + txt_date.Text + "',";
            query += "SoDienThoai = N'" + txt_sdt.Text + "',";
            query += "Email = N'" + txt_mail.Text + "',";
            query += "DiaChi = N'" + txt_dc.Text + "'";
            query += "Where KhachHangID = '" + txt_makh.Text + "'";
            dtg_danhsach.DataSource = provider.ExecuteNonQuery(query);
            loadKH();
        }

        private void btn_themkh_Click(object sender, EventArgs e)
        {
            string query = "insert into KhachHang(KhachHangID,HoTen,GioiTinh,NgaySinh,SoDienThoai,Email,DiaChi)"
                            + "values ('" + txt_makh.Text + "',N'" + txt_tenkh.Text + "',N'" + combo_gt.Text + "',N'" + txt_date.Text + "',N'" + txt_sdt.Text + "',N'" + txt_mail.Text + "',N'" + txt_dc.Text + "')";
            dtg_danhsach.DataSource = provider.ExecuteNonQuery(query);
            loadKH();
            txt_makh.Clear();
            txt_tenkh.Clear();
            txt_date.Clear();
            txt_sdt.Clear();
            txt_mail.Clear();
            txt_dc.Clear();
        }

        private void dtg_danhsach_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_makh.Text = dtg_danhsach[0, e.RowIndex].Value.ToString();
            txt_tenkh.Text = dtg_danhsach[1, e.RowIndex].Value.ToString();
            combo_gt.Text = dtg_danhsach[2, e.RowIndex].Value.ToString();
            txt_date.Text = dtg_danhsach[3, e.RowIndex].Value.ToString();
            txt_sdt.Text = dtg_danhsach[4, e.RowIndex].Value.ToString();
            txt_mail.Text = dtg_danhsach[5, e.RowIndex].Value.ToString();
            txt_dc.Text = dtg_danhsach[6, e.RowIndex].Value.ToString();
        }

        private void btn_themCTHD_Click(object sender, EventArgs e)
        {
            string query = "insert into ChiTietHoaDon(ChiTietHoaDonID,HoaDonID,MonAnID,SoLuong,DonGia,TenMonAn,GiamGia,ThanhTien)"
                            + "values ('" + txb_maCTHD.Text + "','" + txb_maHD_CTHD.Text + "','" + txb_maMA_CTHD.Text + "','" + txb_sl_CTHD.Text + "','" + txb_donGia_CTHD.Text + "',N'" + txb_tenMA_CTHD.Text + "','" + txb_giamGia.Text + "','" + txb_thanhTien_CTHD.Text + "' )";
            dgv_ChiTietHD.DataSource = provider.ExecuteNonQuery(query);

            txb_maCTHD.Clear();
            txb_maHD_CTHD.Clear();
            txb_maMA_CTHD.Clear();
            txb_sl_CTHD.Clear();
            txb_donGia_CTHD.Clear();
            txb_tenMA_CTHD.Clear();
            txb_giamGia.Clear();
            txb_thanhTien_CTHD.Clear();
        }

        private void btn_suaCTHD_Click(object sender, EventArgs e)
        {
            string query = "update ChiTietHoaDon set ";
            query += "HoaDonID = '" + txb_maHD_CTHD.Text + "',";
            query += "MonAnID = '" + txb_maMA_CTHD.Text + "',";
            query += "SoLuong = '" + txb_sl_CTHD.Text + "',";
            query += "DonGia = '" + txb_donGia_CTHD.Text + "',";
            query += "TenMonAn = N'" + txb_tenMA_CTHD.Text + "',";
            query += "GiamGia = '" + txb_giamGia.Text + "',";
            query += "ThanhTien = '" + txb_thanhTien_CTHD.Text + "'";
            query += "Where ChiTietHoaDonID = '" + txb_maCTHD.Text + "'";
            dgv_ChiTietHD.DataSource = provider.ExecuteNonQuery(query);

        }

        private void dgv_ChiTietHD_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maCTHD.Text = dgv_ChiTietHD[0, e.RowIndex].Value.ToString();
            txb_maHD_CTHD.Text = dgv_ChiTietHD[1, e.RowIndex].Value.ToString();
            txb_maMA_CTHD.Text = dgv_ChiTietHD[2, e.RowIndex].Value.ToString();
            txb_sl_CTHD.Text = dgv_ChiTietHD[3, e.RowIndex].Value.ToString();
            txb_donGia_CTHD.Text = dgv_ChiTietHD[4, e.RowIndex].Value.ToString();
            txb_tenMA_CTHD.Text = dgv_ChiTietHD[5, e.RowIndex].Value.ToString();
            txb_giamGia.Text = dgv_ChiTietHD[6, e.RowIndex].Value.ToString();
            txb_thanhTien_CTHD.Text = dgv_ChiTietHD[7, e.RowIndex].Value.ToString();
        }

        private void btn_xoaCTHD_Click(object sender, EventArgs e)
        {

            string maHD = txb_maCTHD.Text;
            string query = $"DELETE ChiTietHoaDon WHERE ChiTietHoaDonID = '{maHD}'";
            dgv_ChiTietHD.DataSource = provider.ExecuteNonQuery(query);
            txb_maCTHD.Clear();
            txb_maHD_CTHD.Clear();
            txb_maMA_CTHD.Clear();
            txb_sl_CTHD.Clear();
            txb_donGia_CTHD.Clear();
            txb_tenMA_CTHD.Clear();
            txb_giamGia.Clear();
            txb_thanhTien_CTHD.Clear();
        }

        private void btn_timKiemHD_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM HoaDon where HoaDonID like N'%" + txb_timKiemHD.Text + "%'";
            dgv_HoaDon.DataSource = provider.ExecuteQuery(query);
            dgv_HoaDon.Columns[0].HeaderText = "Mã hóa đơn";
            dgv_HoaDon.Columns[1].HeaderText = "Mã nhân viên";
            dgv_HoaDon.Columns[2].HeaderText = "Ngày lập";
            dgv_HoaDon.Columns[3].HeaderText = "Mã Khách Hàng";
            dgv_HoaDon.Columns[4].HeaderText = "Tổng tiền";
        }

        private void btn_timNv_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM NhanVien where HoTen like N'%" + txb_timNv.Text + "%'";
            dgvNhanVien.DataSource = provider.ExecuteQuery(query);
            dgvNhanVien.Columns[0].HeaderText = "Mã nhân viên";
            dgvNhanVien.Columns[1].HeaderText = "Tên nhân viên";
            dgvNhanVien.Columns[2].HeaderText = "Giới tính";
            dgvNhanVien.Columns[3].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns[4].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns[5].HeaderText = "Email";
            dgvNhanVien.Columns[6].HeaderText = "Chức vụ";
            dgvNhanVien.Columns[7].HeaderText = "Lương";
        }

        private void btn_timKiemCTHD_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM ChiTietHoaDon where ChiTietHoaDonID like N'%" + txb_timKiemCTHD.Text + "%'";
            dgv_ChiTietHD.DataSource = provider.ExecuteQuery(query);
        }
        public void loadPhieuNhap()
        {
            string query = "SELECT * FROM PhieuNhap";
            dgv_PhieuNhap.DataSource = provider.ExecuteQuery(query);
            dgv_PhieuNhap.Columns[0].HeaderText = "Mã phiếu nhập";
            dgv_PhieuNhap.Columns[1].HeaderText = "Mã nhà cung cấp";
            dgv_PhieuNhap.Columns[2].HeaderText = "Mã nhân viên";
            dgv_PhieuNhap.Columns[3].HeaderText = "Mã ngày nhập";
            dgv_PhieuNhap.Columns[4].HeaderText = "Tổng tiền";
        }
        private void btn_themPN_Click(object sender, EventArgs e)
        {
            string maPN = txb_maPN.Text;
            string maNCC = txb_maNCC_PN.Text;
            string maNV = txb_maNV_PN.Text;        
            string ngayNhap = txb_ngayNhap.Text;
            decimal tongTien = decimal.Parse(txb_tongTien_PN.Text);

            string query = "insert into PhieuNhap(PhieuNhapID,NhaCungCapID,NhanVienID,NgayNhap,TongTien)" +
                            "values ('"+ maPN +"','"+ maNCC +"','"+ maNV +"','"+ ngayNhap +"','"+ tongTien +"')";
            dgv_PhieuNhap.DataSource = provider.ExecuteNonQuery(query);
            loadPhieuNhap();
        }

        private void btn_hienThiPN_Click(object sender, EventArgs e)
        {
            loadPhieuNhap();
        }

        public void loadncc()
        {
            string query = "SELECT * FROM NhaCungCap";
            dgv_NCC.DataSource = provider.ExecuteQuery(query);
            dgv_NCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgv_NCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            dgv_NCC.Columns[2].HeaderText = "Địa chỉ";
            dgv_NCC.Columns[3].HeaderText = "Số điện thoại";
            dgv_NCC.Columns[4].HeaderText = "Email";
        }
        private void btn_themNCC_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO NhaCungCap (NhaCungCapID, TenNhaCungCap, DiaChi, SoDienThoai, Email) " +
            "VALUES ('" + txb_maNCC.Text + "', N'" + txb_tenNCC.Text + "', N'" + txb_diaChi.Text + "', N'" + txb_sdtNCC.Text + "', N'" + txb_emailNCC.Text + "')";

            provider.ExecuteNonQuery(query);
            dgv_NCC.DataSource = provider.ExecuteQuery("SELECT * FROM NhaCungCap");
            loadncc();
        }

        private void btn_hienThiNCC_Click(object sender, EventArgs e)
        {
            loadncc();
        }

        private void btn_themCTPN_Click(object sender, EventArgs e)
        {
            string query = "insert into ChiTietPhieuNhap(ChiTietPhieuNhapID,PhieuNhapID,NguyenLieuID,SoLuong,DonGia,ThanhTien)"
                            + "values ('" + txb_maCTPN.Text + "','" + txb_maPN_CTPN.Text + "','" + txb_maNL_CTPN.Text + "','" + txb_soLuong_CTPN.Text + "','" + txb_donGia_CTPN.Text + "','" + txb_thanhTien_CTHD.Text + "' )";
            dgv_ChiTietPN.DataSource = provider.ExecuteNonQuery(query);

            txb_maCTPN.Clear();
            txb_maPN_CTPN.Clear();
            txb_maNL_CTPN.Clear();
            txb_soLuong_CTPN.Clear();
            txb_donGia_CTPN.Clear();
            txb_thanhTien_CTPN.Clear();
        }

        private void btn_suaPN_Click(object sender, EventArgs e)
        {
            string maPN = txb_maPN.Text;
            string maNCC = txb_maNCC_PN.Text;
            string maNV = txb_maNV_PN.Text;
            string ngayNhap = txb_ngayNhap.Text;
            
            decimal tongTien = decimal.Parse(txb_tongTien.Text);

            string query = "UPDATE PhieuNhap SET ";
            query += "NhanVienID = '" + maNV + "',";
            query += "NgayNhap = '" + ngayNhap + "',";
            query += "NhaCungCapID = '" + maNCC + "',";
            query += "TongTien = '" + tongTien + "'";
            query += "WHERE PhieuNhapID = '" + maPN + "'";

            dgv_PhieuNhap.DataSource = provider.ExecuteNonQuery(query);
            loadPhieuNhap();
        }

        private void btn_xoaPN_Click(object sender, EventArgs e)
        {
              
        }
        string idBA;

        public void loadBA(string maBanAn)
        {
            string query = "SELECT BanAn.BanAnID, BanAn.TenBan, BanAn.SoCho, BanAn.TrangThai," + 
                           " DatBan.KhachHangID, DatBan.DatBanID, DatBan.NgayDat, DatBan.GioBatDau, DatBan.GioKetThuc, DatBan.NhanVienID"+
                           " FROM BanAn LEFT JOIN DatBan ON BanAn.BanAnID = DatBan.BanAnID"+
                           " WHERE BanAn.BanAnID = '"+ maBanAn +"'" ;
            dtg_banAn.DataSource = provider.ExecuteQuery(query);
            dtg_banAn.Columns[0].HeaderText = "Mã bàn ăn";
            dtg_banAn.Columns[1].HeaderText = "Tên bàn";
            dtg_banAn.Columns[2].HeaderText = "Số chỗ";
            dtg_banAn.Columns[3].HeaderText = "Trạng thái";
            dtg_banAn.Columns[4].HeaderText = "Khách hàng";
            dtg_banAn.Columns[5].HeaderText = "Mã đặt bàn";
            dtg_banAn.Columns[6].HeaderText = "Ngày đặt";
            dtg_banAn.Columns[7].HeaderText = "Giờ bắt đầu";
            dtg_banAn.Columns[8].HeaderText = "Giờ kết thúc";
            

        }
        public void loadMau(string maBanAn, Button btn)
        {


            string connectionString = "Data Source=DESKTOP-JPN0TR7;Initial Catalog=QL_NhaHang;Integrated Security=True";

            string query = "SELECT TrangThai FROM BanAn WHERE BanAnID = '" + maBanAn + "'";
            string trangThai = "";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        trangThai = reader["TrangThai"].ToString();
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

            switch (trangThai)
            {
                case "Trong":
                    btn.BackColor = Color.Blue;
                    break;
                case "Trống":
                    btn.BackColor = Color.Blue;
                    break;
                default:
                    btn.BackColor = Color.LightPink;
                    break;
            }
        }
        private void btn_ban1_Click(object sender, EventArgs e)
        {
            loadBA("BA001");
            idBA = "BA001";
            loadMau(idBA, btn_ban1);
        }

        private void btn_ban2_Click(object sender, EventArgs e)
        {
            loadBA("BA002");
            idBA = "BA002";
            loadMau(idBA, btn_ban2);
        }

        private void btn_ban3_Click(object sender, EventArgs e)
        {
            loadBA("BA003");
            idBA = "BA003";
            loadMau(idBA, btn_ban3);
        }

        private void btn_ban4_Click(object sender, EventArgs e)
        {
            loadBA("BA004");
            idBA = "BA004";
            loadMau(idBA, btn_ban4);
        }

        private void btn_ban5_Click(object sender, EventArgs e)
        {
            loadBA("BA005");
            idBA = "BA005";
            loadMau(idBA, btn_ban5);
        }

        private void btn_ban6_Click(object sender, EventArgs e)
        {
            loadBA("BA006");
            idBA = "BA006";
            loadMau(idBA, btn_ban6);
        }

        private void btn_ban7_Click(object sender, EventArgs e)
        {
            loadBA("BA007");
            idBA = "BA007";
            loadMau(idBA, btn_ban7);
        }

        private void btn_ban8_Click(object sender, EventArgs e)
        {
            loadBA("BA008");
            idBA = "BA008";
            loadMau(idBA, btn_ban8);
        }

        private void btn_ban9_Click(object sender, EventArgs e)
        {
            loadBA("BA009");
            idBA = "BA009";
            loadMau(idBA, btn_ban9);
        }

        private void btn_ban10_Click(object sender, EventArgs e)
        {
            loadBA("BA010");
            idBA = "BA010";
            loadMau(idBA, btn_ban10);
        }

        private void btn_ban11_Click(object sender, EventArgs e)
        {
            loadBA("BA011");
            idBA = "BA011";
            loadMau(idBA, btn_ban11);
        }

        private void btn_ban12_Click(object sender, EventArgs e)
        {
            loadBA("BA012");
            idBA = "BA012";
            loadMau(idBA, btn_ban12);
        }

        private void btn_themDB_Click(object sender, EventArgs e)
        {

            string mdb = txb_idDB.Text;
            string mkh = txb_mKH.Text;
            DateTime ndb = DateTime.Parse(dtp_ngay.Text);
            string gBD = txb_gBD.Text;
            string gKT = txb_gKT.Text;
            string stt = cb_stt.Text;

            string k1 = "insert into KhachHang (KhachHangID,HoTen,GioiTinh,NgaySinh,SoDienThoai,Email,DiaChi) " +
                " values ('" + mkh + "',null,null,null,null,null,null)";
            string q1 = "update BanAn set TrangThai = '" + stt + "' where BanAnID = '" + idBA + "'";
            string query = "insert into DatBan(DatBanID,KhachHangID,GioBatDau,GioKetThuc,NgayDat, BanAnId)" +
                                "values ('" + mdb + "','" + mkh + "','" + gBD + "','" + gKT + "','" + ndb + "','" + idBA + "' )";
            dtg_banAn.DataSource = provider.ExecuteNonQuery(k1);
            dtg_banAn.DataSource = provider.ExecuteNonQuery(query);
            dtg_banAn.DataSource = provider.ExecuteNonQuery(q1);
            loadBA(idBA);
        }

        private void btn_daTT_Click(object sender, EventArgs e)
        {
            string maTT = txb_idDB.Text;
            string query = $"DELETE FROM DatBan WHERE DatBanID = N'{maTT}'";
            dtg_fb.DataSource = provider.ExecuteNonQuery(query);
            loadBA(idBA);

            txb_idDB.Clear();
            txb_mKH.Clear();
            txb_gBD.Clear();
            txb_gKT.Clear();
            dtp_ngay = null;
        }

        private void btn_suaBD_Click(object sender, EventArgs e)
        {
            string stt = cb_stt.Text;
            string query = "update BanAn set TrangThai = '" + stt + "'";

            string mdb = txb_idDB.Text;
            string mkh = txb_mKH.Text;
            DateTime ndb = DateTime.Parse(dtp_ngay.Text);
            string gBD = txb_gBD.Text;
            string gKT = txb_gKT.Text;

            string b1 = "update DatBan set NgayDat = '" + ndb + "', GioBatDau = '" + gBD + "',GioKetThuc = '" + gKT + "' where DatBanID = '" + mdb + "' and KhachHangID = '" + mkh + "' and BanAnID = '" + idBA + "'\r\n";

            dtg_banAn.DataSource = provider.ExecuteNonQuery(query);
            dtg_banAn.DataSource = provider.ExecuteNonQuery(b1);
            loadBA(idBA);
        }

        private void dgv_PhieuNhap_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maPN.Text = dgv_PhieuNhap[0, e.RowIndex].Value.ToString();
            txb_maNCC_PN.Text = dgv_PhieuNhap[1, e.RowIndex].Value.ToString();
            txb_maNV_PN.Text = dgv_PhieuNhap[2, e.RowIndex].Value.ToString();
            txb_ngayNhap_PN.Text = dgv_PhieuNhap[3, e.RowIndex].Value.ToString();
            txb_tongTien.Text = dgv_PhieuNhap[4, e.RowIndex].Value.ToString();

            string query = "SELECT * FROM ChiTietPhieuNhap WHERE PhieuNhapID = '" + dgv_PhieuNhap.Rows[e.RowIndex].Cells[0].Value.ToString() + "'";
            dgv_ChiTietPN.DataSource = provider.ExecuteQuery(query);
        }

        private void dgv_ChiTietPN_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txb_maCTPN.Text = dgv_ChiTietPN[0, e.RowIndex].Value.ToString();
            txb_maPN_CTPN.Text = dgv_ChiTietPN[1, e.RowIndex].Value.ToString();
            txb_maNL_CTPN.Text = dgv_ChiTietPN[2, e.RowIndex].Value.ToString();
            txb_soLuong_CTPN.Text = dgv_ChiTietPN[3, e.RowIndex].Value.ToString();
            txb_donGia_CTPN.Text = dgv_ChiTietPN[4, e.RowIndex].Value.ToString();
            txb_thanhTien_CTPN.Text = dgv_ChiTietPN[5, e.RowIndex].Value.ToString();
        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void dtg_phancong_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dtg_phancong_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_tkllv_Click(object sender, EventArgs e)
        {

        }

        private void dtg_ttllv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_giovao_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoapc_Click(object sender, EventArgs e)
        {

        }

        private void btn_suapc_Click(object sender, EventArgs e)
        {

        }

        private void btn_thempc_Click(object sender, EventArgs e)
        {

        }

        private void btn_tknvlv_Click(object sender, EventArgs e)
        {

        }

        private void btn_suaCTPN_Click(object sender, EventArgs e)
        {

        }

        private void btn_xoaCTPN_Click(object sender, EventArgs e)
        {

        }

        private void btn_thempc_Click_1(object sender, EventArgs e)
        {
            string maNhanVien = dtg_phancong[0, dtg_phancong.CurrentRow.Index].Value.ToString();

            // Lấy thông tin ca làm việc mới từ các TextBox
            string maCa = txt_caid.Text;
            string ngayLam = txt_ngaylv.Text;
            string gioVao = txt_giovao.Text;
            string gioRa = txt_giora.Text;

            // Thêm mới ca làm việc vào cơ sở dữ liệu
            string query = $"INSERT INTO [QL_NhaHang].[dbo].[LichLamViec] (LichLamViecID,NhanVienID, NgayLamViec, GioBatDau, GioKetThuc) VALUES (N'{maCa}',N'{maNhanVien}', N'{ngayLam}', N'{gioVao}', N'{gioRa}')";
            provider.ExecuteNonQuery(query);

            // Cập nhật lại DataGridView dtg_ttllv
            query = $"SELECT * FROM [QL_NhaHang].[dbo].[LichLamViec] WHERE NhanVienID = N'{maNhanVien}'";
            dtg_ttllv.DataSource = provider.ExecuteQuery(query);
        }

        private void btn_suapc_Click_1(object sender, EventArgs e)
        {
            string lichLamViecID = txt_caid.Text;
            string maNhanVien = dtg_phancong[0, dtg_phancong.CurrentRow.Index].Value.ToString();
            string ngayLamViec = txt_ngaylv.Text;
            string gioBatDau = txt_giovao.Text;
            string gioKetThuc = txt_giora.Text;

            // Cập nhật thông tin ca làm việc trong cơ sở dữ liệu
            string query = $"UPDATE [QL_NhaHang].[dbo].[LichLamViec] " +
                           $"SET NgayLamViec = N'{ngayLamViec}', GioBatDau = N'{gioBatDau}', GioKetThuc = N'{gioKetThuc}' " +
                           $"WHERE LichLamViecID = N'{lichLamViecID}' AND NhanVienID = N'{maNhanVien}'";
            provider.ExecuteNonQuery(query);

            // Cập nhật lại DataGridView dtg_ttllv
            query = $"SELECT * FROM [QL_NhaHang].[dbo].[LichLamViec] WHERE NhanVienID = N'{maNhanVien}'";
            dtg_ttllv.DataSource = provider.ExecuteQuery(query);
        }

        private void btn_xoapc_Click_1(object sender, EventArgs e)
        {
            string maCa = txt_caid.Text;
            string maNhanVien = dtg_phancong[0, dtg_phancong.CurrentRow.Index].Value.ToString();
            string query = $"DELETE FROM LichLamViec WHERE LichlamViecID = N'{maCa}'";
            provider.ExecuteNonQuery(query);

            query = $"SELECT * FROM [QL_NhaHang].[dbo].[LichLamViec] WHERE NhanVienID = N'{maNhanVien}'";
            dtg_ttllv.DataSource = provider.ExecuteQuery(query);
            txt_ngaylv.Clear();
            txt_giovao.Clear();
            txt_giora.Clear();
            txt_caid.Clear();
        }

        private void btn_tkllv_Click_1(object sender, EventArgs e)
        {
            string lichLamViecID = txt_tkllv.Text.Trim();

            // Xây dựng câu truy vấn SQL để tìm kiếm
            string query = $"SELECT * FROM [QL_NhaHang].[dbo].[LichLamViec] WHERE LichLamViecID = N'{lichLamViecID}'";

            // Thực thi câu truy vấn và gán kết quả vào DataGridView
            dtg_ttllv.DataSource = provider.ExecuteQuery(query);
        }

        private void btn_tknvlv_Click_1(object sender, EventArgs e)
        {
            string manv = txt_tkpc.Text.Trim();

            // Xây dựng câu truy vấn SQL để tìm kiếm
            string query = $"SELECT NhanVienID,HoTen,ChucVu FROM [QL_NhaHang].[dbo].[NhanVien] WHERE NhanVienID = N'{manv}'";

            // Thực thi câu truy vấn và gán kết quả vào DataGridView
            dtg_phancong.DataSource = provider.ExecuteQuery(query);
        }

        private void dtg_phancong_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txb_maNv.Text = dtg_phancong[0, e.RowIndex].Value.ToString();
            txb_tenNv.Text = dtg_phancong[1, e.RowIndex].Value.ToString();
            txb_chucVu.Text = dtg_phancong[2, e.RowIndex].Value.ToString();

            string manv = txb_maNv.Text;
            string query = $"SELECT * FROM [QL_NhaHang].[dbo].[LichLamViec] WHERE NhanVienID = N'{manv}'";
            dtg_ttllv.DataSource = provider.ExecuteQuery(query);
            dtg_ttllv.Columns[0].HeaderText = "Mã ca";
            dtg_ttllv.Columns[1].HeaderText = "Mã nhân viên";
            dtg_ttllv.Columns[2].HeaderText = "Ngày Làm";
            dtg_ttllv.Columns[3].HeaderText = "Giờ Vào ca";
            dtg_ttllv.Columns[4].HeaderText = "Giờ kết thúc";
            dtg_ttllv.AllowUserToAddRows = false;
        }

        private void dtg_ttllv_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txt_caid.Text = dtg_ttllv[0, e.RowIndex].Value.ToString();
            txt_ngaylv.Text = dtg_ttllv[2, e.RowIndex].Value.ToString();
            txt_giovao.Text = dtg_ttllv[3, e.RowIndex].Value.ToString();
            txt_giora.Text = dtg_ttllv[4, e.RowIndex].Value.ToString();
        }

        private void btn_suaNCC_Click(object sender, EventArgs e)
        {
            string query = "UPDATE NhaCungCap SET ";
            query += "TenNhaCungCap = N'" + txb_tenNCC.Text + "',";
            query += "DiaChi = N'" + txb_diaChi.Text + "',";
            query += "SoDienThoai = N'" + txb_sdtNCC.Text + "',";
            query += "Email = N'" + txb_emailNCC.Text + "'";
            query += "WHERE NhaCungCapID = '" + txb_maNCC.Text + "'";
            dgv_NCC.DataSource = provider.ExecuteNonQuery(query);
            loadncc();
        }

        private void btn_xoaNCC_Click(object sender, EventArgs e)
        {
            string xncc = txb_maNCC.Text;
            string query = $"DELETE NhaCungCap WHERE NhaCungCapID = N'{xncc}'";
            dgv_NCC.DataSource = provider.ExecuteNonQuery(query);
            loadncc();

            txb_maNCC.Clear();
            txb_tenNCC.Clear();
            txb_diaChi.Clear();
            txb_sdtNCC.Clear();
            txb_emailNCC.Clear();
        }

        private void btn_timKiemNCC_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM [QL_NhaHang].[dbo].[NhaCungCap] where NhaCungCapID like N'%" + txb_timKiemNCC.Text + "%'";
            dgv_NCC.DataSource = provider.ExecuteQuery(query);
            dgv_NCC.Columns[0].HeaderText = "Mã NCC";
            dgv_NCC.Columns[1].HeaderText = "Tên NCC";
            dgv_NCC.Columns[2].HeaderText = "Địa chỉ";
            dgv_NCC.Columns[3].HeaderText = "Số điện thoại";
            dgv_NCC.Columns[4].HeaderText = "Email";
        }

        private void dtg_banAn_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
