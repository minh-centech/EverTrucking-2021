/*---------------
create table ctKeHoachVanTai
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	IDDanhMucChungTuTrangThai		bigint not null,
	So								nvarchar(35) not null,
	NgayLap							datetime not null,
	--
	IDDanhMucSale					bigint not null,
	IDDanhMucKhachHang				bigint not null,
	LoaiHinh						tinyint not null, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
	LoaiHang						tinyint not null, --Loại hàng: 1: FCL, 2: LCL
	IDDanhMucHangTau				bigint,
	IDDanhMucDiaDiemNangCont		bigint,
	NgayNangCont					datetime,
	IDDanhMucDiaDiemHaCont			bigint,
	NgayHaCont						datetime,
	SoLuongCont20					int,
	SoCont20						nvarchar(512),
	SoLuongCont40					int,
	SoCont40						nvarchar(512),
	SoLuongCont45					int,
	SoCont45						nvarchar(512),
	IDDanhMucDiaDiemDongHang		bigint,
	NgayDongHang					datetime,
	IDDanhMucDiaDiemTraHang			bigint,
	NgayTraHang						datetime,
	KhoiLuong						float,			--Nếu là hàng rời
	NguoiGiaoNhan					nvarchar(128),
	SoDienThoaiGiaoNhan				nvarchar(128),
	--
	GhiChu							nvarchar(max),
	Huy								bit,
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	IDDanhMucNguoiSuDungDelete		bigint,
	DeleteDate						datetime,
	constraint PK_ctKeHoachVanTai primary key (ID),
	constraint ctKeHoachVanTai_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctKeHoachVanTai foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctKeHoachVanTai foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint DanhMucChungTuTrangThai_ctKeHoachVanTai foreign key (IDDanhMucChungTuTrangThai) references DanhMucChungTuTrangThai(ID),
	constraint So_ctKeHoachVanTai unique (So),
	--
	constraint DanhMucNhanSu_ctKeHoachVanTai foreign key (IDDanhMucSale) references DanhMucNhanSu(ID),
	constraint DanhMucKhachHang_ctKeHoachVanTai foreign key (IDDanhMucKhachHang) references DanhMucKhachHang(ID),
	
	constraint IDDanhMucHangTau_ctKeHoachVanTai foreign key (IDDanhMucHangTau) references DanhMucDoiTuong(ID),
	constraint DiaDiemNangCont_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemNangCont) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemHaCont_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemHaCont) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemDongHang_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemDongHang) references DanhMucDiaDiemGiaoNhan(ID),
	constraint DiaDiemTraHang_ctKeHoachVanTai foreign key (IDDanhMucDiaDiemTraHang) references DanhMucDiaDiemGiaoNhan(ID),
	
	--
	constraint UserCreate_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID),
	constraint UserDelete_ctKeHoachVanTai foreign key (IDDanhMucNguoiSuDungDelete) references DanhMucNguoiSuDung(ID)
)
---------------*/
alter procedure List_ctKeHoachVanTai_Display
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@TuNgay				date,
	@DenNgay			date,
	@ID					bigint = null
as
begin
	set nocount on;
	--
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.NgayLap,
		--
		a.IDDanhMucSale,
		Sale.Ma MaDanhMucSale,
		a.IDDanhMucKhachHang,
		KhachHang.Ma MaDanhMucKhachHang,
		a.LoaiHinh, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
		case when a.LoaiHinh = 1 then N'Nhập' when a.LoaiHinh = 2 then N'Xuất' else N'Nội địa' end TenLoaiHinh,
		a.LoaiHang, --Loại hàng: 1: FCL, 2: LCL
		case when a.LoaiHang = 1 then N'FCL' else N'LCL' end TenLoaiHang,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		a.IDDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ma MaDanhMucDiaDiemNangCont,
		a.NgayNangCont,
		a.IDDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ma MaDanhMucDiaDiemHaCont,
		a.NgayHaCont,
		a.SoLuongCont20,
		a.SoCont20,
		a.SoLuongCont40,
		a.SoCont40,
		a.SoLuongCont45,
		a.SoCont45,
		a.IDDanhMucDiaDiemDongHang,
		DiaDiemDongHang.Ma MaDanhMucDiaDiemDongHang,
		a.NgayDongHang,
		a.IDDanhMucDiaDiemTraHang,
		DiaDiemTraHang.Ma MaDanhMucDiaDiemTraHang,
		a.NgayTraHang,
		a.KhoiLuong,			--Nếu là hàng rời
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
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
	from ctKeHoachVanTai a
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID

		left join DanhMucDiaDiemGiaoNhan DiaDiemNangCont on a.IDDanhMucDiaDiemNangCont = DiaDiemNangCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemHaCont on a.IDDanhMucDiaDiemHaCont = DiaDiemHaCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemDongHang on a.IDDanhMucDiaDiemDongHang = DiaDiemDongHang.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemTraHang on a.IDDanhMucDiaDiemTraHang = DiaDiemTraHang.ID

		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and cast(a.NgayLap as date) >= @TuNgay
		and cast(a.NgayLap as date) <= @DenNgay
		and case when @ID is not null then a.ID else -1 end = isnull(@ID, -1)
	order by a.NgayLap;
