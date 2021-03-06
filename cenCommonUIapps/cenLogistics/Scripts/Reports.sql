ALTER procedure [dbo].[rep_BC_CHI_PHI_VAN_TAI]
		@IDDanhMucDonVi bigint,
		@TuNgay date,
		@DenNgay date,
		@IDDanhMucNhomHangVanChuyen bigint = null,
		@IDDanhMucSale bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2020-12-31',
--		@IDDanhMucNhomHangVanChuyen bigint = null,
--		@IDDanhMucSale bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt								bigint identity(1, 1),
		IDctDonHang						bigint,
		DebitNote						nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		TenDanhMucTaiXe					nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo_ChuXeNgoai				nvarchar(128),
		NgayLenhDieuXe					nvarchar(10),
		SoLuongNhienLieu				float,
		SoTienVeCauDuong				float,
		SoTienLuatAnCa					float,
		SoTienKetHopVeCauDuongLuatAnCa	float,
		SoTienLuuCaKhac					float, 
		SoTienLuatDuongCam				float,
		SoTienTongLuuCaKhacLuatDuongCam	float,
		SoTienLuongChuyen				float,
		SoTienLuongChuNhat				float,
		SoTienLuongTong					float,
		SoTienCuocThueXeNgoai			float,
		SoTienLuuCaThueXeNgoai			float,
		SoTienTongThueXeNgoai			float,
		SoTienTamUng					float,
		SoTienChenhLech					float,
		GhiChu							nvarchar(max),
		SoDonHang						nvarchar(128)
	);
	insert into #Report
	(
		IDctDonHang,
		DebitNote,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		TenDanhMucTaiXe,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		NgayLenhDieuXe,
		SoLuongNhienLieu,
		SoTienVeCauDuong,
		SoTienLuatAnCa,
		SoTienKetHopVeCauDuongLuatAnCa,
		SoTienLuuCaKhac,
		SoTienLuatDuongCam,
		SoTienTongLuuCaKhacLuatDuongCam,
		SoTienLuongChuyen,
		SoTienLuongChuNhat,
		SoTienLuongTong,
		SoTienCuocThueXeNgoai,
		SoTienLuuCaThueXeNgoai,
		SoTienTongThueXeNgoai,
		SoTienTamUng,
		SoTienChenhLech,
		GhiChu,
		SoDonHang
	)
	select
		a.ID IDctDonHang,
		a.DebitNote DebiNote,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		case when ctDieuHanh.IDDanhMucThauPhu not in (9307, 10614) then ChuXe.Ten else TaiXe.Ten end,
		ChuXe.KyHieuKeToan MaDanhMucChuXe,
		case when ctDieuHanh.IDDanhMucThauPhu not in (9307, 10614) then ChuXe.Ma else Xe.BienSo end,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103) NgayLenhDieuXe,
		ctChiPhiVanTai.SoLuongNhienLieu,
		ctChiPhiVanTai.SoTienVeCauDuong,
		ctChiPhiVanTai.SoTienLuatAnCa,
		ctChiPhiVanTai.SoTienKetHopVeCauDuongLuatAnCa,
		ctChiPhiVanTai.SoTienLuuCaKhac,
		ctChiPhiVanTai.SoTienLuatDuongCam,
		isnull(ctChiPhiVanTai.SoTienVeCauDuong, 0) + isnull(ctChiPhiVanTai.SoTienLuatAnCa, 0) + isnull(ctChiPhiVanTai.SoTienKetHopVeCauDuongLuatAnCa, 0) + isnull(ctChiPhiVanTai.SoTienLuuCaKhac, 0) + isnull(ctChiPhiVanTai.SoTienLuatDuongCam, 0),
		ctChiPhiVanTai.SoTienLuongChuyen,
		ctChiPhiVanTai.SoTienLuongChuNhat,
		ISNULL(ctChiPhiVanTai.SoTienLuongChuyen, 0) + ISNULL(ctChiPhiVanTai.SoTienLuongChuNhat, 0) SoTienLuongTong,
		ctChiPhiVanTai.SoTienCuocThueXeNgoai,
		null SoTienLuuCaThueXeNgoai,
		ctChiPhiVanTai.SoTienCuocThueXeNgoai SoTienTongThueXeNgoai,
		null SoTienTamUng,
		null SoTienChenhLech,
		ctChiPhiVanTai.GhiChu,
		a.So
	from ctDonHang a
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
		left join ctChiPhiVanTai on a.ID = ctChiPhiVanTai.IDChungTu
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
	order by isnull(a.NgayDongHang, a.NgayTraHang);
	--update số tiền đã tạm ứng, số tiền chênh lệch
	update #Report set SoTienTamUng = T.SoTienTamUng
		from #Report left join (select IDChungTu, SUM(isnull(SoTienCuocVo, 0) + isnull(SoTienHaiQuan, 0) + isnull(SoTienNangHa, 0) + isnull(SoTienChiKhac, 0)) SoTienTamUng from ctDonHangChiTietTamUng group by IDChungTu) T
		on #Report.IDctDonHang = T.IDChungTu;
	update #Report set SoTienChenhLech = ISNULL(SoTienVeCauDuong, 0) + ISNULL(SoTienLuatAnCa, 0) + ISNULL(SoTienVeCauDuong, 0) + ISNULL(SoTienKetHopVeCauDuongLuatAnCa, 0) 
										+ ISNULL(SoTienLuuCaKhac, 0) + ISNULL(SoTienLuatDuongCam, 0) - ISNULL(SoTienTamUng, 0);
	--
	insert into #Report
	(
		DebitNote,
		SoLuongNhienLieu,
		SoTienVeCauDuong,
		SoTienLuatAnCa,
		SoTienKetHopVeCauDuongLuatAnCa,
		SoTienLuuCaKhac,
		SoTienLuatDuongCam,
		SoTienTongLuuCaKhacLuatDuongCam,
		SoTienLuongChuyen,
		SoTienLuongChuNhat,
		SoTienLuongTong,
		SoTienCuocThueXeNgoai,
		SoTienTongThueXeNgoai,
		SoTienTamUng,
		SoTienChenhLech
	)
	select
		N'TỔNG CỘNG',
		sum(SoLuongNhienLieu),
		sum(SoTienVeCauDuong),
		sum(SoTienLuatAnCa),
		sum(SoTienKetHopVeCauDuongLuatAnCa),
		sum(SoTienLuuCaKhac),
		sum(SoTienLuatDuongCam),
		sum(SoTienTongLuuCaKhacLuatDuongCam),
		sum(SoTienLuongChuyen),
		sum(SoTienLuongChuNhat),
		sum(SoTienLuongTong),
		sum(SoTienCuocThueXeNgoai),
		sum(SoTienTongThueXeNgoai),
		sum(SoTienTamUng),
		sum(SoTienChenhLech)
	from #Report;
	--
	select * from #Report order by Stt;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_CHI_PHI_VAN_TAI_BO_SUNG]
		@IDDanhMucDonVi bigint,
		@TuNgay date,
		@DenNgay date,
		@IDDanhMucNhomHangVanChuyen bigint = null,
		@IDDanhMucSale bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2020-12-31',
