

create database people
go
use people
create table people(
	[Ρerson_Id] [int] IDENTITY (1,1) PRIMARY KEY NOT NULL,
	[Рersonal_Νame] [nvarchar](50) NULL,
	[Family_Name] [nvarchar](50) NULL,
	[Gender] [bit] NULL,
	[Fathеr_Id] [int] NULL,
	[Mother_Id] [int] NULL,
	[Spouѕe_Id] [int] NULL
)

INSERT INTO people ([Рersonal_Νame], [Family_Name], [Gender], [Fathеr_Id], [Mother_Id], [Spouѕe_Id])  
VALUES  
('יוסף', 'כהן', 1, NULL, NULL, 2),  
('שרה', 'כהן', 0, NULL, NULL, 1),  

('דוד', 'כהן', 1, 1, 2, 5),  
('מרים', 'כהן', 0, 1, 2, 6),  

('רוני', 'כהן', 1, 3, 5, NULL),  
('נועה', 'כהן', 0, 3, 5, NULL),  
('דביר', 'לוי', 1, 4, 6, NULL),  
('תמר', 'לוי', 0, 4, 6, NULL);
select * from people

Person_Id | Relative_Id | Connection_Type
Connection_Type 
create table tree(
	Person_Id int ,
	FOREIGN KEY (Person_Id) references people,
	Relative_Id int,
	FOREIGN KEY (Relative_Id) references people,
	Connection_Type nvarchar(10) 
	check(Connection_Type in('אב' ,  'אם', 'אח', 'אחות', 'בן', 'בת', 'בן זוג', 'בת זוג'))
)
select * from tree
select * from people


alter proc ex1
as 
begin
	print 'start proc'
	declare @id int, @fid int, @mid int, @gender bit, @sid int
	declare @orders nvarchar(max) = ''
	declare crs cursor scroll
	for select Ρerson_Id, Fathеr_Id , mother_id, gender, Spouѕe_Id from people
	open crs
		fetch next from crs into @id, @fid, @mid, @gender, @sid
		print @id 
		while @@FETCH_STATUS = 0
		begin
			declare @sql nvarchar(max) = 'insert into tree values', @added bit = 0, @start nvarchar(10)=concat(' (',@id,',')
			--print @sql +' \n sql' 
			--print @start +' \n start' 
			----father
			if @fid != null
				set @sql = concat(@sql,@start,@fid,', ''אב''),')
				print @sql
				set @added = 1
				print @sql
			--mother
			if @mid != null
				set @sql = concat(@sql ,@start ,@mid,', ''אם''),')
				print @sql
				set @added = 1
				print @sql
			--siblings
			if @added = 1--there is father or mother- means there may be siblings
			begin
				declare @sib table (
					id int not null, gender bit not null
				)
				insert into @sib (id, gender) 
					select Ρerson_Id, gender from people 
						where (Fathеr_Id != null and Fathеr_Id = @fid) or (Mother_Id != null and Mother_Id = @mid)
				declare @sibid int, @sibgender bit
				declare sibCur cursor scroll
				for select id, gender from @sib
				open sibCur
					fetch next from sibCur into @sibid, @sibgender
					while @@FETCH_STATUS =0
					begin
						if @sibid != null and @sibgender != null
						begin
							if @sibgender = 1
								set @sql = CONCAT(@sql , @start,@sibid ,', ''אח''),')
							else
								set @sql =CONCAT(@sql , @start,@sibid ,', ''אחות''),')
							set @added = 1
							print @sql
						end
						fetch next from sibCur into @sibid, @sibgender
					end
				close sibCur
				deallocate sibCur
			end--siblings
			--spouse
			if @sid != null
			begin
				if @gender = 1
					set @sql = concat(@sql ,@start,@sid,', ''בת זוג''),')
				else
					set @sql = concat(@sql ,@start,@sid,', ''בן זוג''),')
				set @added = 1
				print @sql
			end
			--since it could be someone how lost his spouse i looking for children without checking married or not
			--children
			declare @chil table (
					id int not null, gender bit not null
			)
			insert into @chil (id, gender) 
				select Ρerson_Id, gender from people 
					where Fathеr_Id = @id or Mother_Id = @id
			declare @childid int, @childgender bit
			declare chilCur cursor scroll
			for select id, gender from @chil
			open chilCur
				fetch next from chilCur into @childid, @childgender
				while @@FETCH_STATUS =0
				begin
					if @childid != null and @childgender != null
					begin
						if @childgender = 1
							set @sql = concat(@sql , @start,@childid ,', ''בן''),')
						else
							set @sql = concat(@sql , @start,@childid ,', ''בת''),')
						set @added = 1
						print @sql
					end
					fetch next from chilCur into @childid, @childgender
				end
			close chilCur
			deallocate chilCur

			--
			if @added = 1
			begin
				set @sql = left(@sql, len(@sql)-1)
				print(@sql)
				set @orders = concat(@orders, @sql)
			end
			fetch next from crs into @id, @fid, @mid, @gender, @sid
		end
	close crs
	deallocate crs

	
end

exec ex1


declare @i nvarchar(max) = 'print ''high''' , @j nvarchar(max) = 'print ''low'''
declare @ij nvarchar(max) = concat(@i,' ', @j)
print @ij
exec( @ij)
print(len(@i))
print left(@i, len(@i)-1)


