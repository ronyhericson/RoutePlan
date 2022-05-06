/* ::: CRIAÇÂO DAS BASES DE DADOS */

CREATE DATABASE routeplandb
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    LC_COLLATE = 'en_US.utf8'
    LC_CTYPE = 'en_US.utf8'
    TABLESPACE = pg_default
    CONNECTION LIMIT = -1;


/* ::: CRIAÇÃO DAS ESTRUTURAS DA BASE */	

\c routeplandb


/* CONFIGURANDO O TIME ZONE */
SET TIMEZONE TO 'America/Sao_Paulo';


/* EXTENSOES */

CREATE EXTENSION IF NOT EXISTS pgcrypto;

/* .:: INICIO ::. TABLES */

DROP SEQUENCE IF EXISTS routeplan_id_seq;
CREATE SEQUENCE routeplan_id_seq
					 INCREMENT 1
					 MINVALUE 1
					 MAXVALUE 9223372036854775807
					 START 1
					 CACHE 1;

 CREATE TABLE IF NOT EXISTS routeplan
 (
	id int not null DEFAULT nextval('routeplan_id_seq'::regclass),
	date_created timestamp,
	origin varchar(10), 
	destiny varchar(10), 
	price numeric(5,2),
	constraint pk_routeplan_id primary key (id)	
 );
 
 /* .:: INSERTS ::. DEFAULT */
 
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'GRU','BRC',10);
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'BRC','SCL',5);
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'GRU','CDG',75);
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'GRU','SCL',20);
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'GRU','ORL',56);
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'ORL','CDG',5);
 INSERT INTO routeplan (date_created, origin, destiny, price) VALUES (now(), 'SCL','ORL',20);
