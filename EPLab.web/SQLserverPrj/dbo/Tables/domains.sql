CREATE TABLE [dbo].[domains] (
    [domainId]          UNIQUEIDENTIFIER CONSTRAINT [DF_domains_domainId] DEFAULT (newid()) NOT NULL,
    [domainName]        VARCHAR (50)     NOT NULL,
    [domainDescription] NVARCHAR (999)   NULL,
    [basicType]         NVARCHAR (50)    NULL,
    [isDomainCaseId]    UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_domains] PRIMARY KEY CLUSTERED ([domainId] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_domains]
    ON [dbo].[domains]([domainName] ASC);

