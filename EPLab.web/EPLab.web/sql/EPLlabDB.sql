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

/*

select *
from allIdHistory

select dealdate, dealtime, [open], high, low, [close], volume, dealmonth, section
from indices2.dbo.ohlc
where dealdate<='20180630'
order by dealdate, dealtime

SELECT dealdate, dealtime, [close], sVolume, aVolume, lastdate, lastclose, lastSvolume, lastAvolume
FROM [indices2].[dbo].[dealdates]
where dealdate<='20180630'
order by dealdate
*/