--		@IDDanhMucNhomHangVanChuyen bigint = null,
--		@IDDanhMucSale bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt								bigint identity(1, 1),
		IDctDonHang						bigint,
		DebitNote						nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		TenDanhMucTaiXe					nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo_ChuXeNgoai				nvarchar(128),
		NgayLenhDieuXe					nvarchar(10),
		SoLuongNhienLieu				float,
		SoTienVeCauDuong				float,
		SoTienLuatAnCa					float,
		SoTienKetHopVeCauDuongLuatAnCa	float,
		SoTienLuuCaKhac					float, 
		SoTienLuatDuongCam				float,
		SoTienTongLuuCaKhacLuatDuongCam	float,
		SoTienLuongChuyen				float,
		SoTienLuongChuNhat				float,
		SoTienLuongTong					float,
		SoTienCuocThueXeNgoai			float,
		SoTienLuuCaThueXeNgoai			float,
		SoTienTongThueXeNgoai			float,
		GhiChu							nvarchar(max),
		SoDonHang						nvarchar(128),
		NgayBoSung						nvarchar(10)
	);
	insert into #Report
	(
		IDctDonHang,
		DebitNote,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		TenDanhMucTaiXe,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		NgayLenhDieuXe,
		SoLuongNhienLieu,
		SoTienVeCauDuong,
		SoTienLuatAnCa,
		SoTienKetHopVeCauDuongLuatAnCa,
		SoTienLuuCaKhac,
		SoTienLuatDuongCam,
		SoTienTongLuuCaKhacLuatDuongCam,
		SoTienLuongChuyen,
		SoTienLuongChuNhat,
		SoTienLuongTong,
		SoTienCuocThueXeNgoai,
		SoTienLuuCaThueXeNgoai,
		SoTienTongThueXeNgoai,
		GhiChu,
		SoDonHang,
		NgayBoSung
	)
	select
		a.ID IDctDonHang,
		a.DebitNote DebiNote,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		case when ctDieuHanh.IDDanhMucThauPhu not in (9307, 10614) then ChuXe.Ten else TaiXe.Ten end,
		ChuXe.KyHieuKeToan MaDanhMucChuXe,
		case when ctDieuHanh.IDDanhMucThauPhu not in (9307, 10614) then ChuXe.Ma else Xe.BienSo end,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103) NgayLenhDieuXe,
		ctChiPhiVanTaiBoSung.SoLuongNhienLieu,
		ctChiPhiVanTaiBoSung.SoTienVeCauDuong,
		ctChiPhiVanTaiBoSung.SoTienLuatAnCa,
		ctChiPhiVanTaiBoSung.SoTienKetHopVeCauDuongLuatAnCa,
		ctChiPhiVanTaiBoSung.SoTienLuuCaKhac,
		ctChiPhiVanTaiBoSung.SoTienLuatDuongCam,
		isnull(ctChiPhiVanTaiBoSung.SoTienVeCauDuong, 0) + isnull(ctChiPhiVanTaiBoSung.SoTienLuatAnCa, 0) + isnull(ctChiPhiVanTaiBoSung.SoTienKetHopVeCauDuongLuatAnCa, 0) + isnull(ctChiPhiVanTaiBoSung.SoTienLuuCaKhac, 0) + isnull(ctChiPhiVanTaiBoSung.SoTienLuatDuongCam, 0),
		ctChiPhiVanTaiBoSung.SoTienLuongChuyen,
		ctChiPhiVanTaiBoSung.SoTienLuongChuNhat,
		ISNULL(ctChiPhiVanTaiBoSung.SoTienLuongChuyen, 0) + ISNULL(ctChiPhiVanTaiBoSung.SoTienLuongChuNhat, 0) SoTienLuongTong,
		ctChiPhiVanTaiBoSung.SoTienCuocThueXeNgoai,
		null SoTienLuuCaThueXeNgoai,
		ctChiPhiVanTaiBoSung.SoTienCuocThueXeNgoai SoTienTongThueXeNgoai,
		ctChiPhiVanTaiBoSung.GhiChu,
		a.So,
		convert(nvarchar(10), ctChiPhiVanTaiBoSung.NgayBoSung, 103)
	from ctDonHang a
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
		left join ctChiPhiVanTaiBoSung on a.ID = ctChiPhiVanTaiBoSung.IDChungTu
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and ctChiPhiVanTaiBoSung.ID is not null and a.Huy is null
		and ctChiPhiVanTaiBoSung.NgayBoSung >= @TuNgay and ctChiPhiVanTaiBoSung.NgayBoSung <= @DenNgay
		and case when @IDDanhMucNhomHangVanChuyen is not null then a.IDDanhMucNhomHangVanChuyen else -1 end = isnull(@IDDanhMucNhomHangVanChuyen, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
	order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	insert into #Report
	(
		DebitNote,
		SoLuongNhienLieu,
		SoTienVeCauDuong,
		SoTienLuatAnCa,
		SoTienKetHopVeCauDuongLuatAnCa,
		SoTienLuuCaKhac,
		SoTienLuatDuongCam,
		SoTienTongLuuCaKhacLuatDuongCam,
		SoTienLuongChuyen,
		SoTienLuongChuNhat,
		SoTienLuongTong,
		SoTienCuocThueXeNgoai,
		SoTienTongThueXeNgoai
	)
	select
		N'TỔNG CỘNG',
		sum(SoLuongNhienLieu),
		sum(SoTienVeCauDuong),
		sum(SoTienLuatAnCa),
		sum(SoTienKetHopVeCauDuongLuatAnCa),
		sum(SoTienLuuCaKhac),
		sum(SoTienLuatDuongCam),
		sum(SoTienTongLuuCaKhacLuatDuongCam),
		sum(SoTienLuongChuyen),
		sum(SoTienLuongChuNhat),
		sum(SoTienLuongTong),
		sum(SoTienCuocThueXeNgoai),
		sum(SoTienTongThueXeNgoai)
	from #Report;
	--
	select * from #Report order by Stt;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_DOANHTHU_KD]
	@IDDanhMucDonVi bigint,
	@TuNgay date,
	@DenNgay date,
	@IDDanhMucKhachHang bigint = null,
	@IDDanhMucSale bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2020-12-31',
--		@IDDanhMucKhachHang bigint = null,
--		@IDDanhMucSale bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt							bigint identity(1, 1),
		DebitNote					nvarchar(128),
		MaDanhMucKhachHang			nvarchar(128),
		MaDanhMucTuyenVanTai		nvarchar(128),
		TenDanhMucTuyenVanTai		nvarchar(255),
		MaDanhMucChuXe				nvarchar(128),
		BienSo						nvarchar(128),
		NgayDongTraHang				nvarchar(10),
		SoTienThuTuc				float,
		SoTienCuoc					float,
		SoTienDoanhThuKhac			float,
		SoTienDoanhThu				float,
		ThoiHanThanhToan			nvarchar(10),
		SoTienHoaHong				float,
		SoTienPhanTram				float,
		SoTienGiamDoanhThu			float,
		GhiChu						nvarchar(max)
	);
	insert into #Report
	select
		a.DebitNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		ChuXe.Ma MaDanhMucChuXe,
		Xe.BienSo,
		convert(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103),
		a.SoTienThuTuc,
		a.SoTienCuoc,
		a.SoTienDoanhThuKhac,
		isnull(a.SoTienThuTuc, 0) + isnull(a.SoTienCuoc, 0) + isnull(a.SoTienDoanhThuKhac, 0) SoTienDoanhThu,
		convert(nvarchar(10), a.ThoiHanThanhToan, 103),
		a.SoTienHoaHong,
		round(isnull(a.SoTienCuoc, 0) * 1.3 / 100, 0) SoTienPhanTram,
		isnull(a.SoTienHoaHong, 0) + round(isnull(a.SoTienCuoc, 0) * 1.3 / 100, 0) SoTienGiamDoanhThu,
		a.GhiChu
	from ctDonHang a
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
	order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	insert into #Report
	(
		DebitNote,
		SoTienThuTuc,
		SoTienCuoc,
		SoTienDoanhThuKhac,
		SoTienDoanhThu,
		SoTienHoaHong,
		SoTienPhanTram,
		SoTienGiamDoanhThu
	)
	select
		N'TỔNG CỘNG',
		sum(SoTienThuTuc),
		sum(SoTienCuoc),
		sum(SoTienDoanhThuKhac),
		sum(SoTienDoanhThu),
		sum(SoTienHoaHong),
		sum(SoTienPhanTram),
		sum(SoTienGiamDoanhThu)
	from #Report;
	--
	select * from #Report;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_DOANHTHU_KD_CNKH]
	@IDDanhMucDonVi bigint,
	@TuNgay date,
	@DenNgay date,
	@IDDanhMucKhachHang bigint = null,
	@IDDanhMucSale bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2020-12-31',
