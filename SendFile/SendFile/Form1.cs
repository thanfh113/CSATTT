using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using DESLibrary; // Thêm namespace của DESLibrary

namespace SendFile
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = openFileDialog.FileName;
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtFilePath.Text))
                {
                    MessageBox.Show("Please choose a file to send.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string filePath = txtFilePath.Text;

                // Kết nối đến địa chỉ IP và cổng của máy nhận
                TcpClient client = new TcpClient();
                client.Connect("127.0.0.1", 5000);

                // Đọc file cần truyền và mã hóa dữ liệu
                byte[] data = File.ReadAllBytes(filePath);
                string key = "AbcEFjkl"; // Khóa mã hóa 8 ký tự
                byte[] encryptedData = EncryptData(data, key);

                // Gửi kích thước của file
                NetworkStream stream = client.GetStream();
                byte[] fileSizeBytes = BitConverter.GetBytes(encryptedData.Length);
                stream.Write(fileSizeBytes, 0, fileSizeBytes.Length);

                // Gửi dữ liệu file đã được mã hóa
                stream.Write(encryptedData, 0, encryptedData.Length);

                MessageBox.Show("File sent successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                client.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm mã hóa DES sử dụng DESLibrary
        private byte[] EncryptData(byte[] data, string key)
        {
            DES des = new DES(key); // Sử dụng class DES từ DESLibrary
            return des.Encrypt(data);
        }
    }
}