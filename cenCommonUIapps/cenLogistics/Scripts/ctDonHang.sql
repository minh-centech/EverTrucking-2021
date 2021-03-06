/*
--drop table ctDonHangChiTietTamUng
create table ctDonHang
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	IDDanhMucChungTuTrangThai		bigint not null,
	IDctChotDoanhThuGuiKeToan		bigint,
	So								nvarchar(35) not null,
	NgayLap							datetime not null,
	--
	IDDanhMucSale					bigint not null,
	IDDanhMucKhachHang				bigint not null,
	IDDanhMucKhachHangF2			bigint,
	DebitNote						nvarchar(128) not null,
	BillBooking						nvarchar(128),
	LoaiHang						tinyint not null, --1: nhập, 2: xuất, 3: nội địa
	IDDanhMucNhomHangVanChuyen		bigint not null,
	IDDanhMucHangHoa				bigint not null,
	IDDanhMucHangTau				bigint,
	SoLuong							float
	KhoiLuong						float,
	TheTich							float,
	SoContainer						nvarchar(128),
	IDDanhMucDiaDiemLayContHang		bigint,
	IDDanhMucDiaDiemTraContHang		bigint,
	NgayDongHang					date,
	GioDongHang						nvarchar(5),
	NgayTraHang						date,
	GioTraHang						nvarchar(5),
	IDDanhMucKhachHangF3DongHang	bigint,
	IDDanhMucKhachHangF3TraHang		bigint,
	IDDanhMucTuyenVanTai			bigint not null,
	NgayCatMang						date,
	GioCatMang						nvarchar(5),
	NguoiGiaoNhan					nvarchar(128),
	SoDienThoaiGiaoNhan				nvarchar(128),
	SoTienCuoc						float,
	SoTienThuTuc					float,
	SoTienDoanhThuKhac				float,
	SoTienHoaHong					float,
	ThoiHanThanhToan				date,
	--
	GhiChu							nvarchar(max),
	Huy								bit,
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	IDDanhMucNguoiSuDungDelete		bigint,
	DeleteDate						datetime,
	constraint PK_ctDonHang primary key (ID),
	constraint ctDonHang_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctDonHang foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctDonHang foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint DanhMucChungTuTrangThai_ctDonHang foreign key (IDDanhMucChungTuTrangThai) references DanhMucChungTuTrangThai(ID),
	constraint So_ctDonHang unique (So),
	--
	constraint DanhMucNhanSu_ctDonHang foreign key (IDDanhMucSale) references DanhMucNhanSu(ID),
	constraint DanhMucKhachHang_ctDonHang foreign key (IDDanhMucKhachHang) references DanhMucKhachHang(ID),
	constraint DanhMucKhachHangF2_ctDonHang foreign key (IDDanhMucKhachHangF2) references DanhMucKhachHang(ID),
	constraint NhomHangVanChuyen_ctDonHang foreign key (IDDanhMucNhomHangVanChuyen) references DanhMucDoiTuong(ID),
	constraint DanhMucHangHoa_ctDonHang foreign key (IDDanhMucHangHoa) references DanhMucHangHoa(ID),
	constraint IDDanhMucHangTau_ctDonHang foreign key (IDDanhMucHangTau) references DanhMucDoiTuong(ID),
	constraint DiaDiemLayContHang_ctDonHang foreign key (IDDanhMucDiaDiemLayContHang) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemTraContHang_ctDonHang foreign key (IDDanhMucDiaDiemTraContHang) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DanhMucKhachHangF3DongHang_ctDonHang foreign key (IDDanhMucKhachHangF3DongHang) references DanhMucKhachHang(ID),
	constraint DanhMucKhachHangF3TraHang_ctDonHang foreign key (IDDanhMucKhachHangF3TraHang) references DanhMucKhachHang(ID),
	constraint DanhMucTuyenVanTai_ctDonHang foreign key (IDDanhMucTuyenVanTai) references DanhMucTuyenVanTai(ID),
	--
	constraint UserCreate_ctDonHang foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctDonHang foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID),
	constraint UserDelete_ctDonHang foreign key (IDDanhMucNguoiSuDungDelete) references DanhMucNguoiSuDung(ID)
)
go
create table ctDonHangChiTietTamUng
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	IDChungTu						bigint not null,
	--
	NgayTamUng						date not null,
	LanTamUng						int not null,
	IDDanhMucCanBoTamUng			bigint not null,
	SoTienCuocVo					float,
	SoTienHaiQuan					float,
	SoTienNangHa					float,
	SoTienChiKhac					float,
	IDDanhMucHangTau				bigint,
	ThoiHanThanhToan				date not null,
	--
	GhiChu							nvarchar(max),
	Huy								bit,
	IDDanhMucNguoiSuDungCreate		bigint not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	IDDanhMucNguoiSuDungDelete		bigint,
	DeleteDate						datetime,

	constraint PK_ctDonHangChiTietTamUng primary key (ID),
	constraint ctDonHangChiTietTamUng_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctDonHangChiTietTamUng foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctDonHangChiTietTamUng foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctDonHangChiTietTamUng foreign key (IDChungTu) references ctDonHang(ID),
	--
	constraint DanhMucHangTau_ctDonHang foreign key (IDDanhMucHangTau) references DanhMucDoiTuong(ID),
	constraint DanhMucCanBoTamUng_ctDonHang foreign key (IDDanhMucCanBoTamUng) references DanhMucNhanSu(ID),
	constraint UserCreate_ctDonHangChiTietTamUng foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctDonHangChiTietTamUng foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID),
	constraint UserDelete_ctDonHangChiTietTamUng foreign key (IDDanhMucNguoiSuDungDelete) references DanhMucNguoiSuDung(ID)
)
go
create index idx_ctDonHang_NgayDongTraHang on ctDonHang (NgayDongTraHang);
create index idx_ctDonHang_DebitNote on ctDonHang (DebitNote);
go
*/
---------------
alter procedure List_ctDonHang_Display
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint = null,
	@TuNgay				date = null,
	@DenNgay			date = null
