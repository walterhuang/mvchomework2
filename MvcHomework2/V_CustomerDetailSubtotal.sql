CREATE VIEW [dbo].[V_CustomerDetailSubtotal]
	AS SELECT A.Id
             ,MAX(A.客戶名稱) CustomerName
             ,COUNT(DISTINCT B.Id) NumOfBanks
             ,COUNT(DISTINCT C.Id) NumOfContacts
         FROM 客戶資料 A
    LEFT JOIN 客戶銀行資訊 B ON A.Id = B.客戶Id
    LEFT JOIN 客戶聯絡人 C ON A.Id = C.客戶Id
     GROUP BY A.Id

-- v2 for IsDelete
       SELECT A.Id
             ,MAX(A.客戶名稱) CustomerName
             ,COUNT(DISTINCT B.Id) NumOfBanks
             ,COUNT(DISTINCT C.Id) NumOfContacts
         FROM 客戶資料 A
    LEFT JOIN 客戶銀行資訊 B ON A.Id = B.客戶Id
    LEFT JOIN 客戶聯絡人 C ON A.Id = C.客戶Id
	    WHERE A.IsDelete = 0 
	      AND (B.IsDelete IS NULL OR B.IsDelete = 0)
	      AND (C.IsDelete IS NULL OR C.IsDelete = 0)
     GROUP BY A.Id
