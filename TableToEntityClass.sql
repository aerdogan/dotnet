-- MSSQL için aktif veritabanının C# Entity Class'larınızı oluşturur

declare @tableName varchar(200)
declare @columnName varchar(200)
declare @datatype varchar(50)
declare @sType varchar(50)
declare @sProperty varchar(200)

DECLARE table_cursor CURSOR FOR 
SELECT TABLE_NAME
FROM [INFORMATION_SCHEMA].[TABLES]

OPEN table_cursor

FETCH NEXT FROM table_cursor 
INTO @tableName

WHILE @@FETCH_STATUS = 0
BEGIN

PRINT 'public class ' + LEFT(@tableName, LEN(@tableName) - 1) + ' : IEntity
{'

    DECLARE column_cursor CURSOR FOR 
    SELECT COLUMN_NAME, DATA_TYPE
    from [INFORMATION_SCHEMA].[COLUMNS] 
	WHERE [TABLE_NAME] = @tableName
	order by [ORDINAL_POSITION]

    OPEN column_cursor
    FETCH NEXT FROM column_cursor INTO @columnName, @datatype

    WHILE @@FETCH_STATUS = 0
    BEGIN

	-- datatype
	select @sType = case @datatype
	when 'int' then 'Int32'
	when 'decimal' then 'Decimal'
	when 'money' then 'Decimal'
	when 'char' then 'String'
	when 'nchar' then 'String'
	when 'varchar' then 'String'
	when 'nvarchar' then 'String'
	when 'uniqueidentifier' then 'Guid'
	when 'datetime' then 'DateTime'
	when 'bit' then 'Boolean'
	else 'String'
	END
		SELECT @sProperty = '	public ' + @sType + ' ' + @columnName + ' { get; set;}'
		PRINT @sProperty
		FETCH NEXT FROM column_cursor INTO @columnName, @datatype
	END
    CLOSE column_cursor
    DEALLOCATE column_cursor

	print '}'
	print ''
    FETCH NEXT FROM table_cursor 
    INTO @tableName
END
CLOSE table_cursor
DEALLOCATE table_cursor
