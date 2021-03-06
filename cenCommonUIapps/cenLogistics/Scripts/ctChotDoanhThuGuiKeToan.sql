/*
create table ctChotDoanhThuGuiKeToan
(
	ID								bigint not null,
	IDDanhMucDonVi					bigint not null,
	IDDanhMucChungTu				bigint not null,
	--
	IDChungTu						bigint not null,
	--
	GhiChu							nvarchar(max),
	IDDanhMucNguoiSuDungCreate		bigint	not null,
	CreateDate						datetime not null,
	IDDanhMucNguoiSuDungEdit		bigint,
	EditDate						datetime,
	constraint PK_ctChotDoanhThuGuiKeToan primary key (ID),
	constraint ctChotDoanhThuGuiKeToan_AutoID foreign key (ID) references AutoID(ID),
	constraint DonVi_ctChotDoanhThuGuiKeToan foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint DanhMucChungTu_ctChotDoanhThuGuiKeToan foreign key (IDDanhMucChungTu) references DanhMucChungTu(ID),
	constraint ChungTu_ctChotDoanhThuGuiKeToan foreign key (IDChungTu) references ctDonHang(ID),
	--
	constraint UserCreate_ctChotDoanhThuGuiKeToan foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint UserEdit_ctChotDoanhThuGuiKeToan foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
*/
---------------
alter procedure List_ctChotDoanhThuGuiKeToan
	@IDDanhMucDonVi		bigint,
	@IDDanhMucChungTu	bigint,
	@TuNgay				date = null,
	@DenNgay			date = null,
	@IDDanhMucKhachHang	bigint = null,
	@IDDanhMucSale		bigint = null

