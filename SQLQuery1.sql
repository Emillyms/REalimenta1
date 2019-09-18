CREATE DATABASE bd_realimenta;

USE bd_realimenta;

CREATE TABLE continente 
(
	continente_id INT IDENTITY NOT NULL,
    nome VARCHAR(25) NOT NULL
	Primary key (continente_id)
);

CREATE TABLE pais
(
	pais_id INT IDENTITY NOT NULL,
    nome VARCHAR(25) NOT NULL,
    continente_id INT NOT NULL
	Primary key (pais_id)
	Foreign key (continente_id) references continente (continente_id)
);

CREATE TABLE estado
(
	estado_id INT IDENTITY NOT NULL,
    nome VARCHAR(25) NOT NULL,
    pais_id INT NOT NULL
	Primary key (estado_id),
	Foreign key (pais_id) references pais (pais_id)
);

CREATE TABLE localidade
(
	localidade_id INT IDENTITY NOT NULL,
    cidade VARCHAR(25) NOT NULL,
    endereco VARCHAR(40) NOT NULL,
    estado_id INT,
	Primary key (localidade_id),
	Foreign key (estado_id) references estado (estado_id)
);

CREATE TABLE mercado
(
	mercado_id INT IDENTITY NOT NULL,
    cnpj VARCHAR(18) NOT NULL,
    razao_social VARCHAR(25) NOT NULL,
    email VARCHAR(30) NOT NULL,
    responsavel VARCHAR(25) NOT NULL,
    contato VARCHAR(25) NOT NULL,
    localidade_id INT NOT NULL,
	Primary key (mercado_id),
	Foreign key (localidade_id) references localidade (localidade_id)
);

CREATE TABLE ong
(
	ong_id INT IDENTITY NOT NULL,
    cnpj VARCHAR(18) NOT NULL,
    razao_social VARCHAR(25) NOT NULL,
    atividade VARCHAR(50) NOT NULL,
    email VARCHAR(30) NOT NULL,
    responsavel VARCHAR(25) NOT NULL,
    contato VARCHAR(25) NOT NULL,
    localidade_id INT NOT NULL,
	Primary key (ong_id),
	Foreign key (localidade_id) references localidade (localidade_id)
);

CREATE TABLE categoria_alimento
(
	categoriaalimento_id INT IDENTITY  NOT NULL,
    nome VARCHAR(25) NOT NULL,
	Primary key (categoriaalimento_id)
);

CREATE TABLE alimento
(
	alimento_id INT IDENTITY NOT NULL,
    validade DATE NOT NULL,
    quantidade INT NOT NULL,
    nome VARCHAR(25) NOT NULL,
    detalhes VARCHAR(50) NOT NULL,
    origem VARCHAR(25) NOT NULL,
    mercado_id INT NOT NULL,
    categoriaalimento_id INT NOT NULL,
	Primary key (alimento_id),
	Foreign key (mercado_id) references mercado (mercado_id),
	Foreign key (categoriaalimento_id) references categoria_alimento (categoriaalimento_id),
);

CREATE TABLE categoria_higiene
(
	categoriahigiene_id INT IDENTITY NOT NULL,
    nome VARCHAR(25) NOT NULL,
	Primary key (categoriahigiene_id)
);

CREATE TABLE higiene 
(
	higiene_id INT IDENTITY NOT NULL,
    validade DATE NOT NULL,
    quantidade INT NOT NULL,
    nome VARCHAR(25) NOT NULL,
    detalhes VARCHAR(50) NOT NULL,
    origem VARCHAR(25) NOT NULL,
    mercado_id INT NOT NULL,
    categoriahigiene_id INT NOT NULL,
	Primary key (higiene_id),
	Foreign key (mercado_id) references mercado (mercado_id),
	Foreign key (categoriahigiene_id) references categoria_higiene (categoriahigiene_id),
);

CREATE TABLE doacao
(
	doacao_id INT IDENTITY NOT NULL,
	ong_id INT NOT NULL,
    mercado_id INT NOT NULL,
    alimento_id INT NOT NULL,
    higiene_id INT NOT NULL,
	Primary key (doacao_id),
	Foreign key (ong_id) references ong (ong_id),
	Foreign key (mercado_id) references mercado (mercado_id),
	Foreign key (alimento_id) references alimento (alimento_id),
	Foreign key (higiene_id) references higiene (higiene_id)
);
