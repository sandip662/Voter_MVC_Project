USE [VOTER_DB]
GO
/****** Object:  StoredProcedure [dbo].[SP_GET_GENDER] 3   Script Date: 28-05-2024 02:32:07 ******/

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[SP_GET_GENDER]
	
 @GENDER_ID INT
	

As
Begin 

SET NOCOUNT ON;
	
   BEGIN TRY
       
        BEGIN TRANSACTION;

        
		
		IF(@GENDER_ID = 0)
        BEGIN
			
            SELECT * FROM  GENDER_MASTER WITH (NOLOCK)  
								
		END

		 ELSE  
        BEGIN
	
			 SELECT * FROM  GENDER_MASTER WITH (NOLOCK) WHERE  GENDER_ID = @GENDER_ID 
            
        END

    



	IF @@TRANCOUNT > 0
        BEGIN
            COMMIT TRANSACTION;
        END

        RETURN @GENDER_ID;
    END TRY
    BEGIN CATCH
        IF @@ERROR <> 0  
        BEGIN
            ROLLBACK TRANSACTION;
            INSERT INTO tblErrorMessage (spName, errorMessage, systemDate)
            VALUES ('SP_GET_GENDER', ERROR_MESSAGE(), GETDATE());
            SET @GENDER_ID = 0;
        END
    END CATCH
END