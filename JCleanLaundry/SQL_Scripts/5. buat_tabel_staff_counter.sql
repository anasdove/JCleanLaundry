-- BUAT TABEL STAFF COUNTER
DROP TABLE [STAFF_COUNTER]

CREATE TABLE [STAFF_COUNTER]
(
	Kode			INT NOT NULL PRIMARY KEY IDENTITY, 
	Kode_Counter	VARCHAR(10) NOT NULL,
	Kode_Staff		NVARCHAR(128) NOT NULL
)
GO

ALTER TABLE [STAFF_COUNTER] WITH CHECK ADD CONSTRAINT [STAFF_COUNTER_COUNTER_FK] FOREIGN KEY(Kode_Counter)
REFERENCES [COUNTER] (Kode_Counter)
GO

ALTER TABLE [STAFF_COUNTER] WITH CHECK ADD CONSTRAINT [STAFF_COUNTER_STAFF_FK] FOREIGN KEY(Kode_Staff)
REFERENCES [AspNetUsers] (Id)
GO

--TAMBAH DATA [STAFF_COUNTER]
INSERT INTO [STAFF_COUNTER] VALUES('C001', '2a879e21-2045-4651-8a96-f2b3ac51f3a5') 
INSERT INTO [STAFF_COUNTER] VALUES('C002', '44079694-2b33-42ac-a3d0-a0ae7859fcd3') 