as
begin
	set nocount on;
	--
	if @TuNgay is null set @TuNgay = '2020-01-01';
	if @DenNgay is null set @DenNgay = '2030-01-01';
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.DebitNote,
		a.BillBooking,
		isnull(a.NgayDongHang, a.NgayTraHang) NgayDongTraHang,
		convert(nvarchar(10), a.NgayDongHang, 103) NgayDongHang,
		a.GioDongHang,
		convert(nvarchar(10), a.NgayTraHang, 103) NgayTraHang,
		a.GioTraHang,
		KhachHang.Ma MaDanhMucKhachHang,
		NhomHangVanChuyen.Ma MaDanhMucNhomHangVanChuyen,
		HangHoa.Ma MaDanhMucHangHoa, --HangHoa.Ten TenDanhMucHangHoa,
		case when ctDieuHanh.TrangThaiDonHang = 1 or ctDieuHanh.TrangThaiDonHang is null then N'Đơn' when ctDieuHanh.TrangThaiDonHang = 2 then N'Kết hợp' else N'Kẹp đôi' end TrangThaiDonHang,
		ThauPhu.Ma MaDanhMucThauPhu,
		a.KhoiLuong,
		a.SoTienCuoc,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		TuyenVanTai.CuLy CuLy,
		a.GhiChu,
		a.Huy,
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate,
		a.IDDanhMucNguoiSuDungDelete,
		UserDelete.Ma MaDanhMucNguoiSuDungDelete,
		a.DeleteDate
	from ctDonHang a
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ThauPhu on ctDieuHanh.IDDanhMucThauPhu = ThauPhu.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucDoiTuong NhomHangVanChuyen on HangHoa.IDDanhMucNhomHangVanChuyen = NhomHangVanChuyen.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and case when @ID is not null then a.ID else -1 end = isnull(@ID, -1)
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and a.Huy is null
	order by NhomHangVanChuyen.Ma, a.DebitNote, isnull(a.NgayDongHang, a.NgayTraHang);