as
begin
	set nocount on;
	--
	if @TuNgay is null set @TuNgay = '2020-01-01';
	if @DenNgay is null set @DenNgay = '2030-01-01';
	--
	create table #ChungTuChuaChotDoanhThu
	(
		ID							bigint,
		IDDanhMucDonVi				bigint,
		IDDanhMucChungTu			bigint,
		IDDanhMucChungTuTrangThai	bigint,
		IDctChotDoanhThuGuiKeToan	bigint,
		LuaChon						bit,
		So							nvarchar(35),
		NgayLap						datetime,
		--
		DebitNote					nvarchar(128),
		BillBooking					nvarchar(128),
		NgayDongTraHang				date,
		TenDanhMucSale				nvarchar(255),
		TenDanhMucKhachHang			nvarchar(255),
		TenDanhMucTuyenVanTai		nvarchar(255),
		SoTienCuoc					float,
		SoTienThuTuc				float,
		SoTienDoanhThuKhac			float,
		SoTienHoaHong				float,
		SoTienTrichPhanTram			float,
		TongGiamDoanhThu			float,
		GhiChu						nvarchar(max),
		--
		IDDanhMucNguoiSuDungCreate	bigint,
		MaDanhMucNguoiSuDungCreate	nvarchar(128),
		CreateDate					datetime,
		IDDanhMucNguoiSuDungEdit	bigint,
		MaDanhMucNguoiSuDungEdit	nvarchar(128),
		EditDate					datetime
	);
	--
	create table #ChungTuDaChotDoanhThu
	(
		ID							bigint,
		IDDanhMucDonVi				bigint,
		IDDanhMucChungTu			bigint,
		IDDanhMucChungTuTrangThai	bigint,
		IDctChotDoanhThuGuiKeToan	bigint,
		LuaChon						bit,
		So							nvarchar(35),
		NgayLap						datetime,
		--
		DebitNote					nvarchar(128),
		BillBooking					nvarchar(128),
		NgayDongTraHang				date,
		TenDanhMucSale				nvarchar(255),
		TenDanhMucKhachHang			nvarchar(255),
		TenDanhMucTuyenVanTai		nvarchar(255),
		SoTienCuoc					float,
		SoTienThuTuc				float,
		SoTienDoanhThuKhac			float,
		SoTienHoaHong				float,
		SoTienTrichPhanTram			float,
		TongGiamDoanhThu			float,
		GhiChu						nvarchar(max),
		--
		IDDanhMucNguoiSuDungCreate	bigint,
		MaDanhMucNguoiSuDungCreate	nvarchar(128),
		CreateDate					datetime,
		IDDanhMucNguoiSuDungEdit	bigint,
		MaDanhMucNguoiSuDungEdit	nvarchar(128),
		EditDate					datetime
	);
	--
	insert into #ChungTuChuaChotDoanhThu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		null,
		0 LuaChon,
		a.So,
		a.NgayLap,
		--
		a.DebitNote,
		a.BillBooking,
		isnull(a.NgayDongHang, a.NgayTraHang),
		DanhMucSale.Ten TenDanhMucSale,
		KhachHang.Ten TenDanhMucKhachHang,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		a.SoTienCuoc,
		a.SoTienThuTuc,
		a.SoTienDoanhThuKhac,
		a.SoTienHoaHong,
		ROUND(a.SoTienCuoc * 1.3 / 100, 0) SoTienTrichPhanTram,
		isnull(a.SoTienHoaHong, 0) +  ROUND(isnull(a.SoTienCuoc, 0) * 1.3 / 100, 0)  TongGiamDoanhThu,
		a.GhiChu,
		--
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate
	from ctDonHang a
		left join ctChotDoanhThuGuiKeToan on a.ID = ctChotDoanhThuGuiKeToan.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucNhanSu DanhMucSale on a.IDDanhMucSale = DanhMucSale.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
		and ctChotDoanhThuGuiKeToan.IDChungTu is null
		and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	insert into #ChungTuDaChotDoanhThu
	select 
		a.ID,
		a.IDDanhMucDonVi,
		a.IDDanhMucChungTu,
		a.IDDanhMucChungTuTrangThai,
		ctChotDoanhThuGuiKeToan.ID,
		0 LuaChon,
		a.So,
		a.NgayLap,
		--
		a.DebitNote,
		a.BillBooking,
		isnull(a.NgayDongHang, a.NgayTraHang),
		DanhMucSale.Ten TenDanhMucSale,
		KhachHang.Ten TenDanhMucKhachHang,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		a.SoTienCuoc,
		a.SoTienThuTuc,
		a.SoTienDoanhThuKhac,
		a.SoTienHoaHong,
		ROUND(a.SoTienCuoc * 1.3 / 100, 0) SoTienTrichPhanTram,
		isnull(a.SoTienHoaHong, 0) +  ROUND(isnull(a.SoTienCuoc, 0) * 1.3 / 100, 0)  TongGiamDoanhThu,
		a.GhiChu,
		--
		a.IDDanhMucNguoiSuDungCreate,
		UserCreate.Ma MaDanhMucNguoiSuDungCreate,
		a.CreateDate,
		a.IDDanhMucNguoiSuDungEdit,
		UserEdit.Ma MaDanhMucNguoiSuDungEdit,
		a.EditDate
	from ctDonHang a
		inner join ctChotDoanhThuGuiKeToan on a.ID = ctChotDoanhThuGuiKeToan.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucNhanSu DanhMucSale on a.IDDanhMucSale = DanhMucSale.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
		left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.IDDanhMucChungTu = @IDDanhMucChungTu
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	select * from #ChungTuChuaChotDoanhThu;
	select * from #ChungTuDaChotDoanhThu;
	--
	drop table #ChungTuChuaChotDoanhThu;
	drop table #ChungTuDaChotDoanhThu;
end;
go
------------------
alter procedure Insert_ctChotDoanhThuGuiKeToan
(
	@ID										bigint = null output,
	@IDDanhMucDonVi							bigint,
	@IDDanhMucChungTu						bigint,
	--
	@IDChungTu								bigint,
	--
	@IDDanhMucNguoiSuDungCreate				bigint,
	@CreateDate								datetime = null output
)
as
begin
	set nocount on;
	declare @Err int;
	select @CreateDate = GETDATE();
	begin tran
	begin try
	
	--
	exec Insert_AutoID @ID out, @TenBangDuLieu = N'ctChotDoanhThuGuiKeToan';
	insert	into ctChotDoanhThuGuiKeToan
	(
		ID,
		IDDanhMucDonVi,
		IDDanhMucChungTu,
		--
		IDChungTu,
		--
		IDDanhMucNguoiSuDungCreate,
		CreateDate
	)
	values
	(
		@ID,
		@IDDanhMucDonVi,
		@IDDanhMucChungTu,
		--
		@IDChungTu,
		--
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
--
alter procedure Delete_ctChotDoanhThuGuiKeToan
(
	@ID	bigint
)
as
begin
	set nocount on;
	declare @Err int;
	declare @NgayCapNhat datetime;
	select @NgayCapNhat = GETDATE()
	begin tran
	begin try
	--
	delete from ctChotDoanhThuGuiKeToan where ID = @ID;
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
