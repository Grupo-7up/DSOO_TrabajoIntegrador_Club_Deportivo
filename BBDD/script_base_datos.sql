-- =============================================
-- 1. CREACIÓN DE BASE DE DATOS
-- =============================================
CREATE DATABASE IF NOT EXISTS club_deportivo_grupo7 
CHARACTER SET utf8mb4 
COLLATE utf8mb4_unicode_ci;

USE club_deportivo_grupo7;

-- =============================================
-- 2. CREACIÓN DE TABLAS
-- =============================================

-- Tabla de Usuarios para Autenticación
CREATE TABLE IF NOT EXISTS usuarios (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    usuario VARCHAR(50) NOT NULL UNIQUE,
    clave VARCHAR(255) NOT NULL
);

-- Tabla de Personas
CREATE TABLE IF NOT EXISTS personas (
    id_persona INT AUTO_INCREMENT PRIMARY KEY,
    tipo_documento VARCHAR(10) NOT NULL,
    documento VARCHAR(20) NOT NULL,
    nombre VARCHAR(50) NOT NULL,
    apellido VARCHAR(50) NOT NULL,
    email VARCHAR(100),
    telefono VARCHAR(20),
    fecha_nacimiento DATE,
    -- Evita personas duplicadas con el mismo documento (se recomienda el DNI como clave de unicidad)
    CONSTRAINT uq_persona_documento UNIQUE (tipo_documento, documento)
);

-- Tabla de Clientes
CREATE TABLE IF NOT EXISTS clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    id_persona INT NOT NULL,
    es_socio BOOLEAN NOT NULL DEFAULT FALSE,
    nro_carnet VARCHAR(20) UNIQUE DEFAULT NULL,
    fecha_inscripcion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    validez DATE,
    activo BOOLEAN NOT NULL DEFAULT FALSE,
    apto_fisico BOOLEAN NOT NULL DEFAULT FALSE,
    FOREIGN KEY (id_persona) REFERENCES personas(id_persona) ON DELETE CASCADE
);

-- Tabla de Actividades del Club
CREATE TABLE IF NOT EXISTS actividades (
    id_actividad INT AUTO_INCREMENT PRIMARY KEY,
    nombre VARCHAR(50) NOT NULL,
    cupo INT NOT NULL DEFAULT 0,
    horario TIME NOT NULL,
    valor_actividad DECIMAL(10,2) NOT NULL
);

-- Tabla de Pagos y Comprobantes
CREATE TABLE IF NOT EXISTS pagos (
    id_pago INT AUTO_INCREMENT PRIMARY KEY,
    id_cliente INT NOT NULL,
    fecha_pago DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    concepto VARCHAR(100) NOT NULL,
    monto DECIMAL(10,2) NOT NULL,
    tipo_pago VARCHAR(20) NOT NULL,
    forma_pago VARCHAR(30),
    cantidad_cuotas INT DEFAULT 1,
    periodo_mes INT,
    periodo_anio INT,
    fecha_vencimiento DATE,
    CONSTRAINT fk_pagos_clientes FOREIGN KEY (id_cliente) 
        REFERENCES clientes(id_cliente) ON DELETE CASCADE
);

-- Tabla Relacional: Clientes - Actividades (Muchos a Muchos)
CREATE TABLE IF NOT EXISTS cliente_actividad (
    id_cliente INT NOT NULL,
    id_actividad INT NOT NULL,
    fecha_inscripcion DATETIME DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (id_cliente, id_actividad),
    CONSTRAINT fk_ca_cliente FOREIGN KEY (id_cliente) 
        REFERENCES clientes(id_cliente) ON DELETE CASCADE,
    CONSTRAINT fk_ca_actividad FOREIGN KEY (id_actividad) 
        REFERENCES actividades(id_actividad) ON DELETE CASCADE
);

-- =============================================
-- 3. DATOS DE PRUEBA
-- =============================================

-- Inserción defensiva de usuario administrador base
INSERT IGNORE INTO usuarios (usuario, clave) 
VALUES ('admin', '1234');

-- Inserción de actividades base
INSERT IGNORE INTO actividades (id_actividad, nombre, cupo, horario, valor_actividad) VALUES
(1, 'Musculación', 30, '08:00:00', 1500.00),
(2, 'Natación', 15, '10:00:00', 2500.00),
(3, 'Spinning', 20, '18:00:00', 1800.00);

