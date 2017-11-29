DROP TABLE IF EXISTS FacturesRapports;
DROP TABLE IF EXISTS ProduitsFactures;
DROP TABLE IF EXISTS RapportsSommaires;
DROP TABLE IF EXISTS RapportsFacturationCliente;
DROP TABLE IF EXISTS RapportsVentesProduit;
DROP TABLE IF EXISTS Rapports;
DROP TABLE IF EXISTS Factures;
DROP TABLE IF EXISTS GabaritsCriteres;
DROP TABLE IF EXISTS Criteres;
DROP TABLE IF EXISTS TypesCriteres;
DROP TABLE IF EXISTS Gabarits;
DROP TABLE IF EXISTS Produits;
DROP TABLE IF EXISTS Inventaires;
DROP TABLE IF EXISTS Clients;
DROP TABLE IF EXISTS Sexes;
DROP TABLE IF EXISTS Rangs;
DROP TABLE IF EXISTS Provinces;

#####################################
#			Table Sexes			    #
#####################################
CREATE TABLE IF NOT EXISTS Sexes 
( 	idSexe INT AUTO_INCREMENT PRIMARY KEY,
	sexe VARCHAR(20)
);

ALTER TABLE Sexes
ADD CONSTRAINT Sexes_sexe_UK
UNIQUE (sexe);
#####################################
#			Table Rangs			    #
#####################################
CREATE TABLE IF NOT EXISTS Rangs
(	idRang INT AUTO_INCREMENT PRIMARY KEY,
	nom VARCHAR(40),
    escompte DECIMAL (5,2)
);
ALTER TABLE Rangs
ADD CONSTRAINT Rangs_rang_UK
UNIQUE (nom);
#####################################
#			Table Provinces			#
#####################################
CREATE TABLE IF NOT EXISTS Provinces
(	idProvince INT AUTO_INCREMENT PRIMARY KEY,
	nom VARCHAR(50)
);
ALTER TABLE Provinces
ADD CONSTRAINT Provinces_Province_UK
UNIQUE (nom);


#####################################
#			Table Clients			#
#####################################
CREATE TABLE IF NOT EXISTS Clients
(	idClient INT AUTO_INCREMENT PRIMARY KEY,
	idSexe INT NULL,
    idRang INT NOT NULL,
    idProvince INT NULL,
    nom VARCHAR(50) NOT NULL,
    prenom VARCHAR(50) NULL,
    adresse VARCHAR(100) NULL,
    codePostal VARCHAR(10) NULL,
    description VARCHAR(150) NULL,
    codeClient VARCHAR(10) NOT NULL,
    telephone VARCHAR(10) NULL,
    estActif BOOLEAN NOT NULL DEFAULT '1'
);


ALTER TABLE Clients
ADD CONSTRAINT Clients_sexe_FK
FOREIGN KEY (idSexe) REFERENCES Sexes (idSexe);

ALTER TABLE Clients
ADD CONSTRAINT Clients_rang_FK
FOREIGN KEY (idRang) REFERENCES Rangs (idRang);

ALTER TABLE Clients
ADD CONSTRAINT Clients_province_FK
FOREIGN KEY (idProvince) REFERENCES Provinces (idProvince);



#####################################
#			Table Produits			#
#####################################
CREATE TABLE IF NOT EXISTS Produits
(	idProduit INT AUTO_INCREMENT PRIMARY KEY,
	nom VARCHAR(50) NOT NULL,
    description VARCHAR(200) NOT NULL,
    prix DECIMAL(10,2) NOT NULL,
    quantite DECIMAL (10,2),
    nbHeure DECIMAL (10,2),
    estActif BOOL NOT NULL DEFAULT '1'
);


#########################################
#             Table Gabarits            #
#########################################
CREATE TABLE IF NOT EXISTS Gabarits
(	idGabarit INT AUTO_INCREMENT PRIMARY KEY,
	titreGabarit VARCHAR(50),
    logo VARCHAR(250),
    dateCreation DATETIME
);

############################################
#            Table TypesCriteres           #
############################################
CREATE TABLE IF NOT EXISTS TypesCriteres
(	idTypeCritere INT AUTO_INCREMENT PRIMARY KEY,
	typeDuCritere VARCHAR(50) NOT NULL,
    nom VARCHAR(50) NOT NULL
);

ALTER TABLE TypesCriteres
ADD CONSTRAINT TypesCriteres_typeDuCritere_nom_UK
UNIQUE (typeDuCritere, nom);

#########################################
#            Table Criteres             #
#########################################
CREATE TABLE IF NOT EXISTS Criteres
(	idCritere INT AUTO_INCREMENT PRIMARY KEY,
    idTypeCritere INT NOT NULL,
	titre VARCHAR(50)
);

ALTER TABLE Criteres
ADD CONSTRAINT Criteres_idTypeCritere_FK
FOREIGN KEY (idTypeCritere) REFERENCES TypesCriteres(idTypeCritere);

#############################################
#             GabaritsCriteres              #
#############################################
CREATE TABLE IF NOT EXISTS GabaritsCriteres
(	idGabaritCritere INT AUTO_INCREMENT PRIMARY KEY,
	idGabarit INT NOT NULL,
    idCritere INT NOT NULL,
    positionCritere INT,
    largeur INT,
    estUtilise BOOL
);

