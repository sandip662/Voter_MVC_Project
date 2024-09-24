USE [VOTER_DB]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_VOTER_DB]    Script Date: 25-05-2024 17:57:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_GET_VOTER_DB]
	
 @VOTER_KEY INT
	

As
Begin 

SET NOCOUNT ON;
	
   BEGIN TRY
       
        BEGIN TRANSACTION;

        
		
		IF(@VOTER_KEY = 0)
        BEGIN
			
            SELECT v.*, s.STATE_NAME, c.CITY_NAME
			FROM  VOTER v WITH (NOLOCK) 
			INNER JOIN GENDER_MASTER g ON v.GENDER_ID = g.GENDER_MASTER_KEY
			INNER JOIN STATE_TABLE s ON v.STATE_ID =s.STATE_ID
			INNER JOIN CITY_TABLE c ON v.CITY_ID = c.CITY_ID
			 WHERE V.ACTIVE_FLAG = 1
								
		END

		 ELSE  
        BEGIN
	
			 SELECT v.*, s.STATE_NAME, c.CITY_NAME
			 FROM  VOTER v WITH (NOLOCK) 
			 INNER JOIN GENDER_MASTER g ON v.GENDER_ID = g.GENDER_MASTER_KEY
			 INNER JOIN STATE_TABLE s ON v.STATE_ID =s.STATE_ID
			 INNER JOIN CITY_TABLE c ON v.CITY_ID = c.CITY_ID
			  WHERE v.VOTER_KEY = @VOTER_KEY 
            
        END

    



	IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        RETURN @VOTER_KEY;
    END TRY
    BEGIN CATCH
        IF @@ERROR <> 0  
        BEGIN
            ROLLBACK TRANSACTION;
            INSERT INTO tblErrorMessage (spName, errorMessage, systemDate)
            VALUES ('SP_GET_VOTER_DB', ERROR_MESSAGE(), GETDATE());
            SET @VOTER_KEY = 0;
        END
    END CATCH
END