-- Clientes dummy, para poder testear "Listar vencimientos" apenas se crea la base.
-- 20 clientes: 15 socios (con distintas fechas de validez, dos de ellos vencen justo HOY)
-- y 5 no socios (control: nunca deberían aparecer en el listado).
-- Protegidos con NOT EXISTS / INSERT IGNORE para que no se dupliquen si el script
-- se vuelve a ejecutar (DatabaseInitializer lo corre en cada arranque de la app).
INSERT IGNORE INTO personas (tipo_documento, documento, nombre, apellido, email, telefono, fecha_nacimiento) VALUES
('DNI', '30100001', 'Lucía', 'Fernández', 'lucia.fernandez@mail.com', '3511000001', '1991-02-10'),
('DNI', '30100002', 'Martín', 'Rodríguez', 'martin.rodriguez@mail.com', '3511000002', '1989-06-21'),
('DNI', '30100003', 'Sofía', 'Martínez', 'sofia.martinez@mail.com', '3511000003', '1993-09-15'),
('DNI', '30100004', 'Diego', 'Sánchez', 'diego.sanchez@mail.com', '3511000004', '1987-12-03'),
('DNI', '30100005', 'Valentina', 'Díaz', 'valentina.diaz@mail.com', '3511000005', '1995-04-27'),
('DNI', '30100006', 'Nicolás', 'Romero', 'nicolas.romero@mail.com', '3511000006', '1990-08-08'),
('DNI', '30100007', 'Camila', 'Flores', 'camila.flores@mail.com', '3511000007', '1992-01-19'),
('DNI', '30100008', 'Tomás', 'Acosta', 'tomas.acosta@mail.com', '3511000008', '1988-03-30'),
('DNI', '30100009', 'Julieta', 'Benítez', 'julieta.benitez@mail.com', '3511000009', '1994-07-14'),
('DNI', '30100010', 'Agustín', 'Castro', 'agustin.castro@mail.com', '3511000010', '1986-10-05'),
('DNI', '30100011', 'Florencia', 'Herrera', 'florencia.herrera@mail.com', '3511000011', '1991-11-22'),
('DNI', '30100012', 'Franco', 'Molina', 'franco.molina@mail.com', '3511000012', '1993-05-17'),
('DNI', '30100013', 'Catalina', 'Ortiz', 'catalina.ortiz@mail.com', '3511000013', '1989-09-09'),
('DNI', '30100014', 'Joaquín', 'Silva', 'joaquin.silva@mail.com', '3511000014', '1996-02-25'),
('DNI', '30100015', 'Milagros', 'Vega', 'milagros.vega@mail.com', '3511000015', '1990-12-12'),
('DNI', '30200001', 'Bruno', 'Aguirre', 'bruno.aguirre@mail.com', '3512000001', '1992-06-06'),
('DNI', '30200002', 'Renata', 'Campos', 'renata.campos@mail.com', '3512000002', '1994-03-03'),
('DNI', '30200003', 'Ezequiel', 'Domínguez', 'ezequiel.dominguez@mail.com', '3512000003', '1987-07-21'),
('DNI', '30200004', 'Abril', 'Navarro', 'abril.navarro@mail.com', '3512000004', '1991-10-30'),
('DNI', '30200005', 'Mateo', 'Peralta', 'mateo.peralta@mail.com', '3512000005', '1993-01-08');

