CREATE TABLE [Facturacion].[Clientes] (
    [Id]         UNIQUEIDENTIFIER NOT NULL,
    [Nombre]     VARCHAR (50)     NOT NULL,
    [Apellido]   VARCHAR (50)     NOT NULL,
    [Domicilio]  VARCHAR (50)     NOT NULL,
    [Email]      VARCHAR (100)    NOT NULL,
    [Password]   VARCHAR (100)    NOT NULL,
    [IdCiudad]   UNIQUEIDENTIFIER NOT NULL,
    [Habilitado] BIT              NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_ClienteCiudad] FOREIGN KEY ([IdCiudad]) REFERENCES [Facturacion].[Ciudades] ([Id])
);