--		@IDDanhMucKhachHang bigint = null,
--		@IDDanhMucSale bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt							bigint identity(1, 1),
		MaDanhMucKhachHang			nvarchar(128),
		TenDanhMucKhachHang			nvarchar(255),
		SoTienCuoc					float,
		SoTienThuTuc				float,
		SoTienDoanhThuKhac			float,
		SoTienHoaHong				float,
		SoTienDoanhThu				float
	);
	insert into #Report
	select
		KhachHang.Ma MaDanhMucKhachHang,
		KhachHang.Ten TenDanhMucKhachHang,
		sum(a.SoTienCuoc),
		sum(a.SoTienThuTuc),
		sum(a.SoTienDoanhThuKhac),
		sum(a.SoTienHoaHong),
		sum(isnull(a.SoTienThuTuc, 0)) + sum(isnull(a.SoTienCuoc, 0)) + sum(isnull(a.SoTienDoanhThuKhac, 0)) - sum(isnull(a.SoTienHoaHong, 0)) SoTienDoanhThu
	from ctDonHang a
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
	group by KhachHang.Ma, KhachHang.Ten
	order by KhachHang.Ma;
	--
	insert into #Report
	(
		TenDanhMucKhachHang,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoTienDoanhThu
	)
	select
		N'TỔNG CỘNG',
		sum(SoTienCuoc),
		sum(SoTienThuTuc),
		sum(SoTienDoanhThuKhac),
		sum(SoTienDoanhThu)
	from #Report;
	--
	select * from #Report;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_DOANHTHU_KT]
		@IDDanhMucDonVi bigint,
		@TuNgay date,
		@DenNgay date,
		@IDDanhMucKhachHang bigint = null,
		@IDDanhMucSale bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2021-12-31',
--		@IDDanhMucKhachHang bigint = null,
--		@IDDanhMucSale bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt								bigint identity(1, 1),
		IDctDonHang						bigint,
		DebitNote						nvarchar(128),
		MaDanhMucKhachHang				nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo_ChuXeNgoai				nvarchar(128),
		SoTienThuTuc					float,
		SoTienCuoc						float,
		ThoiHanThanhToan				nvarchar(10),
		SoTienHoaHong					float,
		TrichLaiCongTy					float,
		SoTienGiamDoanhThu				float,
		GhiChu							nvarchar(max),
		MaTaiKhoanDoanhThu				nvarchar(128),
		[1%]							float,
		[MaDanhMucNhaCungCapTrich1%]	nvarchar(255),
		[0.3%]							float,
		[MaNCCTrich0.3%]				nvarchar(255),
		MaTaiKhoanChietKhau				nvarchar(128),
		MaDoanhThuHaiQuan				nvarchar(128),
		MaHoaHongGuiGia					nvarchar(128)
	);
	insert into #Report
	(
		IDctDonHang,
		DebitNote,
		MaDanhMucKhachHang,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		SoTienThuTuc,
		SoTienCuoc,
		ThoiHanThanhToan,
		SoTienHoaHong,
		TrichLaiCongTy,
		SoTienGiamDoanhThu,
		GhiChu,
		MaTaiKhoanDoanhThu,
		[1%],
		[0.3%],
		[MaNCCTrich0.3%],
		MaTaiKhoanChietKhau,
		MaDoanhThuHaiQuan
	)
	select
		a.ID IDctDonHang,
		a.DebitNote DebiNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		ChuXe.Ma MaDanhMucChuXe,
		Xe.BienSo,
		a.SoTienThuTuc,
		isnull(a.SoTienCuoc, 0) + isnull(a.SoTienDoanhThuKhac, 0),
		convert(nvarchar(10), a.ThoiHanThanhToan, 103),
		a.SoTienHoaHong,
		ROUND((ISNULL(a.SoTienCuoc, 0) - ISNULL(a.SoTienHoaHong, 0)) * 1.3 / 100, 0),
		ISNULL(a.SoTienHoaHong, 0) + ROUND((ISNULL(a.SoTienCuoc, 0) - ISNULL(a.SoTienHoaHong, 0)) * 1.3 / 100, 0),
		a.GhiChu,
		Xe.MaTaiKhoanDoanhThu,
		ROUND((ISNULL(a.SoTienCuoc, 0) - ISNULL(a.SoTienHoaHong, 0)) * 1 / 100, 0),
		ROUND((ISNULL(a.SoTienCuoc, 0) - ISNULL(a.SoTienHoaHong, 0)) * 0.3 / 100, 0),
		'NCC00046',
		Xe.MaTaiKhoanChietKhau,
		case when a.SoTienThuTuc is not null and a.SoTienThuTuc <> 0 then N'513' else '0' end
	from ctDonHang a
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
		--left join DanhMucDoiTuong [NhaCungCapTrich1%] on Sale.Ma = [NhaCungCapTrich1%].Ma
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
	order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	insert into #Report
	(
		
		DebitNote,
		SoTienThuTuc,
		SoTienCuoc,
		SoTienHoaHong,
		TrichLaiCongTy,
		SoTienGiamDoanhThu,
		[1%],
		[0.3%]
	)
	select
		N'Tổng cộng',
		SUM(SoTienThuTuc),
		SUM(SoTienCuoc),
		SUM(SoTienHoaHong),
		SUM(TrichLaiCongTy),
		SUM(SoTienGiamDoanhThu),
		SUM([1%]),
		SUM([0.3%])
	from #Report;
	--
	select * from #Report;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_LOINHUAN_KD]
		@IDDanhMucDonVi bigint,
		@TuNgay date,
		@DenNgay date,
		@IDDanhMucKhachHang bigint = null,
		@IDDanhMucSale bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2021-12-31',
