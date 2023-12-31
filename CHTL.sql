use master
go
Create database QL_CUA_HANG_TIEN_LOI
go
USE QL_CUA_HANG_TIEN_LOI
GO
/****** Object:  Table [dbo].[CHITIETHOADON]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHITIETHOADON](
	[MAHD] [int] NULL,
	[MAHH] [char](20) NULL,
	[SOLUONG] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CHUCVU]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHUCVU](
	[MACHUCVU] [char](10) NOT NULL,
	[HESOLUONG] [float] NULL,
	[TENCHUCVU] [nvarchar](20) NULL,
 CONSTRAINT [PK_CHUCVU_MACV] PRIMARY KEY CLUSTERED 
(
	[MACHUCVU] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HANGHOA]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HANGHOA](
	[MAHH] [char](20) NOT NULL,
	[TENHH] [nvarchar](60) NULL,
	[MALOAISP] [char](10) NULL,
	[NGAYSX] [date] NULL,
	[HSD] [nvarchar](40) NULL,
	[NCC] [nvarchar](50) NULL,
	[GIA] [real] NULL,
	[DVT] [nvarchar](40) NULL,
 CONSTRAINT [PK_HANGHOA] PRIMARY KEY CLUSTERED 
(
	[MAHH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[HOADON]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HOADON](
	[MAHD] [int] IDENTITY(1,1) NOT NULL,
	[MAKH] [char](10) NULL,
	[MANV] [char](10) NULL,
	[NGAYXUATHD] [datetime] NULL,
	[TONGTIEN] [real] NULL,
	[TIENKHACHDUA] [real] NULL,
	[TIENTHOILAI] [real] NULL,
	[TinhTrang] [nchar](20) NULL,
 CONSTRAINT [PK_HOADON] PRIMARY KEY CLUSTERED 
(
	[MAHD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[KHACHHANG]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KHACHHANG](
	[MAKH] [char](10) NOT NULL,
	[TENKH] [nvarchar](50) NULL,
	[DIACHI] [nvarchar](max) NULL,
	[SDT] [char](10) NULL,
	[LOAIKH] [nvarchar](20) NULL,
 CONSTRAINT [PK_KHACHHANG] PRIMARY KEY CLUSTERED 
(
	[MAKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAIKH]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAIKH](
	[LOAIKH] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_LOAIKHACH] PRIMARY KEY CLUSTERED 
(
	[LOAIKH] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAINV]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAINV](
	[MALOAINV] [char](10) NOT NULL,
	[TENLOAINV] [nvarchar](40) NULL,
 CONSTRAINT [PK_LOAINV] PRIMARY KEY CLUSTERED 
(
	[MALOAINV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAISANPHAM]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAISANPHAM](
	[MALOAISP] [char](10) NOT NULL,
	[TENLOAISP] [nvarchar](40) NULL,
 CONSTRAINT [PK_LOAISANPHAM] PRIMARY KEY CLUSTERED 
(
	[MALOAISP] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LOAITAIKHOAN]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LOAITAIKHOAN](
	[LOAI] [int] NOT NULL,
	[TENLOAI] [nvarchar](40) NULL,
 CONSTRAINT [PK_LOAITAKHOAN] PRIMARY KEY CLUSTERED 
(
	[LOAI] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NHANVIEN]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NHANVIEN](
	[MANV] [char](10) NOT NULL,
	[TEN] [nvarchar](50) NOT NULL,
	[CCCD] [char](12) NOT NULL,
	[GIOITINH] [nvarchar](5) NULL,
	[STK] [nvarchar](20) NULL,
	[TENNGANHANG] [nvarchar](50) NULL,
	[NGAYSINH] [date] NULL,
	[NGAYVAOLAM] [date] NULL,
	[HINHANH] [char](20) NULL,
	[MACHUCVU] [char](10) NULL,
	[MALOAINV] [char](10) NULL,
 CONSTRAINT [PK_NHANVIEN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TAIKHOAN]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TAIKHOAN](
	[MANV] [char](10) NOT NULL,
	[MATKHAU] [char](129) NULL,
	[LOAI] [int] NULL,
 CONSTRAINT [PK_TAIKHOAN] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[THUONG]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[THUONG](
	[MANV] [char](10) NOT NULL,
	[LYDOTHUONG] [nvarchar](50) NULL,
	[SOTIENTHUONG] [real] NULL,
	[SOGIOLAM] [int] NULL,
 CONSTRAINT [PK_THUONG] PRIMARY KEY CLUSTERED 
(
	[MANV] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TONKHO]    Script Date: 05.01.2023 1:11 SA ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TONKHO](
	[MAKHO] [char](10) NULL,
	[TENKHO] [nvarchar](30) NULL,
	[MAHH] [char](20) NULL,
	[SOLUONGTON] [int] NULL
) ON [PRIMARY]
GO
INSERT [dbo].[CHUCVU] ([MACHUCVU], [HESOLUONG], [TENCHUCVU]) VALUES (N'GD        ', 4, N'Giám Đốc')
INSERT [dbo].[CHUCVU] ([MACHUCVU], [HESOLUONG], [TENCHUCVU]) VALUES (N'KK        ', 2.7, N'Kiểm kho')
INSERT [dbo].[CHUCVU] ([MACHUCVU], [HESOLUONG], [TENCHUCVU]) VALUES (N'KT        ', 2.6, N'Kế Toán')
INSERT [dbo].[CHUCVU] ([MACHUCVU], [HESOLUONG], [TENCHUCVU]) VALUES (N'NV        ', 2.3, N'Nhân viên')
INSERT [dbo].[CHUCVU] ([MACHUCVU], [HESOLUONG], [TENCHUCVU]) VALUES (N'PGD       ', 3.8, N'Phó Giám Đốc')
INSERT [dbo].[CHUCVU] ([MACHUCVU], [HESOLUONG], [TENCHUCVU]) VALUES (N'TK        ', 2.5, N'Thư Ký')
GO
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'3073780808125       ', N'Phô Mai Bò Cười Tí Hon 140g T12', N'ML02      ', CAST(N'2023-06-26' AS Date), N'6 Tháng', N'CN CÔNG TY CP TM&DV SX HƯƠNG THỦY', 45000, N'Túi')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'3073781087567       ', N'Phô Mai Bò Cười 8M 120g T36', N'ML02      ', CAST(N'2023-04-29' AS Date), N'6 Tháng', N'CN CÔNG TY CP TM&DV SX HƯƠNG THỦY', 28200, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'4000436501351       ', N'Phomai Lát Edam 150g*10', N'ML02      ', CAST(N'2023-05-07' AS Date), N'12 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 62500, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'4000436504796       ', N'Phomai Lát Gouda 150g*10', N'ML02      ', CAST(N'2023-08-27' AS Date), N'12 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 62500, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'4000436509180       ', N'Phomai Lát Swiss 150g*10', N'ML02      ', CAST(N'2023-07-22' AS Date), N'12 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 62500, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8769828120313       ', N'Kem cây Melona Banana 80ml T64', N'ML01      ', CAST(N'2023-06-22' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 18500, N'Cây')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8801104122504       ', N'Kem cây Melona vị dưa lưới 80ml T40', N'ML01      ', CAST(N'2023-10-12' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 18500, N'Cây')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8801104170116       ', N'Kem Cá Melona Ice Waffle vị socola 150ml T24', N'ML01      ', CAST(N'2022-12-25' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 22500, N'Cái')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8801104180115       ', N'Kem Cá Melona Ice Waffle vị dâu 150ml T24', N'ML01      ', CAST(N'2022-12-24' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 22500, N'Cái')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8801104190718       ', N'Kem cá Ice Sanwich 150ml T24', N'ML01      ', CAST(N'2022-12-23' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 22500, N'Cái')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8801104900034       ', N'Kem cây Melona vị dâu 80ml T64', N'ML01      ', CAST(N'2023-11-23' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 18500, N'Cây')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8801104900058       ', N'Kem cây Melona vị xoài 80ml T64', N'ML01      ', CAST(N'2023-07-03' AS Date), N'3 Tháng', N'CÔNG TY CỔ PHẦN ĐẠI THUẬN', 18500, N'Cây')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8850393800013       ', N'Sữa Uống Lên Men Betagen Tự Nhiên 140ml', N'ML02      ', CAST(N'2023-04-05' AS Date), N'6 Tháng ', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 9500, N'Chai')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8850393800020       ', N'Sữa Uống Lên Men Betagen Cam 140ml', N'ML02      ', CAST(N'2023-06-23' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 9500, N'Chai')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8850393800426       ', N'Sữa Uống Lên Men Betagen Không Béo 140ml', N'ML02      ', CAST(N'2023-07-25' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 9500, N'Chai')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673090926       ', N'Kem Đậu Xanh Vinamilk 100ML T2', N'ML01      ', CAST(N'2022-09-04' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 7200, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673092920       ', N'Kem Hương Dâu Vinamilk 100ML T24', N'ML01      ', CAST(N'2023-09-07' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 7200, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673093927       ', N'Kem Hương Sầu Riêng Vinamilk 100ML T24', N'ML01      ', CAST(N'2023-09-08' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 7200, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673096928       ', N'Kem Dứa Vinamilk 100ML T24', N'ML01      ', CAST(N'2023-09-06' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 7200, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673099929       ', N'Kem Socola Vinamilk 100ML T24', N'ML01      ', CAST(N'2023-07-05' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 7200, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673573320       ', N'Sữa Tươi Tiệt Trùng Có Đường Vinamilk 110ml Lốc 4 T12', N'ML02      ', CAST(N'2023-09-22' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 17600, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673573344       ', N'Sữa Tươi Tiệt Trùng Có Đường Vinamilk 180ml Lốc 4 T12', N'ML02      ', CAST(N'2023-07-21' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 28000, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673573399       ', N'Sữa Tươi Tiệt Trùng Có Đường Vinamilk 1L T12', N'ML02      ', CAST(N'2023-09-23' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 29800, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673581349       ', N'Sữa Tươi Tiệt Trùng Ít Đường Vinamilk 180ml Lốc 4 T12', N'ML02      ', CAST(N'2023-06-23' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 28000, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673601825       ', N'Sữa Chua Nha Đam Vinamilk 100g', N'ML02      ', CAST(N'2023-09-30' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 24900, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673604826       ', N'Sữa Chua Có Đường Probi 100g', N'ML02      ', CAST(N'2023-04-24' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 23200, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673605823       ', N'Sữa Chua không Đường Vinamilk Hộp 100g', N'ML02      ', CAST(N'2023-08-09' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 24500, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673606813       ', N'Sữa Chua Có Đường Susu 80g ', N'ML02      ', CAST(N'2023-06-12' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 24200, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673606820       ', N'Sữa Chua Có Đường Vinamilk 100g ', N'ML02      ', CAST(N'2023-05-23' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 24500, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673609821       ', N'Sữa Chua Việt Quất Probeaty 100g', N'ML02      ', CAST(N'2023-06-08' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 30000, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673613828       ', N'Sữa Chua Ít Đường Vinamilk 100g', N'ML02      ', CAST(N'2023-09-08' AS Date), N'6 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 24500, N'Lốc 4')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673700825       ', N'Kem VaniI Vinamilk 100ML T24', N'ML01      ', CAST(N'2023-07-06' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 7200, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673717700       ', N'Kem Đậu Xanh Vinamilk Que 60ML', N'ML01      ', CAST(N'2023-07-06' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 6500, N'Que')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673718707       ', N'Kem Dâu Vinamilk Que 60ML ', N'ML01      ', CAST(N'2023-06-08' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 6500, N'Que')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673720700       ', N'Kem Socola 2X Vinamilk Que 60ML', N'ML01      ', CAST(N'2023-07-08' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 6500, N'Que')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673721707       ', N'Kem Sầu Riêng Vinamilk Que 60ML', N'ML01      ', CAST(N'2023-06-07' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 6500, N'Que')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934673723701       ', N'Kem Khoai Môn Dứa Vinamilk Que 60ML', N'ML01      ', CAST(N'2023-09-04' AS Date), N'3 Tháng', N'CÔNG TY TNHH PHÂN PHỐI KHÁNH CHI (VINAMILK)', 6500, N'Que')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934804025742       ', N'Milo nước 4x115ml T12', N'ML02      ', CAST(N'2023-07-14' AS Date), N'6 Tháng', N'CÔNG TY TNHH&CBTP MINH DƯƠNG (NESTLE)', 18000, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934804025766       ', N'Milo nước 4x180ml T12', N'ML02      ', CAST(N'2023-02-02' AS Date), N'6 Tháng', N'CÔNG TY TNHH&CBTP MINH DƯƠNG (NESTLE)', 26000, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8934804027784       ', N'Milo UHT lon 24*240ml  T24', N'ML02      ', CAST(N'2023-08-24' AS Date), N'6 Tháng', N'CÔNG TY TNHH&CBTP MINH DƯƠNG (NESTLE)', 12500, N'Lon')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8935217400058       ', N'Sữa Tươi Tiệt Trùng Nguyên Chất TH True Milk 180ml T12', N'ML02      ', CAST(N'2023-09-23' AS Date), N'6 Tháng', N'CÔNG TY CP CHUỖI THỰC PHẨM TH', 30600, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8935217400164       ', N'Sữa Tươi Tiệt Trùng Có Đường TH True Milk 110ml T12', N'ML02      ', CAST(N'2023-08-13' AS Date), N'6 Tháng', N'CÔNG TY CP CHUỖI THỰC PHẨM TH', 20000, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8935217400362       ', N'Sữa Tươi Tiệt Trùng Ít Đường TH True Milk 110ml T12', N'ML02      ', CAST(N'2023-08-23' AS Date), N'6 Tháng', N'CÔNG TY CP CHUỖI THỰC PHẨM TH', 20000, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011771313       ', N'Kem Ly Celano-Dâu  65g Ly T12', N'ML01      ', CAST(N'2022-08-22' AS Date), N'3 Tháng', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 21600, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011771320       ', N'Kem Ly Celano-Macadamia  65g Ly T12', N'ML01      ', CAST(N'2023-08-02' AS Date), N'3 Tháng', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 21600, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011771337       ', N'Kem Ly Celano- Nam Việt Quất  65g Ly T12', N'ML01      ', CAST(N'2023-09-09' AS Date), N'3 Tháng', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 21600, N'Ly')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011771603       ', N'Kem Viên Cao Cấp Celano Sweetie – Vani 45g Gói T20', N'ML01      ', CAST(N'2023-11-23' AS Date), N'3 Tháng', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 11800, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011771610       ', N'Kem Viên Cao Cấp Celano Sweetie – Sô cô la  45g Gói T20', N'ML01      ', CAST(N'2023-10-23' AS Date), N'3 Tháng', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 11800, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011771696       ', N'Kem Viên Cao Cấp Celano Sweetie – Sô cô la  45g Gói T20', N'ML01      ', CAST(N'2023-11-11' AS Date), N'3 Tháng', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 11800, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011776707       ', N'Kem Hộp Celano-Socola 265g', N'ML01      ', CAST(N'2023-07-23' AS Date), N'1 Năm', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 58400, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011776714       ', N'Kem Hộp Celano-Dâu 265g', N'ML01      ', CAST(N'2023-08-22' AS Date), N'1 Năm', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 58400, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011776721       ', N'Kem Hộp Celano-Macadamia 500ml', N'ML01      ', CAST(N'2023-07-06' AS Date), N'1 Năm', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 58400, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011776738       ', N'Kem Hộp Celano-Nam Việt Quất 500ml', N'ML01      ', CAST(N'2022-07-29' AS Date), N'1 Năm', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 58400, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936011776851       ', N'Kem Hộp Celano - Matcha 265g', N'ML01      ', CAST(N'2023-06-29' AS Date), N'1 Năm', N'CÔNG TY CP THỰC PHẨM ĐÔNG LẠNH KIDO', 58400, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936025770685       ', N'Sữa Chua Ba vì 100g Có đường T48 ', N'ML02      ', CAST(N'2023-09-23' AS Date), N'6 Tháng', N'CÔNG TY CỔ PHẦN SỮA QUỐC TẾ', 21200, N'Vỉ')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936026265012       ', N'Sữa Uống Lên Men Betagen Dâu 85ml', N'ML02      ', CAST(N'2023-12-22' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 21800, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936026265029       ', N'Sữa Uống Lên Men Betagen Không Béo 85ml', N'ML02      ', CAST(N'2023-07-22' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 21800, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936026265036       ', N'Sữa Uống Lên Men Betagen Dứa 85ml', N'ML02      ', CAST(N'2023-07-08' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 21800, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936026265043       ', N'Sữa Uống Lên Men Betagen Tự Nhiên 85ml', N'ML02      ', CAST(N'2023-05-24' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 21800, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936026265050       ', N'Sữa Uống Lên Men Betagen Cam  85ml', N'ML02      ', CAST(N'2023-11-29' AS Date), N'6 Tháng', N'CÔNG TY TNHH BETAGEN VIỆT NAM', 21800, N'Lốc')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936044530581       ', N'Phomat Gouda Cắt 200g', N'ML02      ', CAST(N'2023-07-30' AS Date), N'12 Tháng', N'CTY TNHH TM HOÀNG LÊ', 68700, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936044530604       ', N'Phomai Mozarella Cắt 200g', N'ML02      ', CAST(N'2023-05-23' AS Date), N'12 Tháng', N'CTY TNHH TM HOÀNG LÊ', 55000, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8936044530611       ', N'Phomat  Cheddar Cắt 200g', N'ML02      ', CAST(N'2023-08-21' AS Date), N'12 Tháng', N'CTY TNHH TM HOÀNG LÊ', 60500, N'Gói')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8938503131032       ', N'Sữa Tươi Thanh Trùng Đà Lạt 180ml', N'ML02      ', CAST(N'2023-09-03' AS Date), N'6 Tháng', N'CÔNG TY CỔ PHẦN SỮA ĐÀ LẠT', 12500, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8938503131049       ', N'Sữa Tươi Thanh Trùng Đà Lạt Có Đường 180ml', N'ML02      ', CAST(N'2023-03-23' AS Date), N'6 Tháng', N'CÔNG TY CỔ PHẦN SỮA ĐÀ LẠT', 12500, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8938503131056       ', N'Sữa Tươi Thanh Trùng Đà Lạt Hương Dâu 180ml', N'ML02      ', CAST(N'2023-04-22' AS Date), N'6 Tháng', N'CÔNG TY CỔ PHẦN SỮA ĐÀ LẠT', 12500, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8938503131063       ', N'Sữa Tươi Thanh Trùng Đà Lạt Có Đường 450ml', N'ML02      ', CAST(N'2023-08-20' AS Date), N'6 Tháng', N'CÔNG TY CỔ PHẦN SỮA ĐÀ LẠT', 23500, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8938503131087       ', N'Sữa Tươi Thanh Trùng Đà Lạt Hương Sôcôla 180ml', N'ML02      ', CAST(N'2023-06-23' AS Date), N'6 Tháng', N'CÔNG TY CỔ PHẦN SỮA ĐÀ LẠT', 12500, N'Hộp')
INSERT [dbo].[HANGHOA] ([MAHH], [TENHH], [MALOAISP], [NGAYSX], [HSD], [NCC], [GIA], [DVT]) VALUES (N'8938504344042       ', N'Phô Mai Bò Cười 4M 60g T54', N'ML02      ', CAST(N'2023-07-28' AS Date), N'6 Tháng', N'CN CÔNG TY CP TM&DV SX HƯƠNG THỦY', 14500, N'Hộp')
GO
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [DIACHI], [SDT], [LOAIKH]) VALUES (N'0         ', N'Không xác định', N'Chưa xác định', N'0         ', NULL)
INSERT [dbo].[KHACHHANG] ([MAKH], [TENKH], [DIACHI], [SDT], [LOAIKH]) VALUES (N'033       ', N'Trung', N'SG', N'033       ', N'Thân thiết')
GO
INSERT [dbo].[LOAIKH] ([LOAIKH]) VALUES (N'Thân thiết')
INSERT [dbo].[LOAIKH] ([LOAIKH]) VALUES (N'Thường')
INSERT [dbo].[LOAIKH] ([LOAIKH]) VALUES (N'VIP')
GO
INSERT [dbo].[LOAINV] ([MALOAINV], [TENLOAINV]) VALUES (N'1         ', N'Nhân viên thời vụ')
INSERT [dbo].[LOAINV] ([MALOAINV], [TENLOAINV]) VALUES (N'2         ', N'Nhân viên chính thức')
GO
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAISP]) VALUES (N'ML01      ', N'Kem')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAISP]) VALUES (N'ML02      ', N'Sữa')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAISP]) VALUES (N'ML03      ', N'Nước Giải Khát')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAISP]) VALUES (N'ML04      ', N'Bia-Rượu')
INSERT [dbo].[LOAISANPHAM] ([MALOAISP], [TENLOAISP]) VALUES (N'ML05      ', N'Thực Phẩm Khô')
GO
INSERT [dbo].[LOAITAIKHOAN] ([LOAI], [TENLOAI]) VALUES (0, N'Quản trị')
INSERT [dbo].[LOAITAIKHOAN] ([LOAI], [TENLOAI]) VALUES (1, N'Thường')
GO
INSERT [dbo].[NHANVIEN] ([MANV], [TEN], [CCCD], [GIOITINH], [STK], [TENNGANHANG], [NGAYSINH], [NGAYVAOLAM], [HINHANH], [MACHUCVU], [MALOAINV]) VALUES (N'NV001     ', N'Admin', N'0000        ', N'Nam', N'012345855', N'Vietcombank', CAST(N'1993-09-24' AS Date), CAST(N'2016-01-20' AS Date), NULL, N'GD        ', N'2         ')
INSERT [dbo].[NHANVIEN] ([MANV], [TEN], [CCCD], [GIOITINH], [STK], [TENNGANHANG], [NGAYSINH], [NGAYVAOLAM], [HINHANH], [MACHUCVU], [MALOAINV]) VALUES (N'NV002     ', N'Người được chọn', N'516565      ', N'Nam', N'65412', N'Vietcombank', CAST(N'1993-09-24' AS Date), CAST(N'2016-01-22' AS Date), N'                    ', N'NV        ', N'1         ')
GO
INSERT [dbo].[TAIKHOAN] ([MANV], [MATKHAU], [LOAI]) VALUES (N'NV001     ', N'1                                                                                                                                ', 0)
INSERT [dbo].[TAIKHOAN] ([MANV], [MATKHAU], [LOAI]) VALUES (N'NV002     ', N'tcMkC+NbLg5SrBzkBSYivX53MffMCbk4af/oXtpnO10=                                                                                     ', 1)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__NHANVIEN__A955A0AA421224D8]    Script Date: 05.01.2023 1:11 SA ******/
ALTER TABLE [dbo].[NHANVIEN] ADD UNIQUE NONCLUSTERED 
(
	[CCCD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[HOADON] ADD  DEFAULT (N'Chưa thanh toán') FOR [TinhTrang]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT (N'Chưa xác định') FOR [DIACHI]
GO
ALTER TABLE [dbo].[KHACHHANG] ADD  DEFAULT (N'Chưa xác định') FOR [SDT]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT (N'Chưa xác định') FOR [STK]
GO
ALTER TABLE [dbo].[NHANVIEN] ADD  DEFAULT (N'Chưa xác định') FOR [TENNGANHANG]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_MAHD] FOREIGN KEY([MAHD])
REFERENCES [dbo].[HOADON] ([MAHD])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_MAHD]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [FK_CHITIETHOADON_MAHH] FOREIGN KEY([MAHH])
REFERENCES [dbo].[HANGHOA] ([MAHH])
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [FK_CHITIETHOADON_MAHH]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [FK_HANGHOA_MALOAISP] FOREIGN KEY([MALOAISP])
REFERENCES [dbo].[LOAISANPHAM] ([MALOAISP])
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [FK_HANGHOA_MALOAISP]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_KH] FOREIGN KEY([MAKH])
REFERENCES [dbo].[KHACHHANG] ([MAKH])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_KH]
GO
ALTER TABLE [dbo].[HOADON]  WITH CHECK ADD  CONSTRAINT [FK_HOADON_NV] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[HOADON] CHECK CONSTRAINT [FK_HOADON_NV]
GO
ALTER TABLE [dbo].[KHACHHANG]  WITH CHECK ADD  CONSTRAINT [FK_KHACHHANG_LOAIKH] FOREIGN KEY([LOAIKH])
REFERENCES [dbo].[LOAIKH] ([LOAIKH])
GO
ALTER TABLE [dbo].[KHACHHANG] CHECK CONSTRAINT [FK_KHACHHANG_LOAIKH]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_MACHUCVU] FOREIGN KEY([MACHUCVU])
REFERENCES [dbo].[CHUCVU] ([MACHUCVU])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_MACHUCVU]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [FK_NHANVIEN_TENLOAINV] FOREIGN KEY([MALOAINV])
REFERENCES [dbo].[LOAINV] ([MALOAINV])
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [FK_NHANVIEN_TENLOAINV]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN]
GO
ALTER TABLE [dbo].[TAIKHOAN]  WITH CHECK ADD  CONSTRAINT [FK_TAIKHOAN_LOAITK] FOREIGN KEY([LOAI])
REFERENCES [dbo].[LOAITAIKHOAN] ([LOAI])
GO
ALTER TABLE [dbo].[TAIKHOAN] CHECK CONSTRAINT [FK_TAIKHOAN_LOAITK]
GO
ALTER TABLE [dbo].[THUONG]  WITH CHECK ADD  CONSTRAINT [FK_THUONG_MANV] FOREIGN KEY([MANV])
REFERENCES [dbo].[NHANVIEN] ([MANV])
GO
ALTER TABLE [dbo].[THUONG] CHECK CONSTRAINT [FK_THUONG_MANV]
GO
ALTER TABLE [dbo].[TONKHO]  WITH CHECK ADD  CONSTRAINT [FK_TONKHO_MAHH] FOREIGN KEY([MAHH])
REFERENCES [dbo].[HANGHOA] ([MAHH])
GO
ALTER TABLE [dbo].[TONKHO] CHECK CONSTRAINT [FK_TONKHO_MAHH]
GO
ALTER TABLE [dbo].[CHITIETHOADON]  WITH CHECK ADD  CONSTRAINT [CHK_SOLUONG] CHECK  (([SOLUONG]>(0)))
GO
ALTER TABLE [dbo].[CHITIETHOADON] CHECK CONSTRAINT [CHK_SOLUONG]
GO
ALTER TABLE [dbo].[CHUCVU]  WITH CHECK ADD  CONSTRAINT [CHK_HESOLUONG] CHECK  (([HESOLUONG]>(0) AND [HESOLUONG]<=(4)))
GO
ALTER TABLE [dbo].[CHUCVU] CHECK CONSTRAINT [CHK_HESOLUONG]
GO
ALTER TABLE [dbo].[HANGHOA]  WITH CHECK ADD  CONSTRAINT [CHK_GIA] CHECK  (([GIA]>(0)))
GO
ALTER TABLE [dbo].[HANGHOA] CHECK CONSTRAINT [CHK_GIA]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [CHK_MANV] CHECK  (([MANV] like 'NV_%'))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [CHK_MANV]
GO
ALTER TABLE [dbo].[NHANVIEN]  WITH CHECK ADD  CONSTRAINT [CHK_NGAYSINH] CHECK  (((datepart(year,getdate())-datepart(year,[NGAYSINH]))>=(18)))
GO
ALTER TABLE [dbo].[NHANVIEN] CHECK CONSTRAINT [CHK_NGAYSINH]
GO
ALTER TABLE [dbo].[THUONG]  WITH CHECK ADD  CONSTRAINT [CHK_SOGIOLAM] CHECK  (([SOGIOLAM]>(0)))
GO
ALTER TABLE [dbo].[THUONG] CHECK CONSTRAINT [CHK_SOGIOLAM]
GO
ALTER TABLE [dbo].[TONKHO]  WITH CHECK ADD  CONSTRAINT [CHK_SOLUONGTON] CHECK  (([SOLUONGTON]>(0)))
GO
ALTER TABLE [dbo].[TONKHO] CHECK CONSTRAINT [CHK_SOLUONGTON]
GO
