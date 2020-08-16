use EPLlabDB

select f1.rowId, f1.fieldValue dealdatetime, f2.fieldValue dealdate, f3.fieldValue dealtime
	, f4.fieldValue [open], f5.fieldValue [high], f6.fieldValue [low], f7.fieldValue [close]
	, f8.fieldValue volume, f9.fieldValue dealmonth, f10.fieldValue section
from
(
select fv.rowId, fv.fieldValue
from fieldValues fv 
join fields f on fv.fieldId=f.fieldId and f.defaultOrder=1
) f1
join [rows] r on f1.rowId=r.rowId
join [tables] t on r.tableId=t.tableId and t.tableName='ohlc'
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
--where f2.fieldValue='20180629'
order by f1.fieldValue, f2.fieldValue