-- Socios (15): distintas fechas de validez para cubrir vencidos, vigentes y por vencer
INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 20 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100001'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 15 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100002'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 10 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100003'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 7 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100004'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 5 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100005'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 3 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100006'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_SUB(CURDATE(), INTERVAL 1 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100007'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

-- Estos dos vencen HOY (coincide con el valor por defecto del DateTimePicker)
INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, CURDATE(), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100008'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, CURDATE(), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100009'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_ADD(CURDATE(), INTERVAL 3 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100010'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_ADD(CURDATE(), INTERVAL 5 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100011'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_ADD(CURDATE(), INTERVAL 10 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100012'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_ADD(CURDATE(), INTERVAL 15 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100013'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_ADD(CURDATE(), INTERVAL 20 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100014'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, TRUE, DATE_ADD(CURDATE(), INTERVAL 30 DAY), TRUE, TRUE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30100015'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

-- No socios (5): control, nunca deberían aparecer en "Listar vencimientos"
-- (la consulta filtra es_socio = 1), ni siquiera cuando su fecha "coincide" con la buscada.
INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, FALSE, CURDATE(), TRUE, FALSE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30200001'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, FALSE, DATE_SUB(CURDATE(), INTERVAL 5 DAY), TRUE, FALSE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30200002'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, FALSE, DATE_ADD(CURDATE(), INTERVAL 10 DAY), TRUE, FALSE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30200003'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, FALSE, DATE_SUB(CURDATE(), INTERVAL 10 DAY), TRUE, FALSE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30200004'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

INSERT INTO clientes (id_persona, es_socio, validez, activo, apto_fisico)
SELECT p.id_persona, FALSE, DATE_ADD(CURDATE(), INTERVAL 5 DAY), TRUE, FALSE
FROM personas p WHERE p.tipo_documento = 'DNI' AND p.documento = '30200005'
  AND NOT EXISTS (SELECT 1 FROM clientes c WHERE c.id_persona = p.id_persona);

-- Les asignamos número de carnet a los socios dummy, con el mismo formato que usa la app
-- al inscribir un socio nuevo (Club.emitir_carnet: "SOC-" + Id con 5 dígitos). Los no socios
-- no llevan carnet. Es idempotente: solo toca filas que todavía no tengan uno asignado.
UPDATE clientes SET nro_carnet = CONCAT('SOC-', LPAD(id_cliente, 5, '0'))
WHERE es_socio = 1 AND nro_carnet IS NULL;

-- =============================================
-- 4. PROCEDIMIENTOS ALMACENADOS
-- =============================================

DROP PROCEDURE IF EXISTS sp_ValidarLogin;

DELIMITER //

CREATE PROCEDURE sp_ValidarLogin(
    IN p_usuario VARCHAR(50),
    IN p_clave VARCHAR(255)
)
BEGIN
    SELECT id_usuario, usuario
    FROM usuarios 
    WHERE usuario = p_usuario AND clave = p_clave;
END //

DELIMITER ;

-- =============================================

DROP PROCEDURE IF EXISTS sp_registrar_cliente;

DELIMITER //

CREATE PROCEDURE sp_registrar_cliente(
    IN p_tipo_documento VARCHAR(10),
    IN p_documento VARCHAR(20),
    IN p_nombre VARCHAR(50),
    IN p_apellido VARCHAR(50),
    IN p_email VARCHAR(100),
    IN p_telefono VARCHAR(20),
    IN p_fecha_nacimiento DATE,
    IN p_es_socio BOOLEAN,
    IN p_apto_fisico BOOLEAN,
    OUT p_id_cliente INT
)
BEGIN
    DECLARE v_id_persona INT;
    DECLARE v_validez DATE;

    -- Calcular fecha de validez según si es socio o no
    IF p_es_socio THEN
        SET v_validez = NULL;
    ELSE
        SET v_validez = CURDATE();
    END IF;

    -- Iniciar transacción para asegurar consistencia
    START TRANSACTION;

    -- 1. Insertar en la tabla personas (si el documento ya existe, podemos actualizarlo o ignorar, aquí insertamos)
    INSERT INTO personas (tipo_documento, documento, nombre, apellido, email, telefono, fecha_nacimiento)
    VALUES (p_tipo_documento, p_documento, p_nombre, p_apellido, p_email, p_telefono, p_fecha_nacimiento)
    ON DUPLICATE KEY UPDATE 
        nombre = VALUES(nombre),
        apellido = VALUES(apellido),
        email = VALUES(email),
        telefono = VALUES(telefono);

    -- Obtener el ID de la persona (ya sea recién insertada o existente)
    SELECT id_persona INTO v_id_persona 
    FROM personas 
    WHERE documento = p_documento AND tipo_documento = p_tipo_documento;

    -- 2. Insertar en la tabla clientes vinculada a la persona
    INSERT INTO clientes (id_persona, es_socio, validez, apto_fisico)
    VALUES (
        v_id_persona, 
        p_es_socio, 
        v_validez, 
        p_apto_fisico
    );

    SET p_id_cliente = LAST_INSERT_ID();

    COMMIT;
END //

DELIMITER ;

-- =============================================

DROP PROCEDURE IF EXISTS sp_existe_cliente;

DELIMITER //

CREATE PROCEDURE sp_existe_cliente(
    IN p_tipo_documento VARCHAR(10),
    IN p_documento VARCHAR(20),
    OUT p_existe INT
)
BEGIN
    SELECT COUNT(*)
    INTO p_existe
    FROM clientes c
    JOIN personas p ON c.id_persona = p.id_persona
    WHERE p.documento = p_documento AND p.tipo_documento = p_tipo_documento;
END //

DELIMITER ;