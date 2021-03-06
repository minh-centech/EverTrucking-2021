--ĐẾM SỐ BẢN GHI TRONG 1 TABLE

create procedure countID
	@TableName nvarchar(512) = 'DanhMucKhachHang', 
	@countID bigint = 0 out
as

create table #countID
(
	countID bigint
);

declare @strSQL nvarchar(max) = 'insert into #countID select count(ID) from ' + @TableName;

exec sp_executesql @strSQL;

select @countID = (select top 1 countID from #countID);

select @countID;

drop table #countID;