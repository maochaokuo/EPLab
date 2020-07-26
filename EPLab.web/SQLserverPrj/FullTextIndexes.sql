CREATE FULLTEXT INDEX ON [dbo].[tables]
    ([tableName] LANGUAGE 1033, [tableDesc] LANGUAGE 1033)
    KEY INDEX [PK_tables]
    ON [c];


GO
CREATE FULLTEXT INDEX ON [dbo].[fieldValues]
    ([fieldValue] LANGUAGE 1033)
    KEY INDEX [PK_fieldValues]
    ON [c];


GO
CREATE FULLTEXT INDEX ON [dbo].[fieldText]
    ([fieldText] LANGUAGE 1033)
    KEY INDEX [PK_fieldText]
    ON [c];


GO
CREATE FULLTEXT INDEX ON [dbo].[fields]
    ([fieldName] LANGUAGE 1033, [fieldDesc] LANGUAGE 1033)
    KEY INDEX [PK_fields]
    ON [c];