end;
go
---------------
alter procedure List_ctDonHang
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	create table #ChungTu
	(
		ID								bigint,
		IDDanhMucDonVi					bigint,
		IDDanhMucChungTu				bigint,
		IDDanhMucChungTuTrangThai		bigint,
		So								nvarchar(35),
		NgayLap							datetime,
		--
		IDDanhMucSale					bigint,
		IDDanhMucKhachHang				bigint,
		MaDanhMucKhachHang				nvarchar(128),
		TenDanhMucKhachHang				nvarchar(255),
		MaSoThue						nvarchar(128),
		IDDanhMucKhachHangF2			bigint,
		DebitNote						nvarchar(128),
		BillBooking						nvarchar(128),
		LoaiHang						tinyint, --1: nhập, 2: xuất, 3: nội địa
		IDDanhMucNhomHangVanChuyen		bigint,
		IDDanhMucHangHoa				bigint,
		IDDanhMucHangTau				bigint,
		SoLuong							float,
		KhoiLuong						float,
		TheTich							float,
		SoContainer						nvarchar(128),
		IDDanhMucDiaDiemLayContHang		bigint,
		IDDanhMucDiaDiemTraContHang		bigint,
		NgayDongHang					date,
		GioDongHang						nvarchar(5),
		NgayTraHang						date,
		GioTraHang						nvarchar(5),
		IDDanhMucKhachHangF3DongHang	bigint,
		IDDanhMucKhachHangF3TraHang		bigint,
		IDDanhMucTuyenVanTai			bigint,
		NgayCatMang						date,
		GioCatMang						nvarchar(5),
		NguoiGiaoNhan					nvarchar(128),
		SoDienThoaiGiaoNhan				nvarchar(128),
		SoTienCuoc						float,
		SoTienThuTuc					float,
		SoTienDoanhThuKhac				float,
		SoTienHoaHong					float,
		TongSoTienTamUngCuocVo			float,
		TongSoTienTamUngHaiQuan			float,
		TongSoTienTamUngNangHa			float,
		TongSoTienTamUngChiKhac			float,
		ThoiHanThanhToan				date,
		GhiChu							nvarchar(max),
		Huy								bit,
		--
		IDDanhMucNguoiSuDungCreate		bigint,
		MaDanhMucNguoiSuDungCreate		nvarchar(128),
		CreateDate						datetime,
		IDDanhMucNguoiSuDungEdit		bigint,
		MaDanhMucNguoiSuDungEdit		nvarchar(128),
		EditDate						datetime,
		IDDanhMucNguoiSuDungDelete		bigint,
		MaDanhMucNguoiSuDungDelete		nvarchar(128),
		DeleteDate						datetime
	);
	create table #ChungTuChiTiet
	(
		ID								bigint,
		IDDanhMucDonVi					bigint,
		IDDanhMucChungTu				bigint,
		IDChungTu						bigint,
		--
		NgayTamUng						date not null,
		LanTamUng						int not null,
		IDDanhMucCanBoTamUng			bigint not null,
		MaDanhMucCanBoTamUng			nvarchar(128),
		TenDanhMucCanBoTamUng			nvarchar(255),
		SoTienCuocVo					float,
		SoTienHaiQuan					float,
		SoTienNangHa					float,
		SoTienChiKhac					float,
		IDDanhMucHangTau				bigint,
		MaDanhMucHangTau				nvarchar(128),
		TenDanhMucHangTau				nvarchar(255),
		ThoiHanThanhToan				date not null,
		--
		GhiChu							nvarchar(max),
		Huy								bit,
		--
		IDDanhMucNguoiSuDungCreate		bigint,
		MaDanhMucNguoiSuDungCreate		nvarchar(128),
		CreateDate						datetime,
		IDDanhMucNguoiSuDungEdit		bigint,
		MaDanhMucNguoiSuDungEdit		nvarchar(128),
		EditDate						datetime,
		IDDanhMucNguoiSuDungDelete		bigint,
		MaDanhMucNguoiSuDungDelete		nvarchar(128),
		DeleteDate						datetime
	);
	--
	insert into #ChungTu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.NgayLap,
		--
		a.IDDanhMucSale,
		a.IDDanhMucKhachHang,
		KhachHang.Ma MaDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		KhachHang.MaSoThue MaSoThue,
		a.IDDanhMucKhachHangF2,
		a.DebitNote,
		a.BillBooking,
		a.LoaiHang,
		a.IDDanhMucNhomHangVanChuyen,
		a.IDDanhMucHangHoa,
		a.IDDanhMucHangTau,
		a.SoLuong,
		a.KhoiLuong,
		a.TheTich,
		a.SoContainer,
		a.IDDanhMucDiaDiemLayContHang,
		a.IDDanhMucDiaDiemTraContHang,
		a.NgayDongHang,
		a.GioDongHang,
		a.NgayTraHang,
		a.GioTraHang,
		a.IDDanhMucKhachHangF3DongHang,
		a.IDDanhMucKhachHangF3TraHang,
		a.IDDanhMucTuyenVanTai,
		a.NgayCatMang,
		a.GioCatMang,
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
		a.SoTienCuoc,
		a.SoTienThuTuc,
		a.SoTienDoanhThuKhac,
		a.SoTienHoaHong,
		null TongSoTienTamUngCuocVo,
		null TongSoTienTamUngHaiQuan,
		null TongSoTienTamUngNangHa,
		null TongSoTienTamUngChiKhac,
		a.ThoiHanThanhToan,
		--
		a.GhiChu,
		a.Huy,
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate,
		a.IDDanhMucNguoiSuDungDelete,
		UserDelete.Ma MaDanhMucNguoiSuDungDelete,
		a.DeleteDate
	from ctDonHang a
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.ID = @ID;
	--
	insert into #ChungTuChiTiet
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		--
		a.NgayTamUng,
		a.LanTamUng,
		a.IDDanhMucCanBoTamUng,
		NhanSu.Ma MaDanhMucCanBoTamUng,
		NhanSu.Ten TenDanhMucCanBoTamUng,
		a.SoTienCuocVo,
		a.SoTienHaiQuan,
		a.SoTienNangHa,
		a.SoTienChiKhac,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		HangTau.Ten TenDanhMucHangTau,
		a.ThoiHanThanhToan,
		--
		a.GhiChu,
		a.Huy,
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate,
		a.IDDanhMucNguoiSuDungDelete,
		UserDelete.Ma MaDanhMucNguoiSuDungDelete,
		a.DeleteDate
	from ctDonHangChiTietTamUng a
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID
		left join DanhMucNhanSu NhanSu on a.IDDanhMucCanBoTamUng = NhanSu.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.IDChungTu = @ID and a.Huy is null;
	--update tổng tiền tạm ứng
	update #ChungTu set TongSoTienTamUngCuocVo	= T.SoTienCuocVo,
						TongSoTienTamUngHaiQuan	= T.SoTienHaiQuan,
						TongSoTienTamUngNangHa	= T.SoTienNangHa,
						TongSoTienTamUngChiKhac	= T.SoTienChiKhac
	from #ChungTu inner join (select IDChungTu, sum(isnull(SoTienCuocVo, 0)) SoTienCuocVo, sum(isnull(SoTienHaiQuan, 0)) SoTienHaiQuan, sum(isnull(SoTienNangHa, 0)) SoTienNangHa, sum(isnull(SoTienChiKhac, 0)) SoTienChiKhac
								from #ChungTuChiTiet where IDChungTu = @ID and Huy is null group by IDChungTu) T on #ChungTu.ID = T.IDChungTu;
	--
	select * from #ChungTu;
	select * from #ChungTuChiTiet;
	--
	drop table #ChungTu;
	drop table #ChungTuChiTiet;
