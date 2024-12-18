DROP DATABASE [QLSINHVIEN];

GO

CREATE DATABASE [QLSINHVIEN];

GO

USE [QLSINHVIEN];

GO

CREATE TABLE KhoaHoc(
	MaKhoaHoc varchar(10) CONSTRAINT PK_KhoaHoc PRIMARY KEY NOT NULL,
	NgayBatDau datetime NOT NULL,
	NgayKetThuc datetime NOT NULL
	);

GO

INSERT INTO KhoaHoc VALUES ('K52', '09/05/2007', '06/30/2012');
INSERT INTO KhoaHoc VALUES ('K53', '09/05/2008', '06/30/2013');
INSERT INTO KhoaHoc VALUES ('K54', '09/05/2009', '06/30/2014');
INSERT INTO KhoaHoc VALUES ('K55', '09/05/2010', '06/30/2015');
INSERT INTO KhoaHoc VALUES ('K56', '09/05/2011', '06/30/2016');
INSERT INTO KhoaHoc VALUES ('K57', '09/05/2012', '06/30/2017');
INSERT INTO KhoaHoc VALUES ('K58', '09/05/2013', '06/30/2018');

GO

CREATE TABLE HeDaoTao(
	MaHe varchar(10) CONSTRAINT PK_HeDaoTao PRIMARY KEY NOT NULL,
	TenHe nvarchar(50) NOT NULL
	);
	
GO

INSERT INTO HeDaoTao VALUES ('CQ', N'Chính quy');
INSERT INTO HeDaoTao VALUES ('TC', N'Tại chức');

GO

CREATE TABLE Khoa(
	MaKhoa varchar(10) CONSTRAINT PK_Khoa PRIMARY KEY NOT NULL,
	Tenkhoa nvarchar(50) NOT NULL
	);
	
GO

INSERT INTO Khoa VALUES ('CD', N'Cầu đường');
INSERT INTO Khoa VALUES ('CK', N'Cơ khí xây dựng');
INSERT INTO Khoa VALUES ('CNTT', N'Công nghệ thông tin');
INSERT INTO Khoa VALUES ('CTT', N'Công trình thủy');
INSERT INTO Khoa VALUES ('KT-QH', N'Kiến trúc quy hoạch');

GO

CREATE TABLE NganhDaoTao(
	MaNganh varchar(10) CONSTRAINT PK_NganhDaoTao PRIMARY KEY NOT NULL,
	TenNganh nvarchar(50) NOT NULL,
	MaKhoa varchar(10) CONSTRAINT FK_NganhDaoTao_Khoa FOREIGN KEY REFERENCES Khoa(MaKhoa)
	);
	
GO

INSERT INTO NganhDaoTao VALUES ('CDT', N'Cảng - đường thủy', 'CTT');
INSERT INTO NganhDaoTao VALUES ('CG', N'Cơ giới hóa xây dựng','CK');
INSERT INTO NganhDaoTao VALUES ('CNPM', N'Công nghệ phần mềm', 'CNTT');
INSERT INTO NganhDaoTao VALUES ('DUONG', N'Đường oto và đường đô thị', 'CD');
INSERT INTO NganhDaoTao VALUES ('KTCK', N'Kỹ thuật cơ khí', 'CK');
INSERT INTO NganhDaoTao VALUES ('KTDD', N'Kiến trúc dân dụng', 'KT-QH');
INSERT INTO NganhDaoTao VALUES ('KTHT', N'Kỹ thuật hệ thống', 'CNTT');
INSERT INTO NganhDaoTao VALUES ('QH', N'Quy hoạch', 'KT-QH');
INSERT INTO NganhDaoTao VALUES ('TD', N'Trắc địa', 'CD');
INSERT INTO NganhDaoTao VALUES ('TLTD', N'Thủy lợi - thủy điện', 'CTT');

GO

CREATE TABLE Lop(
	MaLop varchar(10) CONSTRAINT PK_Lop PRIMARY KEY NOT NULL,
	TenLop nvarchar(50) NOT NULL,
	MaKhoaHoc varchar(10) CONSTRAINT FK_Lop_KhoaHoc FOREIGN KEY REFERENCES KhoaHoc(MaKhoaHoc) NOT NULL,
	MaHeDaoTao varchar(10) CONSTRAINT FK_Lop_HeDaoTao FOREIGN KEY REFERENCES HeDaoTao(MaHe) NOT NULL,
	MaNganh varchar(10) CONSTRAINT FK_Lop_NganhDaoTao FOREIGN KEY REFERENCES NganhDaoTao(MaNganh)NOT NULL
	);
	
GO


INSERT INTO Lop VALUES ('55PM', N'55 phần mềm', 'K55', 'CQ', 'CNPM');
INSERT INTO Lop VALUES ('55TH', N'55 tin học', 'K55', 'CQ', 'KTHT');
INSERT INTO Lop VALUES ('56PM', N'56 phần mềm', 'K56', 'CQ', 'CNPM');
INSERT INTO Lop VALUES ('56TH', N'56 tin học', 'K56', 'CQ', 'KTHT');
INSERT INTO Lop VALUES ('57PM', N'57 phần mềm', 'K57', 'CQ', 'CNPM');
INSERT INTO Lop VALUES ('57TH', N'57 tin học', 'K57', 'CQ', 'KTHT');

GO

CREATE TABLE SinhVien(
	MaSinhVien varchar(10) CONSTRAINT PK_SinhVien PRIMARY KEY NOT NULL,
	TenSinhVien nvarchar(50) NOT NULL,
	NgaySinh datetime NOT NULL,
	GioiTinh bit NOT NULL,
	Anh image NULL,
	Lop varchar(10) CONSTRAINT FK_SinhVien_Lop FOREIGN KEY REFERENCES Lop(MaLop)NOT NULL,
	DiaChi nvarchar(50) NOT NULL,
	ChinhSachUuTien bit NULL
	);


GO

CREATE TABLE HocKy(
	MaHocKy varchar(10) CONSTRAINT PK_HocKy PRIMARY KEY NOT NULL,
	TenHocKy nvarchar(50) NOT NULL
	);
	
GO

INSERT INTO HocKy VALUES ('20101', N'Học kỳ 1 năm 2010');
INSERT INTO HocKy VALUES ('20102', N'Học kỳ 2 năm 2010');
INSERT INTO HocKy VALUES ('20111', N'Học kỳ 1 năm 2011');
INSERT INTO HocKy VALUES ('20112', N'Học kỳ 2 năm 2011');
INSERT INTO HocKy VALUES ('20121', N'Học kỳ 1 năm 2012');
INSERT INTO HocKy VALUES ('20122', N'Học kỳ 2 năm 2012');
INSERT INTO HocKy VALUES ('20131', N'Học kỳ 1 năm 2013');
INSERT INTO HocKy VALUES ('20132', N'Học kỳ 2 năm 2013');
INSERT INTO HocKy VALUES ('20141', N'Học kỳ 1 năm 2014');
--INSERT INTO HocKy VALUES ('20142', N'Học kỳ 2 năm 2014');
--INSERT INTO HocKy VALUES ('20151', N'Học kỳ 1 năm 2015');
--INSERT INTO HocKy VALUES ('20152', N'Học kỳ 2 năm 2015');

GO

CREATE TABLE MonHoc(
	MaMonHoc varchar(10) CONSTRAINT PK_MonHoc PRIMARY KEY NOT NULL,
	TenMonHoc nvarchar(50) NOT NULL,
	SoTinChi int NOT NULL
	);

GO

