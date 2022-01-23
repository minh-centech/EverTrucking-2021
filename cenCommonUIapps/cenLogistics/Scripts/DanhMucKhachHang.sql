/*
drop table DanhMucKhachHang
--luôn luôn mặc định khách hàng là Fn, nếu có F2, F1 thì khai báo F2, F1
create table DanhMucKhachHang
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	Ma							nvarchar(128)	not null,
	Ten							nvarchar(255)	not null,
	--
	IDDanhMucNhanSu				bigint			not null,
	DiaChi						nvarchar(512),
	SoDienThoai					nvarchar(128),
	SoFax						nvarchar(128),
	Email						nvarchar(255),
	MaSoThue					nvarchar(20),
	TenNganHang					nvarchar(255),
	SoTaiKhoan					nvarchar(255),
	NguoiDaiDien				nvarchar(255),
	NguoiGiaoNhan				nvarchar(255),
	SoDienThoaiGiaoNhan			nvarchar(255),
	IDDanhMucTuyenVanTai		bigint,
	GhiChu						nvarchar(512),
	--
	IDDanhMucNguoiSuDungCreate	bigint			not null,
	CreateDate					datetime		not null,
	IDDanhMucNguoiSuDungEdit	bigint,
	EditDate					datetime,
	constraint	PK_DanhMucKhachHang primary key (ID),
	constraint	DanhMucKhachHang_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucKhachHang foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucKhachHang foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	constraint	Ma_DanhMucKhachHang unique(Ma),
	--
	constraint	DanhMucNhanSu_DanhMucKhachHang foreign key (IDDanhMucNhanSu) references DanhMucNhanSu(ID),
	constraint	DanhMucTuyenVanTai_DanhMucKhachHang foreign key (IDDanhMucTuyenVanTai) references DanhMucTuyenVanTai(ID),
	--
	constraint	DanhMucNguoiSuDungCreate_DanhMucKhachHang foreign key (IDDanhMucNguoiSuDungCreate) references DanhMucNguoiSuDung(ID),
	constraint	DanhMucNguoiSuDungEdit_DanhMucKhachHang foreign key (IDDanhMucNguoiSuDungEdit) references DanhMucNguoiSuDung(ID)
)
go
create index idx_KhachHang_Ma on DanhMucKhachHang (Ma);
create index idx_KhachHang_Ten on DanhMucKhachHang (Ten);

create table DanhMucKhachHangPhanCap
(
	ID							bigint			not null,
	IDDanhMucDonVi				bigint			not null,
	IDDanhMucLoaiDoiTuong		bigint			not null,
	--
	IDDanhMucKhachHang			bigint			not null, --giả định khách hàng luôn luôn là Fn
	IDDanhMucKhachHangF2		bigint,
	IDDanhMucKhachHangF1		bigint			not null,
	GhiChu						nvarchar(512)
	constraint	PK_DanhMucKhachHangPhanCap primary key (ID),
	constraint	DanhMucKhachHangPhanCap_DanhMucDoiTuong foreign key (ID) references DanhMucDoiTuong(ID),
	constraint	DanhMucDonVi_DanhMucKhachHangPhanCap foreign key (IDDanhMucDonVi) references DanhMucDonVi(ID),
	constraint	DanhMucLoaiDoiTuong_DanhMucKhachHangPhanCap foreign key (IDDanhMucLoaiDoiTuong) references DanhMucLoaiDoiTuong(ID),
	--
	constraint DanhMucKhachHang_DanhMucKhachHangPhanCap foreign key (IDDanhMucKhachHang) references DanhMucKhachHang(ID),
	constraint DanhMucKhachHangF2_DanhMucKhachHangPhanCap foreign key (IDDanhMucKhachHangF2) references DanhMucKhachHang(ID),
	constraint DanhMucKhachHangF1_DanhMucKhachHangPhanCap foreign key (IDDanhMucKhachHangF1) references DanhMucKhachHang(ID)
)
go
*/
alter procedure List_DanhMucKhachHang
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
	@Level tinyint = 0,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		into #DanhMucKhachHang
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @ID is not null then a.ID else -1 end = ISNULL(@ID, -1) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by a.Ma;
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.IDDanhMucKhachHang,
			a.IDDanhMucKhachHangF1, KhachHangF1.Ma MaDanhMucKhachHangF1, KhachHangF1.Ten TenDanhMucKhachHangF1,
			a.IDDanhMucKhachHangF2, KhachHangF2.Ma MaDanhMucKhachHangF2, KhachHangF2.Ten TenDanhMucKhachHangF2,
			a.GhiChu
		into #DanhMucKhachHangPhanCap
		from DanhMucKhachHangPhanCap a 
			left join DanhMucKhachHang KhachHangF2 on a.IDDanhMucKhachHangF2 = KhachHangF2.ID
			left join DanhMucKhachHang KhachHangF1 on a.IDDanhMucKhachHangF1 = KhachHangF1.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucKhachHang in (select ID from #DanhMucKhachHang)
	--order by a.Ma;
	--
	select * from #DanhMucKhachHang;
	select * from #DanhMucKhachHangPhanCap;
	--
	drop table #DanhMucKhachHangPhanCap;
	drop table #DanhMucKhachHang;


	--if (@Level = 0) --List toàn bộ danh mục khách hàng
	--begin
	--	select	a.ID, 
	--			a.IDDanhMucDonVi, 
	--			a.IDDanhMucLoaiDoiTuong, 
	--			--
	--			a.Ma,
	--			a.Ten,
	--			a.IDDanhMucNhanSu,
	--			NhanSu.Ten TenDanhMucNhanSu,
	--			a.DiaChi,
	--			a.SoDienThoai,
	--			a.SoFax,
	--			a.Email,
	--			a.MaSoThue,
	--			a.TenNganHang,
	--			a.SoTaiKhoan,
	--			a.NguoiDaiDien,
	--			a.NguoiGiaoNhan,
	--			a.SoDienThoaiGiaoNhan,
	--			a.IDDanhMucKhachHangF2, KhachHangF2.Ten TenDanhMucKhachHangF2,
	--			a.IDDanhMucKhachHangF1, KhachHangF1.Ten TenDanhMucKhachHangF1,
	--			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
	--			a.GhiChu,
	--			--
	--			a.Ten + case when a.DiaChi is null then '' else ' - ' + a.DiaChi end TenDiaChi,
	--			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
	--			a.CreateDate, 
	--			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
	--			a.EditDate 
	--		from DanhMucKhachHang a 
	--			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
	--			left join DanhMucKhachHang KhachHangF2 on a.IDDanhMucKhachHangF2 = KhachHangF2.ID
	--			left join DanhMucKhachHang KhachHangF1 on a.IDDanhMucKhachHangF1 = KhachHangF1.ID
	--			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	--			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
	--			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	--	where 
	--		a.IDDanhMucDonVi = @IDDanhMucDonVi
	--		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
	--		and case when @ID is not null then a.ID else -1 end = ISNULL(@ID, -1) 
	--		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	--	order by a.Ma;
	--end;
	--if (@Level = 1)
	--begin
	--	select	a.ID, 
	--			a.IDDanhMucDonVi, 
	--			a.IDDanhMucLoaiDoiTuong, 
	--			--
	--			a.Ma,
	--			a.Ten,
	--			a.IDDanhMucNhanSu,
	--			NhanSu.Ten TenDanhMucNhanSu,
	--			a.DiaChi,
	--			a.SoDienThoai,
	--			a.SoFax,
	--			a.Email,
	--			a.MaSoThue,
	--			a.TenNganHang,
	--			a.SoTaiKhoan,
	--			a.NguoiDaiDien,
	--			a.NguoiGiaoNhan,
	--			a.SoDienThoaiGiaoNhan,
	--			a.IDDanhMucKhachHangF2, KhachHangF2.Ten TenDanhMucKhachHangF2,
	--			a.IDDanhMucKhachHangF1, KhachHangF1.Ten TenDanhMucKhachHangF1,
	--			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
	--			a.GhiChu,
	--			--
	--			a.Ten + case when a.DiaChi is null then '' else ' - ' + a.DiaChi end TenDiaChi,
	--			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
	--			a.CreateDate, 
	--			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
	--			a.EditDate 
	--		from DanhMucKhachHang a 
	--			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
	--			left join DanhMucKhachHang KhachHangF2 on a.IDDanhMucKhachHangF2 = KhachHangF2.ID
	--			left join DanhMucKhachHang KhachHangF1 on a.IDDanhMucKhachHangF1 = KhachHangF1.ID
	--			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	--			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
	--			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	--	where 
	--		a.IDDanhMucDonVi = @IDDanhMucDonVi
	--		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
	--		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
	--		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	--	order by a.Ma;
	--end;
	--if (@Level = 2)
	--begin
	--	select	a.ID, 
	--			a.IDDanhMucDonVi, 
	--			a.IDDanhMucLoaiDoiTuong, 
	--			--
	--			a.Ma,
	--			a.Ten,
	--			a.IDDanhMucNhanSu,
	--			NhanSu.Ten TenDanhMucNhanSu,
	--			a.DiaChi,
	--			a.SoDienThoai,
	--			a.SoFax,
	--			a.Email,
	--			a.MaSoThue,
	--			a.TenNganHang,
	--			a.SoTaiKhoan,
	--			a.NguoiDaiDien,
	--			a.NguoiGiaoNhan,
	--			a.SoDienThoaiGiaoNhan,
	--			a.IDDanhMucKhachHangF2, KhachHangF2.Ten TenDanhMucKhachHangF2,
	--			a.IDDanhMucKhachHangF1, KhachHangF1.Ten TenDanhMucKhachHangF1,
	--			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
	--			a.GhiChu,
	--			--
	--			a.Ten + case when a.DiaChi is null then '' else ' - ' + a.DiaChi end TenDiaChi,
	--			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
	--			a.CreateDate, 
	--			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
	--			a.EditDate 
	--		from DanhMucKhachHang a 
	--			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
	--			left join DanhMucKhachHang KhachHangF2 on a.IDDanhMucKhachHangF2 = KhachHangF2.ID
	--			left join DanhMucKhachHang KhachHangF1 on a.IDDanhMucKhachHangF1 = KhachHangF1.ID
	--			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	--			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
	--			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	--	where 
	--		a.IDDanhMucDonVi = @IDDanhMucDonVi
	--		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
	--		and a.IDDanhMucKhachHangF2 is null
	--		and a.IDDanhMucKhachHangF1 is not null
	--		and a.IDDanhMucKhachHangF1 = @IDDanhMucKhachHangF1
	--		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
	--		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	--	order by a.Ma;
	--end;
	--if (@Level = 3)
	--begin
	--	select	a.ID, 
	--			a.IDDanhMucDonVi, 
	--			a.IDDanhMucLoaiDoiTuong, 
	--			--
	--			a.Ma,
	--			a.Ten,
	--			a.IDDanhMucNhanSu,
	--			NhanSu.Ten TenDanhMucNhanSu,
	--			a.DiaChi,
	--			a.SoDienThoai,
	--			a.SoFax,
	--			a.Email,
	--			a.MaSoThue,
	--			a.TenNganHang,
	--			a.SoTaiKhoan,
	--			a.NguoiDaiDien,
	--			a.NguoiGiaoNhan,
	--			a.SoDienThoaiGiaoNhan,
	--			a.IDDanhMucKhachHangF2, KhachHangF2.Ten TenDanhMucKhachHangF2,
	--			a.IDDanhMucKhachHangF1, KhachHangF1.Ten TenDanhMucKhachHangF1,
	--			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
	--			a.GhiChu,
	--			--
	--			a.Ten + case when a.DiaChi is null then '' else ' - ' + a.DiaChi end TenDiaChi,
	--			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
	--			a.CreateDate, 
	--			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
	--			a.EditDate 
	--		from DanhMucKhachHang a 
	--			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
	--			left join DanhMucKhachHang KhachHangF2 on a.IDDanhMucKhachHangF2 = KhachHangF2.ID
	--			left join DanhMucKhachHang KhachHangF1 on a.IDDanhMucKhachHangF1 = KhachHangF1.ID
	--			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	--			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
	--			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	--	where 
	--		a.IDDanhMucDonVi = @IDDanhMucDonVi
	--		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
	--		and a.IDDanhMucKhachHangF2 is not null
	--		and a.IDDanhMucKhachHangF1 is not null
	--		and a.IDDanhMucKhachHangF2 = @IDDanhMucKhachHangF2
	--		and a.IDDanhMucKhachHangF1 = @IDDanhMucKhachHangF1
	--		and case when @ID is not null then a.ID else 0 end = ISNULL(@ID, 0) 
	--		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	--	order by a.Ma;
	--end;
end
go
--
alter procedure Insert_DanhMucKhachHang
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucNhanSu			bigint = null,
	@DiaChi						nvarchar(512) = null,
	@SoDienThoai				nvarchar(128) = null,
	@SoFax						nvarchar(128) = null,
	@Email						nvarchar(255) = null,
	@MaSoThue					nvarchar(20) = null,
	@TenNganHang				nvarchar(255) = null,
	@SoTaiKhoan					nvarchar(255) = null,
	@NguoiDaiDien				nvarchar(255) = null,
	@NguoiGiaoNhan				nvarchar(255) = null,
	@SoDienThoaiGiaoNhan		nvarchar(255) = null,
	@IDDanhMucTuyenVanTai		bigint = null,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_DanhMucDoiTuong @ID out, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, @Ma, @Ten, @IDDanhMucNguoiSuDungCreate, @CreateDate out;
		insert DanhMucKhachHang 
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			Ma,
			Ten,
			IDDanhMucNhanSu,
			DiaChi,
			SoDienThoai,
			SoFax,
			Email,
			MaSoThue,
			TenNganHang,
			SoTaiKhoan,
			NguoiDaiDien,
			NguoiGiaoNhan,
			SoDienThoaiGiaoNhan,
			IDDanhMucTuyenVanTai,
			GhiChu,
			IDDanhMucNguoiSuDungCreate, 
			CreateDate
		) 
		values 
		(	
			@ID, 
			@IDDanhMucDonVi, 
			@IDDanhMucLoaiDoiTuong, 
			@Ma, 
			@Ten, 
			isnull(@IDDanhMucNhanSu, 308),
			@DiaChi,
			@SoDienThoai,
			@SoFax,
			@Email,
			@MaSoThue,
			@TenNganHang,
			@SoTaiKhoan,
			@NguoiDaiDien,
			@NguoiGiaoNhan,
			@SoDienThoaiGiaoNhan,
			@IDDanhMucTuyenVanTai,
			@GhiChu,
			@IDDanhMucNguoiSuDungCreate, 
			@CreateDate
		);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
