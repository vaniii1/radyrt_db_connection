using MySql.Data.MySqlClient;

class radyrtDbConnection
{
    static string connStr =
        "Server=localhost;Database=RåDyrT;Uid=root;Pwd=1234;";

    static void Main()
    {
        using var conn = new MySqlConnection(connStr);
        conn.Open();

        Console.WriteLine("Running INSERTS...");
        RunNonQuery(conn, Inserts);

        Console.WriteLine("\nRunning QUERIES a–q...\n");
        RunQuery(conn, QueryA, "A");
        RunQuery(conn, QueryB, "B");
        RunQuery(conn, QueryC, "C");
        RunQuery(conn, QueryD, "D");
        RunQuery(conn, QueryE, "E");
        RunQuery(conn, QueryF, "F");
        RunQuery(conn, QueryG, "G");
        RunQuery(conn, QueryH, "H");
        RunQuery(conn, QueryI, "I");
        RunQuery(conn, QueryJ, "J");
        RunQuery(conn, QueryK, "K");
        RunQuery(conn, QueryL, "L");
        RunQuery(conn, QueryM, "M");
        RunQuery(conn, QueryN, "N");
        RunQuery(conn, QueryO, "O");
        RunQuery(conn, QueryP, "P");
        RunQuery(conn, QueryQ, "Q");
    }
    
    static void RunNonQuery(MySqlConnection conn, string sql)
    {
        using var cmd = new MySqlCommand(sql, conn);
        cmd.ExecuteNonQuery();
    }

    static void RunQuery(MySqlConnection conn, string sql, string label)
    {
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        Console.WriteLine(label + ")");

        while (reader.Read())
        {
            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write(reader[i] + "\t");
            Console.WriteLine();
        }
        reader.Close();
    }
    
