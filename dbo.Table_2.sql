CREATE TABLE [dbo].[Tratamento]
(
	[IdTratamento] INT NOT NULL PRIMARY KEY, 
    [PATID] INT NOT NULL, 
    [DocID] INT NOT NULL, 
    [Valor] FLOAT NOT NULL, 
    [PATName] VARCHAR(50) NOT NULL, 
    [DOCName] VARCHAR(50) NOT NULL, 
    CONSTRAINT [FK] FOREIGN KEY ([PATID]) REFERENCES [Paciente]([Patid]), 
    CONSTRAINT [FK2] FOREIGN KEY ([DocID]) REFERENCES [DoctorDb]([DoctorId])
);
