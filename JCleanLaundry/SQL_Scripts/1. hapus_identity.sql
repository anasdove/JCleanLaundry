--Jalankan script ini jika gagal mendaftarkan user baru

DROP TABLE dbo.AspNetUserRoles
DROP TABLE dbo.AspNetUserLogins
DROP TABLE dbo.AspNetUserClaims
DROP TABLE dbo.AspNetRoles
DROP TABLE dbo.AspNetUsers
DROP TABLE dbo.[__MigrationHistory]

SELECT * FROM [dbo].[__MigrationHistory]
DELETE FROM [dbo].[__MigrationHistory]