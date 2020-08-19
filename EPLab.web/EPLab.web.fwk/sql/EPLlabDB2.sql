use EPLlabDB

-- QohlcBydate queryId='75732706-EE00-4EA4-BE7A-44E7ED240177'
declare @queryName varchar(99)='QohlcBydate'
declare @dealdate varchar(99)='20180629'
--declare @dealdate varchar(99)='20180702'

-- 首先看where與order by 欄位, 有沒有該欄位沒有值的row(s)
/*
;
with fieldsMustHaveValue(mustHaveFieldId)
as
(
	select f1.fieldId
	from queries q
	join expressions e on q.whereExpressionId=e.expressionId
	join fields f1 on e.paraField1id=f1.fieldId
	where q.queryName=@queryName
	union
	select f2.fieldId
	from queries q
	join expressions e on q.whereExpressionId=e.expressionId
	join fields f2 on e.paraField2id=f2.fieldId
	where q.queryName=@queryName
	union
	select f3.fieldId
	from queries q
	join expressions e on q.whereExpressionId=e.expressionId
	join fields f3 on e.paraField3id=f3.fieldId
	where q.queryName=@queryName
	union
	select f4.fieldId
	from queries q
	join expressions e on q.whereExpressionId=e.expressionId
	join fields f4 on e.paraField4id=f4.fieldId
	where q.queryName=@queryName
	union
	select f5.fieldId
	from queries q
	join expressions e on q.whereExpressionId=e.expressionId
	join fields f5 on e.paraField5id=f5.fieldId
	where q.queryName=@queryName
	union
	select qf.fieldId
	from queryFields qf
	join fields f on qf.fieldId=f.fieldId
	join queries q on qf.queryId=q.queryId
	where q.queryName=@queryName and qf.orderByOrder>0
)
select fmhv.mustHaveFieldId, r.rowId
from queries q
join [rows] r on r.tableId=q.tableId and q.queryName=@queryName
join fields f on f.tableId=q.tableId
join fieldsMustHaveValue fmhv on fmhv.mustHaveFieldId=f.fieldId
left join fieldValues fv on fv.rowId=r.rowId and fv.fieldId=fmhv.mustHaveFieldId
where fv.fieldValueId is null
;

-- 若確定沒有，則查出所有符合資料的rows，並套上order by條件
-- where條件
select o.operatorName, o.stringInSourceCode, o.isPrefix, o.paraNum
	, e.paraField1id, f1.fieldName field1Name
	, e.paraField2id, f2.fieldName field2Name, e.para2externalName
from queries q
join expressions e on q.whereExpressionId=e.expressionId
join operators o on e.operatorId=o.operatorId
join fields f1 on e.paraField1id=f1.fieldId
left join fields f2 on e.paraField2id=f2.fieldId
where q.queryName=@queryName --and o.operatorName='SQL_EQUAL'

-- order by 欄位
select qf.fieldId, f.fieldName,
	case when qf.orderByDesc=0 then 'asc' else 'desc' end ascDesc
	, qf.orderByOrder
from queryFields qf
join queries q on q.queryId=qf.queryId
join fields f on qf.fieldId=f.fieldId and q.tableId=f.tableId
where q.queryName=@queryName and orderByOrder>0
order by orderByOrder

	-- 所以這裡有點麻煩，得從資料庫讀出，再產生sql script
	select r.rowId, fvOrder1.fieldValue fieldValueO1
	from [rows] r
	join queries q on r.tableId=q.tableId
	join expressions e on q.whereExpressionId=e.expressionId
	join fieldValues fvWhere on r.rowId=fvWhere.rowId and fvWhere.fieldId=e.paraField1id
	join queryFields qf1 on qf1.queryId=q.queryId and qf1.orderByOrder=1
	join fieldValues fvOrder1 on r.rowId=fvOrder1.rowId and qf1.fieldId=fvOrder1.fieldId
	where q.queryName=@queryName and fvWhere.fieldValue=@dealdate
	order by fvOrder1.fieldValue
*/
-- 再加上要顯示的欄位
-- 也是有點麻煩，只能讀出資料之後產生sql script
select qf.fieldId, f.fieldName, qf.displayOrder
from queryFields qf
join queries q on qf.queryId=q.queryId
join fields f on qf.fieldId=f.fieldId
where q.queryName=@queryName and qf.displayOrder>0
order by qf.displayOrder

;
with rowsWhereOrder(rowId, fieldValue1)
as
(
	select r.rowId, fvOrder1.fieldValue fieldValue1
	from [rows] r
	join queries q on r.tableId=q.tableId
	join expressions e on q.whereExpressionId=e.expressionId
	join fieldValues fvWhere on r.rowId=fvWhere.rowId and fvWhere.fieldId=e.paraField1id
	join queryFields qf1 on qf1.queryId=q.queryId and qf1.orderByOrder=1
	join fieldValues fvOrder1 on r.rowId=fvOrder1.rowId and qf1.fieldId=fvOrder1.fieldId
	where q.queryName=@queryName and fvWhere.fieldValue=@dealdate
--select r.rowId, fvOrder1.fieldValue fieldValue1
--from [rows] r
--join queries q on r.tableId=q.tableId
--join expressions e on q.whereExpressionId=e.expressionId
--join fieldValues fvWhere on r.rowId=fvWhere.rowId and fvWhere.fieldId=e.paraField1id
--join queryFields qfO1 on qfO1.queryId=q.queryId and qfO1.orderByOrder=1
--join fieldValues fvOrder1 on r.rowId=fvOrder1.rowId and qfO1.fieldId=fvOrder1.fieldId
--where q.queryName=@queryName and fvWhere.fieldValue=@dealdate
)
select fwo.rowId, f1.fieldValue dealtime, f2.fieldValue [open], f3.fieldValue [high]
	, f4.fieldValue [low], f5.fieldValue [close], f6.fieldValue volume
	, f7.fieldValue dealmonth, f8.fieldValue section
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
order by fwo.fieldValue1
;

-- 於是，就可以進行計算欄位的處理，例如preTop, preBottom

