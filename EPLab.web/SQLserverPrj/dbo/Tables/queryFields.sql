CREATE TABLE [dbo].[queryFields] (
    [queryFieldId] INT              IDENTITY (1, 1) NOT NULL,
    [queryId]      UNIQUEIDENTIFIER NOT NULL,
    [fieldId]      UNIQUEIDENTIFIER NOT NULL,
    [displayOrder] INT              CONSTRAINT [DF_queryFields_displayOrder] DEFAULT ((0)) NOT NULL,
    [orderByOrder] INT              CONSTRAINT [DF_queryFields_orderByOrder] DEFAULT ((0)) NOT NULL,
    [editable]     BIT              CONSTRAINT [DF_queryFields_editable] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_queryFields] PRIMARY KEY CLUSTERED ([queryFieldId] ASC)
);




GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'for order by field, 0: hidden, >0 order by this field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'orderByOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'for display field, 0: hidden, >0 order by this field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'displayOrder';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'1 editable, but displayOrder must > 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'queryFields', @level2type = N'COLUMN', @level2name = N'editable';