end;
go
------------------
alter procedure List_ctDonHangChiTietTamUng_ID
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint
as
begin
	set nocount on;
	--
	select
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDChungTu,
		--
		ctDonHang.DebitNote,
		ctDonHang.BillBooking,
		a.NgayTamUng,
		a.LanTamUng,
		a.IDDanhMucCanBoTamUng,
		NhanSu.Ma MaDanhMucCanBoTamUng,
		NhanSu.Ten TenDanhMucCanBoTamUng,
		PhongBan.Ten TenDanhMucPhongBan,
		a.SoTienCuocVo,
		a.SoTienHaiQuan,
		a.SoTienNangHa,
		a.SoTienChiKhac,
		isnull(a.SoTienCuocVo, 0) + isnull(a.SoTienHaiQuan, 0) + isnull(a.SoTienNangHa, 0) + isnull(a.SoTienChiKhac, 0) SoTienTamUng,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		HangTau.Ten TenDanhMucHangTau,
		a.ThoiHanThanhToan,
		--
		a.GhiChu
	from ctDonHangChiTietTamUng a
		left join ctDonHang on a.IDChungTu = ctDonHang.ID
		left join DanhMucKhachHang KhachHang on ctDonHang.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID
		left join DanhMucNhanSu NhanSu on a.IDDanhMucCanBoTamUng = NhanSu.ID
		left join DanhMucDoiTuong PhongBan on NhanSu.IDDanhMucPhongBan = PhongBan.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.Huy is null and a.ID = @ID;
