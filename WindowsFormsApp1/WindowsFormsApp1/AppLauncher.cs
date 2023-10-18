using MySql.Data.MySqlClient; 
using System;
using System.Diagnostics;
using System.IO; 
using System.Windows.Forms; 

namespace WindowsFormsApp1
{
    public partial class AppLauncher : Form
    {
        private Timer messageTimer;
        public AppLauncher()
        {
            InitializeComponent();
            txtIONLINE.Text = "";
            txtOFFLINE.Text = "";
            if (CheckProses())
            {
                txtIONLINE.Text = "ONLINE";
                txtOFFLINE.Text = "";
            }
            else
            {
                txtOFFLINE.Text = "OFFLINE";
                txtIONLINE.Text = "";
            }
        }

        private void btnRepair_Click(object sender, EventArgs e)
        {
            messageTimer = new Timer();
            messageTimer.Interval = 1000; // 1000 milidetik (1 detik)
            messageTimer.Tick += UpdateMessage;
            messageTimer.Start();

            // Mulai proses yang membutuhkan waktu
            System.Threading.ThreadPool.QueueUserWorkItem(prosesFullRepair); 
        } 
        private void prosesFullRepair(object state)
        {


            stopServer();
            System.Threading.Thread.Sleep(10000);
            //Fungsi untuk mengganti nama folder
            var _oldPath = "C:\\xampp\\mysql\\data";
            var _newPath = "C:\\xampp\\mysql\\" + Guid.NewGuid();

            try
            {
                if (Directory.Exists(_oldPath))
                {
                    Directory.Move(_oldPath, _newPath);
                }

                // Fungsi untuk menyalin folder
                var _destinationPath = "C:\\xampp\\mysql\\data";
                var _destinationBackUp = "C:\\xampp\\mysql\\backup";
                CopyFolder(_destinationPath, _destinationBackUp);

                PindahFilePenting(_destinationPath, _newPath);

                UbahPasswordRootMySQL();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + "Saat mencoba melakukan perbaikan = 1");
            }
            // Setelah proses selesai, perbarui pesan
            UpdateMessage(this, EventArgs.Empty);

            messageTimer.Stop();
            // Anda dapat mengeksekusi kode selanjutnya setelah proses selesai di sini. 
        }

        private void CopyFolder(string _destinationPath, string _destinationBackUp)
        {
            try
            {
                if (!Directory.Exists(_destinationPath))
                {
                    Directory.CreateDirectory(_destinationPath);
                }
                var _fileDifolderBackUp = Directory.GetFiles(_destinationBackUp);
                foreach (string file in _fileDifolderBackUp)
                {
                    var _namaFile = Path.GetFileName(file);
                    //data ini tidak perlu di copi karen mau dimasukkan dari data yang sudah ada
                    if (_namaFile != "ibdata1" /*&& _namaFile != "ib_logfile1"*/)
                    {
                        string destFile = Path.Combine(_destinationPath, _namaFile);
                        File.Copy(file, destFile);
                    }
                }

                foreach (string folder in Directory.GetDirectories(_destinationBackUp))
                {
                    string destFolder = Path.Combine(_destinationPath, new DirectoryInfo(folder).Name);
                    CopyFolder(destFolder, folder);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + "Saat mencoba melakukan perbaikan = 2");
            }
        }

