CREATE TABLE [dbo].[Agenda] (
    [IdAgenda] INT           NOT NULL IDENTITY(500, 1),
    [PatName]  VARCHAR (100) NOT NULL,
    [IDdoctor] INT           NOT NULL,
    [Data]     DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([IdAgenda] ASC),
    CONSTRAINT [FK3] FOREIGN KEY ([IDdoctor]) REFERENCES [dbo].[DoctorDb] ([DoctorId])
);

