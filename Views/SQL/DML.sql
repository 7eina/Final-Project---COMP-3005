
INSERT INTO trainers (fname, lname, address, phone) VALUES
('King', 'Julien', '123 Blue St.', '613-456-7890'),
('Marty', 'TheZeebra', '456 Green Ave', '613-567-8901'),
('Alex', 'TheLion', '789 Yellow Blvd', '613-678-9012'),
('Winnie', 'ThePooh', '101 Orange Rd.', '613-789-0123'),
('Avatar', 'Ang', '202 Purple Way', '613-890-1234');

INSERT INTO availabilities (available_from, available_to, trainer_id) VALUES
('2024-04-08 09:00:00', '2024-04-08 12:00:00', 1),
('2024-04-09 09:00:00', '2024-04-09 12:00:00', 1),
('2024-04-11 09:00:00', '2024-04-11 12:00:00', 1),
('2024-04-12 09:00:00', '2024-04-12 12:00:00', 1),
('2024-04-13 09:00:00', '2024-04-13 12:00:00', 1),
('2024-04-10 09:00:00', '2024-04-10 12:00:00', 1),
('2024-04-10 09:00:00', '2024-04-10 12:00:00', 1),
('2024-04-11 13:00:00', '2024-04-11 17:00:00', 2),
('2024-04-12 08:00:00', '2024-04-12 11:00:00', 3),
('2024-04-13 14:00:00', '2024-04-13 18:00:00', 4),
('2024-04-14 10:00:00', '2024-04-14 15:00:00', 5);

INSERT INTO members (fname, lname, email, address, phone, weight_goal_start_date, weight_goal_end_date, weight_goal_start_kg, weight_goal_end_kg, height_cm) VALUES
('Manny', 'Mamouth', 'Manny@iceage.com', '123 Red St.', '613-901-2345', '2024-04-01', '2024-10-01', 990.0, 880.0, 180.34),
('Diego', 'Tiger', 'Diego@iceage.com', '234 Indigo Rd.', '613-012-3456', '2024-05-01', '2024-11-01', 270.0, 165.0, 115.10),
('Sid', 'Milton', 'Sid@iceage.com', '345 Teal Blvd', '613-123-4567', '2024-06-01', '2024-12-01', 88.0, 78.0, 75.26),
('Ellie', 'Manny', 'Ellie@iceage.com', '456 Silver Ave', '613-234-5678', '2024-07-01', '2025-01-01', 860.0, 755.0, 160.02),
('Peaches', 'Ethan', 'Peaches@iceage.com','567 Gold Way', '613-345-6789', '2024-08-01', '2025-02-01', 675.0, 470.0, 150.22);

-- Manny@iceage.com
INSERT INTO health_metrics (heart_rate, blood_press_up, blood_press_down, cholesterol_level, weight_kg, date, member_id) VALUES
(72, 120, 80, 990.50, 90.0, '2023-04-10', 1),
(72, 120, 80, 890.50, 90.0, '2024-01-10', 1),
(72, 120, 80, 850.50, 90.0, '2024-04-10', 1),
(68, 115, 75, 195.30, 70.0, '2024-04-11', 2),
(70, 118, 76, 198.00, 88.0, '2024-04-12', 3),
(65, 110, 70, 190.25, 60.0, '2024-04-13', 4),
(75, 122, 82, 202.75, 75.0, '2024-04-14', 5);

INSERT INTO admin_staff (fname, lname, address, phone, start_date) VALUES
('Shrek', 'Steig', '123 Villain St.', '123-456-7899', '2023-01-01 08:00:00'),
('Princess', 'Fiona', '456 Hero Rd.', '234-567-8900', '2023-02-01 09:00:00'),
('Puss', 'Inboots', '789 Gotham Blvd', '345-678-9011', '2023-03-01 10:00:00'),
('Don', 'key', '101 Metropolis Rd.', '456-789-0122', '2023-04-01 11:00:00'),
('Pinocchio', 'Geppetto', '202 Themyscira Way', '567-890-1233', '2023-05-01 12:00:00');

INSERT INTO payments (service_type, amount, pay_method, date, member_id, admin_staff_id) VALUES
('Membership Fee', '$50', 'Credit Card', '2024-04-10', 1, 1),
('Personal Training', '$30', 'Debit Card', '2024-04-11', 2, 2),
('Yoga Classes', '$40', 'Cash', '2024-04-12', 3, 3),
('Gym Equipment', '$20', 'Credit Card', '2024-04-13', 4, 4),
('Health Consultation', '$60', 'Cash', '2024-04-14', 5, 5);

INSERT INTO sessions (name, description, difficulty_level) VALUES
('Morning Cardio', 'A high-intensity morning workout to boost your day', 2),
('Evening Yoga', 'Relaxing yoga to unwind after a long day', 1),
('Power Lifting', 'Strength training session focusing on lifting heavy', 3),
('HIIT', 'High Intensity Interval Training for fat loss', 3),
('Pilates', 'Core strengthening and flexibility', 1);

INSERT INTO classes (name, description, difficulty_level, capacity) VALUES
('Basic Fitness', 'Fitness fundamentals for beginners', 1, 10),
('Advanced Aerobics', 'High-energy movements for advanced learners', 2, 15),
('Senior Wellness', 'Low-impact exercises suitable for seniors', 1, 20),
('Kids Dance', 'Fun dance routines for children', 1, 25),
('Boxing 101', 'Basics of boxing for all skill levels', 2, 10);


INSERT INTO rooms (name, location, capacity) VALUES
('Room A', 'First Floor', 20),
('Room B', 'Second Floor', 15),
('Room C', 'Third Floor', 10),
('Room D', 'Fourth Floor', 25),
('Room E', 'Fifth Floor', 30);

INSERT INTO bookings (amount, method, date, is_class, is_session, start_time, end_time, member_id, admin_staff_id, room_id, session_id, class_id, trainer_id) VALUES
('$25', 'Credit Card', '2024-04-10', true, false, '2024-04-10 09:00:00', '2024-04-10 10:00:00', 1, 1, 1, null, 1, 1),
('$15', 'Cash', '2024-04-11', false, true, '2024-04-11 11:00:00', '2024-04-11 12:00:00', 2, 2, 2, 2, null, 2),
('$20', 'Debit Card', '2024-04-12', true, false, '2024-04-12 13:00:00', '2024-04-12 14:30:00', 3, 3, 3, null, 3, 3),
('$30', 'Credit Card', '2024-04-13', false, true, '2024-04-13 15:00:00', '2024-04-13 16:00:00', 4, 4, 4, 4, null, 4),
('$10', 'Cash', '2024-04-14', true, false, '2024-04-14 17:00:00', '2024-04-14 18:00:00', 5, 5, 5, null, 5, 5);

INSERT INTO equipments (id, name, maintenance_duedate, purchase_date, maintenance_info, room_id, admin_staff_id) VALUES
(1, 'Treadmill', '2024-12-31', '2023-01-01', 'Regular maintenance every 6 months', 1, 1),
(2, 'Dumbbells', '2024-06-30', '2023-02-01', 'Check for rust and wear bi-annually', 2, 2),
(3, 'Exercise Bike', '2024-12-31', '2023-03-01', 'Lubricate moving parts every year', 3, 3),
(4, 'Rowing Machine', '2024-11-30', '2023-04-01', 'Inspect cables and seat', 4, 4),
(5, 'Yoga Mats', '2024-10-31', '2023-05-01', 'Clean after every class, replace annually', 5, 5);