INSERT INTO MonHoc VALUES ('300101', N'Hình họa',2);
INSERT INTO MonHoc VALUES ('380211', N'Pháp luật việt nam đại cương',2);
INSERT INTO MonHoc VALUES ('390111', N'Đại số tuyến tính',3);
INSERT INTO MonHoc VALUES ('390121', N'Giải tích 1',3);
INSERT INTO MonHoc VALUES ('401701', N'Logic học đại cương',2);
INSERT INTO MonHoc VALUES ('430101', N'Giáo dục thể chất 1',0);
INSERT INTO MonHoc VALUES ('450101', N'Tin học đại cương',3);
INSERT INTO MonHoc VALUES ('480101', N'Giáo dục quốc phòng 1',0);
INSERT INTO MonHoc VALUES ('480102', N'Giáo dục quốc phòng 2',0);
INSERT INTO MonHoc VALUES ('480103', N'Giáo dục quốc phòng 3',0);
INSERT INTO MonHoc VALUES ('480104', N'Giáo dục quốc phòng 4',0);

INSERT INTO MonHoc VALUES ('250101', N'Vật lí 1', 3);
INSERT INTO MonHoc VALUES ('300102', N'Vẽ kỹ thuật', 2);
INSERT INTO MonHoc VALUES ('390141', N'Giải tích 2', 4);
INSERT INTO MonHoc VALUES ('401703', N'Toán học tính toán', 3);
INSERT INTO MonHoc VALUES ('401712', N'Toán rời rạc', 3);
INSERT INTO MonHoc VALUES ('420101', N'Những N.lý CB của CN Mác-Leenin(Phần 1)', 2);
INSERT INTO MonHoc VALUES ('430102', N'Giáo dục thể chất 2', 0);
INSERT INTO MonHoc VALUES ('440121', N'Ngoại ngữ 1', 3);
INSERT INTO MonHoc VALUES ('531723', N'Thực hành TH1', 2);

INSERT INTO MonHoc VALUES ('250102', N'Vật lý 2', 2);
INSERT INTO MonHoc VALUES ('250103', N'Thực hành vật lý', 1);
INSERT INTO MonHoc VALUES ('400101', N'Xác xuất thống kê', 2);
INSERT INTO MonHoc VALUES ('401806', N'Lý thuyết đồ thị', 2);
INSERT INTO MonHoc VALUES ('401808', N'Automat & NNHT', 2);
INSERT INTO MonHoc VALUES ('420102', N'Những N.lý CB của CN Mác - Lenin (Phần 2)', 3);
INSERT INTO MonHoc VALUES ('430103', N'Giáo dục thể chất 3', 0);
INSERT INTO MonHoc VALUES ('440141', N'Ngoại ngữ 2', 3);
INSERT INTO MonHoc VALUES ('461727', N'Ngôn ngữ lập trình C++', 3);

INSERT INTO MonHoc VALUES ('270201', N'Kỹ thuật điện', 3);
INSERT INTO MonHoc VALUES ('270812', N'Kỹ thuật điện tử', 2);
INSERT INTO MonHoc VALUES ('401816', N'Lý thuyết điều khiển', 2);
INSERT INTO MonHoc VALUES ('410112', N'Tư tưởng Hồ Chí Minh', 2);
INSERT INTO MonHoc VALUES ('430104', N'Giáo dục thể chất 4', 0);
INSERT INTO MonHoc VALUES ('461725', N'Cơ sở hệ điều hành', 2);
INSERT INTO MonHoc VALUES ('461736', N'Cơ sở lý thuyết truyền tin', 2);
INSERT INTO MonHoc VALUES ('471726', N'Thuật toán và cấu trúc dữ liệu', 2);
INSERT INTO MonHoc VALUES ('471780', N'Nhập môn cơ sở dữ liệu', 2);
INSERT INTO MonHoc VALUES ('531733', N'Kỹ thuật số', 2);

INSERT INTO MonHoc VALUES ('410113', N'Đường lối CM của Đảng cộng sản VN', 3);
INSERT INTO MonHoc VALUES ('430105', N'Giáo dục thể chất 5', 0);
INSERT INTO MonHoc VALUES ('440214', N'Ngoại ngữ chuyên ngành', 2);
INSERT INTO MonHoc VALUES ('461714', N'Mạng máy tính', 2);
INSERT INTO MonHoc VALUES ('461737', N'Kỹ thuật truyền số liệu', 3);
INSERT INTO MonHoc VALUES ('471717', N'Hệ quản trị cơ sở dữ liệu', 2);
INSERT INTO MonHoc VALUES ('471728', N'Đồ án hệ quản trị CSDL', 1);
INSERT INTO MonHoc VALUES ('531713', N'Kiến trúc máy tính', 2);
INSERT INTO MonHoc VALUES ('531734', N'Kỹ thuật vi xử lý 1', 2);

INSERT INTO MonHoc VALUES ('451762', N'Thuật toán & CTDL nâng cao', 2);
INSERT INTO MonHoc VALUES ('461730', N'Phương pháp lập trình hướng đối tượng', 3);
INSERT INTO MonHoc VALUES ('471729', N'Đồ họa máy tính 1', 2);
INSERT INTO MonHoc VALUES ('471732', N'Công nghệ phần mềm', 2);
INSERT INTO MonHoc VALUES ('471733', N'Phân tích & thiết kế HTTT', 2);
INSERT INTO MonHoc VALUES ('471734', N'Đồ án phân tích & thiết kế HTTT', 1);
INSERT INTO MonHoc VALUES ('471781', N'Cơ sở dữ liệu nâng cao', 2);
INSERT INTO MonHoc VALUES ('531735', N'Kỹ thuật vi xử lý 2', 2);
INSERT INTO MonHoc VALUES ('531815', N'Lập trình hệ thống', 2);
INSERT INTO MonHoc VALUES ('531824', N'Thực hành TH 2', 2);

INSERT INTO MonHoc VALUES ('461731', N'Đồ án PPLT hướng đối tượng', 1);
INSERT INTO MonHoc VALUES ('461761', N'Trí tuệ nhân tạo', 2);
INSERT INTO MonHoc VALUES ('471731', N'Công nghệ WEB', 2);
INSERT INTO MonHoc VALUES ('471735', N'Đồ họa máy tính 2', 2);
INSERT INTO MonHoc VALUES ('471738', N'Nhận dạng xủ lý tiếng nói', 2);
INSERT INTO MonHoc VALUES ('471740', N'Đồ án đồ họa máy tính', 1);
INSERT INTO MonHoc VALUES ('471741', N'Đồ án công nghệ phần mềm', 1);
INSERT INTO MonHoc VALUES ('471774', N'Lập trình LINUX', 3);
INSERT INTO MonHoc VALUES ('531732', N'Xử lý số tín hiệu', 2);

INSERT INTO MonHoc VALUES ('461751', N'An toàn bảo mật thông tin', 2);
INSERT INTO MonHoc VALUES ('461781', N'Hệ chuyên gia', 2);
INSERT INTO MonHoc VALUES ('471730', N'Lập trình trên môi trường Windowns', 2);
INSERT INTO MonHoc VALUES ('471752', N'Quản lý dự án CNTT', 2);
INSERT INTO MonHoc VALUES ('471771', N'Công nghệ WEB nâng cao', 2);
INSERT INTO MonHoc VALUES ('471772', N'C# và MT NET', 4);
INSERT INTO MonHoc VALUES ('471773', N'Phần mềm nguồn mở & TK WEB', 4);
INSERT INTO MonHoc VALUES ('471782', N'Công nghệ đa phương tiện', 2);
INSERT INTO MonHoc VALUES ('471783', N'Đồ án tổng hợp (CNTT)', 1);
INSERT INTO MonHoc VALUES ('471784', N'Lập trình trong môi trường nhúng', 3);
INSERT INTO MonHoc VALUES ('471811', N'Đồ án cơ sở dữ liệu', 1);

INSERT INTO MonHoc VALUES ('451780', N'Thực tập', 4);
INSERT INTO MonHoc VALUES ('451781', N'Đồ án tốt nghiệp', 10);
GO

