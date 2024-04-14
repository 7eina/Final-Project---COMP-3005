DROP TABLE IF EXISTS bookings;
DROP TABLE IF EXISTS equipments;
DROP TABLE IF EXISTS availabilities;
DROP TABLE IF EXISTS health_metrics;
DROP TABLE IF EXISTS payments;
DROP TABLE IF EXISTS admin_staff;
DROP TABLE IF EXISTS members;
DROP TABLE IF EXISTS trainers;
DROP TABLE IF EXISTS sessions;
DROP TABLE IF EXISTS classes;
DROP TABLE IF EXISTS rooms;


CREATE TABLE IF NOT EXISTS trainers
(
    id serial PRIMARY KEY,
    fname character varying(50) NOT NULL,
    lname character varying(50) NOT NULL,
    address character varying(250),
    phone character(14) NOT NULL
);


CREATE TABLE IF NOT EXISTS availabilities
(
    id serial PRIMARY KEY,
    available_from timestamp without time zone NOT NULL,
    available_to timestamp without time zone NOT NULL,
    trainer_id integer NOT NULL,
	CONSTRAINT fk_trainer FOREIGN KEY(trainer_id) REFERENCES trainers (id)
);

CREATE TABLE IF NOT EXISTS members
(
    id serial PRIMARY KEY,
    fname character varying(50) NOT NULL,
    lname character varying(50) NOT NULL,
	email character varying(250) NOT NULL UNIQUE,
    address character varying(250),
    phone character(14) NOT NULL,
    weight_goal_start_date timestamp without time zone,
    weight_goal_end_date timestamp without time zone,
    weight_goal_start_kg numeric(6, 3),
    weight_goal_end_kg numeric(6, 3),
    height_cm numeric(5, 2)
);


CREATE TABLE IF NOT EXISTS health_metrics
(
    id serial PRIMARY KEY,
    heart_rate numeric(3, 0),
    blood_press_up numeric(3, 0),
    blood_press_down numeric(3, 0),
    cholesterol_level numeric(5, 2),
    weight_kg numeric(5, 2),
    date timestamp without time zone,
    member_id integer,
	CONSTRAINT fk_member FOREIGN KEY(member_id) REFERENCES members (id)
);


CREATE TABLE IF NOT EXISTS admin_staff
(
    id serial PRIMARY KEY,
    fname character varying(50) NOT NULL,
    lname character varying(50) NOT NULL,
    address character varying(250) NOT NULL,
    phone character(14) NOT NULL,
    start_date timestamp without time zone NOT NULL
);


CREATE TABLE IF NOT EXISTS payments
(
    id serial PRIMARY KEY,
    service_type character varying(50),
    amount money,
    pay_method character varying(30),
    date timestamp without time zone,
    member_id integer,
    admin_staff_id integer,
	CONSTRAINT fk_member FOREIGN KEY(member_id) REFERENCES members (id),
	CONSTRAINT fk_admin_staff FOREIGN KEY(admin_staff_id) REFERENCES admin_staff (id)
);


CREATE TABLE IF NOT EXISTS sessions
(
    id serial PRIMARY KEY,
    name character varying(50) NOT NULL,
    description text,
    difficulty_level numeric(1, 0)
);


CREATE TABLE IF NOT EXISTS classes
(
    id serial PRIMARY KEY,
    name character varying(50) NOT NULL,
    description text,
    difficulty_level numeric(1, 0) NOT NULL DEFAULT 1,
    capacity numeric(2, 0) NOT NULL
);


CREATE TABLE IF NOT EXISTS rooms
(
    id serial PRIMARY KEY,
    name character varying(50) NOT NULL,
    location character varying(40) NOT NULL,
    capacity numeric(2, 0) NOT NULL
);


CREATE TABLE IF NOT EXISTS bookings
(
    id serial PRIMARY KEY,
    amount money,
    method character varying(30),
    date timestamp without time zone,
	is_class boolean,
    is_session boolean,
	start_time timestamp without time zone,
	end_time timestamp without time zone,
    member_id integer,
    admin_staff_id integer,
    room_id integer,
    session_id integer,
    class_id integer,
    trainer_id integer,
	CONSTRAINT fk_member FOREIGN KEY(member_id) REFERENCES members (id),
	CONSTRAINT fk_admin_staff FOREIGN KEY(admin_staff_id) REFERENCES admin_staff (id),
    CONSTRAINT fk_room FOREIGN KEY(room_id) REFERENCES rooms (id),
    CONSTRAINT fk_session FOREIGN KEY(session_id) REFERENCES sessions (id),
    CONSTRAINT fk_class FOREIGN KEY(class_id) REFERENCES classes (id),
    CONSTRAINT fk_trainer FOREIGN KEY(trainer_id) REFERENCES trainers (id)
);

CREATE TABLE IF NOT EXISTS equipments
(
    id serial,
    name character varying(50) PRIMARY KEY,
    maintenance_duedate date NOT NULL,
	last_maintenance_date date,
    purchase_date date NOT NULL,
    maintenance_info text,
    room_id integer,
    admin_staff_id integer,
	CONSTRAINT fk_admin_staff FOREIGN KEY(admin_staff_id) REFERENCES admin_staff (id),
    CONSTRAINT fk_room FOREIGN KEY(room_id) REFERENCES rooms (id)
);
