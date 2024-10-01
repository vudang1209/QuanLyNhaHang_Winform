
-- in thong tin nha cung cap xem cung cap nguyen lieu gì
SELECT NhaCungCap.TenNhaCungCap, NguyenLieu.TenNguyenLieu, NguyenLieu.SoLuong
FROM NhaCungCap
INNER JOIN PhieuNhap ON NhaCungCap.NhaCungCapID = PhieuNhap.NhaCungCapID
INNER JOIN ChiTietPhieuNhap ON PhieuNhap.PhieuNhapID = ChiTietPhieuNhap.PhieuNhapID
INNER JOIN NguyenLieu ON ChiTietPhieuNhap.NguyenLieuID = NguyenLieu.NguyenLieuID;

INSERT INTO MonAn (MonAnID, TenMonAn, Gia, MoTa)
VALUES ('MA022', N'Phở bò', 50000, N'Phở bò thơm ngon');
-- 

-- Cập nhật thông tin nhân viên có mã NV001
UPDATE NhanVien
SET HoTen = N'Nguyen Van B', Luong = 12000000
WHERE NhanVienID = 'NV001';

