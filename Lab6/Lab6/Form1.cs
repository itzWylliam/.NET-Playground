using System;
using System.IO;
using System.Windows.Forms;

namespace Lab6
{
    public partial class Form1 : Form
    {
        private String currentFile = "";

        private enum action { encrypt, decrypt };

        public Form1()
        {
            InitializeComponent();
        }

        private void browseFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK) 
            { 
                this.fileNameTextbox.Text = openFileDialog.FileName;
                currentFile = openFileDialog.FileName;
            }
        }

        private void cryptAndWrite(String key, FileStream fin, FileStream fout) 
        {
                int rbyte;
                int pos = 0;    //position in key string
                int length = key.Length; //length of key
                byte kbyte, ebyte; //encrypted byte

                while ((rbyte = fin.ReadByte()) != -1)
                {
                    kbyte = (byte)key[pos];
                    ebyte = (byte)(rbyte ^ kbyte);
                    fout.WriteByte(ebyte);
                    ++pos;
                    if (pos == length)
                        pos = 0;
                }

        }

        private void encryptButton_Click(object sender, EventArgs e)
        {
            if (this.keyTextbox.Text.Trim() == "") 
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show("Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            processFile(currentFile, action.encrypt);

        }

        private void decryptButton_Click(object sender, EventArgs e)
        {
            if (this.keyTextbox.Text.Trim() == "")
            {
                System.Media.SystemSounds.Beep.Play();
                MessageBox.Show( "Please enter a key.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            processFile(currentFile, action.decrypt);
        }

        private void processFile(String filename, action action) 
        {
            FileStream inFile = null, outFile = null;

            Console.WriteLine(filename);
            Console.WriteLine("Extension: " + Path.GetExtension(filename));
            try
            {

                if (checkDesFileExists(filename, action))
                {

                    if (MessageBox.Show(
                                    "Output file exists. Overwrite?",
                                    "File Exists",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Question
                                ) == DialogResult.No)
                    {
                        if (inFile != null)
                        {
                            inFile.Close();
                        }
                        return;
                    }
                } 

                if (action == action.decrypt)
                {
                    if (Path.GetExtension(filename) == ".enc")
                    {
                        outFile = new FileStream(filename.Substring(0, filename.Length - 4), FileMode.Create);
                    }
                    else
                    {
                        MessageBox.Show("Not a .enc file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    outFile = new FileStream(filename + ".enc", FileMode.Create);
                }

                inFile = new FileStream(filename, FileMode.Open);

                cryptAndWrite(this.keyTextbox.Text, inFile, outFile);
                
                inFile.Close();
                outFile.Close();
                MessageBox.Show("Operation completed successfully.");
            }
            catch (Exception ef)
            {
                Console.WriteLine("EXCEPTION: " + ef.Message);

                if (action == action.encrypt)
                { MessageBox.Show("Could not open source or destination file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            }
        }

        private bool checkDesFileExists(String filename, action a) {

            Console.WriteLine(filename.Substring(0, filename.Length - 4));


            if (a == action.decrypt)
            {
                return File.Exists(filename.Substring(0, filename.Length - 4));
            }
            else
            {
                return File.Exists(filename + ".enc");
            }


        }
    }
}
