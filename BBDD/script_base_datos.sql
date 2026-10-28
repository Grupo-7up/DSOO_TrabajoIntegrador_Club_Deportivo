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
    fecha_nacimiento DATE
);

-- Tabla de Clientes
CREATE TABLE IF NOT EXISTS clientes (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    id_persona INT NOT NULL,
    es_socio BOOLEAN NOT NULL DEFAULT FALSE,
    nro_carnet VARCHAR(20) UNIQUE DEFAULT NULL,
    fecha_inscripcion DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    validez DATE NOT NULL,
    estado VARCHAR(20) DEFAULT 'Activo',
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

--------------------------------

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
    IN p_apto_fisico BOOLEAN
)
BEGIN
    DECLARE v_id_persona INT;
    DECLARE v_validez DATE;

    -- Calcular fecha de validez según si es socio o no
    IF p_es_socio THEN
        SET v_validez = DATE_ADD(CURDATE(), INTERVAL 30 DAY);
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

    COMMIT;
END //

--------------------------------

DELIMITER ;

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