use EPLlabDB

select q.queryName, f.fieldName,t.tableName
from queryFields qf
join queries q on q.queryId=qf.queryId
join fields f on qf.fieldId=f.fieldId
join tables t on q.tableId=t.tableId
/*
declare @fieldName varchar(99)='dealdate'
declare @queryName varchar(99)='QohlcBydate'

select fv.fieldValue --,fv.rowId, q.tableId
from queries q 
join queryFields qf on q.queryId=qf.queryId
join fields f on qf.fieldId=f.fieldId and f.fieldName=@fieldName
join fieldValues fv on  fv.fieldId=qf.fieldId
join [rows] r on fv.rowId=r.rowId and r.tableId=q.tableId
where q.queryName=@queryName
group by fv.fieldValue
order by fv.fieldValue --{0}

select *
from [rows]
where rowId='D521F9AC-3506-405D-BB1E-38DF7AF0E8DA'
	--tableId='DDC58962-C0AE-4327-9ED9-D9E516244431'

select *
from fields
where tableId='DDC58962-C0AE-4327-9ED9-D9E516244431'

select *
from tables

select fv.fieldValue
from queries q 
join queryFields qf on q.queryId=qf.queryId
join fields f on qf.fieldId=f.fieldId and f.fieldName=@fieldName
join fieldValues fv on  fv.fieldId=qf.fieldId
join [rows] r on fv.rowId=r.rowId and r.tableId=q.tableId
where q.queryName=@queryName
group by fv.fieldValue
order by fv.fieldValue 

select f.fieldName, qf.*
from queryFields qf
join fields f on qf.fieldId=f.fieldId

select *
from tables

select * 
from fields
where tableId='889CD40E-BA39-4985-A434-902E69EC8B7A'

select --q.tableId,qf.fieldId, r.rowId,
	 fv.fieldValue
from queries q 
join queryFields qf on q.queryId=qf.queryId
join fields f on qf.fieldId=f.fieldId and f.fieldName='dealdate'
join fieldValues fv on  fv.fieldId=qf.fieldId
join [rows] r on fv.rowId=r.rowId and r.tableId=q.tableId
where q.queryName='QohlcBydate'
group by fv.fieldValue
order by fv.fieldValue

select *
from [rows]
where tableId='DDC58962-C0AE-4327-9ED9-D9E516244431'

select *
from fields

select r.*, a.createtime, a.allIdHistoryId
from [rows] r
left join allIdHistory a on r.rowId=a.uid
order by a.allIdHistoryId

select *
from queries

select *
from domains

select *
from allIdHistory

declare @queryName varchar(99)='QohlcBydate'
declare @dealdate varchar(99)='20180629'
declare @lowestOpen varchar(99)='10600'

--select f.fieldName, qf.*
--from queryFields qf
--join queries q on q.queryId=qf.queryId
--join fields f on qf.fieldId=f.fieldId
--where q.queryName=@queryName
--order by displayOrder
;

with rowsWhereOrder(rowId, fieldValue1)
as
(
    
    select r.rowId, fv1.fieldValue fieldValue1
    from [rows] r
    join queries q on r.tableId=q.tableId
    join expressions e on q.whereExpressionId=e.expressionId

    join fieldValues fv2 on r.rowId=fv2.rowId and fv2.fieldId='b205442e-d2e5-48da-be28-5b5a23aa0dcc'

    join fieldValues fv3 on r.rowId=fv3.rowId and fv3.fieldId='9e7a1a9f-e8a6-4c39-8790-6bd5a263f623'

    join fieldValues fv4 on r.rowId=fv4.rowId and fv4.fieldId='2593a7b0-29ba-45d8-a5f7-c112596a2d5b'

    join queryFields qf1 on qf1.queryId=q.queryId and qf1.orderByOrder=1
    join fieldValues fv1 on r.rowId=fv1.rowId and qf1.fieldId=fv1.fieldId

    where q.queryName=@queryName and ((fv2.fieldValue = @dealdate) and ((fv3.fieldValue > @lowestOpen) or (fv3.fieldValue <= fv4.fieldValue)))

)

select fwo.rowId, f1.fieldValue [dealtime], f2.fieldValue [open], f3.fieldValue [high], f4.fieldValue [low], f5.fieldValue [close], f6.fieldValue [volume], f7.fieldValue [dealmonth], f8.fieldValue [section]
from rowsWhereOrder fwo

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=1
	join fieldValues fv on fv.fieldId=qf.fieldId
) f1 on fwo.rowId=f1.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=2
	join fieldValues fv on fv.fieldId=qf.fieldId
) f2 on fwo.rowId=f2.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=3
	join fieldValues fv on fv.fieldId=qf.fieldId
) f3 on fwo.rowId=f3.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=4
	join fieldValues fv on fv.fieldId=qf.fieldId
) f4 on fwo.rowId=f4.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=5
	join fieldValues fv on fv.fieldId=qf.fieldId
) f5 on fwo.rowId=f5.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=6
	join fieldValues fv on fv.fieldId=qf.fieldId
) f6 on fwo.rowId=f6.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=7
	join fieldValues fv on fv.fieldId=qf.fieldId
) f7 on fwo.rowId=f7.rowId

join 
(
	select fv.rowId, fv.fieldValue
	from queries q
	join queryFields qf on qf.queryId=q.queryId and q.queryName=@queryName
		and qf.displayOrder=8
	join fieldValues fv on fv.fieldId=qf.fieldId
) f8 on fwo.rowId=f8.rowId
order by fwo.fieldValue1 asc

select *
from fieldValues

declare @queryName varchar(99)='QohlcBydate'
;
with expressList
as
(
	select a.*, cast (1 as bit) isWhereExpressId
	from expressions a
	join queries q on a.expressionId=q.whereExpressionId
	where q.queryName=@queryName
	union all
	select b.*, cast (0 as bit) isWhereExpressId
	from expressions b
	join expressList c on c.subExpression1Id=b.expressionId
	where c.subExpression1Id is not null
	union all
	select d.*, cast (0 as bit) isWhereExpressId
	from expressions d
	join expressList e on e.subExpression2Id=d.expressionId
	where e.subExpression2Id is not null
)
select e.isWhereExpressId,
	e.expressionId, o.operatorName, o.stringInSourceCode, o.isPrefix, o.paraNum
	, e.paraField1id, f1.fieldName field1Name
	, e.paraField2id, f2.fieldName field2Name
	, e.para2externalName, e.subExpression1Id, e.subExpression2Id
from expressList e 
join operators o on e.operatorId=o.operatorId
left join fields f1 on e.paraField1id=f1.fieldId
left join fields f2 on e.paraField2id=f2.fieldId

declare @queryName varchar(99)='QohlcBydate'
declare @dealdate varchar(99)='20180629'

select r.rowId
from [rows] r
join queries q on r.tableId=q.tableId
join expressions e on q.whereExpressionId=e.expressionId

join fieldValues fvWhere on r.rowId=fvWhere.rowId and fvWhere.fieldId=e.paraField1id

join queryFields qf1 on qf1.queryId=q.queryId and qf1.orderByOrder=1
join fieldValues fvOrder1 on r.rowId=fvOrder1.rowId and qf1.fieldId=fvOrder1.fieldId

where q.queryName=@queryName and fvWhere.fieldValue = @dealdate
order by fvOrder1.fieldValue asc

select *
from queries

select *
from queryFields
order by displayOrder

select * 
from expressions

select e.expressionId, o.*
from operators o
join expressions e on e.operatorId=o.operatorId

select *
from fields
where tableId='DDC58962-C0AE-4327-9ED9-D9E516244431'
order by tableId, defaultOrder

select r.tableId, t.tableName, count(r.rowId) counts
from [rows] r
join [tables] t on r.tableId=t.tableId
where t.tableName='ohlc'
group by r.tableId, t.tableName

select *
from fields 
order by tableId, defaultOrder

select *
from tables

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
