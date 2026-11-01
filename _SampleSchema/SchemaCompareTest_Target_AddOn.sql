USE SchemaCompareTest_Target;
GO

-- ============================================================
-- Additional schema comparison scenarios
-- All new objects use the dbo schema explicitly.
-- ============================================================
CREATE TABLE dbo.TestCompare_Index(
    IDNo INT NOT NULL IDENTITY(1, 1),
    GroupNo INT NOT NULL,
    SearchCode VARCHAR(40) NOT NULL,
    SearchName NVARCHAR(100) NOT NULL,
    ExtraValue NVARCHAR(100) NULL,
    IsDelete VARCHAR(5) NOT NULL CONSTRAINT DE_TestCompare_Index__IsDelete DEFAULT('FALSE'),
    IsActive BIT NOT NULL CONSTRAINT DE_TestCompare_Index__IsActive DEFAULT(1),
    CreateDate DATETIME NOT NULL CONSTRAINT DE_TestCompare_Index__CreateDate DEFAULT(GETDATE()),
    CONSTRAINT PK_TestCompare_Index PRIMARY KEY (IDNo)
);
GO

-- [SAME] Filtered index definition on both sides.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__FilterSame
ON dbo.TestCompare_Index (SearchCode ASC)
INCLUDE (SearchName)
WHERE IsDelete = 'FALSE';
GO

-- [SAME] Explicit ASC vs implicit ASC; expected equivalent key definition.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__KeySame
ON dbo.TestCompare_Index (GroupNo, SearchCode);
GO

-- [SAME] UNIQUE constraint vs UNIQUE constraint.
ALTER TABLE dbo.TestCompare_Index
ADD CONSTRAINT UQ_TestCompare_Index__SearchCode UNIQUE (SearchCode);
GO

CREATE TABLE dbo.TestCompare_Parent(
    ParentID INT NOT NULL,
    ParentCode VARCHAR(30) NOT NULL,
    CONSTRAINT PK_TestCompare_Parent PRIMARY KEY (ParentID),
    CONSTRAINT UQ_TestCompare_Parent__Code UNIQUE (ParentCode)
);
GO

CREATE TABLE dbo.TestCompare_Child(
    ChildID INT NOT NULL,
    ParentID INT NOT NULL,
    ChildCode VARCHAR(30) NOT NULL,
    CONSTRAINT PK_TestCompare_Child PRIMARY KEY (ChildID)
);
GO

-- [SAME] FK with default NO ACTION on both sides.
ALTER TABLE dbo.TestCompare_Child
ADD CONSTRAINT FK_TestCompare_Child__Parent
FOREIGN KEY (ParentID) REFERENCES dbo.TestCompare_Parent (ParentID);
GO


-- [DIFF] Same index name and key, but no WHERE filter on Target.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__FilterOnlySource
ON dbo.TestCompare_Index (GroupNo ASC);
GO

-- [DIFF] Filter predicate differs by one literal.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__FilterDifferent
ON dbo.TestCompare_Index (IsDelete ASC, CreateDate DESC)
WHERE IsDelete = 'TRUE';
GO

-- [DIFF] No INCLUDE on Target.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__IncludeDifferent
ON dbo.TestCompare_Index (CreateDate DESC);
GO

-- [DIFF] Same name and keys, but UNIQUE CONSTRAINT rather than UNIQUE INDEX.
ALTER TABLE dbo.TestCompare_Index
ADD CONSTRAINT UQ_TestCompare_Index__GroupSearch UNIQUE NONCLUSTERED (GroupNo, SearchName);
GO

-- [DIFF] Target index disabled.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__DisabledDifferent
ON dbo.TestCompare_Index (ExtraValue);
GO
ALTER INDEX IDX_TestCompare_Index__DisabledDifferent ON dbo.TestCompare_Index DISABLE;
GO

-- [DIFF] Target-only index; source-oriented comparator may intentionally ignore it.
CREATE NONCLUSTERED INDEX IDX_TestCompare_Index__TargetOnly
ON dbo.TestCompare_Index (SearchName);
GO

-- [DIFF] FK referential action (Source CASCADE, Target NO ACTION).
ALTER TABLE dbo.TestCompare_Child
ADD CONSTRAINT FK_TestCompare_Child__ParentCode
FOREIGN KEY (ChildCode) REFERENCES dbo.TestCompare_Parent (ParentCode)
ON UPDATE NO ACTION;
GO
