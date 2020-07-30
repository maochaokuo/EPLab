use EPLlabDB

select * from tables

select dealdate, dealtime, [open], high, low, [close], volume, dealmonth, section
from indices2.dbo.ohlc
where dealdate<='20180630'
order by dealdate, dealtime

SELECT dealdate, dealtime, [close], sVolume, aVolume, lastdate, lastclose, lastSvolume, lastAvolume
FROM [indices2].[dbo].[dealdates]
where dealdate<='20180630'
order by dealdate