end;
go
---------------
alter procedure List_ctKeHoachVanTai
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
		a.IDDanhMucChungTuTrangThai,
		a.So,
		a.NgayLap,
		--
		a.IDDanhMucSale,
		Sale.Ma MaDanhMucSale,
		a.IDDanhMucKhachHang,
		KhachHang.Ma MaDanhMucKhachHang,
		a.LoaiHinh, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
		case when a.LoaiHinh = 1 then N'Nhập' when a.LoaiHinh = 2 then N'Xuất' else N'Nội địa' end TenLoaiHinh,
		a.LoaiHang, --Loại hàng: 1: FCL, 2: LCL
		case when a.LoaiHang = 1 then N'FCL' else N'LCL' end TenLoaiHang,
		a.IDDanhMucHangTau,
		HangTau.Ma MaDanhMucHangTau,
		a.IDDanhMucDiaDiemNangCont,
		DiaDiemNangCont.Ma MaDanhMucDiaDiemNangCont,
		a.NgayNangCont,
		a.IDDanhMucDiaDiemHaCont,
		DiaDiemHaCont.Ma MaDanhMucDiaDiemHaCont,
		a.NgayHaCont,
		a.SoLuongCont20,
		a.SoCont20,
		a.SoLuongCont40,
		a.SoCont40,
		a.SoLuongCont45,
		a.SoCont45,
		a.IDDanhMucDiaDiemDongHang,
		DiaDiemDongHang.Ma MaDanhMucDiaDiemDongHang,
		a.NgayDongHang,
		a.IDDanhMucDiaDiemTraHang,
		DiaDiemTraHang.Ma MaDanhMucDiaDiemTraHang,
		a.NgayTraHang,
		a.KhoiLuong,			--Nếu là hàng rời
		a.NguoiGiaoNhan,
		a.SoDienThoaiGiaoNhan,
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
	from ctKeHoachVanTai a
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucDoiTuong HangTau on a.IDDanhMucHangTau = HangTau.ID

		left join DanhMucDiaDiemGiaoNhan DiaDiemNangCont on a.IDDanhMucDiaDiemNangCont = DiaDiemNangCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemHaCont on a.IDDanhMucDiaDiemHaCont = DiaDiemHaCont.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemDongHang on a.IDDanhMucDiaDiemDongHang = DiaDiemDongHang.ID
		left join DanhMucDiaDiemGiaoNhan DiaDiemTraHang on a.IDDanhMucDiaDiemTraHang = DiaDiemTraHang.ID

		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
		left join DanhMucNguoiSuDung UserDelete on a.IDDanhMucNguoiSuDungDelete = UserDelete.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu and a.ID = @ID;
end;
go
------------------
alter procedure Insert_ctKeHoachVanTai
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
	@LoaiHinh						tinyint, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
	@LoaiHang						tinyint, --Loại hàng: 1: FCL, 2: LCL
	@IDDanhMucHangTau				bigint = null,
	@IDDanhMucDiaDiemNangCont		bigint = null,
	@NgayNangCont					datetime = null,
	@IDDanhMucDiaDiemHaCont			bigint = null,
	@NgayHaCont						datetime = null,
	@SoLuongCont20					int = null,
	@SoCont20						nvarchar(512) = null,
	@SoLuongCont40					int = null,
	@SoCont40						nvarchar(512) = null,
	@SoLuongCont45					int = null,
	@SoCont45						nvarchar(512) = null,
	@IDDanhMucDiaDiemDongHang		bigint = null,
	@NgayDongHang					datetime = null,
	@IDDanhMucDiaDiemTraHang		bigint = null,
	@NgayTraHang					datetime = null,
	@KhoiLuong						float = null,			--Nếu là hàng rời
	@NguoiGiaoNhan					nvarchar(128) = null,
	@SoDienThoaiGiaoNhan			nvarchar(128) = null,
	@GhiChu							nvarchar(max) = null,
	--
	@IDDanhMucNguoiSuDungCreate		bigint
)
as
begin
	set nocount on;
	declare @Err int, @ErrMsg nvarchar(max);
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE()
	begin tran
	begin try
	--Đánh số chứng từ
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctKeHoachVanTai';
	declare @KyHieu nvarchar(20), @ctCount int, @ThuTu nvarchar(5);
	select @KyHieu = KiHieu from DanhMucChungTu where ID = @IDDanhMucChungTu;
	select @ctCount = ISNULL(MAX(CAST(RIGHT(SO, 5) AS INT)), 0) + 1 from ctKeHoachVanTai; -- where cast(NgayLap as date) = cast(@NgayLap as date);
	set @ThuTu = RIGHT('00000'+ISNULL(cast(@ctCount as nvarchar(5)),''),5);
	--set @So = @KyHieu + CONVERT(VARCHAR(8), @NgayLap, 112) + '-' + @ThuTu;
	set @So = @KyHieu + @ThuTu;
	--
	insert	into ctKeHoachVanTai
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
		LoaiHinh,
		LoaiHang,
		IDDanhMucHangTau,
		IDDanhMucDiaDiemNangCont,
		NgayNangCont,
		IDDanhMucDiaDiemHaCont,
		NgayHaCont,
		SoLuongCont20,
		SoCont20,
		SoLuongCont40,
		SoCont40,
		SoLuongCont45,
		SoCont45,
		IDDanhMucDiaDiemDongHang,
		NgayDongHang,
		IDDanhMucDiaDiemTraHang,
		NgayTraHang,
		KhoiLuong,
		NguoiGiaoNhan,
		SoDienThoaiGiaoNhan,
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
		@LoaiHinh,
		@LoaiHang,
		@IDDanhMucHangTau,
		@IDDanhMucDiaDiemNangCont,
		@NgayNangCont,
		@IDDanhMucDiaDiemHaCont,
		@NgayHaCont,
		@SoLuongCont20,
		@SoCont20,
		@SoLuongCont40,
		@SoCont40,
		@SoLuongCont45,
		@SoCont45,
		@IDDanhMucDiaDiemDongHang,
		@NgayDongHang,
		@IDDanhMucDiaDiemTraHang,
		@NgayTraHang,
		@KhoiLuong,
		@NguoiGiaoNhan,
		@SoDienThoaiGiaoNhan,
		@GhiChu,
		--
		@IDDanhMucNguoiSuDungCreate,
		@NgayCapNhat
	);
	commit tran
	end try
	begin catch
		rollback
		select @ErrMsg = error_message();
		raiserror(@ErrMsg, 16, 1);
	end catch
	set @Err = @@Error;
	return @Err;