CREATE TABLE BangDiem(
	Stt int IDENTITY(1,1) CONSTRAINT PK_BangDiem PRIMARY KEY NOT NULL,
	MaSinhVien varchar(10) CONSTRAINT FK_BangDiem_SinhVien FOREIGN KEY REFERENCES SinhVien(MaSinhVien) NOT NULL,
	MaMonHoc varchar(10) CONSTRAINT FK_BangDiem_MonHoc FOREIGN KEY REFERENCES MonHoc(MaMonHoc)NOT NULL,
	MaHocKy varchar(10) CONSTRAINT FK_BangDiem_HocKy FOREIGN KEY REFERENCES HocKy(MaHocKy)NOT NULL,
	DiemQuaTrinh float NOT NULL,
	DiemThi float NOT NULL
	);

GO

INSERT INTO BangDiem VALUES ('615155', '300101', '20101', '6.5', '1');
INSERT INTO BangDiem VALUES ('615155', '380211', '20101', '7', '5');
INSERT INTO BangDiem VALUES ('615155', '390111', '20101', '5.5', '3.5');
INSERT INTO BangDiem VALUES ('615155', '390121', '20101', '7', '3');
INSERT INTO BangDiem VALUES ('615155', '401701', '20101', '8', '6');
INSERT INTO BangDiem VALUES ('615155', '430101', '20101', '3', '4');
INSERT INTO BangDiem VALUES ('615155', '450101', '20101', '7.5', '3');
INSERT INTO BangDiem VALUES ('615155', '480101', '20101', '7', '5');
INSERT INTO BangDiem VALUES ('615155', '480102', '20101', '7', '6.5');
INSERT INTO BangDiem VALUES ('615155', '480103', '20101', '7', '5');
INSERT INTO BangDiem VALUES ('615155', '480104', '20101', '5', '6');

INSERT INTO BangDiem VALUES ('615155', '250101', '20102', '3.0', '3.7');
INSERT INTO BangDiem VALUES ('615155', '300102', '20102', '8.0', '3.0');
INSERT INTO BangDiem VALUES ('615155', '390141', '20102', '7.5', '4.5');
INSERT INTO BangDiem VALUES ('615155', '401703', '20102', '9.2', '3.0');
INSERT INTO BangDiem VALUES ('615155', '401712', '20102', '6.3', '5.0');
INSERT INTO BangDiem VALUES ('615155', '420101', '20102', '6.5', '7.0');
INSERT INTO BangDiem VALUES ('615155', '430102', '20102', '7.0', '2.0');
INSERT INTO BangDiem VALUES ('615155', '440121', '20102', '8.5', '2.0');
INSERT INTO BangDiem VALUES ('615155', '531723', '20102', '7.5', '5.0');

INSERT INTO BangDiem VALUES ('615155', '250102', '20111', '8.5', '3.2');
INSERT INTO BangDiem VALUES ('615155', '250103', '20111', '6.5', '6.5');
INSERT INTO BangDiem VALUES ('615155', '400101', '20111', '10.0', '6.5');
INSERT INTO BangDiem VALUES ('615155', '401806', '20111', '9.5', '7.0');
INSERT INTO BangDiem VALUES ('615155', '401808', '20111', '6.5', '9.0');
INSERT INTO BangDiem VALUES ('615155', '420102', '20111', '7.0', '6.5');
INSERT INTO BangDiem VALUES ('615155', '430103', '20111', '7.0', '3.0');
INSERT INTO BangDiem VALUES ('615155', '440141', '20111', '5.5', '3.0');
INSERT INTO BangDiem VALUES ('615155', '461727', '20111', '7.5', '2.5');

