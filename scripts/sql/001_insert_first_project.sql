USE [PortfolioDB]
GO

BEGIN
	BEGIN TRY
		BEGIN TRANSACTION;
            INSERT INTO [dbo].[Project]
                ([Title]
                ,[Description]
                ,[Category]
                ,[Status])
            VALUES (
                'Title', 
                'Description',
                1,
                2
             )
		COMMIT TRANSACTION;
	END TRY
	BEGIN CATCH
		ROLLBACK TRANSACTION;
		THROW;
	END CATCH
END;
GO
