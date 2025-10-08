use master;
drop database Botiga;
CREATE database Botiga;
use Botiga;
CREATE TABLE Families_Productes (
   Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), 
   Nom NVARCHAR(100) NOT NULL,                      
   Descripcio TEXT                        
);
CREATE TABLE Productes (
   Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), 
   Nom NVARCHAR(100) NOT NULL,
   Descripcio TEXT,
   Preu DECIMAL(10,2) NOT NULL,                     
   Descompte INT,                                   
   IdFamilia UNIQUEIDENTIFIER,                      
   CONSTRAINT FK_Productes_Familia
       FOREIGN KEY (IdFamilia) REFERENCES Families_Productes(Id)
);
CREATE TABLE Carros (
   Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), 
   Nom NVARCHAR(100) NOT NULL
);
CREATE TABLE CarroDeLaCompra (
   Id UNIQUEIDENTIFIER PRIMARY KEY DEFAULT NEWID(), 
   IdCarro UNIQUEIDENTIFIER NOT NULL,          
   IdProducte UNIQUEIDENTIFIER NOT NULL,  
   Quantitat INT NOT NULL DEFAULT 1,                
   CONSTRAINT FK_Carro_Producte
       FOREIGN KEY (IdProducte) REFERENCES Productes(Id),
   CONSTRAINT FK_Producte_Carro
       FOREIGN KEY (IdCarro) REFERENCES Carros(Id)
      
);