INSERT INTO BangDiem VALUES ('615155', '270201', '20112', '4.5', '2.0');
INSERT INTO BangDiem VALUES ('615155', '270812', '20112', '6.0', '4.0');
INSERT INTO BangDiem VALUES ('615155', '401816', '20112', '8.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '410112', '20112', '7.8', '7.5');
INSERT INTO BangDiem VALUES ('615155', '430104', '20112', '6.0', '4.0');
INSERT INTO BangDiem VALUES ('615155', '461725', '20112', '8.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '461736', '20112', '10.0', '5.5');
INSERT INTO BangDiem VALUES ('615155', '471726', '20112', '9.0', '2.5');
INSERT INTO BangDiem VALUES ('615155', '471780', '20112', '9.0', '5.0');
INSERT INTO BangDiem VALUES ('615155', '531733', '20112', '5.5', '3.5');

INSERT INTO BangDiem VALUES ('615155', '410113', '20121', '7.8', '6.4');
INSERT INTO BangDiem VALUES ('615155', '430105', '20121', '5.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '440214', '20121', '8.5', '2.5');
INSERT INTO BangDiem VALUES ('615155', '461714', '20121', '7.0', '6.0');
INSERT INTO BangDiem VALUES ('615155', '461737', '20121', '6.0', '7.0');
INSERT INTO BangDiem VALUES ('615155', '471717', '20121', '6.5', '4.0');
INSERT INTO BangDiem VALUES ('615155', '471728', '20121', '8.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '531713', '20121', '6.0', '5.5');
INSERT INTO BangDiem VALUES ('615155', '531734', '20121', '8.0', '4.0');

INSERT INTO BangDiem VALUES ('615155', '270201', '20122', '8.2', '7.0');
INSERT INTO BangDiem VALUES ('615155', '300101', '20122', '8.2', '7.5');
INSERT INTO BangDiem VALUES ('615155', '451762', '20122', '7.0', '5.0');
INSERT INTO BangDiem VALUES ('615155', '461730', '20122', '8.0', '6.5');
INSERT INTO BangDiem VALUES ('615155', '471729', '20122', '8.0', '5.0');
INSERT INTO BangDiem VALUES ('615155', '471732', '20122', '9.0', '9.5');
INSERT INTO BangDiem VALUES ('615155', '471733', '20122', '7.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '471734', '20122', '8.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '471781', '20122', '9.0', '7.5');
INSERT INTO BangDiem VALUES ('615155', '531735', '20122', '8.0', '4.0');
INSERT INTO BangDiem VALUES ('615155', '531815', '20122', '7.0', '4.0');
INSERT INTO BangDiem VALUES ('615155', '531824', '20122', '9.0', '3.0');
INSERT INTO BangDiem VALUES ('615155', '430101', '20122', '7.0', '5.0');

INSERT INTO BangDiem VALUES ('615155', '430103', '20131', '6.0', '4.0');
INSERT INTO BangDiem VALUES ('615155', '461731', '20131', '9.0', '9.0');
INSERT INTO BangDiem VALUES ('615155', '461761', '20131', '9.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '471731', '20131', '8.0', '6.5');
INSERT INTO BangDiem VALUES ('615155', '471735', '20131', '8.0', '7.5');
INSERT INTO BangDiem VALUES ('615155', '471738', '20131', '5.5', '9.0');
INSERT INTO BangDiem VALUES ('615155', '471740', '20131', '9.5', '9.5');
INSERT INTO BangDiem VALUES ('615155', '471741', '20131', '9.0', '9.0');
INSERT INTO BangDiem VALUES ('615155', '471774', '20131', '6.0', '4.0');
INSERT INTO BangDiem VALUES ('615155', '531732', '20131', '7.5', '7.0');

INSERT INTO BangDiem VALUES ('615155', '430102', '20132', '7.0', '7.0');
INSERT INTO BangDiem VALUES ('615155', '430103', '20132', '7.0', '7.0');
INSERT INTO BangDiem VALUES ('615155', '461751', '20132', '8.1', '7.1');
INSERT INTO BangDiem VALUES ('615155', '461781', '20132', '9.0', '6.0');
INSERT INTO BangDiem VALUES ('615155', '471730', '20132', '7.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '471752', '20132', '8.0', '6.5');
INSERT INTO BangDiem VALUES ('615155', '471771', '20132', '9.0', '5.0');
INSERT INTO BangDiem VALUES ('615155', '471772', '20132', '9.0', '5.0');
INSERT INTO BangDiem VALUES ('615155', '471773', '20132', '9.5', '7.0');
INSERT INTO BangDiem VALUES ('615155', '471782', '20132', '8.6', '8.5');
INSERT INTO BangDiem VALUES ('615155', '471783', '20132', '8.0', '8.0');
INSERT INTO BangDiem VALUES ('615155', '471784', '20132', '10.0', '9.0');
INSERT INTO BangDiem VALUES ('615155', '471811', '20132', '9.0', '9.0');
INSERT INTO BangDiem VALUES ('615155', '250101', '20132', '6.0', '6.0');

INSERT INTO BangDiem VALUES ('615155', '451780', '20141', '9.0', '8.5');
INSERT INTO BangDiem VALUES ('615155', '451781', '20141', '9.2', '9.2');

GO

CREATE TABLE DoiDiem(
	Stt int IDENTITY(1,1) CONSTRAINT PK_DoiDiem PRIMARY KEY NOT NULL,
	DiemChu varchar(10) NULL,
	DiemSo float NULL,
	KetLuan nvarchar(10) NULL
	);
	
GO

INSERT INTO DoiDiem VALUES ('F', '0', N'Học lại');
INSERT INTO DoiDiem VALUES ('D', '1', N'Qua');
INSERT INTO DoiDiem VALUES ('D+', '1.5', N'Qua');
INSERT INTO DoiDiem VALUES ('C', '2', N'Qua');
INSERT INTO DoiDiem VALUES ('C+', '2.5', N'Qua');
INSERT INTO DoiDiem VALUES ('B', '3', N'Qua');
INSERT INTO DoiDiem VALUES ('B+', '3.5', N'Qua');
INSERT INTO DoiDiem VALUES ('A', '4', N'Qua');

GO

CREATE TABLE ThongTinDanhNhap(
	TaiKhoan varchar(30) CONSTRAINT PK_ThongTinDanhNhap PRIMARY KEY NOT NULL,
	MatKhau varchar(30) NOT NULL,
	Quyen nvarchar(30) NOT NULL,
	TrangThai bit
	);

GO

INSERT INTO ThongTinDanhNhap VALUES ('chukimmuoi','pomcoi',N'Admin', 0);
INSERT INTO ThongTinDanhNhap VALUES ('dothisim','pomcoi',N'Quản Lý', 0);
INSERT INTO ThongTinDanhNhap VALUES ('nguyenthithuy','pomcoi',N'Quản Lý', 0);

/*###=========================GIAO DIỆN DANH SÁCH SINH VIÊN===================###*/
--DANH SÁCH SINH VIÊN.
GO
CREATE PROC DanhSachSinhVien
AS
	SELECT MaSinhVien, TenSinhVien, NgaySinh, GioiTinh, Lop, DiaChi, ChinhSachUuTien FROM SinhVien ORDER BY TenSinhVien ASC;
--TÌM KIẾM SINH VIÊN.
GO
CREATE PROC TimKiemSinhVien
@TimKiem nvarchar(50)
AS
	SELECT MaSinhVien, TenSinhVien, NgaySinh, GioiTinh, Lop, DiaChi, ChinhSachUuTien 
	FROM SinhVien WHERE MaSinhVien LIKE '%'+@TimKiem+'%' OR TenSinhVien LIKE '%'+@TimKiem+'%' 
	OR Lop LIKE '%'+@TimKiem+'%';
--DANH SÁCH LƠP HỌC
GO
CREATE PROC DanhSachLop
AS
	SELECT * FROM Lop;
--THÊM SINH VIÊN MỚI.
GO
CREATE PROC ThemSinhVien
@MaSinhVien varchar(10),
@TenSinhVien nvarchar(50),
@NgaySinh datetime,
@GioiTinh bit,
@Anh image,
@Lop varchar(10),
@DiaChi nvarchar(50),
@ChinhSachUuTien bit
AS
	INSERT INTO SinhVien VALUES (@MaSinhVien, @TenSinhVien, @NgaySinh, @GioiTinh, @Anh, @Lop, 
	@DiaChi, @ChinhSachUuTien);
--SỬA THÔNG TIN SINH VIÊN.
GO
CREATE PROC SuaThongTinSinhVien
@MaSinhVien varchar(10),
@TenSinhVien nvarchar(50),
@NgaySinh datetime,
@GioiTinh bit,
@Lop varchar(10),
@DiaChi nvarchar(50),
@ChinhSachUuTien bit
AS
	UPDATE SinhVien SET TenSinhVien = @TenSinhVien, NgaySinh = @NgaySinh, 
	GioiTinh = @GioiTinh, Lop = @Lop, DiaChi = @DiaChi, ChinhSachUuTien = @ChinhSachUuTien 
	WHERE MaSinhVien = @MaSinhVien;	
--LẤY RA ẢNH CỦA MỘT SINH VIÊN.
GO
CREATE PROC LayAnhSinhVien
@TimKiem nvarchar(50)
AS
	SELECT Anh FROM SinhVien WHERE MaSinhVien = @TimKiem;
--XÓA SINH VIÊN.
GO
CREATE PROC XoaSinhVien
@Xoa varchar(10)
AS
	DELETE FROM SinhVien WHERE MaSinhVien = @Xoa;

/*###=========================GIAO DIỆN DANH SÁCH LỚP======================###*/
--LẤY RA DANH SÁCH VÀ THÔNG TIN LỚP HỌC.
GO
CREATE PROC DanhSach_ThongTin_Lop
AS
SELECT A.MaLop, A.TenLop, A.MaKhoaHoc, C.TenHe, B.TenNganh, D.Tenkhoa 
FROM Lop A, NganhDaoTao B, HeDaoTao C, Khoa D
WHERE A.MaNganh = B.MaNganh AND A.MaHeDaoTao = C.MaHe AND B.MaKhoa = D.MaKhoa 
ORDER BY Tenkhoa ASC, MaKhoaHoc DESC, MaLop ASC;
--LẤY RA DANH SÁCH 14 HỌC KỲ GẦN NHẤT
GO
CREATE PROC DanhSachHocKy
AS
	SELECT TOP 14 * FROM HocKy ORDER BY MaHocKy DESC;
--DANH SÁCH MÔN HỌC
GO
CREATE PROC DanhSachMonHoc
AS
	SELECT * FROM MonHoc ORDER BY TenMonHoc ASC;
--TÌM KIẾM MÔN HỌC
GO
CREATE PROC TimKiemMonHoc
@TenMonHoc nvarchar(50)
AS
	SELECT * FROM MonHoc WHERE TenMonHoc LIKE ''+@TenMonHoc+'%'  ORDER BY TenMonHoc ASC;
--DANH SÁCH SINH VIÊN CỦA LỚP HOC.
GO
CREATE PROC DanhSachSinhVienCuaLop
@MaLop varchar(10)
AS
	SELECT MaSinhVien, TenSinhVien FROM SinhVien WHERE Lop = @MaLop ORDER BY TenSinhVien ASC;
--LẤY RA ĐIỂM TRONG 1 HỌC KỲ CỦA SINH VIÊN.
GO
CREATE PROC LayDiemTheoKySinhVien
@MaSinhVien varchar(10),
@MaHocKy varchar(10) 
AS
	SELECT A.STT, A.MaHocKy, A.MaMonHoc, B.TenMonHoc, B.SoTinChi, A.DiemQuaTrinh, A.DiemThi, ROUND((A.DiemQuaTrinh*0.4 + A.DiemThi*0.6),1)[Diem Tong Ket],
	CASE
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) >= 8.45 THEN 'A'
	END [Diem Chu], (b.SoTinChi*c.DiemSo)[Diem Tich Luy], c.KetLuan
	FROM BangDiem A, MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc AND C.DiemChu = 
	(CASE
		WHEN (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) AND (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) AND (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) AND (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) AND (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) AND (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) AND (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND A.MaSinhVien = @MaSinhVien AND A.MaHocKy = @MaHocKy ORDER BY MaMonHoc ASC, MaHocKy ASC;
--THÊM ĐIỂM QUÁ TRÌNH VÀ ĐIỂM THI VÀO BẢNG ĐIỂM
GO
CREATE PROC ThemKetQua
@MaSinhVien varchar(10),
@MaMonHoc varchar(10),
@MaHocKy varchar(10),
@DiemQuaTrinh float,
@DiemThi float
AS
	INSERT INTO BangDiem VALUES (@MaSinhVien, @MaMonHoc, @MaHocKy, @DiemQuaTrinh, @DiemThi);
--UPFATE ĐIỂM QUÁ TRÌNH VÀ ĐIỂM THI
GO
CREATE PROC UpDateDiemQTVaDiemThi
@MaSinhVien varchar(10),
@MaMonHoc varchar(10),
@MaHocKy varchar(10),
@DiemQuaTrinh float,
@DiemThi float
AS
	UPDATE BangDiem SET DiemQuaTrinh = @DiemQuaTrinh, DiemThi = @DiemThi
	WHERE MaSinhVien = @MaSinhVien AND MaMonHoc = @MaMonHoc AND MaHocKy = @MaHocKy;
--XÓA ĐIỂM CỦA MỘT SINH VIÊN.
GO
CREATE PROC XoaDiemCuaSinhVien
@STT int
AS
	DELETE FROM BangDiem WHERE Stt = @STT;
/*###=========================GIAO DIỆN QUẢN LÝ LỚP======================###*/
--LẤY BẢNG HỆ ĐÀO TẠO
GO
CREATE PROC DanhSachHeDaoTao
AS
	SELECT * FROM HeDaoTao;
--LẤY BẢNG NGÀNH ĐÀO TẠO
GO
CREATE PROC DanhSachNganhDaoTao
AS
	SELECT MaNganh, TenNganh FROM NganhDaoTao;
--LẤY DANH SÁCH KHÓA HỌC
GO
CREATE PROC DanhSachKhoaHoc
AS
	SELECT MaKhoaHoc FROM KhoaHoc ORDER BY MaKhoaHoc DESC;
--THÊM LỚP HỌC MỚI.
GO
CREATE PROC ThemLopHocMoi
@MaLop varchar(10),
@TenLop nvarchar(50),
@MaKhoaHoc varchar(10),
@MaHeDaoTao varchar(10),
@MaNganh varchar(10)
AS
	INSERT INTO Lop(MaLop, TenLop, MaKhoaHoc, MaHeDaoTao, MaNganh) 
	VALUES (@MaLop, @TenLop, @MaKhoaHoc, @MaHeDaoTao, @MaNganh);
--SỬA THÔNG TIN LỚP HỌC
GO
CREATE PROC SuaThongTinLopHoc
@MaLop varchar(10),
@TenLop nvarchar(50),
@MaKhoaHoc varchar(10),
@MaHeDaoTao varchar(10),
@MaNganh varchar(10)
AS
	UPDATE Lop SET TenLop = @TenLop, MaKhoaHoc = @MaKhoaHoc, MaHeDaoTao = @MaHeDaoTao, MaNganh = @MaNganh
	WHERE MaLop = @MaLop;
--TÌM KIẾM NGÀNH ĐÀO TẠO.
GO
CREATE PROC TimKiemNganhDaoTao
@TenNganh nvarchar(50)
AS
	SELECT * FROM NganhDaoTao WHERE TenNganh LIKE ''+@TenNganh+'%'  ORDER BY TenNganh ASC;
--XÓA LỚP HỌC
GO
CREATE PROC XoaLopHoc
@MaLop varchar(10)
AS
	DELETE FROM Lop WHERE MaLop = @MaLop;
--TÌM KIẾM LỚP HỌC
GO
CREATE PROC TimKiemLopHoc
@TimKiem varchar(10)
AS
SELECT A.MaLop, A.TenLop, A.MaKhoaHoc, C.TenHe, B.TenNganh, D.Tenkhoa 
FROM Lop A, NganhDaoTao B, HeDaoTao C, Khoa D
WHERE A.MaNganh = B.MaNganh AND A.MaHeDaoTao = C.MaHe AND B.MaKhoa = D.MaKhoa
AND (A.MaLop LIKE '%'+@TimKiem+'%' OR A.TenLop LIKE '%'+@TimKiem+'%' OR D.Tenkhoa LIKE '%'+@TimKiem+'%'
OR C.TenHe LIKE '%'+@TimKiem+'%' OR B.TenNganh LIKE '%'+@TimKiem+'%' OR A.MaKhoaHoc LIKE '%'+@TimKiem+'%')
ORDER BY Tenkhoa ASC, MaKhoaHoc DESC, MaLop ASC;
/*###=========================GIAO DIÊN XEM KẾT QUẢ HỌC TẬP CỦA SINH VIÊN======================###*/
--LẤY RA TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.
GO
CREATE PROC LayKetQuaHocTap
@MaSinhVien varchar(10)
AS
	SELECT A.STT, A.MaHocKy, A.MaMonHoc, B.TenMonHoc, B.SoTinChi, A.DiemQuaTrinh, A.DiemThi, ROUND((A.DiemQuaTrinh*0.4 + A.DiemThi*0.6),1)[Diem Tong Ket],
	CASE
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) >= 8.45 THEN 'A'
	END [Diem Chu], (b.SoTinChi*c.DiemSo)[Diem Tich Luy], c.KetLuan
	FROM BangDiem A, MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc AND C.DiemChu = 
	(CASE
		WHEN (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (a.DiemQuaTrinh*0.4 + a.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND A.MaSinhVien = @MaSinhVien ORDER BY MaHocKy ASC, MaMonHoc ASC;
--TOÀN BỘ KẾT QUẢ HỌC TẬP - KHÔNG TÍNH MÔN TRƯỢT VÀ TRÙNG
GO
CREATE PROC KetQuaTongKetDaoTao
@MaSinhVien varchar(10)
AS
	SELECT SUM(B.SoTinChi)[SO TIN CHI TICH LUY],
	   ROUND((SUM(B.SoTinChi*(A.DiemQuaTrinh*0.4 + A.DiemThi*0.6))/SUM(B.SoTinChi)),2)[DIEM TICH LUY HE 10],
	   ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2)[DIEM TICH LUY HE 4]
	FROM (BangDiem A RIGHT JOIN 
		(SELECT B.MaMonHoc AS MA, MAX (B.DiemQuaTrinh*0.4 + B.DiemThi*0.6) AS DIEM FROM BangDiem B 
			WHERE MaSinhVien = @MaSinhVien 
			GROUP BY B.MaMonHoc) 
			AS BANGTAM
			ON A.MaMonHoc = MA AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) = DIEM), MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) > 3.95 ;
--KẾT QUẢ TỔNG KẾT THEO KỲ - TÍNH MÔN TRƯỢT.
----SỐ TÍN CHỈ ĐẠT - KHÔNG TÍNH MÔN TRƯỢT.
GO
CREATE PROC SoTinChiDat
@MaSinhVien varchar(10),
@MaHocKy varchar(10)
AS
	SELECT SUM(B.SoTinChi)[SO TIN CHI DAT]
	FROM BangDiem A , MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND MaSinhVien = @MaSinhVien AND MaHocKy = @MaHocKy;
----KẾT QUẢ HỌC TẬP - TÍNH MÔN TRƯỢT.
GO
CREATE PROC KetQuaTongKetHocKy
@MaSinhVien varchar(10),
@MaHocKy varchar(10)
AS
	SELECT
	   ROUND((SUM(B.SoTinChi*(A.DiemQuaTrinh*0.4 + A.DiemThi*0.6))/SUM(B.SoTinChi)),2)[DIEM TRUNG BINH HE 10],
	   ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2)[DIEM TRUNG BINH HE 4]
	FROM BangDiem A , MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND MaSinhVien = @MaSinhVien AND MaHocKy = @MaHocKy;
--/*###=========================GIAO DIỆN XÉT HỌC BỔNG======================###*/
--LẤY DANH SÁCH KHOA
GO
CREATE PROC DanhSachKhoa
AS
	SELECT MaKhoa, Tenkhoa FROM Khoa ORDER BY Tenkhoa ASC; 
--DANH SÁCH SINH VIÊN TOÀN TRƯỜNG ĐẠT HỌC BỔNG TRONG HỌC KỲ GẦN NHẤT. 
GO
CREATE PROC DanhSachSinhVienXetHocBong
@MaHocKy varchar(10)
AS
	SELECT
	A.MaSinhVien, D.TenSinhVien, E.TenLop, F.MaKhoaHoc, G.TenNganh, H.Tenkhoa,
	ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2)[DiemTrungBinhHocKyHe4]
	FROM BangDiem A , MonHoc B, DoiDiem C, SinhVien D, Lop E, KhoaHoc F, NganhDaoTao G, Khoa H
	WHERE A.MaMonHoc = B.MaMonHoc AND A.MaSinhVien = D.MaSinhVien AND D.Lop = E.MaLop
	AND E.MaKhoaHoc = F.MaKhoaHoc AND E.MaNganh = G.MaNganh AND G.MaKhoa = H.MaKhoa AND C.DiemChu = 
	(CASE
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND A.MaHocKy = @MaHocKy AND
	A.MaSinhVien
	NOT IN
	(SELECT
		M.MaSinhVien
	FROM BangDiem M, MonHoc B, DoiDiem C 
	WHERE M.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 5.45 THEN 'D+'
	END) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 5.45 AND M.MaHocKy = @MaHocKy)
	GROUP BY A.MaSinhVien, D.TenSinhVien, E.TenLop, F.MaKhoaHoc, G.TenNganh, H.Tenkhoa
	HAVING ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2) >= 2.5
	ORDER BY [DiemTrungBinhHocKyHe4] DESC;
--DANH SÁCH SINH VIÊN ĐẠT HỌC BỔNG CỦA KHOA.
GO
CREATE PROC DanhSachSinhVienXetHocBong_Khoa
@MaHocKy varchar(10),
@TimKiem varchar(10)
AS
	SELECT
	A.MaSinhVien, D.TenSinhVien, E.TenLop, F.MaKhoaHoc, G.TenNganh, H.Tenkhoa,
	ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2)[DiemTrungBinhHocKyHe4]
	FROM BangDiem A , MonHoc B, DoiDiem C, SinhVien D, Lop E, KhoaHoc F, NganhDaoTao G, Khoa H
	WHERE A.MaMonHoc = B.MaMonHoc AND A.MaSinhVien = D.MaSinhVien AND D.Lop = E.MaLop
	AND E.MaKhoaHoc = F.MaKhoaHoc AND E.MaNganh = G.MaNganh AND G.MaKhoa = H.MaKhoa AND C.DiemChu = 
	(CASE
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND A.MaHocKy = @MaHocKy AND H.MaKhoa = @TimKiem AND
	A.MaSinhVien
	NOT IN
	(SELECT
		M.MaSinhVien
	FROM BangDiem M, MonHoc B, DoiDiem C 
	WHERE M.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 5.45 THEN 'D+'
	END) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 5.45 AND M.MaHocKy = @MaHocKy)
	GROUP BY A.MaSinhVien, D.TenSinhVien, E.TenLop, F.MaKhoaHoc, G.TenNganh, H.Tenkhoa
	HAVING ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2) >= 2.5
	ORDER BY [DiemTrungBinhHocKyHe4] DESC;
--DANH SÁCH SINH VIÊN ĐẠT HỌC BỔNG CỦA KHOA - TOP.
GO
CREATE PROC DanhSachSinhVienXetHocBong_Khoa_Top
@MaHocKy varchar(10),
@TimKiem varchar(10),
@Top int
AS
	SELECT TOP (@Top) WITH TIES
	A.MaSinhVien, D.TenSinhVien, E.TenLop, F.MaKhoaHoc, G.TenNganh, H.Tenkhoa,
	ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2)[DiemTrungBinhHocKyHe4]
	FROM BangDiem A , MonHoc B, DoiDiem C, SinhVien D, Lop E, KhoaHoc F, NganhDaoTao G, Khoa H
	WHERE A.MaMonHoc = B.MaMonHoc AND A.MaSinhVien = D.MaSinhVien AND D.Lop = E.MaLop
	AND E.MaKhoaHoc = F.MaKhoaHoc AND E.MaNganh = G.MaNganh AND G.MaKhoa = H.MaKhoa AND C.DiemChu = 
	(CASE
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND A.MaHocKy = @MaHocKy AND H.MaKhoa = @TimKiem AND
	A.MaSinhVien
	NOT IN
	(SELECT
		M.MaSinhVien
	FROM BangDiem M, MonHoc B, DoiDiem C 
	WHERE M.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 3.95 THEN 'F'
		WHEN 3.95 <= (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 5.45 THEN 'D+'
	END) AND (M.DiemQuaTrinh*0.4 + M.DiemThi*0.6) < 5.45 AND M.MaHocKy = @MaHocKy)
	GROUP BY A.MaSinhVien, D.TenSinhVien, E.TenLop, F.MaKhoaHoc, G.TenNganh, H.Tenkhoa
	HAVING ROUND((SUM(B.SoTinChi*C.DiemSo)/SUM(B.SoTinChi)),2) >= 2.5
	ORDER BY [DiemTrungBinhHocKyHe4] DESC;	
--/*###=========================GIAO DIỆN XÉT RA TRƯỜNG======================###*/
--DANH SÁCH SINH VIÊN HẾT THỜI GIAN HỌC TẬP - HOẶC ĐỦ ĐIỀU KIÊN RA TRƯỜNG.
GO
CREATE PROC DanhSachSinhVienRaTruong
AS
	SELECT A.MaSinhVien, A.TenSinhVien, A.GioiTinh, B.TenLop, C.MaKhoaHoc, D.TenHe, E.TenNganh, F.Tenkhoa
	FROM SinhVien A, Lop B, KhoaHoc C, HeDaoTao D, NganhDaoTao E, Khoa F
	WHERE A.Lop = B.MaLop AND B.MaKhoaHoc = C.MaKhoaHoc AND B.MaHeDaoTao = D.MaHe
	AND B.MaNganh = E.MaNganh AND E.MaKhoa = F.MaKhoa
	AND ((DATEDIFF(DD, GETDATE(), C.NgayKetThuc) <=0 AND DATEDIFF(DD, GETDATE(), C.NgayKetThuc) > -365)
	OR A.MaSinhVien IN
	(SELECT A.MaSinhVien
	FROM (BangDiem A RIGHT JOIN 
		(SELECT B.MaMonHoc AS MA, MAX (B.DiemQuaTrinh*0.4 + B.DiemThi*0.6) AS DIEM , B.MaSinhVien FROM BangDiem B 
			WHERE MaSinhVien IN (SELECT MaSinhVien FROM SinhVien)
			GROUP BY B.MaMonHoc, B.MaSinhVien) 
			AS BANGTAM
			ON A.MaMonHoc = MA AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) = DIEM), MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) > 3.95 
	GROUP BY A.MaSinhVien
	HAVING SUM(B.SoTinChi) >= 130))
	ORDER BY A.TenSinhVien ASC;
