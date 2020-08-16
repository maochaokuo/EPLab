CREATE TABLE [dbo].[queryFields] (
    [queryFieldId] UNIQUEIDENTIFIER CONSTRAINT [DF_queryFields_queryFieldId] DEFAULT (newid()) NOT NULL,
    [queryId]      UNIQUEIDENTIFIER NOT NULL,
    [fieldId]      UNIQUEIDENTIFIER NULL,
    [previousNo]   SMALLINT         CONSTRAINT [DF_queryFields_previousNo] DEFAULT ((0)) NULL,
    [displayOrder] INT              CONSTRAINT [DF_queryFields_displayOrder] DEFAULT ((0)) NOT NULL,
    [orderByOrder] INT              CONSTRAINT [DF_queryFields_orderByOrder] DEFAULT ((0)) NOT NULL,
    [expressionId] UNIQUEIDENTIFIER NULL,
    [save2fieldId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_queryFields_1] PRIMARY KEY CLUSTERED ([queryFieldId] ASC)
);










GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'for order by field, 0: hidden, >0 order by this field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'orderByOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'for display field, 0: hidden, >0 order by this field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'displayOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'it will be a new calculated field if it is not from original data (when fieldId,pre1fieldId,pre2fieldId all = null)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'queryFieldId';


GO



GO



GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'from expression of expressionId, if this is not from original field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'expressionId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'對應資料庫中的欄位代碼', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'fieldId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'這是若expressionId非null, 計算出來的值, 要存回哪個欄位', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'save2fieldId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'前面的fieldId, 要取query結果中的, 前第previousNo筆, 目前僅規劃0,1,2三種值', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'previousNo';

