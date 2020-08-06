use EPLlabDB

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
/*
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
*/
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

/*
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