ALTER TABLE GabaritsCriteres
ADD CONSTRAINT GabaritsCriteres_idCritere_FK
FOREIGN KEY (idCritere) REFERENCES Criteres(idCritere);

ALTER TABLE GabaritsCriteres
ADD CONSTRAINT GabaritsCriteres_idGabarit_FK
FOREIGN KEY (idGabarit) REFERENCES Gabarits(idGabarit);

ALTER TABLE GabaritsCriteres
ADD CONSTRAINT GabaritsCritere_idGabarit_idCritere_UK
UNIQUE (idGabarit, idCritere);

#########################################
#			Table Factures				#
#########################################
CREATE TABLE IF NOT EXISTS Factures
(	idFacture INT AUTO_INCREMENT PRIMARY KEY,
	idClient INT NOT NULL,
    idGabarit INT NOT NULL,
    dateFacture DATETIME NOT NULL
);

ALTER TABLE Factures
ADD CONSTRAINT Facture_Client_FK
FOREIGN KEY (idClient) REFERENCES Clients(idClient);

ALTER TABLE Factures
ADD CONSTRAINT Factures_idGabarit_FK
FOREIGN KEY (idGabarit) REFERENCES Gabarits(idGabarit);

ALTER TABLE factures
ADD CONSTRAINT Factures_idClient_Date_UK
UNIQUE (idClient, dateFacture);


#####################################
#		Table ProduitsFactures		#
#####################################
CREATE TABLE IF NOT EXISTS ProduitsFactures
( 	idProduitFacture INT AUTO_INCREMENT PRIMARY KEY,
	idProduit INT NOT NULL,
    idFacture INT NOT NULL,
    quantite INT NOT NULL
);

ALTER TABLE ProduitsFactures
ADD CONSTRAINT ProduitsFactures_produit_FK
FOREIGN KEY (idProduit) REFERENCES Produits(idProduit);

ALTER TABLE ProduitsFactures
ADD CONSTRAINT ProduitsFactures_Facture_FK
FOREIGN KEY (idFacture) REFERENCES Factures(idFacture);

ALTER TABLE ProduitsFactures
ADD CONSTRAINT ProduitsFactures_idProduitidFacture_FK
UNIQUE(idFacture,idProduit);

#####################################
#			Table Rapports			#
#####################################
CREATE TABLE IF NOT EXISTS Rapports
(	idRapport INT AUTO_INCREMENT PRIMARY KEY,
	dateRapport DATETIME NOT NULL
);

ALTER TABLE Rapports
ADD CONSTRAINT Rapports_dateRapport
UNIQUE(dateRapport);


#############################################
#			Table FacturesRapports			#
#############################################
CREATE TABLE IF NOT EXISTS FacturesRapports
(	idFacturesRapports INT AUTO_INCREMENT PRIMARY KEY,
	idRapport INT NOT NULL,
    idFacture INT NOT NULL
);

ALTER TABLE FacturesRapports
ADD CONSTRAINT FacturesRapports_idFacturei_FK
FOREIGN KEY (idFacture) REFERENCES Factures(idFacture);

ALTER TABLE FacturesRapports
ADD CONSTRAINT FacturesRapports_idRapport_FK
FOREIGN KEY (idRapport) REFERENCES Rapports(idRapport);

ALTER TABLE FacturesRapports
ADD CONSTRAINT FacturesRapport_idFactureidRapport_FK
UNIQUE(idFacture,idRapport);

#############################################
#			Table RapportsSommaires			#
#############################################
CREATE TABLE IF NOT EXISTS RapportsSommaires
(	idRapportSommaire INT AUTO_INCREMENT PRIMARY KEY
);

ALTER TABLE RapportsSommaires
ADD CONSTRAINT RappportsSommaires_idRapportSommaire_FK
FOREIGN KEY(idRapportSommaire) REFERENCES Rapports(idRapport);


#########################################################
#			Table RapportsFacturationCliente			#
#########################################################
CREATE TABLE IF NOT EXISTS RapportsFacturationCliente
(	idRapportFacturationCliente INT AUTO_INCREMENT PRIMARY KEY
);
ALTER TABLE RapportsFacturationCliente
ADD CONSTRAINT RapportFacturationCliente_idRapportFacturationCliente_FK
FOREIGN KEY(idRapportFacturationCliente) REFERENCES Rapports(idRapport);

#################################################
#			Table RapportsVenteProduit			#
#################################################
CREATE TABLE IF NOT EXISTS RapportsVentesProduit
(	idRapportVenteProduit INT AUTO_INCREMENT PRIMARY KEY,
	idProduit INT NOT NULL
);
ALTER TABLE RapportsVentesProduit
ADD CONSTRAINT RapportsVentesProduit_idRapportFacturationCliente_FK
FOREIGN KEY(idRapportVenteProduit) REFERENCES Rapports(idRapport);

ALTER TABLE RapportsVentesProduit
ADD CONSTRAINT RapportsVentesProduit_idProduit_FK
FOREIGN KEY(idProduit) REFERENCES Produits(idProduit);