        private void PindahFilePenting(string _tempatData,string _newPath)
        {
            try
            {
                string[] _fileYangMaudipindah = { _newPath + "\\ibdata1"/*, _newPath + "\\ib_logfile1" */};
                foreach (string file in _fileYangMaudipindah)
                {
                    var _namaFile = Path.GetFileName(file);
                    string destFile = Path.Combine(_tempatData, _namaFile);
                    File.Copy(file, destFile);
                } 
                CopiFolderDatabase(_tempatData, _newPath); 
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + "Saat mencoba melakukan perbaikan = 3");
            }
        }


        public void CopiFolderDatabase(string _newPath, string _data)
        {

            foreach (string folder in Directory.GetDirectories(_data))
            {
                var _namaFolder = new DirectoryInfo(folder).Name;
                if (_namaFolder != "mysql" &&  _namaFolder != "test" && _namaFolder != "phpmyadmin" && _namaFolder != "performance_schema")
                {
                    var _path = _newPath + "\\" + _namaFolder;
                    if (!Directory.Exists(_path))
                    {
                        Directory.CreateDirectory(_path);
                    } 
                    var _pathYangAkanDicopi = _data + "\\" + _namaFolder;
                    string destFolder = Path.Combine(_newPath, new DirectoryInfo(folder).Name);
                    var _fileDifolderBackUp = Directory.GetFiles(_pathYangAkanDicopi);
                    foreach (string file in _fileDifolderBackUp)
                    {
                        var _namaFile = Path.GetFileName(file);
                        string destFile = Path.Combine(_path, _namaFile);
                        File.Copy(file, destFile);
                    }
                } 
            } 
        }

        public void UbahPasswordRootMySQL()
        {
            starServer();
            System.Threading.Thread.Sleep(10000);
            string connectionString = "Server=localhost;User=root;Password=;";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Change the root password
                    string newPassword = "goendel14045";

                    string sql = $"ALTER USER 'root'@'localhost' IDENTIFIED BY '{newPassword}';";
                    MySqlCommand cmd = new MySqlCommand(sql, connection);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Proses selesai, silahkan coba aktifkan server!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + "Saat mencoba melakukan perbaikan = 4");
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            messageTimer = new Timer();
            messageTimer.Interval = 1000; // 1000 milidetik (1 detik)
            messageTimer.Tick += UpdateMessage;
            messageTimer.Start();

            // Mulai proses yang membutuhkan waktu
            System.Threading.ThreadPool.QueueUserWorkItem(prosesStartServer);
             
        }
        private void prosesStartServer(object state)
        {
            starServer();
            // Setelah proses selesai, perbarui pesan
            UpdateMessage(this, EventArgs.Empty); 
            messageTimer.Stop();
            // Anda dapat mengeksekusi kode selanjutnya setelah proses selesai di sini. 
        }

        private void starServer()
        {
            try
            {
                Process mysqlCMD = new Process();
                mysqlCMD.StartInfo.FileName = "C:\\xampp\\mysql\\bin\\mysqld.exe";
                mysqlCMD.StartInfo.WindowStyle = ProcessWindowStyle.Hidden; // This is to hide the black CMD window
                mysqlCMD.Start(); 
                System.Threading.Thread.Sleep(10000); 
                MessageBox.Show("Server berhasil diaktifkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + "Saat mencoba mengaktifkan server");
            }
        }

        private void stopServer()
        {
            try
            {
                Process mysqlCloseCMD = new Process();
                //mysqlCloseCMD.StartInfo.FileName = Environment.CurrentDirectory + "\\mysql-server\\bin\\mysqladmin.exe";
                mysqlCloseCMD.StartInfo.FileName = "C:\\xampp\\mysql\\bin\\mysqld.exe";
                mysqlCloseCMD.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                mysqlCloseCMD.StartInfo.Arguments = "--user=root shutdown";
                mysqlCloseCMD.Start();
                System.Threading.Thread.Sleep(10000);
                MessageBox.Show("Server berhasil dinonaktifkan!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + "Saat mencoba menonaktifkan server");
            }
        }

        private void btnStopServer_Click(object sender, EventArgs e)
        {
            messageTimer = new Timer();
            messageTimer.Interval = 1000; // 1000 milidetik (1 detik)
            messageTimer.Tick += UpdateMessage;
            messageTimer.Start();

            // Mulai proses yang membutuhkan waktu
            System.Threading.ThreadPool.QueueUserWorkItem(prosesStopServer);
             
          
        }

        private void prosesStopServer(object state)
        {
            stopProcess();
            stopServer();
            // Setelah proses selesai, perbarui pesan
            UpdateMessage(this, EventArgs.Empty);

            messageTimer.Stop();
            // Anda dapat mengeksekusi kode selanjutnya setelah proses selesai di sini. 
        }

        private void UpdateMessage(object sender, EventArgs e)
        {
            if (txtIONLINE.InvokeRequired && txtOFFLINE.InvokeRequired)
            { 
                if (CheckProses() == true)
                {
                    txtIONLINE.Invoke(new Action(() => txtIONLINE.Text = "ONLINE"));
                    txtOFFLINE.Invoke(new Action(() => txtOFFLINE.Text = ""));
                }
                else
                {
                    txtIONLINE.Invoke(new Action(() => txtIONLINE.Text = ""));
                    txtOFFLINE.Invoke(new Action(() => txtOFFLINE.Text = "OFFLINE"));
                }
            }

            if (txtLabelNotif.InvokeRequired)
            { 
                txtLabelNotif.Invoke(new Action(() => txtLabelNotif.Text = ""));
            }
            else
            {
                txtLabelNotif.Text = "Mohon Tunggu! Proses sedang dijalankan.....";
            }
            // Ini adalah metode yang akan dipanggil oleh Timer untuk memperbarui pesan
            // Gantilah pesan dengan pesan yang sesuai dengan proses Anda
            // Anda juga dapat menampilkan pesan berdasarkan waktu, status, atau informasi lainnya.
        }

        private void stopProcess()
        { 
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                // now check the modules of the process
                try
                {
                    var _as = process.MainModule.ModuleName;

                    if (_as == "mysqld.exe")
                    {
                        process.Kill();

                    } 
                }
                catch (Exception ex)
                {
                    //MessageBox.Show("Error: " + "Saat mencoba menonaktifkan server");
                }
            }
        }


        private bool CheckProses()
        { 
            var _status = false;
            Process[] runningProcesses = Process.GetProcesses();
            foreach (Process process in runningProcesses)
            {
                // now check the modules of the process
                try
                {
                    var _as = process.MainModule.ModuleName;

                    if (_as == "mysqld.exe")
                    { 
                       _status = true;
                    } 
                }
                catch (Exception ex)
                { 
                }
            }
           
            return _status;
        }
        private void btnQuickFix_Click(object sender, EventArgs e)
        {
            messageTimer = new Timer();
            messageTimer.Interval = 1000; // 1000 milidetik (1 detik)
            messageTimer.Tick += UpdateMessage;
            messageTimer.Start();

            // Mulai proses yang membutuhkan waktu
            System.Threading.ThreadPool.QueueUserWorkItem(prosesQUickRepair);

           
        }

        private void prosesQUickRepair(object state)
        {
            stopProcess();
            if (CheckProses())
            {
                MessageBox.Show("Gagal memperbaiki server, silahkan coba dengan Deep Fix Server!");
            }
            else
            {
                MessageBox.Show("Server berhasil di pulihkan, silahkan coba jalankan server, tapi jika masalah belum terselesaikan silahkan coba dengan Deep Fix Server!");
            }
            // Setelah proses selesai, perbarui pesan
            UpdateMessage(this, EventArgs.Empty);
            messageTimer.Stop();
            // Anda dapat mengeksekusi kode selanjutnya setelah proses selesai di sini. 
        }

        private void AppLauncher_Load(object sender, EventArgs e)
        {

        }
    }
}
