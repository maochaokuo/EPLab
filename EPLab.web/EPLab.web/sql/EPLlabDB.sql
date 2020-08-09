use EPLlabDB

select *
from tables

/*
select r.rowId, fv1.fieldValue dealdate, fv2.fieldValue [close], fv3.fieldValue sVolume, fv4.fieldValue aVolume
	, fv5.fieldValue lastdate, fv6.fieldValue lastclose, fv7.fieldValue lastSvolume, fv8.fieldValue lastAvolume
from [rows] r
join [tables] t on r.tableId=t.tableId and t.tableName='dealdates'
join fieldValues fv1 on r.rowId=fv1.rowId 
join fields f1 on fv1.fieldId=f1.fieldId and f1.defaultOrder=1
join fieldValues fv2 on r.rowId=fv2.rowId
join fields f2 on fv2.fieldId=f2.fieldId and f2.defaultOrder=2
join fieldValues fv3 on r.rowId=fv3.rowId
join fields f3 on fv3.fieldId=f3.fieldId and f3.defaultOrder=3
join fieldValues fv4 on r.rowId=fv4.rowId
join fields f4 on fv4.fieldId=f4.fieldId and f4.defaultOrder=4
join fieldValues fv5 on r.rowId=fv5.rowId
join fields f5 on fv5.fieldId=f5.fieldId and f5.defaultOrder=5
join fieldValues fv6 on r.rowId=fv6.rowId
join fields f6 on fv6.fieldId=f6.fieldId and f6.defaultOrder=6
join fieldValues fv7 on r.rowId=fv7.rowId
join fields f7 on fv7.fieldId=f7.fieldId and f7.defaultOrder=7
join fieldValues fv8 on r.rowId=fv8.rowId
join fields f8 on fv8.fieldId=f8.fieldId and f8.defaultOrder=8

select f.*, t.tableName
from fields f
join [tables] t on f.tableId=t.tableId
where t.tableName='dealdates'
order by f.tableId, f.defaultOrder

select f.*, t.tableName
from fields f
join [tables] t on f.tableId=t.tableId
where t.tableName='dealdates'
order by f.tableId, f.defaultOrder

select *
from [tables]

select f1.rowId, f1.fieldValue, f2.fieldValue, f3.fieldValue
	, f4.fieldValue, f5.fieldValue, f6.fieldValue
	, f7.fieldValue, f8.fieldValue, f9.fieldValue, f10.fieldValue
from
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=1
) f1
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=2
) f2 on f1.rowId = f2.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=3
) f3 on f1.rowId = f3.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=4
) f4 on f1.rowId = f4.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=5
) f5 on f1.rowId = f5.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=6
) f6 on f1.rowId = f6.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=7
) f7 on f1.rowId = f7.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=8
) f8 on f1.rowId = f8.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=9
) f9 on f1.rowId = f9.rowId
join
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=10
) f10 on f1.rowId = f10.rowId
order by f1.fieldValue, f2.fieldValue

select *
from fields 
where tableId='238F769B-8A57-402E-A6CB-D3026F19B524'
order by defaultOrder

select
from [rows] r
join fieldValues fv on r.rowId=fv.rowId 
left join fields f1 on fv.fieldId=f1.fieldId and f1.fieldName='dealdate'

select distinct fv.fieldValue
from fieldValues fv
join fields f on fv.fieldId=f.fieldId and f.fieldName='dealdate'

--declare @fieldlst varchar(999)=''

--SELECT 
--    @fieldlst += QUOTENAME(fieldName) + ','
--FROM 
--    fields
--ORDER BY 
--    defaultOrder;
--SET @fieldlst = LEFT(@fieldlst, LEN(@fieldlst) - 1);

--PRINT @fieldlst;
--select @fieldlst

--select fieldName
--from fields f
--order by f.defaultOrder

DECLARE 
    @columns NVARCHAR(MAX) = '', 
    @sql     NVARCHAR(MAX) = '';

-- select the category names
SELECT 
    @columns+=QUOTENAME(category_name) + ','
FROM 
    production.categories
ORDER BY 
    category_name;

-- remove the last comma
SET @columns = LEFT(@columns, LEN(@columns) - 1);

-- construct dynamic SQL
SET @sql ='
SELECT * FROM   
(
    SELECT 
        category_name, 
        model_year,
        product_id 
    FROM 
        production.products p
        INNER JOIN production.categories c 
            ON c.category_id = p.category_id
) t 
PIVOT(
    COUNT(product_id) 
    FOR category_name IN ('+ @columns +')
) AS pivot_table;';

-- execute the dynamic SQL
EXECUTE sp_executesql @sql;

select f.fieldName, fv.fieldValue
from fieldValues fv
join
(
select r.rowId, fv1.fieldValue--, fv2.fieldValue
from [rows] r
join fieldValues fv1 on r.rowId=fv1.rowId 
join fields f1 on fv1.fieldId=f1.fieldId and f1.fieldName='dealdatetime'
--join fieldValues fv2 on r.rowId=fv2.rowId 
--join fields f2 on fv2.fieldId=f2.fieldId and f2.fieldName='dealtime'
--where r.rowId='CA8F15B9-4893-4301-A05A-0010FAB6BF26'
--order by fv1.fieldValue
) b on fv.rowId=b.rowId 
join fields f on fv.fieldId=f.fieldId
order by b.fieldValue,f.defaultOrder

--select dealdate+dealtime dealdatetime, dealdate, dealtime, [open], high, low, [close], volume, dealmonth, section
--from indices2.dbo.ohlc
--where dealdate between '20180702' /*and '20180706'*/ and section=1
--order by dealdate, dealtime

 cross tabl ref: 
http://www.sqlfiddle.com/#!18/a592d/7
https://www.essentialsql.com/create-cross-tab-query-summarize-data-sql-server/
https://www.mssqltips.com/sqlservertip/1019/crosstab-queries-using-pivot-in-sql-server/

select 
from [tables] t
join fields f on t.tableId=f.fieldId
join [rows] r on r.tableId=t.tableId
join fieldValues fv on fv.rowId=r.rowId and fv.fieldId=f.fieldId

select * 
-- delete
from [tables]

select *
-- delete
from [rows]

select *
-- delete
from fields
order by defaultOrder

select * 
-- delete
from fieldValues

select *
-- delete
from allIdHistory

select a.*
from tables a
join allIdHistory b on a.tableId=uid
where b.tag='dealdates'

select a.*
from fields a
join allIdHistory b on a.tableId=uid
where b.tag='dealdates'

select *
from allIdHistory
where uid='D75FBC6E-3137-4F00-A979-07D8ABF24468'


select dealdate, dealtime, [open], high, low, [close], volume, dealmonth, section
from indices2.dbo.ohlc
where dealdate<='20180630'
order by dealdate, dealtime

SELECT dealdate, dealtime, [close], sVolume, aVolume, lastdate, lastclose, lastSvolume, lastAvolume
FROM [indices2].[dbo].[dealdates]
where dealdate<='20180630'
order by dealdate
*/