--
alter procedure Update_DanhMucKhachHang
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@Ma							nvarchar(128),
	@Ten						nvarchar(255),
	@IDDanhMucNhanSu			bigint = null,
	@DiaChi						nvarchar(512) = null,
	@SoDienThoai				nvarchar(128) = null,
	@SoFax						nvarchar(128) = null,
	@Email						nvarchar(255) = null,
	@MaSoThue					nvarchar(20) = null,
	@TenNganHang				nvarchar(255) = null,
	@SoTaiKhoan					nvarchar(255) = null,
	@NguoiDaiDien				nvarchar(255) = null,
	@NguoiGiaoNhan				nvarchar(255) = null,
	@SoDienThoaiGiaoNhan		nvarchar(255) = null,
	@IDDanhMucTuyenVanTai		bigint = null,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Update_DanhMucDoiTuong @ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, @Ma, @Ten, @IDDanhMucNguoiSuDungEdit, @EditDate out
		update DanhMucKhachHang set
			Ma = @Ma,
			Ten = @Ten,
			IDDanhMucNhanSu = isnull(@IDDanhMucNhanSu, 308),
			DiaChi = @DiaChi,
			SoDienThoai = @SoDienThoai,
			SoFax = @SoFax,
			Email = @Email,
			MaSoThue = @MaSoThue,
			TenNganHang = @TenNganHang,
			SoTaiKhoan = @SoTaiKhoan,
			NguoiDaiDien = @NguoiDaiDien,
			NguoiGiaoNhan = @NguoiGiaoNhan,
			SoDienThoaiGiaoNhan = @SoDienThoaiGiaoNhan,
			IDDanhMucTuyenVanTai = @IDDanhMucTuyenVanTai,
			GhiChu = @GhiChu,
			IDDanhMucNguoiSuDungEdit = @IDDanhMucNguoiSuDungEdit,
			EditDate = @EditDate
		where ID = @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