    static string Inserts = @"
USE `RåDyrT`;

-- 1a Clinics
INSERT INTO Clinic (clinic_number, street, postal_area, postal_code, telephone, fax)
VALUES
(1, 'clinic_street1', 'New York', 'clinic_code1', 'clinic_phone1', 'clinic_fax1'),
(2, 'clinic_street2', 'clinic_area2', 'clinic_code2', 'clinic_phone2', 'clinic_fax2');


-- Staff
INSERT INTO Staff (
    staff_number, clinic_number, first_name, last_name, street,
    postal_area, postal_code, telephone, date_of_birth,
    sex, ssn, position, annual_salary
)
VALUES
(11, 1, 'staff_name11', 'staff_last_name11', 'staff_street11', 'staff_area11', 'staff_code11', 'staff_phone11', '1972-03-15', 'F', 'staff_ssn11', 'Manager', 850000.00),
(12, 1, 'staff_name12', 'staff_last_name12', 'staff_street12', 'staff_area12', 'staff_code12', 'staff_phone12', '1997-08-30', 'M', 'staff_ssn12', 'Vet', 600000.00),
(13, 1, 'staff_name13', 'staff_last_name13', 'staff_street13', 'staff_area13', 'staff_code13', 'staff_phone13', '1976-03-02', 'F', 'staff_ssn13', 'Nurse', 100000.00),
(21, 2, 'staff_name21', 'staff_last_name21', 'staff_street21', 'staff_area21', 'staff_code21', 'staff_phone21', '1983-08-20', 'M', 'staff_ssn21', 'Manager', 650000.00),
(22, 2, 'staff_name22', 'staff_last_name22', 'staff_street22', 'staff_area22', 'staff_code22', 'staff_phone22', '1970-02-20', 'F', 'staff_ssn22', 'Nurse', 890000.00),
(23, 2, 'staff_name23', 'staff_last_name23', 'staff_street23', 'staff_area23', 'staff_code23', 'staff_phone23', '1974-02-19', 'F', 'staff_ssn23', 'Vet', 980000.00);


-- Managers
INSERT INTO Clinic_manager (clinic_number, staff_number)
VALUES
(1, 11),
(2, 21);


-- 1b Pet Owners
INSERT INTO Pet_owner (
    owner_number, clinic_number, first_name, last_name,
    street, postal_area, postal_code, telephone
)
VALUES
(1, 1, 'owner_name1', 'owner_last_name1', 'owner_street1', 'owner_area1', 'owner_code1', 'owner_phone1'),
(2, 1, 'owner_name2', 'owner_last_name2', 'owner_street2', 'owner_area2', 'owner_code2', 'owner_phone2'),
(3, 2, 'owner_name3', 'owner_last_name3', 'owner_street3', 'owner_area3', 'owner_code3', 'owner_phone3'),
(4, 2, 'owner_name4', 'owner_last_name4', 'owner_street4', 'owner_area4', 'owner_code4', 'owner_phone4');


-- 1c Pets
INSERT INTO Pet (
    pet_number, owner_number, clinic_number, pet_name,
    pet_type, description, date_of_birth,
    date_registered, current_status
)
VALUES
(11, 1, 1, 'pet_name11', 'dog', 'pet_desc11', '2018-04-10', '2020-01-15', 'Alive'),
(12, 1, 1, 'pet_name12', 'cat', 'pet_desc12', '2019-07-20', '2020-03-01', 'Alive'),
(13, 2, 1, 'pet_name13', 'dog', 'pet_desc13', '2017-09-05', '2019-08-20', 'Alive'),
(21, 3, 2, 'pet_name21', 'dog', 'pet_desc21', '2016-11-11', '2018-05-05', 'Alive'),
(22, 4, 2, 'pet_name22', 'cat', 'pet_desc22', '2020-05-25', '2021-01-10', 'Alive'),
(23, 4, 2, 'pet_name23', 'cat', 'pet_desc23', '2019-07-20', '2020-07-01', 'Alive');


-- 1d Treatments
INSERT INTO Treatment (treatment_number, description, cost)
VALUES
('Tr000', 'treatment_desc_Tr000', 250.00),
('Tr025', 'treatment_desc_Tr026', 2500.00),
('Tr050', 'treatment_desc_Tr050', 500.00),
('Tr100', 'treatment_desc_Tr200', 1000.00),
('Tr200', 'treatment_desc_Tr204', 2000.00);


-- 1e Examinations
INSERT INTO Examination (
    examination_number, clinic_number, exam_date,
    exam_time, vet_staff_number, pet_number,
    results_description
)
VALUES
(1001, 1, '2024-01-10', '10:00:00', 12, 11, 'Minor infection detected'),
(1002, 1, '2024-01-12', '11:30:00', 12, 12, 'Routine check, healthy'),
(1003, 1, '2024-02-01', '09:15:00', 13, 13, 'Vaccination completed'),
(2001, 2, '2024-02-10', '13:00:00', 22, 21, 'Fracture suspected'),
(2002, 2, '2024-02-15', '15:45:00', 23, 22, 'Skin allergy treatment');


-- Pet Treatments
INSERT INTO Pet_treatment (
    examination_number, pet_number, treatment_number,
    quantity, date_begin, date_end, comments
)
VALUES
(1001, 11, 'Tr000', 1, '2024-01-10', '2024-01-17', 'comment1'),
(1002, 12, 'Tr025', 1, '2024-01-12', '2024-01-12', 'comment2'),
(1003, 13, 'Tr050', 1, '2024-02-01', '2024-02-01', 'comment3'),
(2001, 21, 'Tr100', 2, '2024-02-10', '2024-02-20', 'comment4'),
(2002, 22, 'Tr000', 1, '2024-02-15', '2024-02-22', 'comment5');


-- Invoices
INSERT INTO Invoice (
    clinic_number, owner_number, pet_number,
    invoice_date, total_cost, paid_date, payment_method
)
VALUES
(1, 1, 11, '1998-01-20', 250.00, '2024-01-25', 'Visa'),
(1, 1, 12, '2099-01-22', 2500.00, NULL, NULL),
(1, 2, 13, '2097-02-05', 500.00, '2024-02-06', 'Cash'),
(2, 3, 21, '1998-02-12', 1000.00, NULL, NULL),
(2, 4, 22, '1997-02-18', 750.00, '2024-02-20', 'Visa');


-- Invoice Lines
INSERT INTO Invoice_line (
    invoice_number, pet_treatment_id, line_cost
)
VALUES
(1, 1, 250.00),
(2, 2, 2500.00),
(3, 3, 500.00),
(4, 4, 1000.00),
(5, 5, 750.00);


-- Supplies
INSERT INTO Supply (
    item_number, clinic_number, supply_type, name,
    description, reorder_level, reorder_quantity,
    cost_per_unit, quantity_stock
)
VALUES
('S001', 1, 'Surgical', 'name1', 'desc1', 10, 50, 5.00, 100),
('S002', 1, 'Non-surgical', 'name2', 'desc2', 20, 100, 2.50, 200),
('S003', 2, 'Surgical', 'name3', 'desc3', 15, 60, 3.00, 120),
('S004', 2, 'Non-surgical', 'name4', 'desc4', 30, 200, 1.50, 300),
('S005', 1, 'Pharmaceutical', 'name5', 'desc5', 10, 40, 20.00, 5);


-- Pens
INSERT INTO Pen (
    pen_number, clinic_number, capacity, is_available
)
VALUES
(1, 1, 4, TRUE),
(2, 1, 2, TRUE),
(3, 2, 3, TRUE),
(4, 2, 4, FALSE),
(5, 1, 1, TRUE);


-- Pen Allocation
INSERT INTO Pen_allocation (
    pen_number, pet_number, date_in, date_out, comments
)
VALUES
(1, 11, '2024-01-10', '2024-01-15', 'com1'),
(2, 12, '2024-01-12', NULL, 'com2'),
(3, 21, '2024-02-10', '2024-02-18', 'com3'),
(4, 22, '2024-02-15', NULL, 'com4'),
(5, 13, '2024-02-01', '2024-02-03', 'com5');


-- Appointments
INSERT INTO Appointment (
    appointment_number, clinic_number, owner_number,
    pet_number, appointment_date, appointment_time
)
VALUES
(1, 1, 1, 11, '2024-03-01', '09:00:00'),
(2, 1, 2, 13, '2024-03-02', '10:30:00'),
(3, 2, 3, 21, '2024-03-03', '11:00:00'),
(4, 2, 4, 22, '2024-03-04', '13:15:00'),
(5, 1, 1, 12, '2024-03-05', '14:00:00');
";
    