--DANH SÁCH SINH VIÊN RA TRƯỜNG ĐƯỢC NHẬN BẰNG.
GO
CREATE PROC DanhSachSinhVienRaTruongDuocNhanBang
AS
	SELECT A.MaSinhVien, A.TenSinhVien, A.GioiTinh, B.TenLop, C.MaKhoaHoc, D.TenHe, E.TenNganh, F.Tenkhoa
	FROM SinhVien A, Lop B, KhoaHoc C, HeDaoTao D, NganhDaoTao E, Khoa F
	WHERE A.Lop = B.MaLop AND B.MaKhoaHoc = C.MaKhoaHoc AND B.MaHeDaoTao = D.MaHe
	AND B.MaNganh = E.MaNganh AND E.MaKhoa = F.MaKhoa
	AND (DATEDIFF(DD, GETDATE(), C.NgayKetThuc) > -365)
	AND A.MaSinhVien IN
	(SELECT A.MaSinhVien
	FROM (BangDiem A RIGHT JOIN 
		(SELECT B.MaMonHoc AS MA, MAX (B.DiemQuaTrinh*0.4 + B.DiemThi*0.6) AS DIEM , B.MaSinhVien FROM BangDiem B 
			WHERE MaSinhVien IN (SELECT MaSinhVien FROM SinhVien)
			GROUP BY B.MaMonHoc, B.MaSinhVien) 
			AS BANGTAM
			ON A.MaMonHoc = MA AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) = DIEM), MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) > 3.95 
	GROUP BY A.MaSinhVien
	HAVING SUM(B.SoTinChi) >= 130)
	ORDER BY A.TenSinhVien ASC;
