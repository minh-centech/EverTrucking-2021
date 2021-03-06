/*
create table ctSuaChua
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	IDDanhMucChungTuTrangThai		bigint not null,
	So								nvarchar(35) not null,
	NgayLap							datetime not null,
	--
	IDDanhMucXe						bigint,
	NgaySuaChua						datetime not null,
	NoiDungSuaChua					nvarchar(max),
	NoiSuaChua						nvarchar(512),
	SoKmDongHo						int,
	DonViTinh						nvarchar(128),
	SoLuong							float,
	DonGiaNhanCong					float,
	SoTienNhanCong					float,
	DonGiaVatTu						float,
	SoTienVatTu						float, 
	SoTien							float,
	ThoiGianBaoHanh					datetime,
	NguoiSuaChua					nvarchar(255),
	--
	GhiChu							nvarchar(max),
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctSuaChua primary key (ID),
	constraint ctSuaChua_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctSuaChua foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctSuaChua foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint DanhMucChungTuTrangThai_ctSuaChua foreign key (IDDanhMucChungTuTrangThai) references DanhMucChungTuTrangThai(ID),
	constraint So_ctSuaChua unique (So),
	--
	constraint DanhMucXe_ctSuaChua foreign key (IDDanhMucXe) references DanhMucXe(ID),
	--
	constraint UserCreate_ctSuaChua foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctSuaChua foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctSuaChua
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@ID					bigint = null,
	@TuNgay				date = null,
	@DenNgay			date = null,
	@IDDanhMucXe		bigint = null
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
		a.NgayLap,
		--
		a.IDDanhMucXe,
		Xe.BienSo,
		a.NgaySuaChua,
		a.NoiDungSuaChua,
		a.NoiSuaChua,
		a.SoKmDongHo,
		a.DonViTinh,
		a.SoLuong,
		a.DonGiaNhanCong,
		a.SoTienNhanCong,
		a.DonGiaVatTu,
		a.SoTienVatTu,
		a.SoTien,
		a.ThoiGianBaoHanh,
		a.NguoiSuaChua,
		a.GhiChu,
		--
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate
	from ctSuaChua a
		left join DanhMucXe Xe on a.IDDanhMucXe = Xe.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu 
		and cast(a.NgaySuaChua as date) >= @TuNgay and cast(a.NgaySuaChua as date) <= @DenNgay
		and case when @ID is not null then a.ID else 0 end = isnull(@ID, 0)
		and case when @IDDanhMucXe is not null then a.IDDanhMucXe else 0 end = isnull(@IDDanhMucXe, 0)
	order by a.NgaySuaChua, Xe.BienSo;
end;
go
------------------
alter procedure Insert_ctSuaChua
(
	@ID								bigint = null output,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	@IDDanhMucChungTuTrangThai		bigint,
	@So								nvarchar(35) = null output,
	@NgayLap						datetime,
	--
	@IDDanhMucXe					bigint = null,
	@NgaySuaChua					datetime,
	@NoiDungSuaChua					nvarchar(max) = null,
	@NoiSuaChua						nvarchar(512) = null,
	@SoKmDongHo						int = null,
	@DonViTinh						nvarchar(128) = null,
	@SoLuong						float = null,
	@DonGiaNhanCong					float = null,
	@SoTienNhanCong					float = null,
	@DonGiaVatTu					float = null,
	@SoTienVatTu					float = null,
	@SoTien							float = null,
	@ThoiGianBaoHanh				datetime = null,
	@NguoiSuaChua					nvarchar(255) = null,
	--
	@GhiChu							nvarchar(255) = null,
	@IDDanhMucNguoiSuDungCreate		bigint,
	@CreateDate						datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	set @CreateDate = GETDATE()
	begin tran
	begin try
	--Đánh số chứng từ
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctSuaChua';
	declare @KyHieu nvarchar(20), @ctCount int, @ThuTu nvarchar(5);
	select @KyHieu = KiHieu from DanhMucChungTu where ID = @IDDanhMucChungTu;
	select @ctCount = ISNULL(MAX(CAST(RIGHT(SO, 5) AS INT)), 0) + 1 from ctSuaChua; -- where cast(NgayLap as date) = cast(@NgayLap as date);
	set @ThuTu = RIGHT('00000'+ISNULL(cast(@ctCount as nvarchar(5)),''),5);
	--set @So = @KyHieu + CONVERT(VARCHAR(8), @NgayLap, 112) + '-' + @ThuTu;
	set @So = @KyHieu + @ThuTu;
	--
	insert	into ctSuaChua
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		IDDanhMucChungTuTrangThai,
		So,
		NgayLap,
		--
		IDDanhMucXe,
		NgaySuaChua,
		NoiDungSuaChua,
		NoiSuaChua,
		SoKmDongHo,
		DonViTinh,
		SoLuong,
		DonGiaNhanCong,
		SoTienNhanCong,
		DonGiaVatTu,
		SoTienVatTu,
		SoTien,
		ThoiGianBaoHanh,
		NguoiSuaChua,
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
		@IDDanhMucChungTuTrangThai,
		@So,
		@NgayLap,
		--
		@IDDanhMucXe,
		@NgaySuaChua,
		@NoiDungSuaChua,
		@NoiSuaChua,
		@SoKmDongHo,
		@DonViTinh,
		@SoLuong,
		@DonGiaNhanCong,
		@SoTienNhanCong,
		@DonGiaVatTu,
		@SoTienVatTu,
		@SoTien,
		@ThoiGianBaoHanh,
		@NguoiSuaChua,
		--
		@GhiChu,
		@IDDanhMucNguoiSuDungCreate,
		@CreateDate
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
alter procedure Update_ctSuaChua
(
	@ID								bigint,
	@IDDanhMucDonVi					bigint,
	@IDDanhMucChungTu				bigint,
	@IDDanhMucChungTuTrangThai		bigint,
	--
	@IDDanhMucXe					bigint = null,
	@NgaySuaChua					datetime,
	@NoiDungSuaChua					nvarchar(max) = null,
	@NoiSuaChua						nvarchar(512) = null,
	@SoKmDongHo						int = null,
	@DonViTinh						nvarchar(128) = null,
	@SoLuong						float = null,
	@DonGiaNhanCong					float = null,
	@SoTienNhanCong					float = null,
	@DonGiaVatTu					float = null,
	@SoTienVatTu					float = null,
	@SoTien							float = null,
	@ThoiGianBaoHanh				datetime = null,
	@NguoiSuaChua					nvarchar(255) = null,
	--
	@GhiChu							nvarchar(255) = null,
	@IDDanhMucNguoiSuDungEdit		bigint,
	@EditDate						datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @EditDate = GETDATE()
	begin tran
	begin try
	update ctSuaChua
		set
			IDDanhMucChungTuTrangThai = @IDDanhMucChungTuTrangThai,
			--
			IDDanhMucXe = @IDDanhMucXe,
			NgaySuaChua = @NgaySuaChua,
			NoiDungSuaChua = @NoiDungSuaChua,
			NoiSuaChua = @NoiSuaChua,
			SoKmDongHo = @SoKmDongHo,
			DonViTinh = @DonViTinh,
			SoLuong = @SoLuong,
			DonGiaNhanCong = @DonGiaNhanCong,
			SoTienNhanCong = @SoTienNhanCong,
			DonGiaVatTu = @DonGiaVatTu,
			SoTienVatTu = @SoTienVatTu,
			SoTien = @SoTien,
			ThoiGianBaoHanh = @ThoiGianBaoHanh,
			NguoiSuaChua = @NguoiSuaChua,
			--
			GhiChu = @GhiChu,
			IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
			EditDate = @EditDate
		where ID = @ID;
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
alter procedure Delete_ctSuaChua
(
	@ID	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	begin tran
	begin try
	--
	delete from ctSuaChua where ID = @ID;
	delete from AutoID where ID = @ID;
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