end
go
------------------
alter procedure Update_ctKeHoachVanTai
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
	@LoaiHinh						tinyint, --Loại hình: 1: nhập, 2: xuất, 3: nội địa
	@LoaiHang						tinyint, --Loại hàng: 1: FCL, 2: LCL
	@IDDanhMucHangTau				bigint = null,
	@IDDanhMucDiaDiemNangCont		bigint = null,
	@NgayNangCont					datetime = null,
	@IDDanhMucDiaDiemHaCont			bigint = null,
	@NgayHaCont						datetime = null,
	@SoLuongCont20					int = null,
	@SoCont20						nvarchar(512) = null,
	@SoLuongCont40					int = null,
	@SoCont40						nvarchar(512) = null,
	@SoLuongCont45					int = null,
	@SoCont45						nvarchar(512) = null,
	@IDDanhMucDiaDiemDongHang		bigint = null,
	@NgayDongHang					datetime = null,
	@IDDanhMucDiaDiemTraHang		bigint = null,
	@NgayTraHang					datetime = null,
	@KhoiLuong						float = null,			--Nếu là hàng rời
	@NguoiGiaoNhan					nvarchar(128) = null,
	@SoDienThoaiGiaoNhan			nvarchar(128) = null,
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
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctKeHoachVanTai where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungEdit
	begin
		raiserror(N'Bạn không có quyền sửa đơn hàng của người khác!', 16, 1);
		return;
	end;
	begin
		begin tran
		begin try
		update ctKeHoachVanTai
			set
				IDDanhMucSale = @IDDanhMucSale,
				IDDanhMucKhachHang = @IDDanhMucKhachHang,
				LoaiHinh = @LoaiHinh,
				LoaiHang = @LoaiHang,
				IDDanhMucHangTau = @IDDanhMucHangTau,
				IDDanhMucDiaDiemNangCont = @IDDanhMucDiaDiemNangCont,
				NgayNangCont = @NgayNangCont,
				IDDanhMucDiaDiemHaCont = @IDDanhMucDiaDiemHaCont,
				NgayHaCont = @NgayHaCont,
				SoLuongCont20 = @SoLuongCont20,
				SoCont20 = @SoCont20,
				SoLuongCont40 = @SoLuongCont40,
				SoCont40 = @SoCont40,
				SoLuongCont45 = @SoLuongCont45,
				SoCont45 = @SoCont45,
				IDDanhMucDiaDiemDongHang = @IDDanhMucDiaDiemDongHang,
				NgayDongHang = @NgayDongHang,
				IDDanhMucDiaDiemTraHang = @IDDanhMucDiaDiemTraHang,
				NgayTraHang = @NgayTraHang,
				KhoiLuong = @KhoiLuong,
				NguoiGiaoNhan = @NguoiGiaoNhan,
				SoDienThoaiGiaoNhan = @SoDienThoaiGiaoNhan,
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
alter procedure Delete_ctKeHoachVanTai
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
	select @IDDanhMucNguoiSuDungCreate = IDDanhMucNguoiSuDungCreate from ctKeHoachVanTai where ID = @ID;
	if @IDDanhMucNguoiSuDungCreate <> @IDDanhMucNguoiSuDungDelete
	begin
		raiserror(N'Bạn không có quyền xóa kế hoạch của người khác!', 16, 1);
		return;
	end
	else
	begin
		begin tran
		begin try
		delete from ctKeHoachVanTai where ID = @ID;
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
end
go
