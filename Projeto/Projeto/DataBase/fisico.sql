-- -----------------------------------------------------
-- Schema
-- -----------------------------------------------------

CREATE database SmartInvest;
GO
USE SmartInvest;

-- -----------------------------------------------------
-- Table `SmartInvest`.`Mercado`
-- -----------------------------------------------------
CREATE TABLE Mercado (
    codigo VARCHAR(50) NOT NULL, 
    pais VARCHAR(50) NOT NULL,
    nome VARCHAR(50) NOT NULL,
    PRIMARY KEY (codigo)
)

-- -----------------------------------------------------
-- Table `SmartInvest`.`Utilizador`
-- -----------------------------------------------------
CREATE TABLE Utilizador (
    user_id INT NOT NULL IDENTITY(1,1),
    user_name VARCHAR(50) NOT NULL,
    email VARCHAR(50) NOT NULL,
    primeiro_nome VARCHAR(50) NOT NULL,
    ultimo_nome VARCHAR(50) NOT NULL,
    password VARCHAR(50) NOT NULL,
    localizacao VARCHAR(50) NOT NULL,
    capacidade FLOAT NOT NULL,
    experiencia INT NOT NULL,
    PRIMARY KEY (user_id)
)

-- -----------------------------------------------------
-- Table `SmartInvest`.`Empresa`
-- -----------------------------------------------------
CREATE TABLE Empresa (
    empresa_id VARCHAR(50) NOT NULL,
    nome VARCHAR(50) NOT NULL,
    localizacao VARCHAR(50) NOT NULL,
    website VARCHAR(50) NOT NULL,
    categoria VARCHAR(50) NOT NULL,
    mercado_codigo VARCHAR(50) NOT NULL,
    PRIMARY KEY (empresa_id),
    FOREIGN KEY (mercado_codigo) REFERENCES Mercado(codigo)
)


-- -----------------------------------------------------
-- Table `SmartInvest`.`Acao`
-- -----------------------------------------------------
CREATE TABLE Acao (
    codigo VARCHAR(50) NOT NULL,
    hora DATETIME NOT NULL,
    high FLOAT NOT NULL,
    low FLOAT NOT NULL,
    avg FLOAT NOT NULL,
    empresa_id VARCHAR(50) NOT NULL,
    PRIMARY KEY (codigo),
    FOREIGN KEY (empresa_id) REFERENCES Empresa(empresa_id)
)

-- -----------------------------------------------------
-- Table `SmartInvest`.`Favorito`
-- -----------------------------------------------------
CREATE TABLE Favorito (
    user_id INT NOT NULL,
    empresa_id VARCHAR(50) NOT NULL,
    avaliacao INT NOT NULL,
    PRIMARY KEY (user_id, empresa_id),
    FOREIGN KEY (user_id) REFERENCES Utilizador(user_id),
    FOREIGN KEY (empresa_id) REFERENCES Empresa(empresa_id)  
)

