CREATE TABLE [dbo].[allIdHistory] (
    [allIdHistoryId] BIGINT           IDENTITY (1, 1) NOT NULL,
    [uid]            UNIQUEIDENTIFIER NOT NULL,
    [fromTable]      VARCHAR (50)     NULL,
    [createtime]     DATETIME         CONSTRAINT [DF_allIdHistory_createtime] DEFAULT (getdate()) NULL,
    [modifytime]     DATETIME         CONSTRAINT [DF_allIdHistory_modifytime] DEFAULT (getdate()) NULL,
    [createBy]       NVARCHAR (50)    NULL,
    [modifyBy]       NVARCHAR (50)    NULL,
    [tag]            NVARCHAR (50)    NULL,
    CONSTRAINT [PK_allIdHistory] PRIMARY KEY CLUSTERED ([allIdHistoryId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_allIdHistory]
    ON [dbo].[allIdHistory]([uid] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_allIdHistory_1]
    ON [dbo].[allIdHistory]([tag] ASC);

