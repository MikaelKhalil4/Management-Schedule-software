using System.IO;
using System.Data.SQLite;

public class DatabaseInitializer
{
    public static void InitializeDatabase()
    {
        AppPaths.EnsureDirectoriesExist();

        string dbFilePath = AppPaths.DatabasePath;
        if (!File.Exists(dbFilePath))
        {
            SQLiteConnection.CreateFile(dbFilePath);

            using (var conn = new SQLiteConnection($"Data Source={dbFilePath};Version=3;"))//version 3 is for sqllite version
            {
                conn.Open();
               
                string sql = @"BEGIN TRANSACTION;
								DROP TABLE IF EXISTS ""client_services_attendance"";
								CREATE TABLE IF NOT EXISTS ""client_services_attendance"" (
									""attendance_id""	INTEGER NOT NULL,
									""client_id""	INTEGER NOT NULL,
									""client_balance_id""	INTEGER,
									""appointment_id""	INTEGER,
									""execute_date""	TEXT NOT NULL,
									FOREIGN KEY(""client_balance_id"") REFERENCES ""client_balance""(""client_balance_id""),
									FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id""),
									FOREIGN KEY(""appointment_id"") REFERENCES ""appointments""(""appointment_id""),
									PRIMARY KEY(""attendance_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""appointment_has_bundles"";
								CREATE TABLE IF NOT EXISTS ""appointment_has_bundles"" (
									""app_bundle_id""	INTEGER NOT NULL,
									""appointment_id""	INTEGER NOT NULL,
									""bundle_id""	INTEGER NOT NULL,
									FOREIGN KEY(""bundle_id"") REFERENCES ""bundles""(""bundle_id""),
									FOREIGN KEY(""appointment_id"") REFERENCES ""appointments""(""appointment_id""),
									PRIMARY KEY(""app_bundle_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""Albums"";
								CREATE TABLE IF NOT EXISTS ""Albums"" (
									""Album_id""	INTEGER NOT NULL,
									""AlbumType""	TEXT,
									PRIMARY KEY(""Album_id"" AUTOINCREMENT),
									UNIQUE(""AlbumType"")
								);
								DROP TABLE IF EXISTS ""history_employee_availability"";
								CREATE TABLE IF NOT EXISTS ""history_employee_availability"" (
									""history_id""	INTEGER NOT NULL,
									""employee_id""	INTEGER,
									""history_date""	TEXT NOT NULL,
									""rank""	INTEGER NOT NULL,
									""availability""	TEXT,
									FOREIGN KEY(""employee_id"") REFERENCES ""employee""(""employee_id""),
									PRIMARY KEY(""history_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""reminder"";
								CREATE TABLE IF NOT EXISTS ""reminder"" (
									""reminder_id""	INTEGER NOT NULL,
									""client_id""	INTEGER,
									""reminder""	TEXT NOT NULL,
									""repeat""	TEXT NOT NULL,
									""starttime""	TEXT,
									""is_checked""	INTEGER NOT NULL,
									FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id""),
									PRIMARY KEY(""reminder_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""employee"";
								CREATE TABLE IF NOT EXISTS ""employee"" (
									""employee_id""	INTEGER NOT NULL,
									""first_name""	TEXT,
									""last_name""	TEXT,
									""phone_number""	TEXT NOT NULL UNIQUE,
									""password""	TEXT NOT NULL UNIQUE,
									""cash""	REAL,
									""clearcash_date""	TEXT,
									""status""	INTEGER,
									""access""	TEXT,
									""is_schedule_member""	INTEGER,
									""availability""	TEXT,
									""rank""	INTEGER,
									PRIMARY KEY(""employee_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""archive"";
								CREATE TABLE IF NOT EXISTS ""archive"" (
									""archive_id""	INTEGER NOT NULL,
									""client_id""	INTEGER NOT NULL,
									""employee_id""	INTEGER NOT NULL,
									""client_balance_id""	INTEGER NOT NULL,
									""attendance_id""	INTEGER,
									""appointment_id""	INTEGER,
									""action""	TEXT,
									""action_type""	TEXT,
									""date""	TEXT,
									""amount_paid""	REAL,
									""is_moneyOrsession_offre""	INTEGER,
									""previousBalanceOrSession_Offre""	TEXT,
									FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id""),
									FOREIGN KEY(""appointment_id"") REFERENCES ""appointments""(""appointment_id""),
									FOREIGN KEY(""employee_id"") REFERENCES ""employee""(""employee_id""),
									FOREIGN KEY(""client_balance_id"") REFERENCES ""client_balance""(""client_balance_id""),
									FOREIGN KEY(""attendance_id"") REFERENCES ""client_services_attendance""(""attendance_id""),
									PRIMARY KEY(""archive_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""client_balance"";
								CREATE TABLE IF NOT EXISTS ""client_balance"" (
									""client_balance_id""	INTEGER NOT NULL,
									""client_id""	INTEGER NOT NULL,
									""bundle_id""	INTEGER,
									""product_id""	INTEGER,
									""purchase_date""	TEXT,
									""original_offre""	TEXT,
									""offre""	TEXT,
									""amount_paid""	REAL,
									""balance""	REAL,
									""session_left_days""	INTEGER,
									""isbundle_membership""	INTEGER,
									""due_date""	TEXT,
									""is_freezed""	INTEGER,
									""is_expired""	INTEGER,
									FOREIGN KEY(""product_id"") REFERENCES ""products""(""product_id""),
									FOREIGN KEY(""bundle_id"") REFERENCES ""bundles""(""bundle_id""),
									FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id""),
									PRIMARY KEY(""client_balance_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""products"";
								CREATE TABLE IF NOT EXISTS ""products"" (
									""product_id""	INTEGER NOT NULL,
									""product_name""	TEXT NOT NULL UNIQUE,
									""product_price""	REAL,
									""status""	INTEGER,
									PRIMARY KEY(""product_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""finance"";
								CREATE TABLE IF NOT EXISTS ""finance"" (
									""finance_id""	INTEGER NOT NULL,
									""client_balance_id""	INTEGER NOT NULL,
									""AlbumType""	TEXT,
									""amount_paid""	REAL,
									""payment_date""	TEXT,
									FOREIGN KEY(""client_balance_id"") REFERENCES ""client_balance""(""client_balance_id""),
									FOREIGN KEY(""AlbumType"") REFERENCES ""Albums""(""AlbumType"") ON UPDATE CASCADE ON DELETE SET NULL,
									PRIMARY KEY(""finance_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""bundles"";
								CREATE TABLE IF NOT EXISTS ""bundles"" (
									""bundle_id""	INTEGER NOT NULL,
									""bundle_name""	TEXT NOT NULL,
									""description""	TEXT,
									""sessions_numb""	INTEGER,
									""bundle_type""	TEXT,
									""price""	REAL,
									""status""	INTEGER,
									""is_member_ship""	INTEGER,
									""duration""	TEXT,
									PRIMARY KEY(""bundle_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""required_visible_fields"";
								CREATE TABLE IF NOT EXISTS ""required_visible_fields"" (
									""fields_id""	INTEGER NOT NULL,
									""Fields""	TEXT NOT NULL,
									""Visible""	INTEGER NOT NULL,
									""Required""	INTEGER NOT NULL,
									""IsOriginal""	INTEGER NOT NULL,
									PRIMARY KEY(""fields_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""client_fields"";
								CREATE TABLE IF NOT EXISTS ""client_fields"" (
									""client_id""	INTEGER NOT NULL,
									""fields_id""	INTEGER NOT NULL,
									""content""	TEXT NOT NULL,
									FOREIGN KEY(""fields_id"") REFERENCES ""required_visible_fields""(""fields_id""),
									FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id""),
									PRIMARY KEY(""client_id"",""fields_id"")
								);
								DROP TABLE IF EXISTS ""client"";
								CREATE TABLE IF NOT EXISTS ""client"" (
									""client_id""	INTEGER NOT NULL,
									""name""	TEXT,
									""family_name""	TEXT,
									""phone_number""	TEXT,
									""email""	TEXT,
									""gender""	TEXT,
									""job""	TEXT,
									""adress""	TEXT,
									""insta_user""	TEXT,
									""date_of_birth""	TEXT,
									""profile_image_path""	TEXT,
									""marital_status""	TEXT,
									""know_about_us""	TEXT,
									""special_note""	TEXT,
									""IsChild""	INTEGER,
									""IsParent""	INTEGER,
									""AlbumType""	TEXT,
									""save_date""	TEXT,
									""check_in""	TEXT,
									""Registration_Date""	TEXT,
									""total_balance""	REAL,
									""total_payment""	REAL,
									""last_time_searched""	TEXT,
									FOREIGN KEY(""AlbumType"") REFERENCES ""Albums""(""AlbumType"") ON UPDATE CASCADE ON DELETE SET NULL,
									PRIMARY KEY(""client_id"" AUTOINCREMENT)
								);
								DROP TABLE IF EXISTS ""appointments"";
								CREATE TABLE IF NOT EXISTS ""appointments"" (
									""appointment_id""	INTEGER NOT NULL,
									""client_id""	INTEGER,
									""employee_id""	INTEGER NOT NULL,
									""is_package_mode""	INTEGER,
									""client_balance_id""	INTEGER,
									""title""	TEXT,
									""start_time""	TEXT,
									""end_time""	TEXT,
									""Note""	TEXT,
									""is_completed""	INTEGER,
									""is_canceled""	INTEGER,
									FOREIGN KEY(""client_balance_id"") REFERENCES ""client_balance""(""client_balance_id""),
									FOREIGN KEY(""employee_id"") REFERENCES ""employee""(""employee_id""),
									FOREIGN KEY(""client_id"") REFERENCES ""client""(""client_id""),
									PRIMARY KEY(""appointment_id"" AUTOINCREMENT)
								);
								DROP INDEX IF EXISTS ""IX_Albums"";
								CREATE UNIQUE INDEX IF NOT EXISTS ""IX_Albums"" ON ""Albums"" (
									""AlbumType""
								);
								COMMIT;";
                            
                using (var cmd = new SQLiteCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}