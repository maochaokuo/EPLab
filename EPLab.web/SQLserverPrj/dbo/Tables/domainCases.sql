CREATE TABLE [dbo].[domainCases] (
    [domainCaseId]          UNIQUEIDENTIFIER CONSTRAINT [DF_domainCases_domainCaseId] DEFAULT (newid()) NOT NULL,
    [domainId]              UNIQUEIDENTIFIER NOT NULL,
    [domainCaseName]        NVARCHAR (50)    NOT NULL,
    [rangeMin]              NVARCHAR (50)    NULL,
    [rangeMax]              NVARCHAR (50)    NULL,
    [domainCaseDescription] NVARCHAR (999)   NULL,
    CONSTRAINT [PK_domainCases] PRIMARY KEY CLUSTERED ([domainId] ASC, [domainCaseName] ASC)
);

