CREATE TABLE [dbo].[Agenda]
(
	[IdAgenda] INT NOT NULL PRIMARY KEY, 
    [PatName] VARCHAR(100) NOT NULL, 
    [IDdoctor] INT NOT NULL, 
    [Data] DATETIME NOT NULL, 
    CONSTRAINT [FK] FOREIGN KEY ([IDdoctor]) REFERENCES [DoctorDb]([DoctorId])
);
