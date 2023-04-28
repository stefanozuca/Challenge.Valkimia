CREATE TABLE [Facturacion].[Facturas] (
    [Id]        UNIQUEIDENTIFIER NOT NULL,
    [IdCliente] UNIQUEIDENTIFIER NOT NULL,
    [Fecha]     DATETIME         NOT NULL,
    [Detalle]   VARCHAR (200)    NOT NULL,
    [Importe]   DECIMAL (18, 2)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FacturaCliente] FOREIGN KEY ([IdCliente]) REFERENCES [Facturacion].[Clientes] ([Id])
);

