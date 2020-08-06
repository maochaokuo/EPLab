use EPLlabDB

select f.fieldName, fv.fieldValue
from fieldValues fv
join
(
select r.rowId, fv1.fieldValue--, fv2.fieldValue
from [rows] r
join fieldValues fv1 on r.rowId=fv1.rowId 
join fields f1 on fv1.fieldId=f1.fieldId and f1.fieldName='dealdate'
--join fieldValues fv2 on r.rowId=fv2.rowId 
--join fields f2 on fv2.fieldId=f2.fieldId and f2.fieldName='dealtime'
--where r.rowId='CA8F15B9-4893-4301-A05A-0010FAB6BF26'
--order by fv1.fieldValue
) b on fv.rowId=b.rowId 
join fields f on fv.fieldId=f.fieldId
order by b.fieldValue,f.defaultOrder

/*
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
