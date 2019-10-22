using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace KasraMobileMiddleware
{
    class FileManager
    {
        public FrmInstallationProcess FrmInstallationProcessObj { set; get; }

        public FileManager(FrmInstallationProcess frmInstallationProcessObj)
        {
            FrmInstallationProcessObj = frmInstallationProcessObj;
        }
        public FileManager()
        {

        }

        /* 
         * This method copies the web app files from the the publish path to the project path.
         * Before begining the copying process it first creates the needed directories.
         * It also logs the appropraite messages while copying the files.
         */
        public bool MobileCopyAndLog(string sourceAddress, string destinationAddress)
        {
            try
            {
                // Log that the essenial folders are being created.
                FrmInstallationProcessObj.TextAppend = DateTimeOffset.Now + "\r\nدر حال ساختن فولدر های لازم...\r\n\r\n";

                // Create all the necessary directories before copying the destinationAddress' contents.
                foreach (string dirPath in Directory.GetDirectories(sourceAddress, "*", SearchOption.AllDirectories))
                    Directory.CreateDirectory(dirPath.Replace(sourceAddress, destinationAddress));

                // Count all the files available in the publish paths.
                int allFiles = Directory.GetFiles(sourceAddress, "*.*", SearchOption.AllDirectories).Length;
                int counter = 0;

                //Copies all the files & Replaces any file with the same name in the destinationAddress.
                foreach (string newPath in Directory.GetFiles(sourceAddress, "*.*", SearchOption.AllDirectories))
                {
                    string s = newPath.Replace(sourceAddress, destinationAddress);
                    File.Copy(newPath, s, true);
                    counter++;
                    FrmInstallationProcessObj.ProgressBarValue = counter * 100 / allFiles;

                    // Log the copied information.
                    FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nفایل " + Path.GetFileName(newPath) + " به مسیر " + s + " کپی شد.\r\n\r\n";
                }

                // Log that all the publish path files have been copied.
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nهمه ی فایل های لازم موجود در مسیر پابلیش کامل و با موفقیت به مسیر پروژه کپی شدند.\r\n\r\n";
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داد");
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nتوقف برنامه. خطای زیر رخ داده است:\r\n";
                FrmInstallationProcessObj.TextAppend = $"{ex.Message}\r\n\r\n";
                SaveTheMobileLogAndLog();
                return false;
            }
        }
        public bool SaveTheMobileLogAndLog()
        {
            try
            {
                string path = FrmInstallationProcessObj.ProjectPath + FrmInstallationProcessObj.WebsiteName + "\\Project" + "\\MobileLog.txt";
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write(FrmInstallationProcessObj.TextAppend);
                }
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nلاگ فرایند در مسیر وبسایت ذخیره شد.";
                return true;
            }
            catch (Exception ex)
            {
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\n خطای زیر در حین ذخیره لاگ رخ داده است:\r\n";
                FrmInstallationProcessObj.TextAppend = $"{ex.Message}";
                return false;
            }
        }
        public bool RestoreMobileDatabaseAndLog(string portNumber, string publishPath, string databaseName, string databaseAddress, string databaseUsername, string databasePassword, string mDFAndlDFDest)
        {
            try
            {
                // Log that the restoring process has begun.
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nدر حال restore کردن دیتابیس...\r\n\r\n";

                // Find the backup file location.
                string pathToBAK = publishPath + "\\Db\\MobileBackup";

                // Create the connection string needed to connect to the SQL server.
                string connectionString = "Password=" + databasePassword + ";Persist Security Info=True;User ID=" + databaseUsername + ";Initial Catalog=master" + ";Data Source=" + databaseAddress;

                // Establish the connection to the SQL server.
                SqlConnection cnn = new SqlConnection(connectionString);

                // Open the connection in order to get connected to the SQL server.
                cnn.Open();

                // Set the MDF and LDF files names as they are in the backup file.
                // If they are not accessable, the a defualt value is assigned to them.
                string mdfName = "", ldfName = "";
                var backupFileLogicalNames = ReturnBackupLogicalNames(databaseUsername, databaseAddress, databasePassword, pathToBAK);
                if(backupFileLogicalNames == null || backupFileLogicalNames.Rows.Count == 0)
                {
                    mdfName = "MobileMiddleWare";
                    ldfName = "MobileMiddleWare_log";
                }
                else
                {
                    mdfName = backupFileLogicalNames.Rows[0][0].ToString();
                    ldfName = backupFileLogicalNames.Rows[1][0].ToString();
                }

                // Produce the command needed to restore the database in SQL server.
                string command = $@"RESTORE DATABASE {databaseName} FROM DISK = '{pathToBAK}'
                                    WITH MOVE '{mdfName}' TO '{mDFAndlDFDest}\{mdfName}.mdf',
                                    MOVE '{ldfName}' TO '{mDFAndlDFDest}\{ldfName}.ldf'";

                // Create a new instance to the database using the commnad and cnn provided above.
                SqlCommand myCommand = new SqlCommand(command, cnn)
                {
                    CommandTimeout = 0
                };

                // Execute the query(command).
                myCommand.ExecuteNonQuery();

                // Change the Url cell in the dbo.GatewayCompany table.
                // The row's name is Kasra Hamrah.
                string id = "48FC0F43-6468-4993-938A-83DB0897B3B4";
                string newURL = GetURL(databaseName, databaseAddress, databaseUsername, databasePassword, id);
                if (portNumber != "80")
                {
                    newURL= newURL.Replace("localhost", GetLocalIPAddress() + ":" + portNumber);
                }
                else
                {
                    newURL = newURL.Replace("localhost", GetLocalIPAddress());
                }
                ChangeURL(databaseName, databaseAddress, databaseUsername, databasePassword, id, newURL);

                // Change the Url cell in the dbo.GatewayCompany table.
                // The row's name is Kasra Nutrition.
                id = "3C976C9B-2581-485D-BA3B-3500B75DE1AE";
                newURL = GetURL(databaseName, databaseAddress, databaseUsername, databasePassword, id);
                if (portNumber != "80")
                {
                    newURL = newURL.Replace("localhost", GetLocalIPAddress() + ":" + portNumber);
                }
                else
                {
                    newURL = newURL.Replace("localhost", GetLocalIPAddress());
                }
                ChangeURL(databaseName, databaseAddress, databaseUsername, databasePassword, id, newURL);

                // Close the connection that was created to the master database.
                cnn.Close();

                // Log that the restoring process has ended.
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nدیتابیس با موفقیت restore شد.";
                myCommand.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "خطایی رخ داد");
                FrmInstallationProcessObj.TextAppend = DateTime.Now + "\r\nتوقف برنامه. خطای زیر رخ داده است:\r\n";
                FrmInstallationProcessObj.TextAppend = $"{ex.Message}\r\n\r\n";
                SaveTheMobileLogAndLog();
                return false;
            }
        }

        private DataTable ReturnBackupLogicalNames(string databaseUsername, string databaseAddress, string databasePassword, string backupFileLocation)
        {
            var connectionString = "Password=" + databasePassword + ";Persist Security Info=True;User ID=" + databaseUsername + ";Initial Catalog=master" + ";Data Source=" + databaseAddress;

            SqlConnection cnn = new SqlConnection(connectionString);

            var command = $@"RESTORE FILELISTONLY FROM DISK = '{backupFileLocation}'";

            // Create a new instance to the database using the commnad provided above.
            SqlCommand myCommand = new SqlCommand(command, cnn);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(myCommand);

            // Initialize a data table and add the amount that the adapter holds to it.
            DataTable result = new DataTable();
            sqlDataAdapter.Fill(result);

            sqlDataAdapter.Dispose();

            return result;
        }
        private static string GetLocalIPAddress()
        {
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        // This method changes the Url cells in dbo.GatewayCompany.
        private void ChangeURL(string databaseName, string databaseAddress, string databaseUsername, string databasePassword, string id, string newURL)
        {
            try
            {
                string connectionString = $"Password={databasePassword};Persist Security Info=True;User ID={databaseUsername};Initial Catalog={databaseName};Data Source={databaseAddress}";
                SqlConnection cnn = new SqlConnection(connectionString);
                var command = $@"UPDATE dbo.GatewayCompany 
                                 SET 
                                    [Url] = '{newURL}'
                                 WHERE
                                    [Id] = '{id}';";
                SqlCommand myCommand = new SqlCommand(command, cnn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(myCommand);
                DataTable result = new DataTable();
                sqlDataAdapter.Fill(result);
                sqlDataAdapter.Dispose();
                cnn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private string GetURL(string databaseName, string databaseAddress, string databaseUsername, string databasePassword, string id)
        {
            try
            {
                string connectionString = $"Password={databasePassword};Persist Security Info=True;User ID={databaseUsername};Initial Catalog={databaseName};Data Source={databaseAddress}";
                SqlConnection cnn = new SqlConnection(connectionString);
                string command = $"SELECT [Url] FROM dbo.GatewayCompany WHERE [Id] = '{id}'";
                SqlCommand myCommand = new SqlCommand(command, cnn);
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(myCommand);
                DataTable result = new DataTable();
                sqlDataAdapter.Fill(result);
                cnn.Close();
                string urlString = result.Rows[0][0].ToString();
                sqlDataAdapter.Dispose();
                return urlString;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message + "هیچ داده ای یافت نشد");
                return "";
            }
        }
    }
}