--DANH SÁCH SINH VIÊN RA TRƯỜNG KHÔNG ĐƯỢC NHẬN BẰNG.
GO
CREATE PROC DanhSachSinhVienRaTruongKhongDuocNhanBang
AS
	SELECT A.MaSinhVien, A.TenSinhVien, A.GioiTinh, B.TenLop, C.MaKhoaHoc, D.TenHe, E.TenNganh, F.Tenkhoa
	FROM SinhVien A, Lop B, KhoaHoc C, HeDaoTao D, NganhDaoTao E, Khoa F
	WHERE A.Lop = B.MaLop AND B.MaKhoaHoc = C.MaKhoaHoc AND B.MaHeDaoTao = D.MaHe
	AND B.MaNganh = E.MaNganh AND E.MaKhoa = F.MaKhoa
	AND DATEDIFF(DD, GETDATE(), C.NgayKetThuc) <=0 AND DATEDIFF(DD, GETDATE(), C.NgayKetThuc) > -365
	AND A.MaSinhVien NOT IN
	(SELECT A.MaSinhVien
	FROM (BangDiem A RIGHT JOIN 
		(SELECT B.MaMonHoc AS MA, MAX (B.DiemQuaTrinh*0.4 + B.DiemThi*0.6) AS DIEM , B.MaSinhVien FROM BangDiem B 
			WHERE MaSinhVien IN (SELECT MaSinhVien FROM SinhVien)
			GROUP BY B.MaMonHoc, B.MaSinhVien) 
			AS BANGTAM
			ON A.MaMonHoc = MA AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) = DIEM), MonHoc B, DoiDiem C 
	WHERE A.MaMonHoc = B.MaMonHoc and C.DiemChu = 
	(CASE
		WHEN 3.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 4.95 THEN 'D'
		WHEN 4.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 5.45 THEN 'D+'
		WHEN 5.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.45 THEN 'C'
		WHEN 6.45 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 6.95 THEN 'C+'
		WHEN 6.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 7.95 THEN 'B'
		WHEN 7.95 <= (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) < 8.45 THEN 'B+'
		WHEN (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) >= 8.45 THEN 'A'
	END) AND (A.DiemQuaTrinh*0.4 + A.DiemThi*0.6) > 3.95 
	GROUP BY A.MaSinhVien
	HAVING SUM(B.SoTinChi) >= 130)
	ORDER BY A.TenSinhVien ASC;