    static string QueryA = @"SELECT c.clinic_number, s.first_name, s.last_name, c.street, c.postal_area, c.telephone
FROM Clinic c
JOIN Clinic_manager cm ON c.clinic_number = cm.clinic_number
JOIN Staff s ON cm.staff_number = s.staff_number
ORDER BY c.clinic_number;";

    static string QueryB = @"SELECT po.owner_number, po.first_name, po.last_name, p.pet_number, p.pet_name, p.pet_type
FROM Pet_owner po
JOIN Pet p ON po.owner_number = p.owner_number
ORDER BY po.owner_number;";

    static string QueryC = @"SELECT * FROM Examination WHERE pet_number = 11;";
    static string QueryD = @"SELECT * FROM Pet_treatment WHERE pet_number = 22 AND examination_number = 2002;";
    static string QueryE = @"SELECT * FROM Invoice WHERE owner_number = 1 AND paid_date IS NULL;";
    static string QueryF = @"SELECT * FROM Invoice WHERE paid_date IS NULL AND invoice_date <= '2024-12-31';";

    static string QueryG = @"SELECT p.pen_number, p.clinic_number FROM Pen p JOIN Clinic c ON p.clinic_number = c.clinic_number WHERE c.postal_area = 'New York';";
    static string QueryH = @"SELECT clinic_number, SUM(annual_salary)/12 FROM Staff GROUP BY clinic_number;";
    static string QueryI = @"SELECT MAX(cost), MIN(cost), AVG(cost) FROM Treatment;";
    static string QueryJ = @"SELECT pet_type, COUNT(*) FROM Pet GROUP BY pet_type;";

    static string QueryK = @"SELECT staff_number, first_name, last_name FROM Staff;";
    static string QueryL = @"SELECT * FROM Appointment;";
    static string QueryM = @"SELECT clinic_number, COUNT(*) FROM Pen GROUP BY clinic_number;";
    static string QueryN = @"SELECT * FROM Invoice;";
    static string QueryO = @"SELECT pet_number, pet_name, description FROM Pet WHERE owner_number = 1;";
    static string QueryP = @"SELECT * FROM Supply WHERE supply_type = 'Pharmaceutical';";
    static string QueryQ = @"SELECT clinic_number, SUM(quantity_stock * cost_per_unit) FROM Supply GROUP BY clinic_number;";
}