--		@IDDanhMucKhachHang bigint = null,
--		@IDDanhMucSale bigint = null;
begin
	set nocount on;
	create table #Report --CHI_TIET
	(
		Stt								bigint identity(1, 1),
		IDctDonHang						bigint,
		SoDonHang						nvarchar(128),
		DebitNote						nvarchar(128),
		MaDanhMucKhachHang				nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo_ChuXeNgoai				nvarchar(128),
		TenDanhMucTaiXe					nvarchar(255),
		NgayDongTraHang					nvarchar(10),
		SoTienCuoc						float,
		SoTienThuTuc					float,
		SoTienDoanhThuKhac				float,
		SoLuongNhienLieu				float,
		SoTienNhienLieu					float,
		SoTienVeCauDuong				float,
		SoTienLuatAnCa					float,
		SoTienKetHopVeCauDuongLuatAnCa	float,
		SoTienLuuCaKhac					float, 
		SoTienLuatDuongCam				float,
		SoTienTongChiPhiChuyenDi		float,
		SoTienLuongChuyen				float,
		SoTienLuongChuNhat				float,
		SoTienLuongTong					float,
		SoTienCuocThueXeNgoai			float,
		SoTienLuuCaThueXeNgoai			float,
		SoTienTongThueXeNgoai			float,
		SoTienThuTucHaiQuan				float,
		SoTienHoaHong					float,
		[1%]							float,
		[0.3%]							float,
		SoTienTongChiPhiKhac			float,
		SoTienDoanhThuTong				float,
		SoTienChiPhiTong				float,
		SoTienLoiNhuan					float,
		GhiChu							nvarchar(max)
	);
	create table #Report1 --VIEW
	(
		Stt								bigint identity(1, 1),
		IDctDonHang						bigint,
		SoDonHang						nvarchar(128),
		DebitNote						nvarchar(128),
		MaDanhMucKhachHang				nvarchar(128),
		MaDanhMucTuyenVanTai			nvarchar(128),
		TenDanhMucTuyenVanTai			nvarchar(255),
		MaDanhMucChuXe					nvarchar(128),
		BienSo_ChuXeNgoai				nvarchar(128),
		TenDanhMucTaiXe					nvarchar(255),
		NgayDongTraHang					nvarchar(10),
		SoTienLoiNhuan					float,
		SoTienCuoc						float,
		SoTienThuTuc					float,
		SoTienDoanhThuKhac				float,
		SoTienDoanhThuTong				float,
		SoTienChiPhiVanTai				float,
		SoTienChiPhiThuTuc				float,
		SoTienChiPhiKhac				float,
		SoTienChiPhiTong				float,
		GhiChu							nvarchar(max)
	);
	insert into #Report
	(
		IDctDonHang,
		SoDonHang,
		DebitNote,
		MaDanhMucKhachHang,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		TenDanhMucTaiXe,
		NgayDongTraHang,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoTienDoanhThuTong,
		SoTienHoaHong,
		[1%],
		[0.3%],
		GhiChu
	)
	select
		a.ID IDctDonHang,
		a.So,
		a.DebitNote DebiNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		ChuXe.KyHieuKeToan,
		case when ctDieuHanh.IDDanhMucThauPhu not in (9307, 10614) then ChuXe.Ma else Xe.BienSo end,
		TaiXe.Ten,
		CONVERT(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103),
		a.SoTienCuoc,
		a.SoTienThuTuc,
		a.SoTienDoanhThuKhac,
		ISNULL(a.SoTienCuoc, 0) + ISNULL(a.SoTienThuTuc, 0) + ISNULL(a.SoTienDoanhThuKhac, 0) SoTienDoanhThuTong,
		a.SoTienHoaHong,
		ROUND((ISNULL(a.SoTienCuoc, 0) - ISNULL(a.SoTienHoaHong, 0)) * 1 / 100, 0),
		ROUND((ISNULL(a.SoTienCuoc, 0) - ISNULL(a.SoTienHoaHong, 0)) * 0.3 / 100, 0),
		a.GhiChu
	from ctDonHang a
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucTaiXe TaiXe on ctDieuHanh.IDDanhMucTaiXe = TaiXe.ID
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = isnull(@IDDanhMucKhachHang, -1)
		and case when @IDDanhMucSale is not null then a.IDDanhMucSale else -1 end = isnull(@IDDanhMucSale, -1)
	order by isnull(a.NgayDongHang, a.NgayTraHang), a.DebitNote;
	--update chi phí vận tải
	update #Report set
		SoLuongNhienLieu = ISNULL(T.SoLuongNhienLieu, 0), 
		SoTienVeCauDuong = ISNULL(T.SoTienVeCauDuong, 0),
		SoTienLuatAnCa = ISNULL(T.SoTienLuatAnCa, 0),
		SoTienKetHopVeCauDuongLuatAnCa = ISNULL(T.SoTienKetHopVeCauDuongLuatAnCa, 0),
		SoTienLuuCaKhac = ISNULL(T.SoTienLuuCaKhac, 0),
		SoTienLuatDuongCam = ISNULL(T.SoTienLuatDuongCam, 0),
		SoTienTongChiPhiChuyenDi = ISNULL(T.SoTienVeCauDuong, 0) + ISNULL(T.SoTienLuatAnCa, 0) + ISNULL(T.SoTienKetHopVeCauDuongLuatAnCa, 0) + ISNULL(T.SoTienLuuCaKhac, 0) + ISNULL(T.SoTienLuatDuongCam, 0),
		SoTienLuongChuyen = ISNULL(T.SoTienLuongChuyen, 0),
		SoTienLuongChuNhat = ISNULL(T.SoTienLuongChuNhat, 0),
		SoTienLuongTong = ISNULL(T.SoTienLuongChuyen, 0) + ISNULL(T.SoTienLuongChuNhat, 0),
		SoTienCuocThueXeNgoai = ISNULL(T.SoTienCuocThueXeNgoai, 0),
		SoTienTongThueXeNgoai = ISNULL(T.SoTienCuocThueXeNgoai, 0)
	from #Report inner join ctChiPhiVanTai T on #Report.IDctDonHang = T.IDChungTu;
	--
	update #Report set
		SoLuongNhienLieu = ISNULL(#Report.SoLuongNhienLieu, 0) + ISNULL(T.SoLuongNhienLieu, 0), 
		SoTienVeCauDuong = ISNULL(#Report.SoTienVeCauDuong, 0) + ISNULL(T.SoTienVeCauDuong, 0),
		SoTienLuatAnCa = ISNULL(#Report.SoTienLuatAnCa, 0) + ISNULL(T.SoTienLuatAnCa, 0),
		SoTienKetHopVeCauDuongLuatAnCa = ISNULL(#Report.SoTienKetHopVeCauDuongLuatAnCa, 0) + ISNULL(T.SoTienKetHopVeCauDuongLuatAnCa, 0),
		SoTienLuuCaKhac = ISNULL(#Report.SoTienLuuCaKhac, 0) + ISNULL(T.SoTienLuuCaKhac, 0),
		SoTienLuatDuongCam = ISNULL(#Report.SoTienLuatDuongCam, 0) + ISNULL(T.SoTienLuatDuongCam, 0),
		SoTienTongChiPhiChuyenDi = ISNULL(#Report.SoTienTongChiPhiChuyenDi, 0) + ISNULL(T.SoTienVeCauDuong, 0) + ISNULL(T.SoTienLuatAnCa, 0) + ISNULL(T.SoTienKetHopVeCauDuongLuatAnCa, 0) + ISNULL(T.SoTienLuuCaKhac, 0) + ISNULL(T.SoTienLuatDuongCam, 0),
		SoTienLuongChuyen = ISNULL(#Report.SoTienLuongChuyen, 0) + ISNULL(T.SoTienLuongChuyen, 0),
		SoTienLuongChuNhat = ISNULL(#Report.SoTienLuongChuNhat, 0) + ISNULL(T.SoTienLuongChuNhat, 0),
		SoTienLuongTong = ISNULL(#Report.SoTienLuongTong, 0) + ISNULL(T.SoTienLuongChuyen, 0) + ISNULL(T.SoTienLuongChuNhat, 0),
		SoTienCuocThueXeNgoai = ISNULL(#Report.SoTienCuocThueXeNgoai, 0) + ISNULL(T.SoTienCuocThueXeNgoai, 0),
		SoTienTongThueXeNgoai = ISNULL(#Report.SoTienTongThueXeNgoai, 0) + ISNULL(T.SoTienCuocThueXeNgoai, 0)
	from #Report inner join 
	(select IDChungTu,	SUM(ISNULL(SoLuongNhienLieu, 0)) SoLuongNhienLieu, SUM(ISNULL(SoTienVeCauDuong, 0)) SoTienVeCauDuong, SUM(ISNULL(SoTienLuatAnCa, 0)) SoTienLuatAnCa, SUM(ISNULL(SoTienKetHopVeCauDuongLuatAnCa, 0)) SoTienKetHopVeCauDuongLuatAnCa, 
						SUM(ISNULL(SoTienLuuCaKhac, 0)) SoTienLuuCaKhac, SUM(ISNULL(SoTienLuatDuongCam, 0)) SoTienLuatDuongCam, SUM(ISNULL(SoTienLuongChuyen, 0)) SoTienLuongChuyen, SUM(ISNULL(SoTienLuongChuNhat, 0)) SoTienLuongChuNhat, 
						SUM(ISNULL(SoTienCuocThueXeNgoai , 0)) SoTienCuocThueXeNgoai  from ctChiPhiVanTaiBoSung group by IDChungTu) T 
	on #Report.IDctDonHang = T.IDChungTu;
	--update số tiền nhiên liệu
	declare @IDctDonHang bigint, @Ngay datetime, @GiaNhienLieu float;
	declare curReport cursor for select IDctDonHang from #Report;
	open curReport;
	while @@fetch_status = 0
	begin
		select @Ngay = isnull(isnull(NgayDongHang, NgayTraHang), getdate()) from ctDonHang where ID = @IDctDonHang;
		select @Ngay = max(NgayGioApDung) from DanhMucGiaNhienLieu where NgayGioApDung <= @Ngay;
		set @GiaNhienLieu = (select top 1 DonGiaTruocThue from DanhMucGiaNhienLieu where NgayGioApDung = @Ngay);
		update #Report set SoTienNhienLieu = SoLuongNhienLieu * isnull(@GiaNhienLieu, 0) where IDctDonHang = @IDctDonHang;
		fetch next from curReport into @IDctDonHang;
	end;
	deallocate curReport;
	--update chi phí thủ tục hải quan
	--update tổng chi phí
	update #Report set SoTienTongChiPhiKhac = ISNULL(SoTienHoaHong, 0) + ISNULL([1%], 0) + ISNULL([0.3%], 0);
	update #Report set SoTienChiPhiTong = ISNULL(SoTienNhienLieu, 0) + ISNULL(SoTienVeCauDuong, 0) + ISNULL(SoTienLuatAnCa, 0)
										+ ISNULL(SoTienKetHopVeCauDuongLuatAnCa, 0) + ISNULL(SoTienLuuCaKhac, 0) + ISNULL(SoTienLuatDuongCam, 0)	
										+ ISNULL(SoTienLuongChuyen, 0) + ISNULL(SoTienLuongChuNhat, 0) + ISNULL(SoTienCuocThueXeNgoai, 0)  + ISNULL(SoTienThuTucHaiQuan, 0)  + ISNULL(SoTienHoaHong, 0)
										+ ISNULL([1%], 0) + ISNULL([0.3%], 0);
	update #Report set SoTienLoiNhuan = ISNULL(SoTienDoanhThuTong, 0) - ISNULL(SoTienChiPhiTong, 0);
	--
	insert into #Report1 --VIEW
	(
		IDctDonHang,
		SoDonHang,
		DebitNote,
		MaDanhMucKhachHang,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		TenDanhMucTaiXe,
		NgayDongTraHang,
		SoTienLoiNhuan,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoTienDoanhThuTong,
		SoTienChiPhiVanTai,
		SoTienChiPhiThuTuc,
		SoTienChiPhiKhac,
		SoTienChiPhiTong,
		GhiChu
	)
	select
		IDctDonHang,
		SoDonHang,
		DebitNote,
		MaDanhMucKhachHang,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		TenDanhMucTaiXe,
		NgayDongTraHang,
		SoTienDoanhThuTong - SoTienChiPhiTong,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoTienDoanhThuTong,
		SoTienVeCauDuong + SoTienLuatAnCa + SoTienKetHopVeCauDuongLuatAnCa + SoTienLuuCaKhac + SoTienLuatDuongCam + SoTienLuongChuyen + SoTienLuongChuyen + SoTienCuocThueXeNgoai,
		SoTienThuTucHaiQuan,
		isnull(SoTienHoaHong, 0) + ISNULL([1%], 0) + ISNULL([0.3%], 0),
		SoTienChiPhiTong,
		GhiChu
	from #Report;
	--
	insert into #Report
	(
		DebitNote,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoLuongNhienLieu,
		SoTienNhienLieu,
		SoTienVeCauDuong,
		SoTienLuatAnCa,
		SoTienKetHopVeCauDuongLuatAnCa,
		SoTienLuuCaKhac,
		SoTienLuatDuongCam,
		SoTienTongChiPhiChuyenDi,
		SoTienLuongChuyen,
		SoTienLuongChuNhat,
		SoTienLuongTong,
		SoTienCuocThueXeNgoai,
		SoTienLuuCaThueXeNgoai,
		SoTienTongThueXeNgoai,
		SoTienThuTucHaiQuan,
		SoTienHoaHong,
		[1%],
		[0.3%],
		SoTienTongChiPhiKhac,
		SoTienDoanhThuTong,
		SoTienChiPhiTong,
		SoTienLoiNhuan
	)
	select
		N'TỔNG CỘNG',
		sum(SoTienCuoc),
		sum(SoTienThuTuc),
		sum(SoTienDoanhThuKhac),
		sum(SoLuongNhienLieu),
		sum(SoTienNhienLieu),
		sum(SoTienVeCauDuong),
		sum(SoTienLuatAnCa),
		sum(SoTienKetHopVeCauDuongLuatAnCa),
		sum(SoTienLuuCaKhac),
		sum(SoTienLuatDuongCam),
		sum(SoTienTongChiPhiChuyenDi),
		sum(SoTienLuongChuyen),
		sum(SoTienLuongChuNhat),
		sum(SoTienLuongTong),
		sum(SoTienCuocThueXeNgoai),
		sum(SoTienLuuCaThueXeNgoai),
		sum(SoTienTongThueXeNgoai),
		sum(SoTienThuTucHaiQuan),
		sum(SoTienHoaHong),
		sum([1%]),
		sum([0.3%]),
		sum(SoTienTongChiPhiKhac),
		sum(SoTienDoanhThuTong),
		sum(SoTienChiPhiTong),
		sum(SoTienLoiNhuan)
	from #Report;
	--
	insert into #Report1 --VIEW
	(
		DebitNote,
		SoTienLoiNhuan,
		SoTienCuoc,
		SoTienThuTuc,
		SoTienDoanhThuKhac,
		SoTienDoanhThuTong,
		SoTienChiPhiVanTai,
		SoTienChiPhiThuTuc,
		SoTienChiPhiKhac,
		SoTienChiPhiTong
	)
	select
		N'TỔNG CỘNG',
		sum(SoTienLoiNhuan),
		sum(SoTienCuoc),
		sum(SoTienThuTuc),
		sum(SoTienDoanhThuKhac),
		sum(SoTienDoanhThuTong),
		sum(SoTienChiPhiVanTai),
		sum(SoTienChiPhiThuTuc),
		sum(SoTienChiPhiKhac),
		sum(SoTienChiPhiTong)
	from #Report1;
	--SHEET CHI_TIET
	select * from #Report;
	--SHEET VIEW
	select * from #Report1;
	--
	drop table #Report;
	drop table #Report1;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_TU_QT]
	@IDDanhMucDonVi bigint = null,
	@TuNgay date = null,
	@DenNgay date = null,
	@IDDanhMucKhachHang bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2030-12-31',
--		@IDDanhMucKhachHang bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt							bigint identity(1, 1),
		IDctDonHangChiTietTamUng	bigint,
		NgayTamUng					nvarchar(10),
		MaDanhMucKhachHang			nvarchar(128),
		DebitNote					nvarchar(128),
		MaDanhMucHangHoa			nvarchar(128),
		TrongLuong					float,
		SoTienTamUng				float,
		SoTienChiCuocVo				float,
		SoTienChiHaiQuan			float,
		SoTienChiNangHa				float,
		SoTienChiLuu				float,
		SoTienChiSuaChua			float,
		SoTienChiThuTuc				float,
		SoTienHoanTamUng			float,
		NgayThanhToanTamUng			nvarchar(10),
		SoTienQuyetToan				float,
		SoTienTon					float,
		MaDanhMucCanBoTamUng		nvarchar(128),
		GhiChu						nvarchar(max),
	)
	--
	insert into #Report
	(
		IDctDonHangChiTietTamUng,
		NgayTamUng,
		MaDanhMucKhachHang,
		DebitNote,
		MaDanhMucHangHoa,
		TrongLuong,
		SoTienTamUng,
		MaDanhMucCanBoTamUng,
		GhiChu
	)
	select
		b.ID,
		convert(nvarchar(10), b.NgayTamUng, 103),
		KhachHang.Ma MaDanhMucKhachHang,
		a.DebitNote,
		HangHoa.Ma MaDanhMucHangHoa,
		a.KhoiLuong,
		isnull(b.SoTienCuocVo, 0) + isnull(b.SoTienHaiQuan, 0) + isnull(b.SoTienNangHa, 0) + isnull(b.SoTienChiKhac, 0) SoTienTamUng,
		CanBoTamUng.Ma MaDanhMucCanBoTamUng,
		a.GhiChu
	from ctDonHang a inner join ctDonHangChiTietTamUng b on a.ID = b.IDChungTu
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join DanhMucHangHoa HangHoa on a.IDDanhMucHangHoa = HangHoa.ID
		left join DanhMucNhanSu CanBoTamUng on b.IDDanhMucCanBoTamUng = CanBoTamUng.ID
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
	and case when @IDDanhMucKhachHang is not null then a.IDDanhMucKhachHang else -1 end = ISNULL(@IDDanhMucKhachHang, -1)
	and b.NgayTamUng >= @TuNgay and b.NgayTamUng <= @DenNgay;
	--
	update #Report set	SoTienChiCuocVo = T.SoTienChiCuocVo,
						SoTienChiThuTuc = T.SoTienChiThuTuc,
						SoTienHoanTamUng = T.SoTienHoanTamUng,
						SoTienQuyetToan = ISNULL(T.SoTienChiCuocVo, 0) + ISNULL(T.SoTienChiThuTuc, 0)
	from #Report inner join (select IDChungTuChiTiet, SUM(isnull(SoTienChiCuocVo, 0)) SoTienChiCuocVo,  SUM(isnull(SoTienChiThuTuc, 0)) SoTienChiThuTuc, SUM(isnull(SoTienHoanTamUng, 0)) SoTienHoanTamUng from ctThanhToanTamUng group by IDChungTuChiTiet) T
	on #Report.IDctDonHangChiTietTamUng = T.IDChungTuChiTiet;
	--
	update #Report set	NgayThanhToanTamUng = (select CONVERT(nvarchar(10), max(ctThanhToanTamUng.NgayThanhToanTamUng), 103) from ctThanhToanTamUng where ctThanhToanTamUng.IDChungTuChiTiet = #Report.IDctDonHangChiTietTamUng);
	--
	update #Report set	SoTienTon = isnull(SoTienTamUng, 0) - isnull(SoTienHoanTamUng, 0) - isnull(SoTienQuyetToan, 0);
	--
	insert into #Report
	(
		MaDanhMucKhachHang,
		SoTienTamUng,
		SoTienChiCuocVo,
		SoTienChiHaiQuan,
		SoTienChiNangHa,
		SoTienChiLuu,
		SoTienChiSuaChua,
		SoTienChiThuTuc,
		SoTienHoanTamUng,
		SoTienQuyetToan,
		SoTienTon
	)
	select
		N'Tổng cộng',
		sum(SoTienTamUng),
		sum(SoTienChiCuocVo),
		sum(SoTienChiHaiQuan),
		sum(SoTienChiNangHa),
		sum(SoTienChiLuu),
		sum(SoTienChiSuaChua),
		sum(SoTienChiThuTuc),
		sum(SoTienHoanTamUng),
		sum(SoTienQuyetToan),
		sum(SoTienTon)
	from #Report;
	--
	select * from #Report;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_TU_TIENDUONG]
		@IDDanhMucDonVi bigint,
		@TuNgay date,
		@DenNgay date,
		@IDDanhMucChuXe bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2021-12-31',
--		@IDDanhMucChuXe bigint = null
begin
	set nocount on;
	create table #Report
	(
		Stt						bigint identity(1, 1),
		IDctDonHang				bigint,
		DebitNote				nvarchar(128),
		MaDanhMucKhachHang		nvarchar(128),
		MaDanhMucTuyenVanTai	nvarchar(128),
		TenDanhMucTuyenVanTai	nvarchar(255),
		MaDanhMucChuXe			nvarchar(128),
		BienSo_ChuXeNgoai		nvarchar(128),
		SoLuongNhienLieu		float,
		SoTienTamUng			float,
		GhiChu					nvarchar(max),
		SoDonHang				nvarchar(128),
		NgayDongTraHang			nvarchar(10)
	);
	insert into #Report
	(
		IDctDonHang,
		DebitNote,
		MaDanhMucKhachHang,
		MaDanhMucTuyenVanTai,
		TenDanhMucTuyenVanTai,
		MaDanhMucChuXe,
		BienSo_ChuXeNgoai,
		GhiChu,
		SoDonHang,
		NgayDongTraHang
	)
	select
		a.ID IDctDonHang,
		a.DebitNote DebiNote,
		KhachHang.Ma MaDanhMucKhachHang,
		TuyenVanTai.Ma MaDanhMucTuyenVanTai,
		TuyenVanTai.Ten TenDanhMucTuyenVanTai,
		ChuXe.KyHieuKeToan MaDanhMucChuXe,
		case when ctDieuHanh.IDDanhMucThauPhu not in (9307, 10614) then ChuXe.Ma else Xe.BienSo end,
		a.GhiChu,
		a.So,
		CONVERT(nvarchar(10), isnull(a.NgayDongHang, a.NgayTraHang), 103)
	from ctDonHang a
		left join DanhMucTuyenVanTai TuyenVanTai on a.IDDanhMucTuyenVanTai = TuyenVanTai.ID
		left join DanhMucKhachHang KhachHang on a.IDDanhMucKhachHang = KhachHang.ID
		left join ctDieuHanh on a.ID = ctDieuHanh.IDChungTu
		left join DanhMucThauPhu ChuXe on ctDieuHanh.IDDanhMucThauPhu = ChuXe.ID
		left join DanhMucXe Xe on ctDieuHanh.IDDanhMucXe = Xe.ID
		left join DanhMucNhanSu Sale on a.IDDanhMucSale = Sale.ID
		--left join DanhMucDoiTuong [NhaCungCapTrich1%] on Sale.Ma = [NhaCungCapTrich1%].Ma
	where a.IDDanhMucDonVi = @IDDanhMucDonVi and a.Huy is null
		and isnull(a.NgayDongHang, a.NgayTraHang) >= @TuNgay and isnull(a.NgayDongHang, a.NgayTraHang) <= @DenNgay
		and case when @IDDanhMucChuXe is not null then ctDieuHanh.IDDanhMucThauPhu else -1 end = isnull(@IDDanhMucChuXe, -1)
	order by isnull(a.NgayDongHang, a.NgayTraHang);
	--
	update #Report set SoLuongNhienLieu = ctChiPhiVanTai.SoLuongNhienLieu
	from #Report inner join ctChiPhiVanTai on #Report.IDctDonHang = ctChiPhiVanTai.IDChungTu;
	update #Report set SoLuongNhienLieu = ISNULL(#Report.SoLuongNhienLieu, 0) +  ctChiPhiVanTaiBoSung.SoLuongNhienLieu
	from #Report inner join ctChiPhiVanTaiBoSung on #Report.IDctDonHang = ctChiPhiVanTaiBoSung.IDChungTu;
	--
	update #Report set SoTienTamUng =	ISNULL(SoTienVeCauDuong, 0) + ISNULL(SoTienLuatAnCa, 0) + ISNULL(SoTienKetHopVeCauDuongLuatAnCa, 0) +
										ISNULL(SoTienLuuCaKhac, 0) + ISNULL(SoTienLuatDuongCam, 0) --ISNULL(SoTienLuongChuyen, 0) + ISNULL(SoTienLuongChuNhat, 0) + 
										--ISNULL(SoTienCuocThueXeNgoai, 0) + ISNULL(SoTienVeCauDuong, 0)
	from #Report inner join ctChiPhiVanTai T on #Report.IDctDonHang = T.IDChungTu;
	update #Report set SoTienTamUng =	ISNULL(SoTienTamUng, 0) + ISNULL(SoTienVeCauDuong, 0) + ISNULL(SoTienLuatAnCa, 0) + ISNULL(SoTienKetHopVeCauDuongLuatAnCa, 0) +
										ISNULL(SoTienLuuCaKhac, 0) + ISNULL(SoTienLuatDuongCam, 0) --+ --ISNULL(SoTienLuongChuyen, 0) + ISNULL(SoTienLuongChuNhat, 0) + 
										--ISNULL(SoTienCuocThueXeNgoai, 0) + ISNULL(SoTienVeCauDuong, 0)
	from #Report inner join ctChiPhiVanTaiBoSung T on #Report.IDctDonHang = T.IDChungTu;
	--
	insert into #Report
	(
		
		DebitNote,
		SoLuongNhienLieu,
		SoTienTamUng
	)
	select
		N'Tổng cộng',
		SUM(SoLuongNhienLieu),
		SUM(SoTienTamUng)
	from #Report;
	--
	select * from #Report;
	--
	drop table #Report;
end;
go
-------------------
ALTER procedure [dbo].[rep_BC_SUACHUA]
	@IDDanhMucDonVi bigint = null,
	@TuNgay date = null,
	@DenNgay date = null,
	@IDDanhMucXe bigint = null
as
--declare	@IDDanhMucDonVi bigint = 1,
--		@TuNgay date = '2020-01-01',
--		@DenNgay date = '2030-12-31',
--		@IDDanhMucXe bigint = null;
begin
	set nocount on;
	create table #Report
	(
		Stt					bigint identity(1, 1),
		NguoiSuaChua		nvarchar(255),
		IDDanhMucXe			bigint,
		BienSo				nvarchar(128),
		NoiSuaChua			nvarchar(512),
		NgaySuaChua			nvarchar(10),
		NoiDungSuaChua		nvarchar(max),
		DonViTinh			nvarchar(128),
		SoLuong				float,
		DonGiaVatTu			float,
		DonGiaNhanCong		float,
		SoTienVatTu			float, 
		SoTienNhanCong		float,
		SoTien				float,
		GhiChu				nvarchar(max),
		ID					tinyint, --1: báo cáo chung, 2: báo cáo theo xe, 3: báo cáo theo nơi sửa chữa
	)
	--
	insert into #Report
	(
		NguoiSuaChua,
		IDDanhMucXe,
		BienSo,
		NoiSuaChua,
		NgaySuaChua,
		NoiDungSuaChua,
		DonViTinh,
		SoLuong,
		DonGiaVatTu,
		DonGiaNhanCong,
		SoTienVatTu,
		SoTienNhanCong,
		SoTien,
		GhiChu,
		ID
	)
	select
		ctSuaChua.NguoiSuaChua,
		ctSuaChua.IDDanhMucXe,
		DanhMucXe.BienSo,
		ctSuaChua.NoiSuaChua,
		convert(nvarchar(10), ctSuaChua.NgaySuaChua, 103),
		ctSuaChua.NoiDungSuaChua,
		ctSuaChua.DonViTinh,
		ctSuaChua.SoLuong,
		ctSuaChua.DonGiaVatTu,
		ctSuaChua.DonGiaNhanCong,
		ctSuaChua.SoTienVatTu,
		ctSuaChua.SoTienNhanCong,
		ctSuaChua.SoTien,
		ctSuaChua.GhiChu,
		1
	from ctSuaChua left join DanhMucXe on ctSuaChua.IDDanhMucXe = DanhMucXe.ID
	where ctSuaChua.IDDanhMucDonVi = @IDDanhMucDonVi 
	and case when @IDDanhMucXe is not null then ctSuaChua.IDDanhMucXe else -1 end = ISNULL(@IDDanhMucXe, -1)
	and cast(ctSuaChua.NgaySuaChua as date) >= @TuNgay and cast(ctSuaChua.NgaySuaChua as date) <= @DenNgay
	order by ctSuaChua.NgaySuaChua;
	--
	insert into #Report
	(
		NguoiSuaChua,
		SoTienVatTu,
		SoTienNhanCong,
		SoTien
	)
	select
		N'TỔNG CỘNG',
		sum(SoTienVatTu),
		sum(SoTienNhanCong),
		sum(SoTien)
	from #Report;
	--chèn 1 dòng trắng
	insert into #Report
	(
		NguoiSuaChua
	)
	values
	(		
		null
	);
	--chèn tổng sửa chữa theo xe
	insert into #Report
	(
		NguoiSuaChua,
		SoTienVatTu,
		SoTienNhanCong,
		SoTien,
		ID
	)
	select
		DanhMucXe.BienSo,
		sum(ctSuaChua.SoTienVatTu),
		sum(ctSuaChua.SoTienNhanCong),
		sum(ctSuaChua.SoTien),
		2
	from ctSuaChua left join DanhMucXe on ctSuaChua.IDDanhMucXe = DanhMucXe.ID
	where ctSuaChua.IDDanhMucDonVi = @IDDanhMucDonVi 
	and case when @IDDanhMucXe is not null then ctSuaChua.IDDanhMucXe else -1 end = ISNULL(@IDDanhMucXe, -1)
	and cast(ctSuaChua.NgaySuaChua as date) >= @TuNgay and cast(ctSuaChua.NgaySuaChua as date) <= @DenNgay
	group by DanhMucXe.BienSo;
	insert into #Report
	(
		NguoiSuaChua,
		SoTienVatTu,
		SoTienNhanCong,
		SoTien,
		ID
	)
	select
		N'TỔNG CỘNG',
		sum(#Report.SoTienVatTu),
		sum(#Report.SoTienNhanCong),
		sum(#Report.SoTien),
		2
	from #Report where ID is not null and ID = 2;
	----chèn 1 dòng trắng
	insert into #Report
	(
		NguoiSuaChua
	)
	values
	(		
		null
	);
	--chèn tổng sửa chữa nơi sửa chữa
	insert into #Report
	(
		NguoiSuaChua,
		SoTienVatTu,
		SoTienNhanCong,
		SoTien,
		ID
	)
	select
		ctSuaChua.NoiSuaChua,
		sum(ctSuaChua.SoTienVatTu),
		sum(ctSuaChua.SoTienNhanCong),
		sum(ctSuaChua.SoTien),
		3
	from ctSuaChua left join DanhMucXe on ctSuaChua.IDDanhMucXe = DanhMucXe.ID
	where ctSuaChua.IDDanhMucDonVi = @IDDanhMucDonVi 
	and case when @IDDanhMucXe is not null then ctSuaChua.IDDanhMucXe else -1 end = ISNULL(@IDDanhMucXe, -1)
	and cast(ctSuaChua.NgaySuaChua as date) >= @TuNgay and cast(ctSuaChua.NgaySuaChua as date) <= @DenNgay
	group by ctSuaChua.NoiSuaChua;
	insert into #Report
	(
		NguoiSuaChua,
		SoTienVatTu,
		SoTienNhanCong,
		SoTien,
		ID
	)
	select
		N'TỔNG CỘNG',
		sum(#Report.SoTienVatTu),
		sum(#Report.SoTienNhanCong),
		sum(#Report.SoTien),
		3
	from #Report where  ID is not null and ID = 3;
	--
	select * from #Report order by Stt;
	--
	drop table #Report;
end;

-------------------
-------------------
-------------------
-------------------
-------------------
-------------------
-------------------