--/*###=========================GIAO DIỆN KHÓA HỌC======================###*/
--LẤY RA DANH SÁCH CÁC KHÓA HỌC TRONG TRƯỜNG
GO
CREATE PROC DanhSach_ThongTin_KhoaHoc
AS
	SELECT MaKhoaHoc, NgayBatDau,NgayKetThuc 
	FROM KhoaHoc ORDER BY MaKhoaHoc DESC;
--THÊM KHÓA HỌC MỚI
GO
CREATE PROC ThemKhoaHoc
@MaKhoaHoc varchar(10),
@NgayBatDau datetime,
@NgayKetThuc datetime
AS
	INSERT INTO KhoaHoc VALUES (@MaKhoaHoc, @NgayBatDau, @NgayKetThuc); 
--CHỈNH SỬA KHÓA HỌC
GO
CREATE PROC ChinhSuaKhoaHoc
@MaKhoaHoc varchar(10),
@NgayBatDau datetime,
@NgayKetThuc datetime
AS
	UPDATE KhoaHoc SET NgayBatDau = @NgayBatDau, NgayKetThuc = @NgayKetThuc WHERE MaKhoaHoc = @MaKhoaHoc;
--XÓA KHÓA HỌC
GO
CREATE PROC XoaKhoaHoc
@MaKhoaHoc varchar(10)
AS
	DELETE FROM KhoaHoc WHERE MaKhoaHoc = @MaKhoaHoc;
--TÌM KIẾM KHÓA HỌC
GO
CREATE PROC TimKiemKhoaHoc
@MaKhoaHoc varchar(10)
AS
	SELECT * FROM KhoaHoc WHERE MaKhoaHoc LIKE '%'+@MaKhoaHoc+'%' ORDER BY MaKhoaHoc DESC;

--/*###=========================GIAO DIỆN MÔN HỌC======================###*/
--LẤY RA DANH SÁCH CÁC MÔN HỌC TRONG TRƯỜNG
GO
CREATE PROC DanhSachMonHocToanTruong
AS
	SELECT MaMonHoc, TenMonHoc, SoTinChi FROM MonHoc ORDER BY MaMonHoc ASC;
--XÓA MÔN HỌC THEO MÃ MÔN
GO
CREATE PROC XoaMonHoc
@MaMonHoc varchar(10)
AS
	DELETE FROM MonHoc WHERE MaMonHoc = @MaMonHoc;
--THÊM MÔN HỌC MỚI
GO
CREATE PROC ThemMonHoc
@MaMonHoc varchar(10),
@TenMonHoc nvarchar(50),
@SoTinChi int
AS
	INSERT INTO MonHoc(MaMonHoc, TenMonHoc, SoTinChi) VALUES (@MaMonHoc, @TenMonHoc, @SoTinChi);
--UPDATE MÔN HOC
GO
CREATE PROC SuaMonHoc
@MaMonHoc varchar(10),
@TenMonHoc nvarchar(50),
@SoTinChi int
AS
	UPDATE MonHoc SET TenMonHoc = @TenMonHoc, SoTinChi = @SoTinChi WHERE MaMonHoc = @MaMonHoc;
--TÌM KIẾM MÔN HỌC
GO
CREATE PROC TimMonHoc
@TimKiem nvarchar(50)
AS
	SELECT MaMonHoc, TenMonHoc, SoTinChi 
	FROM MonHoc WHERE MaMonHoc LIKE '%'+@TimKiem+'%' OR TenMonHoc LIKE '%'+@TimKiem+'%'
	OR SoTinChi LIKE '%'+@TimKiem+'%' ORDER BY MaMonHoc ASC;
--/*###=========================GIAO DIỆN HỌC KỲ======================###*/
--LẤY RA DANH SÁCH HỌC KỲ
GO
CREATE PROC DanhSachThongTinHocKy
AS
	SELECT MaHocKy, TenHocKy FROM HocKy ORDER BY MaHocKy DESC;
--XÓA HỌC KỲ
GO
CREATE PROC XoaHocKy
@MaHocKy varchar(10)
AS
	DELETE FROM HocKy WHERE MaHocKy = @MaHocKy;
--THÊM HỌC KỲ
GO
CREATE PROC ThemHocKy
@MaHocKy varchar(10),
@TenHocKy nvarchar(50)
AS
	INSERT INTO HocKy(MaHocKy, TenHocKy) VALUES (@MaHocKy, @TenHocKy);
--SỬA HỌC KỲ
GO
CREATE PROC SuaHocKy
@MaHocKy varchar(10),
@TenHocKy nvarchar(50)
AS
	UPDATE HocKy SET TenHocKy = @TenHocKy WHERE MaHocKy = @MaHocKy;