--
--
alter procedure Delete_DanhMucKhachHang
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try

		declare @IDChiTiet bigint;
		--
		declare curCT cursor for select ID from DanhMucKhachHangPhanCap where IDDanhMucKhachHang = @ID;
		open curCT;
		fetch next from curCT into @IDChiTiet
		while @@FETCH_STATUS = 0
		begin
			delete from DanhMucKhachHangPhanCap where ID = @IDChiTiet;
			exec Delete_DanhMucDoiTuong @IDChiTiet;
			delete from AutoID where ID = @IDChiTiet;
			fetch next from curCT into @IDChiTiet;
		end;
		deallocate curCT;

		delete DanhMucKhachHang	where ID = @ID;
		exec Delete_DanhMucDoiTuong @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
---
alter procedure Insert_DanhMucKhachHangPhanCap
	@ID							bigint out,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@IDDanhMucKhachHang			bigint,
	@IDDanhMucKhachHangF2		bigint = null,
	@IDDanhMucKhachHangF1		bigint,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungCreate	bigint,
	@CreateDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Insert_DanhMucDoiTuong @ID out, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, null, null, @IDDanhMucNguoiSuDungCreate, @CreateDate out;
		insert DanhMucKhachHangPhanCap
		(	
			ID, 
			IDDanhMucDonVi, 
			IDDanhMucLoaiDoiTuong, 
			IDDanhMucKhachHang,
			IDDanhMucKhachHangF2,
			IDDanhMucKhachHangF1,
			GhiChu
		) 
		values 
		(	
			@ID, 
			@IDDanhMucDonVi, 
			@IDDanhMucLoaiDoiTuong, 
			@IDDanhMucKhachHang,
			@IDDanhMucKhachHangF2,
			@IDDanhMucKhachHangF1,
			@GhiChu
		);
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
--
alter procedure Update_DanhMucKhachHangPhanCap
	@ID							bigint,
	@IDDanhMucDonVi				bigint,
	@IDDanhMucLoaiDoiTuong		bigint,
	@IDDanhMucKhachHang			bigint,
	@IDDanhMucKhachHangF2		bigint = null,
	@IDDanhMucKhachHangF1		bigint,
	@GhiChu						nvarchar(512) = null,
	@IDDanhMucNguoiSuDungEdit	bigint,
	@EditDate					datetime = null out
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		exec Update_DanhMucDoiTuong @ID, @IDDanhMucDonVi, @IDDanhMucLoaiDoiTuong, null, null, @IDDanhMucNguoiSuDungEdit, @EditDate out
		update DanhMucKhachHangPhanCap set
			IDDanhMucKhachHang = @IDDanhMucKhachHang,
			IDDanhMucKhachHangF2 = @IDDanhMucKhachHangF2,
			IDDanhMucKhachHangF1 = @IDDanhMucKhachHangF1,
			GhiChu = @GhiChu
		where ID = @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
