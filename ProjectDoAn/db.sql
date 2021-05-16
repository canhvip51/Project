USE [TBPCCC]
GO
/****** Object:  Table [dbo].[CauHinh]    Script Date: 5/21/2018 2:16:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CauHinh](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenCauHinh] [nvarchar](250) NOT NULL,
	[Giatri] [ntext] NOT NULL,
 CONSTRAINT [PK_CauHinh] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[DanhMucSanPham]    Script Date: 5/21/2018 2:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DanhMucSanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenDanhMuc] [nvarchar](250) NOT NULL,
	[TenUrl] [nvarchar](250) NOT NULL,
	[MoTa] [nvarchar](550) NULL,
	[IdDanhMuc] [int] NULL,
	[STT] [int] NOT NULL,
 CONSTRAINT [PK_DanhMuc] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HinhAnhSanPham]    Script Date: 5/21/2018 2:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HinhAnhSanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenFile] [nvarchar](250) NOT NULL,
	[NgayTao] [datetime] NOT NULL,
	[IdSanPham] [int] NOT NULL,
	[Active] [int] NOT NULL,
 CONSTRAINT [PK_HinhAnhSanPham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 5/21/2018 2:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](250) NOT NULL,
	[IdDanhMuc] [int] NOT NULL,
	[IdThuongHieu] [int] NOT NULL,
	[Mota] [ntext] NULL,
	[GiaSanPham] [int] NOT NULL,
	[Model] [nvarchar](50) NOT NULL,
	[ChatLieu] [nvarchar](250) NOT NULL,
	[HuongDanBaoQuan] [ntext] NULL,
	[HuongDanSudung] [ntext] NULL,
	[TenUrl] [nvarchar](50) NOT NULL,
	[TenFileImage] [nvarchar](250) NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Slider]    Script Date: 5/21/2018 2:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Slider](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenFile] [nvarchar](250) NOT NULL,
	[TenUrl] [nvarchar](250) NOT NULL,
	[Mota] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_Slider] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ThuongHieu]    Script Date: 5/21/2018 2:16:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ThuongHieu](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TenThuongHieu] [nvarchar](250) NOT NULL,
	[MoTa] [nvarchar](550) NULL,
	[XuatXuThuongHieu] [nvarchar](250) NOT NULL,
	[SanXuatTai] [nvarchar](250) NOT NULL,
 CONSTRAINT [PK_ThuongHieu] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[CauHinh] ON 

INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (1, N'Description', N'...')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (2, N'Keywords', N'...')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (4, N'Author', N'....')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (5, N'Map', N'...')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (6, N'MailContact', N'...')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (7, N'UserNameMail', N'...')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (9, N'PasswordMail', N'...')
INSERT [dbo].[CauHinh] ([Id], [TenCauHinh], [Giatri]) VALUES (16, N'a', N'a')
SET IDENTITY_INSERT [dbo].[CauHinh] OFF
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] ON 

INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (1, N'Combo', N'combo', NULL, 0, 1)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (3, N'Mặt nạn chống khói', N'mat-na-chong-khoi', NULL, NULL, 2)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (4, N'Bình cứu hỏa', N'binh-cuu-hoa', NULL, NULL, 3)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (5, N'Búa thoát hiểm', N'bua-thoat-hiem', NULL, NULL, 4)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (6, N'Bộ dây', N'bo-day', NULL, NULL, 5)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (7, N'Găng tay', N'gang-tay', NULL, NULL, 6)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (8, N'Chăn cứu hỏa', N'chan-cuu-hoa', NULL, NULL, 7)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (9, N'Đèn pin', N'den-pin', NULL, NULL, 8)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (10, N'Bộ Móc treo', N'bo-moc-treo', NULL, NULL, 9)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (11, N'Hộp cứu hỏa', N'hop-cuu-hoa', NULL, NULL, 10)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (12, N'Túi đựng đồ', N'tui-dun-do', NULL, NULL, 11)
INSERT [dbo].[DanhMucSanPham] ([Id], [TenDanhMuc], [TenUrl], [MoTa], [IdDanhMuc], [STT]) VALUES (13, N'Thiết bị báo cháy tự động', N'thiet-bi-bao-chay-tu-dong', NULL, NULL, 12)
SET IDENTITY_INSERT [dbo].[DanhMucSanPham] OFF
SET IDENTITY_INSERT [dbo].[HinhAnhSanPham] ON 

INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (1, N'product-1-1.jpg', CAST(0x0000A4B1008423CB AS DateTime), 1, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (2, N'product-1-2.jpg', CAST(0x0000A4B1008423CB AS DateTime), 1, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (3, N'product-1-3.jpg', CAST(0x0000A4B1008423CB AS DateTime), 1, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (4, N'product-1-4.jpg', CAST(0x0000A4B1008423CB AS DateTime), 1, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (5, N'product-1-5.jpg', CAST(0x0000A4B1008423CB AS DateTime), 1, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (7, N'488c3811-8ece-4004-9d69-4f0be512445a_c15--1-.u2409.d20171025.t173904.425974 (1).jpg', CAST(0x0000A8B600CDBAD4 AS DateTime), 3, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (8, N'488c3811-8ece-4004-9d69-4f0be512445a_c15--2-.u2409.d20171025.t173904.454667.jpg', CAST(0x0000A8B600CDBB07 AS DateTime), 3, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (9, N'488c3811-8ece-4004-9d69-4f0be512445a_c15--4-.u2409.d20171025.t173904.504974.jpg', CAST(0x0000A8B600CDBB0C AS DateTime), 3, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (10, N'488c3811-8ece-4004-9d69-4f0be512445a_c15--3-.u2409.d20171025.t173904.481195.jpg', CAST(0x0000A8B600CDBB10 AS DateTime), 3, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (11, N'488c3811-8ece-4004-9d69-4f0be512445a_c15--5-.u2409.d20171025.t173904.531447.jpg', CAST(0x0000A8B600CDBB1A AS DateTime), 3, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (12, N'488c3811-8ece-4004-9d69-4f0be512445a_c15--6-.u2409.d20171025.t173904.557267.jpg', CAST(0x0000A8B600CDBB1E AS DateTime), 3, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (18, N'092e8ad4-4cc1-4ff8-ba28-57c6d84871e5_01.jpg', CAST(0x0000A8B700B059AC AS DateTime), 4, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (19, N'092e8ad4-4cc1-4ff8-ba28-57c6d84871e5_03.jpg', CAST(0x0000A8B700B059B1 AS DateTime), 4, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (20, N'3cd9364f-db77-41d2-8036-e16c3dd9de44_04.jpg', CAST(0x0000A8B700B249A0 AS DateTime), 5, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (21, N'3cd9364f-db77-41d2-8036-e16c3dd9de44_06.jpg', CAST(0x0000A8B700B249AA AS DateTime), 5, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (22, N'3cd9364f-db77-41d2-8036-e16c3dd9de44_05.jpg', CAST(0x0000A8B700B249AA AS DateTime), 5, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (23, N'de86fddc-db93-4822-9a3c-14cc6a1e04ed_09.jpg', CAST(0x0000A8B700B33CF3 AS DateTime), 8, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (24, N'de86fddc-db93-4822-9a3c-14cc6a1e04ed_07.jpg', CAST(0x0000A8B700B33CF8 AS DateTime), 8, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (25, N'de86fddc-db93-4822-9a3c-14cc6a1e04ed_08.jpg', CAST(0x0000A8B700B33CFC AS DateTime), 8, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (26, N'77b58aa4-9306-4515-a456-f251b449ca49_13.jpg', CAST(0x0000A8B700B3F80A AS DateTime), 9, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (27, N'77b58aa4-9306-4515-a456-f251b449ca49_12.jpg', CAST(0x0000A8B700B3F818 AS DateTime), 9, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (28, N'77b58aa4-9306-4515-a456-f251b449ca49_11.jpg', CAST(0x0000A8B700B3F826 AS DateTime), 9, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (29, N'77b58aa4-9306-4515-a456-f251b449ca49_10.jpg', CAST(0x0000A8B700B3F830 AS DateTime), 9, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (30, N'3651f3b1-4948-4f6f-83b2-e719bbd54d2c_18.jpg', CAST(0x0000A8B700B4BE60 AS DateTime), 10, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (31, N'3651f3b1-4948-4f6f-83b2-e719bbd54d2c_17.jpg', CAST(0x0000A8B700B4BE64 AS DateTime), 10, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (32, N'3651f3b1-4948-4f6f-83b2-e719bbd54d2c_15.jpg', CAST(0x0000A8B700B4BE69 AS DateTime), 10, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (33, N'3651f3b1-4948-4f6f-83b2-e719bbd54d2c_16.jpg', CAST(0x0000A8B700B4BE6E AS DateTime), 10, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (34, N'3651f3b1-4948-4f6f-83b2-e719bbd54d2c_14.jpg', CAST(0x0000A8B700B4BE77 AS DateTime), 10, 1)
INSERT [dbo].[HinhAnhSanPham] ([Id], [TenFile], [NgayTao], [IdSanPham], [Active]) VALUES (35, N'3651f3b1-4948-4f6f-83b2-e719bbd54d2c_19.jpg', CAST(0x0000A8B700B4BE7C AS DateTime), 10, 1)
SET IDENTITY_INSERT [dbo].[HinhAnhSanPham] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (1, N'Mặt Nạ Chống Khói Thoát Hiểm SaFer Fire MN1', 3, 1, N'<p>Đang cập nhật</p>', 632000, N'VP', N'Bạc, nhôm', N'<p>Đang cập nhật</p>', N'<p>Đang cập nhật</p>', N'mat-na-chong-khoi-thoat-hiem-safer-fire-mn1', N'02bb36a4-542d-4005-98ac-ae51ad020671product1.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (2, N'Bình Cứu Hỏa Firebeater - Đỏ BFD', 4, 1, N'Đang cập nhật', 230000, N'VP', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'binh-cuu-hoa-firebeater', N'e38a76f4-8076-4122-9e99-882a4bd44ca3product2.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (3, N'Chăn Dập Lửa Safer Fire C15 (1m5 x 1m5)', 8, 1, NULL, 425000, N'VP', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'Chan-dap-lua-safer-fire-c15', N'561d40f3-b4c9-4f1b-996c-06a0a2e0d408c15--1-.u2409.d20171025.t173904.425974.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (4, N'Dây Thoát Hiểm Safer Fire 1 Móc D31 (30m)', 6, 1, N'Dùng trong thi công công trình trên cao
Dây được thiết kế đảm bảo an toàn cho người lao động khi làm việc trên cao
Sản phẩm để tháo lắp tạo thuận lợi cho cả người già và trẻ em cũng có thể sử dụng

Dây thoát hiểm Safer Fire được sử dụng cho lính cứu hỏa, lực lượng cứu hộ cứu nạn', 534000, N'VP', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'c281c812-e901-4511-8731-6e8fc2bf36541.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (5, N'Quả Nổ Chữa Cháy Tự Động Safer Fire QN', 11, 1, N'Bảo vệ môi trường, tiết kiệm năng lượng, không độc, không gây ô nhiễm

Ứng dụng rộng rãi, có thể dập tắt được nhiều loại hỏa hoạn.

Ngăn chặn các đám cháy nhanh chóng, hiệu quả trong vòng 10s.

Chủ động ngăn chặn không cho đám cháy phát sinh mạnh giúp giảm thiểu thiệt hại đáng kể

Hạt động hoàn toàn độc lập, không cần sự tác động của con người nên giúp giảm nguy cơ tai nạn và chấn thương', 946000, N'VP', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'8e00c003-dc11-43d1-869f-1357a9e790e22.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (8, N'Bình Cứu Hỏa Firebeater - Trắng BFT', 4, 1, N'Loại bình cứu hỏa mini thường được sử dụng để trang bị cho xe ô tô 4 - 9 chỗ

Sản phẩm có thiết kế thông minh với dạng bình xịt nhỏ gọn

Sử dụng chất liệu bột ABC có khả năng dập tắt hầu hết các loại đám cháy chất rắn, chất lỏng, chất khí và các chất hóa lỏng', 230000, N'VP', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'Binh-cuu-hoa-firebeater', N'c2b3dabb-4409-44ad-9500-a6576d0be8013.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (9, N'Bình Cứu Hỏa Firebeater - Đỏ BFD', 4, 1, N'Loại bình cứu hỏa mini thường được sử dụng để trang bị cho xe ô tô 4 - 9 chỗ

Sản phẩm có thiết kế thông minh với dạng bình xịt nhỏ gọn

Sử dụng chất liệu bột ABC có khả năng dập tắt hầu hết các loại đám cháy chất rắn, chất lỏng, chất khí và các chất hóa lỏng', 230000, N'VP', N'Đang cập nhật', N'Đang cập nhật', N'Đang cập nhật', N'Binh-cuu-hoa-firebeater-do', N'f322dc8e-749e-47be-a8fd-f86cb37f2a754.jpg')
INSERT [dbo].[SanPham] ([Id], [TenSanPham], [IdDanhMuc], [IdThuongHieu], [Mota], [GiaSanPham], [Model], [ChatLieu], [HuongDanBaoQuan], [HuongDanSudung], [TenUrl], [TenFileImage]) VALUES (10, N'Ròng Rọc Thoát Hiểm Safer Fire R30 (30m)', 6, 1, N'Được làm từ chất liệu dây cáp lõi thép chống cháy gồm sợi Nylon, sợi Polyester, cáp thép đan bện lại với nhau

Móc sắt bằng kim loại đảm bảo chắc chắn và đáng tin cậy

Thiết bị tự hãm làm từ nhựa, cao su và các vật liệu phi kim loại khác

Ròng rọc dễ sử dụng với khả năng chịu lực tải trọng của dây 100kg', 3644000, N'VP', N' làm từ nhựa, cao su và các vật liệu phi kim loại khác', N'Đang cập nhật', N'Đang cập nhật', N'Rong-roc-thoat-hiem', N'b349bb53-1824-43ec-83be-8f6b0f7ba9f35.jpg')
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[Slider] ON 

INSERT [dbo].[Slider] ([Id], [TenFile], [TenUrl], [Mota]) VALUES (4, N'16877c3c-f8a5-40b9-89bf-c28191a770d4slide-02.jpg', N'thiet-bi-bao-chay-tu-dong', N'aaaaaaaaaaaaaaa')
INSERT [dbo].[Slider] ([Id], [TenFile], [TenUrl], [Mota]) VALUES (5, N'b60c1f75-8b16-4899-b99e-253eaa5d176fslide-00.jpg', N'xe-cuu-hoa', N'aaaaa')
SET IDENTITY_INSERT [dbo].[Slider] OFF
SET IDENTITY_INSERT [dbo].[ThuongHieu] ON 

INSERT [dbo].[ThuongHieu] ([Id], [TenThuongHieu], [MoTa], [XuatXuThuongHieu], [SanXuatTai]) VALUES (1, N'SaFer Fire', NULL, N'Trung Quốc', N'Trung Quốc')
INSERT [dbo].[ThuongHieu] ([Id], [TenThuongHieu], [MoTa], [XuatXuThuongHieu], [SanXuatTai]) VALUES (2, N'VPmedia', N'VP', N'Việt Nam', N'Việt Nam')
SET IDENTITY_INSERT [dbo].[ThuongHieu] OFF
ALTER TABLE [dbo].[HinhAnhSanPham]  WITH CHECK ADD  CONSTRAINT [FK_HinhAnhSanPham_SanPham] FOREIGN KEY([IdSanPham])
REFERENCES [dbo].[SanPham] ([Id])
GO
ALTER TABLE [dbo].[HinhAnhSanPham] CHECK CONSTRAINT [FK_HinhAnhSanPham_SanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_DanhMucSanPham] FOREIGN KEY([IdDanhMuc])
REFERENCES [dbo].[DanhMucSanPham] ([Id])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_DanhMucSanPham]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ThuongHieu] FOREIGN KEY([IdThuongHieu])
REFERENCES [dbo].[ThuongHieu] ([Id])
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ThuongHieu]
GO