end;
go
------------------
alter procedure Insert_ctDonHang
(
	@ID								bigint = null output,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	@IDDanhMucChungTuTrangThai		bigint,
	@So								nvarchar(35) = null output,
	@NgayLap						datetime,
	--
	@IDDanhMucSale					bigint,
	@IDDanhMucKhachHang				bigint,
	@IDDanhMucKhachHangF2			bigint = null,
	@DebitNote						nvarchar(128),
	@BillBooking					nvarchar(128) = null,
	@LoaiHang						tinyint, --1: nhập, 2: xuất, 3: nội địa
	@IDDanhMucNhomHangVanChuyen		bigint,
	@IDDanhMucHangHoa				bigint = null,
	@IDDanhMucHangTau				bigint = null,
	@SoLuong						float = null,
	@KhoiLuong						float = null,
	@TheTich						float = null,
	@SoContainer					nvarchar(128) = null,
	@IDDanhMucDiaDiemLayContHang	bigint = null,
	@IDDanhMucDiaDiemTraContHang	bigint = null,
	@NgayDongHang					date = null,
	@GioDongHang					nvarchar(5) = null,
	@NgayTraHang					date = null,
	@GioTraHang						nvarchar(5) = null,
	@IDDanhMucKhachHangF3DongHang	bigint = null,
	@IDDanhMucKhachHangF3TraHang	bigint = null,
	@IDDanhMucTuyenVanTai			bigint,
	@NgayCatMang					date = null,
	@GioCatMang						nvarchar(5) = null,
	@NguoiGiaoNhan					nvarchar(128) = null,
	@SoDienThoaiGiaoNhan			nvarchar(128) = null,
	@SoTienCuoc						float = null,
	@SoTienThuTuc					float = null,
	@SoTienDoanhThuKhac				float = null,
	@SoTienHoaHong					float = null,
	@ThoiHanThanhToan				date = null,
	@GhiChu							nvarchar(max) = null,
	--
	@IDDanhMucNguoiSuDungCreate		bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE()
	begin tran
	begin try
	--Đánh số chứng từ
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctDonHang';
	declare @KyHieu nvarchar(20), @ctCount int, @ThuTu nvarchar(5);
	select @KyHieu = KiHieu from DanhMucChungTu where ID = @IDDanhMucChungTu;
	select @ctCount = ISNULL(MAX(CAST(RIGHT(SO, 5) AS INT)), 0) + 1 from ctDonHang; -- where cast(NgayLap as date) = cast(@NgayLap as date);
	set @ThuTu = RIGHT('00000'+ISNULL(cast(@ctCount as nvarchar(5)),''),5);
	--set @So = @KyHieu + CONVERT(VARCHAR(8), @NgayLap, 112) + '-' + @ThuTu;
	set @So = @KyHieu + @ThuTu;
	--
	insert	into ctDonHang
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		IDDanhMucChungTuTrangThai,
		So,
		NgayLap,
		--
		IDDanhMucSale,
		IDDanhMucKhachHang,
		IDDanhMucKhachHangF2,
		DebitNote,
		BillBooking,
		LoaiHang,
		IDDanhMucNhomHangVanChuyen,
		IDDanhMucHangHoa,
		IDDanhMucHangTau,
		SoLuong,
		KhoiLuong,
		TheTich,
		SoContainer,
		IDDanhMucDiaDiemLayContHang,
		IDDanhMucDiaDiemTraContHang,
		NgayDongHang,
		GioDongHang,
		NgayTraHang,
		GioTraHang,
		IDDanhMucKhachHangF3DongHang,
		IDDanhMucKhachHangF3TraHang,
		IDDanhMucTuyenVanTai,
		NgayCatMang,
		GioCatMang,
		NguoiGiaoNhan,
		SoDienThoaiGiaoNhan,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoTienHoaHong,
		ThoiHanThanhToan,
		GhiChu,
		--
		IDDanhMucNguoiSuDungCreate,
		CreateDate
	)
	values
	(
		@ID,
		@IDDanhMucDonVi,
		@IDDanhMucChungTu,
		@IDDanhMucChungTuTrangThai,
		@So,
		@NgayLap,
		--
		@IDDanhMucSale,
		@IDDanhMucKhachHang,
		@IDDanhMucKhachHangF2,
		isnull(@DebitNote, @So),
		@BillBooking,
		@LoaiHang,
		@IDDanhMucNhomHangVanChuyen,
		@IDDanhMucHangHoa,
		@IDDanhMucHangTau,
		@SoLuong,
		@KhoiLuong,
		@TheTich,
		@SoContainer,
		@IDDanhMucDiaDiemLayContHang,
		@IDDanhMucDiaDiemTraContHang,
		@NgayDongHang,
		@GioDongHang,
		@NgayTraHang,
		@GioTraHang,
		@IDDanhMucKhachHangF3DongHang,
		@IDDanhMucKhachHangF3TraHang,
		@IDDanhMucTuyenVanTai,
		@NgayCatMang,
		@GioCatMang,
		@NguoiGiaoNhan,
		@SoDienThoaiGiaoNhan,
		@SoTienCuoc,
		@SoTienThuTuc,
		@SoTienDoanhThuKhac,
		@SoTienHoaHong,
		@ThoiHanThanhToan,
		@GhiChu,
		--
		@IDDanhMucNguoiSuDungCreate,
		@NgayCapNhat
	)
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
------------------
alter procedure Update_ctDonHang
(
	@ID								bigint,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	@IDDanhMucChungTuTrangThai		bigint,
	@So								nvarchar(35),
	@NgayLap						datetime,
	--
	@IDDanhMucSale					bigint,
	@IDDanhMucKhachHang				bigint,
	@IDDanhMucKhachHangF2			bigint = null,
	@DebitNote						nvarchar(128),
	@BillBooking					nvarchar(128) = null,
	@LoaiHang						tinyint, --1: nhập, 2: xuất, 3: nội địa
	@IDDanhMucNhomHangVanChuyen		bigint,
	@IDDanhMucHangHoa				bigint = null,
	@IDDanhMucHangTau				bigint = null,
	@SoLuong						float = null,
	@KhoiLuong						float = null,
	@TheTich						float = null,
	@SoContainer					nvarchar(128) = null,
	@IDDanhMucDiaDiemLayContHang	bigint = null,
	@IDDanhMucDiaDiemTraContHang	bigint = null,
	@NgayDongHang					date = null,
	@GioDongHang					nvarchar(5) = null,
	@NgayTraHang					date = null,
	@GioTraHang						nvarchar(5) = null,
	@IDDanhMucKhachHangF3DongHang	bigint = null,
	@IDDanhMucKhachHangF3TraHang	bigint = null,
	@IDDanhMucTuyenVanTai			bigint,
	@NgayCatMang					date = null,
	@GioCatMang						nvarchar(5) = null,
	@NguoiGiaoNhan					nvarchar(128) = null,
	@SoDienThoaiGiaoNhan			nvarchar(128) = null,
	@SoTienCuoc						float = null,
	@SoTienThuTuc					float = null,
	@SoTienDoanhThuKhac				float = null,
	@SoTienHoaHong					float = null,
	@ThoiHanThanhToan				date = null,
	@GhiChu							nvarchar(max) = null,
	--
	@IDDanhMucNguoiSuDungEdit		bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE();

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctDonHang where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungEdit
	begin
		raiserror(N'Bạn không có quyền sửa đơn hàng của người khác!', 16, 1);
		return;
	end;
	begin
		begin tran
		begin try
		update ctDonHang
			set
				IDDanhMucChungTuTrangThai = @IDDanhMucChungTuTrangThai,
				So = @So,
				NgayLap = @NgayLap,
				--
				IDDanhMucSale = @IDDanhMucSale,
				IDDanhMucKhachHang = @IDDanhMucKhachHang,
				IDDanhMucKhachHangF2 = @IDDanhMucKhachHangF2,
				DebitNote = @DebitNote,
				BillBooking = @BillBooking,
				LoaiHang = @LoaiHang,
				IDDanhMucNhomHangVanChuyen = @IDDanhMucNhomHangVanChuyen,
				IDDanhMucHangHoa = @IDDanhMucHangHoa,
				IDDanhMucHangTau = @IDDanhMucHangTau,
				SoLuong = @SoLuong,
				KhoiLuong = @KhoiLuong,
				TheTich = @TheTich,
				SoContainer = @SoContainer,
				IDDanhMucDiaDiemLayContHang = @IDDanhMucDiaDiemLayContHang,
				IDDanhMucDiaDiemTraContHang = @IDDanhMucDiaDiemTraContHang,
				NgayDongHang = @NgayDongHang,
				GioDongHang = @GioDongHang,
				NgayTraHang = @NgayTraHang,
				GioTraHang = @GioTraHang,
				IDDanhMucKhachHangF3DongHang = @IDDanhMucKhachHangF3DongHang,
				IDDanhMucKhachHangF3TraHang = @IDDanhMucKhachHangF3TraHang,
				IDDanhMucTuyenVanTai = @IDDanhMucTuyenVanTai,
				NgayCatMang = @NgayCatMang,
				GioCatMang = @GioCatMang,
				NguoiGiaoNhan = @NguoiGiaoNhan,
				SoDienThoaiGiaoNhan = @SoDienThoaiGiaoNhan,
				SoTienCuoc = @SoTienCuoc,
				SoTienThuTuc = @SoTienThuTuc,
				SoTienDoanhThuKhac = @SoTienDoanhThuKhac,
				SoTienHoaHong = @SoTienHoaHong,
				ThoiHanThanhToan = @ThoiHanThanhToan,
				GhiChu = @GhiChu,
				--
				IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
				EditDate = @NgayCapNhat
			where ID = @ID;
		commit tran
		end try
		begin catch
			rollback
			declare @ErrMsg nvarchar(max)
			select @ErrMsg = error_message()
			raiserror(@ErrMsg, 16, 1)
		end catch
	end;
end
go
------------------
alter procedure Delete_ctDonHang
(
	@ID							bigint,
	@IDDanhMucNguoiSuDungDelete	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE();

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctDonHang where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungDelete
	begin
		raiserror(N'Bạn không có quyền xóa đơn hàng của người khác!', 16, 1);
		return;
	end
	else
	begin
		declare @countID bigint = null;
		select @countID = count(ID) from ctDonHangChiTietTamUng where IDChungTu = @ID and Huy is null;
		--exec Check_ForeignKey N'ctDonHangChiTietTamUng', N'IDChungTu', @ID, N'Đơn hàng này đã có phát sinh tạm ứng, không xóa được!', @countID out;
		if @countID > 0
		begin
			raiserror(N'Đơn hàng đã có phát sinh tạm ứng, không xóa được!', 16, 1);
			return;
		end
		else
		begin

			begin tran
			begin try
			update ctDonHang set Huy = 1, IDDanhMucNguoiSuDungDelete = @IDDanhMucNguoiSuDungDelete, DeleteDate = @NgayCapNhat where ID = @ID;

			--delete from AutoID where ID = @ID;

			commit tran
			end try
			begin catch
				rollback
				declare @ErrMsg nvarchar(max)
				select @ErrMsg = error_message()
				raiserror(@ErrMsg, 16, 1)
			end catch
		end;
	end;
end
go
------------------
alter procedure Insert_ctDonHangChiTietTamUng
(
	@ID							bigint = null output,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@IDChungTu					bigint,
	--
	@NgayTamUng					date,
	@IDDanhMucHangTau			bigint = null,
	@SoTienCuocVo				float = null,
	@SoTienHaiQuan				float = null,
	@SoTienNangHa				float = null,
	@SoTienChiKhac				float = null,
	@IDDanhMucCanBoTamUng		bigint,
	@ThoiHanThanhToan			date,
	--
	@GhiChu						nvarchar(max) = null,
	@IDDanhMucNguoiSuDungCreate	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	
	begin tran
	begin try

	declare @LanTamUng int;
	select @LanTamUng = max(LanTamUng) from ctDonHangChiTietTamUng where IDChungTu = @IDChungTu;
	if @LanTamUng is null or @LanTamUng = 0 
		set @LanTamUng = 1
	else
		set @LanTamUng = @LanTamUng + 1;

	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctDonHangChiTietTamUng';

	declare @NgayCapNhat datetime;
	set @NgayCapNhat = GETDATE();

	insert	into ctDonHangChiTietTamUng
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		IDChungTu,
		--
		NgayTamUng,
		LanTamUng,
		IDDanhMucHangTau,
		SoTienCuocVo,
		SoTienHaiQuan,
		SoTienNangHa,
		SoTienChiKhac,
		IDDanhMucCanBoTamUng,
		ThoiHanThanhToan,
		--
		GhiChu,
		IDDanhMucNguoiSuDungCreate,
		CreateDate
	)
	values
	(
		@ID,
		@IDDanhMucDonVi,
		@IDDanhMucChungTu,
		@IDChungTu,
		--
		@NgayTamUng,
		@LanTamUng,
		@IDDanhMucHangTau,
		@SoTienCuocVo,
		@SoTienHaiQuan,
		@SoTienNangHa,
		@SoTienChiKhac,
		@IDDanhMucCanBoTamUng,
		@ThoiHanThanhToan,
		--
		@GhiChu,
		@IDDanhMucNguoiSuDungCreate,
		@NgayCapNhat
	)
	commit tran
	end try
	begin catch
		rollback
		declare @ErrMsg nvarchar(max)
		select @ErrMsg = error_message()
		raiserror(@ErrMsg, 16, 1)
	end catch
	set @Err = @@Error
	return @Err
end
go
------------------
alter procedure Update_ctDonHangChiTietTamUng
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@IDChungTu					bigint,
	--
	@NgayTamUng					date,
	@IDDanhMucHangTau			bigint = null,
	@SoTienCuocVo				float = null,
	@SoTienHaiQuan				float = null,
	@SoTienNangHa				float = null,
	@SoTienChiKhac				float = null,
	@IDDanhMucCanBoTamUng		bigint,
	@ThoiHanThanhToan			date,
	--
	@GhiChu						nvarchar(max) = null,
	@IDDanhMucNguoiSuDungEdit	bigint
as
begin
	set nocount on;
	declare @Err int;

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctDonHangChiTietTamUng where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungEdit
	begin
		raiserror(N'Bạn không có quyền sửa chi tiết tạm ứng của người khác!', 16, 1);
		return;
	end
	else
	begin

		declare @NgayCapNhat datetime;
		select @NgayCapNhat = GETDATE();

		begin tran
		begin try
	
		update ctDonHangChiTietTamUng
		set	IDDanhMucDonVi = @IDDanhMucDonVi,
			IDDanhMucChungTu = @IDDanhMucChungTu,
			IDChungTu = @IDChungTu,
			--
			NgayTamUng = @NgayTamUng,
			IDDanhMucHangTau = @IDDanhMucHangTau,
			SoTienCuocVo = @SoTienCuocVo,
			SoTienHaiQuan = @SoTienHaiQuan,
			SoTienNangHa = @SoTienNangHa,
			SoTienChiKhac = @SoTienChiKhac,
			IDDanhMucCanBoTamUng = @IDDanhMucCanBoTamUng,
			ThoiHanThanhToan = @ThoiHanThanhToan,
			--
			GhiChu = @GhiChu,
			IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
			EditDate = @NgayCapNhat
		where ID = @ID;
		commit tran
		end try
		begin catch
			rollback
			declare @ErrMsg nvarchar(max)
			select @ErrMsg = error_message()
			raiserror(@ErrMsg, 16, 1)
		end catch
	end;
end
go
------------------
alter procedure Delete_ctDonHangChiTietTamUng
	@ID							bigint,
	@IDDanhMucNguoiSuDungDelete	bigint
as
begin
	set nocount on;
	declare @Err int;

	declare @IDDanhMucNguoiSuDungCreate bigint;
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctDonHangChiTietTamUng where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungDelete
	begin
		raiserror(N'Bạn không có quyền xóa chi tiết tạm ứng của người khác!', 16, 1);
		return;
	end
	else
	begin

		declare @countID bigint = null;
		exec Check_ForeignKey N'ctDonHangChiTietTamUng', N'IDChungTuChiTiet', @ID, N'Dòng tạm ứng này đã có phát sinh thanh toán tạm ứng, không xóa được!', @countID out;

		if @countID > 0
			return;
		else
		begin
			begin tran
			begin try
				delete from ctDonHangChiTietTamUng where ID = @ID;
				delete from AutoID where ID = @ID;
			commit tran
			end try
			begin catch
				rollback
				declare @ErrMsg nvarchar(max)
				select @ErrMsg = error_message()
				raiserror(@ErrMsg, 16, 1)
			end catch
		end;
	end;
end
go
------------------
alter procedure Get_ctDonHang_IDctChotDoanhThuGuiKeToan
	@IDctDonHang bigint,
	@IDctChotDoanhThuGuiKeToan bigint = null out
as
begin
	set nocount on;
	select @IDctChotDoanhThuGuiKeToan = ID from ctChotDoanhThuGuiKeToan where IDChungTu = @IDctDonHang;
end
go
------------------
alter procedure List_ctDonHang_ValidDebitNote
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@DebitNote			nvarchar(128) = null
as
begin
	set nocount on;
	if @DebitNote is null set @DebitNote = '%' else set @DebitNote = '%' + @DebitNote + '%';
	--
	select 
		a.ID,
		a.So,
		a.DebitNote,
		a.BillBooking,
		a.GhiChu
	from ctDonHang a
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.DebitNote like @DebitNote and Huy is null;
		
end;
go
------------------
alter procedure List_ctDonHang_NhomHangVanChuyen
	@IDDanhMucDonVi				bigint,
	@IDDanhMucChungTu			bigint,
	@TuNgay						date = null,
	@DenNgay					date = null,
	@IDDanhMucNhomHangVanChuyen	bigint = null
as
begin
	select
		(select Count(ID) from ctDonHang
			where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucChungTu = @IDDanhMucChungTu and Huy is null
			and case when @TuNgay is not null then isnull(NgayDongHang, NgayTraHang) else '1900-01-01' end >= isnull(@TuNgay, '1900-01-01')
			and case when @DenNgay is not null then isnull(NgayDongHang, NgayTraHang) else '1900-01-01' end <= isnull(@DenNgay, '1900-01-01')
			and case when @IDDanhMucNhomHangVanChuyen is not null then IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)) Total,
		(select Count(ID) from ctDonHang
			where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucChungTu = @IDDanhMucChungTu and Huy is null
			and case when @TuNgay is not null then isnull(NgayDongHang, NgayTraHang) else '1900-01-01' end >= isnull(@TuNgay, '1900-01-01')
			and case when @DenNgay is not null then isnull(NgayDongHang, NgayTraHang) else '1900-01-01' end <= isnull(@DenNgay, '1900-01-01')
			and IDDanhMucNhomHangVanChuyen = 2007
			and case when @IDDanhMucNhomHangVanChuyen is not null then IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)) Cont,
		(select Count(ID) from ctDonHang 
			where IDDanhMucDonVi = @IDDanhMucDonVi and IDDanhMucChungTu = @IDDanhMucChungTu and Huy is null
			and case when @TuNgay is not null then isnull(NgayDongHang, NgayTraHang) else '1900-01-01' end >= isnull(@TuNgay, '1900-01-01')
			and case when @DenNgay is not null then isnull(NgayDongHang, NgayTraHang) else '1900-01-01' end <= isnull(@DenNgay, '1900-01-01')
			and IDDanhMucNhomHangVanChuyen <> 2007
			and case when @IDDanhMucNhomHangVanChuyen is not null then IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)) Truck;
	
end;