--TÌM KIẾM HỌC KỲ.
GO
CREATE PROC TimKiemHocKy
@TimKiem nvarchar(50)
AS
	SELECT MaHocKy, TenHocKy FROM HocKy
	WHERE MaHocKy LIKE '%'+@TimKiem+'%' OR TenHocKy LIKE '%'+@TimKiem+'%'
	ORDER BY MaHocKy DESC;
--/*###=========================GIAO DIỆN HỆ ĐÀO TẠO======================###*/
--XÓA HỆ ĐÀO TẠO
GO
CREATE PROC XoaHeDaoTao
@MaHe varchar(10)
AS
	DELETE FROM HeDaoTao WHERE MaHe = @MaHe;
--THÊM HỆ ĐÀO TẠO
GO
CREATE PROC ThemHeDaoTao
@MaHe varchar(10),
@TenHe nvarchar(50)
AS
	INSERT INTO HeDaoTao(MaHe, TenHe) VALUES (@MaHe, @TenHe);
--SỬA HỆ ĐÀO TẠO
GO
CREATE PROC SuaHeDaoTao
@MaHe varchar(10),
@TenHe nvarchar(50)
AS
	UPDATE HeDaoTao SET TenHe = @TenHe WHERE MaHe = @MaHe;
--TÌM KIẾM HỆ ĐÀO TẠO
GO
CREATE PROC TimKiemHeDaoTao
@TimKiem nvarchar(50)
AS
	SELECT MaHe, TenHe FROM HeDaoTao WHERE MaHe LIKE '%'+@TimKiem+'%' OR TenHe LIKE '%'+@TimKiem+'%';
--/*###=========================GIAO DIỆN KHOA======================###*/
--XÓA KHOA
GO
CREATE PROC XoaKhoa
@MaKhoa varchar(10)
AS
	DELETE FROM Khoa WHERE MaKhoa = @MaKhoa;
--THÊM KHOA
GO
CREATE PROC ThemKhoa
@MaKhoa varchar(10),
@TenKhoa nvarchar(50)
AS
	INSERT INTO Khoa(MaKhoa, Tenkhoa) VALUES (@MaKhoa, @TenKhoa);
--SỬA KHOA
GO
CREATE PROC SuaKhoa
@MaKhoa varchar(10),
@TenKhoa nvarchar(50)
AS
	UPDATE Khoa SET Tenkhoa = @TenKhoa WHERE MaKhoa = @MaKhoa;
--TÌM KIẾM KHOA
GO
CREATE PROC TimKiemKhoa
@TimKiem nvarchar(50)
AS
	SELECT MaKhoa, Tenkhoa FROM Khoa WHERE MaKhoa LIKE '%'+@TimKiem+'%' OR Tenkhoa LIKE '%'+@TimKiem+'%';
--/*###=========================GIAO DIỆN NGÀNH ĐÀO TẠO======================###*/
--DANH SÁCH NGÀNH ĐÀO TẠO
GO
CREATE PROC DanhSachThongTinNganhDaoTao
AS
	SELECT A.MaNganh, A.TenNganh, B.Tenkhoa FROM NganhDaoTao A, Khoa B
	WHERE A.MaKhoa = B.MaKhoa
	ORDER BY TenNganh ASC;
--XÓA NGÀNH ĐÀO TẠO
GO
CREATE PROC XoaNganhDaoTao
@MaNganh varchar(10)
AS
	DELETE FROM NganhDaoTao WHERE MaNganh = @MaNganh;
--THÊM NGÀNH ĐÀO TẠO
GO
CREATE PROC ThemNganhDaoTao
@MaNganh varchar(10),
@TenNganh nvarchar(50),
@MaKhoa varchar(10)
AS
	INSERT INTO NganhDaoTao(MaNganh, TenNganh, MaKhoa) VALUES (@MaNganh, @TenNganh, @MaKhoa);
--SỬA NGÀNH ĐÀO TẠO.
GO
CREATE PROC SuaNganhDaoTao
@MaNganh varchar(10),
@TenNganh nvarchar(50),
@MaKhoa varchar(10)
AS
	UPDATE NganhDaoTao SET TenNganh = @TenNganh, MaKhoa = @MaKhoa
	WHERE MaNganh = @MaNganh;
--TÌM KIẾM NGÀNH ĐÀO TẠO.
GO
CREATE PROC TimKiemThongTinNganhDaoTao
@TimKiem nvarchar(50)
AS
	SELECT A.MaNganh, A.TenNganh, B.Tenkhoa FROM NganhDaoTao A, Khoa B
	WHERE A.MaKhoa = B.MaKhoa AND (A.TenNganh LIKE '%'+@TimKiem+'%' OR A.MaNganh LIKE '%'+@TimKiem+'%' 
	OR A.MaKhoa LIKE '%'+@TimKiem+'%')
	ORDER BY TenNganh ASC;
--/*###=========================GIAO DIỆN ĐĂNG NHẬP======================###*/
--KIỂM TRA ĐĂNG NHẬP.
GO
CREATE PROC KiemTraDangNhap
@TaiKhoan varchar(30),
@MatKhau varchar(30)
AS
	SELECT Quyen FROM ThongTinDanhNhap WHERE TaiKhoan = @TaiKhoan AND MatKhau = @MatKhau;
--UPDATE TRẠNG THÁI.
GO
CREATE PROC UpDateTrangThai
@TaiKhoan varchar(30),
@TrangThai bit
AS
	UPDATE ThongTinDanhNhap SET TrangThai = @TrangThai
	WHERE TaiKhoan = @TaiKhoan;
--UPDATE MẬT KHẨU
GO
CREATE PROC UpDateMatKhau
@TaiKhoan varchar(30),
@MatKhau varchar(30)
AS
	UPDATE ThongTinDanhNhap SET MatKhau = @MatKhau
	WHERE TaiKhoan = @TaiKhoan;
--THÊM TÀI KHOẢN
GO
CREATE PROC ThemTaiKhoan
@TaiKhoan varchar(30),
@Quyen nvarchar(30)
AS
	INSERT INTO ThongTinDanhNhap(TaiKhoan, MatKhau, Quyen, TrangThai) 
	VALUES (@TaiKhoan, 'DHXD', @Quyen, '0');
--CHỈNH SỬA QUYỀN
GO
CREATE PROC ChinhSuaQuyen
@TaiKhoan varchar(30),
@Quyen nvarchar(30)
AS
	UPDATE ThongTinDanhNhap SET Quyen = @Quyen
	WHERE TaiKhoan = @TaiKhoan;
--XÓA TÀI KHOẢN
GO
CREATE PROC XoaTaiKhoan
@TaiKhoan varchar(30)
AS
	DELETE FROM ThongTinDanhNhap WHERE TaiKhoan = @TaiKhoan;
--TÌM KIẾM TÀI KHOẢN
GO
CREATE PROC TimKiemTaiKhoan
@TimKiem nvarchar(30)
AS
	SELECT TaiKhoan, Quyen, TrangThai FROM ThongTinDanhNhap
	WHERE TaiKhoan LIKE '%'+@TimKiem+'%' OR Quyen LIKE '%'+@TimKiem+'%' OR TrangThai LIKE '%'+@TimKiem+'%'
	ORDER BY TaiKhoan ASC;
--DANH SÁCH TÀI KHOẢN
GO
CREATE PROC DanhSachTaiKhoan
AS
	SELECT TaiKhoan, Quyen, TrangThai FROM ThongTinDanhNhap ORDER BY TaiKhoan ASC;
--DANH SÁCH QUYỀN
GO
CREATE PROC DanhSachQuyen
AS
	SELECT DISTINCT Quyen FROM ThongTinDanhNhap ORDER BY Quyen ASC;
--//##======================IN BÁO CÁO======================##//--
--LẤY RA TOÀN BỘ KẾT QUẢ HỌC TẬP CỦA SINH VIÊN.