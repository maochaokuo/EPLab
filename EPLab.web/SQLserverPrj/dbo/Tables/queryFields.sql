CREATE TABLE [dbo].[queryFields] (
    [queryFieldId] UNIQUEIDENTIFIER NOT NULL,
    [queryId]      UNIQUEIDENTIFIER NOT NULL,
    [fieldId]      UNIQUEIDENTIFIER NULL,
    [displayOrder] INT              CONSTRAINT [DF_queryFields_displayOrder] DEFAULT ((0)) NOT NULL,
    [orderByOrder] INT              CONSTRAINT [DF_queryFields_orderByOrder] DEFAULT ((0)) NOT NULL,
    [pre1fieldId]  UNIQUEIDENTIFIER NULL,
    [pre2fieldId]  UNIQUEIDENTIFIER NULL,
    [expressionId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_queryFields_1] PRIMARY KEY CLUSTERED ([queryFieldId] ASC)
);






GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'for order by field, 0: hidden, >0 order by this field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'orderByOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'for display field, 0: hidden, >0 order by this field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'displayOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'it will be a new calculated field if it is not from original data (when fieldId,pre1fieldId,pre2fieldId all = null)', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'queryFieldId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'in query result, field of fieldId in previous row of the previous row', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'pre2fieldId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'in query result, field of fieldId in previous row', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'pre1fieldId';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'from expression of expressionId, if this is not from original field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'expressionId';

