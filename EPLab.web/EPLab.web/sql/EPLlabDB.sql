use EPLlabDB

select * 
-- delete
from [tables]

select *
-- delete
from [rows]

select *
-- delete
from fields

select * 
-- delete
from fieldValues

select *
-- delete
from allIdHistory

select 
from [tables] t
join fields f on t.tableId=f.fieldId
join [rows] r on r.tableId=t.tableId
join fieldValues fv on fv.rowId=r.rowId and fv.fieldId=f.fieldId
/*
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