--
--
alter procedure Delete_DanhMucKhachHangPhanCap
	@ID			bigint
as
begin
	set nocount on;
	declare @ErrMsg nvarchar(max);
	begin tran
	begin try
		delete DanhMucKhachHangPhanCap	where ID = @ID;
		exec Delete_DanhMucDoiTuong @ID;
	commit tran
	end try
	begin catch
		if @@TRANCOUNT > 0 rollback tran;
		select @ErrMsg = ERROR_MESSAGE()
		raiserror(@ErrMsg, 16, 1)
	end catch
end
go
---
alter procedure List_DanhMucKhachHang_Valid
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and case when @ID is not null then a.ID else -1 end = ISNULL(@ID, -1) 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
	order by a.Ma;
end
go
---
alter procedure List_DanhMucKhachHang_ValidF1
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		into #DanhMucKhachHang
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
		and (a.ID in (select IDDanhMucKhachHangF1 from DanhMucKhachHangPhanCap) or a.ID not in (select IDDanhMucKhachHang from (select IDDanhMucKhachHang from DanhMucKhachHangPhanCap union all select IDDanhMucKhachHangF2 from DanhMucKhachHangPhanCap union all select IDDanhMucKhachHangF1 from DanhMucKhachHangPhanCap) T where T.IDDanhMucKhachHang is not null));
	if @ID is not null
	begin
		insert into #DanhMucKhachHang
		select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and a.ID = @ID
		and a.ID not in (select ID from #DanhMucKhachHang);
	end;
	--
	select * from #DanhMucKhachHang order by Ma;
	--
	drop table #DanhMucKhachHang;
end
go
---
alter procedure List_DanhMucKhachHang_ValidF2
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
	@IDDanhMucKhachHangF1 bigint = null,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		into #DanhMucKhachHang
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
		and (a.ID in (select IDDanhMucKhachHangF2 from DanhMucKhachHangPhanCap where IDDanhMucKhachHangF1 = @IDDanhMucKhachHangF1))-- or a.ID not in (select IDDanhMucKhachHang from (select IDDanhMucKhachHang from DanhMucKhachHangPhanCap union all select IDDanhMucKhachHangF2 from DanhMucKhachHangPhanCap union all select IDDanhMucKhachHangF1 from DanhMucKhachHangPhanCap) T where T.IDDanhMucKhachHang is not null));
	if @ID is not null
	begin
		insert into #DanhMucKhachHang
		select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and a.ID = @ID
		and a.ID not in (select ID from #DanhMucKhachHang);
	end;
	--
	select * from #DanhMucKhachHang order by Ma;
	--
	drop table #DanhMucKhachHang;
end
go
---
alter procedure List_DanhMucKhachHang_ValidF3
	@ID bigint = null,
	@IDDanhMucDonVi bigint,
	@IDDanhMucLoaiDoiTuong bigint = null,
	@IDDanhMucKhachHangF1 bigint = null,
	@IDDanhMucKhachHangF2 bigint = null,
	@SearchStr nvarchar(255) = null
as
begin
	set nocount on;
	if @SearchStr is null set @SearchStr = '%' else set @SearchStr = '%' + @SearchStr + '%';
	--
	select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		into #DanhMucKhachHang
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and (a.Ma like @SearchStr or a.Ten like @SearchStr)
		and (a.ID in (select IDDanhMucKhachHang from DanhMucKhachHangPhanCap where IDDanhMucKhachHangF1 = @IDDanhMucKhachHangF1 and case when @IDDanhMucKhachHangF2 is not null then IDDanhMucKhachHangF2 else -1 end = isnull(@IDDanhMucKhachHangF2, -1))) --or a.ID not in (select IDDanhMucKhachHang from (select IDDanhMucKhachHang from DanhMucKhachHangPhanCap union all select IDDanhMucKhachHangF2 from DanhMucKhachHangPhanCap union all select IDDanhMucKhachHangF1 from DanhMucKhachHangPhanCap) T where T.IDDanhMucKhachHang is not null));
	if @ID is not null
	begin
		insert into #DanhMucKhachHang
		select	a.ID, 
			a.IDDanhMucDonVi, 
			a.IDDanhMucLoaiDoiTuong, 
			--
			a.Ma,
			a.Ten,
			a.IDDanhMucNhanSu,
			NhanSu.Ten TenDanhMucNhanSu,
			a.DiaChi,
			a.SoDienThoai,
			a.SoFax,
			a.Email,
			a.MaSoThue,
			a.TenNganHang,
			a.SoTaiKhoan,
			a.NguoiDaiDien,
			a.NguoiGiaoNhan,
			a.SoDienThoaiGiaoNhan,
			a.IDDanhMucTuyenVanTai, TuyenVanTai.Ten TenDanhMucTuyenVanTai,
			a.GhiChu,
			--
			a.IDDanhMucNguoiSuDungCreate, UserCreate.Ma MaDanhMucNguoiSuDungCreate, 
			a.CreateDate, 
			a.IDDanhMucNguoiSuDungEdit, UserEdit.Ma MaDanhMucNguoiSuDungEdit, 
			a.EditDate 
		from DanhMucKhachHang a 
			left join DanhMucNhanSu NhanSu on a.IDDanhMucNhanSu = NhanSu.ID
			left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
			left join DanhMucNguoiSuDung UserCreate on a.IDDanhMucNguoiSuDungCreate = UserCreate.ID
			left join DanhMucNguoiSuDung UserEdit on a.IDDanhMucNguoiSuDungEdit = UserEdit.ID
	where 
		a.IDDanhMucDonVi = @IDDanhMucDonVi
		and a.IDDanhMucLoaiDoiTuong = @IDDanhMucLoaiDoiTuong 
		and a.ID = @ID
		and a.ID not in (select ID from #DanhMucKhachHang);
	end;
	--
	select * from #DanhMucKhachHang order by Ma;
	--
	drop table #DanhMucKhachHang;
end
go