// http://devmate.net/2017/10/entity-framework-the-query-plan-cache-story/
//ef不会缓存将参数直接输入的查询
var contacts = dbContext.Contacts.Where(x => x.Name == "Adam").ToList();

SELECT
    [Extent1].[Id] AS [Id],
    [Extent1].[Name] AS [Name],
    [Extent1].[IsDeleted] AS [IsDeleted]
    FROM [dbo].[Contacts] AS [Extent1]
    WHERE N'Adam' = [Extent1].[Name]


//----------------------------------------------------
//采用参数化查询可以直接提高查询的速度
string name = "Adam";
var contacts = dbContext.Contacts.Where(x => x.Name == name).ToList();

exec sp_executesql SELECT
    [Extent1].[Id] AS [Id],
    [Extent1].[Name] AS [Name],
    [Extent1].[IsDeleted] AS [IsDeleted]
    FROM [dbo].[Contacts] AS [Extent1]
    WHERE ([Extent1].[Name] = @p__linq__0) OR (([Extent1].[Name] IS NULL) AND (@p__linq__0 IS NULL)),N'@p__linq__0 nvarchar(4000)',@p__linq__0=N'Adam'

//------------------------------------------------------

int skip = 15;
int take = 10;
var contacts = dbContext.Contacts.OrderBy(x => x.Id).Skip(() => skip).Take(() => take).ToList();


exec sp_executesql N'SELECT
    [Extent1].[Id] AS [Id],
    [Extent1].[Name] AS [Name],
    [Extent1].[IsDeleted] AS [IsDeleted]
    FROM [dbo].[Contacts] AS [Extent1]
    ORDER BY [Extent1].[Id] ASC
    OFFSET @p__linq__0 ROWS FETCH NEXT @p__linq__1 ROWS ONLY ',N'@p__linq__0 int,@p__linq__1 int',@p__linq__0=16,@p__linq__1=10

//-----------------------------------------------------------

int[] ids = {1, 2, 3};
var contacts = dbContext.Contacts.Where(c => ids.Contains(c.Id)).ToList();

SELECT
    [Extent1].[Id] AS [Id],
    [Extent1].[Name] AS [Name],
    [Extent1].[IsDeleted] AS [IsDeleted]
    FROM [dbo].[Contacts] AS [Extent1]
    WHERE [Extent1].[Id] IN (1, 2, 3)
