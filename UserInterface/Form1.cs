using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PrimeHolding.ImageConverter;
using System.IO;
using PrimeHolding.ImageConverter.Exceptions;

namespace UserInterface
{
    public partial class ImageConverter : Form
    {
        private string pathFile;
        private string newPath;
        private string convertType;
        private string fileName;
        private int width;
        private int height;
        private int x;
        private int y;


        public ImageConverter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //buttona submit
            if ((checkBox1.Checked || checkBox2.Checked || checkBox3.Checked)) { 
            ImageContext ic = new ImageContext(pathFile, newPath, convertType);
                try
                {
                    ic.ExecuteStrategy();
                    MessageBox.Show("Everything seems to be okay. The new file with specified width and height is saved", "Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (InvalidPathException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidImageFormatException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnathorizedAccessException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (WrongSaveImageFormatException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileNotFoundException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DirectoryNotFoundException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (PathTooLongException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var FD = new System.Windows.Forms.OpenFileDialog();
            int size = -1;
            string path = FD.FileName;
            DialogResult result = FD.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = FD.FileName;
                try
                {
                    string text = File.ReadAllText(file);
                    size = text.Length;
                }
                catch (IOException)
                {
                }
            }
            Console.WriteLine(size); // <-- Shows file size in debugging mode.
            Console.WriteLine(result); // <-- For debugging use.
            this.pathFile = FD.FileName;
            if(checkBox1.Checked == false && checkBox2.Checked == false && checkBox3.Checked == false)
            {
                this.fileName = Path.GetFileName(FD.FileName);
            }
            else {
                this.fileName = Path.GetFileNameWithoutExtension(FD.FileName);
            }
            
            textBox1.Text = pathFile;
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = pathFile;  
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                this.convertType = "ConvertToJPG";
                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
         
                SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
                savefile.FileName = fileName;
                if (checkBox1.Checked)
                {
                    savefile.FileName = fileName + ".jpg";
                }
                if (checkBox2.Checked)
                {
                    savefile.FileName = fileName + ".png";
                }
                if (checkBox3.Checked)
                {
                    savefile.FileName = fileName + ".gif";
                }
                // set filters - this can be done in properties as well
                savefile.Filter = "All files (*.*)|*.*";
               
                if (savefile.ShowDialog() == DialogResult.OK)
                {

                    this.newPath = Path.GetFullPath(savefile.FileName);
                    textBox2.Text = newPath;
                }
            
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                this.convertType = "ConvertToPNG";
                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                this.convertType = "ConvertToGIF";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                checkBox5.Checked = false;
                checkBox6.Checked = false;
                textBox3.Visible = true;
                textBox4.Visible = true;
                textBox5.Visible = true;
                textBox6.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;
                label11.Visible = true;
                label12.Visible = true;
                this.convertType = "Crop";
                button4.Text = "Crop";
                fileName = "Crop_" + fileName;
               
            }
            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                textBox5.Visible = false;
                textBox6.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
                label9.Visible = false;
                label10.Visible = false;
                label11.Visible = false;
                label12.Visible = false;
            }
        }

        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                checkBox4.Checked = false;
                checkBox6.Checked = false;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                this.convertType = "Skew";
                button4.Text = "Skew";
                fileName = "Skew_" + fileName;
            }
            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
        }

        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                checkBox4.Checked = false;
                checkBox5.Checked = false;
                textBox3.Visible = true;
                textBox4.Visible = true;
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                this.convertType = "KeepAspect";
                button4.Text = "KeepAspect";
                fileName = "KeepAspect_" + fileName;

            }
            else
            {
                textBox3.Visible = false;
                textBox4.Visible = false;
                label5.Visible = false;
                label6.Visible = false;
                label7.Visible = false;
                label8.Visible = false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((checkBox4.Checked || checkBox5.Checked || checkBox6.Checked))
            {
                ImageContext ic = new ImageContext(pathFile, newPath, convertType, x, y, width, height);
                try
                {
                    ic.ExecuteStrategy();
                    MessageBox.Show("Everything seems to be okay. The new file with specified width and height is saved", "Completed",
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                catch (InvalidPathException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidImageFormatException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (UnathorizedAccessException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (WrongSaveImageFormatException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (FileNotFoundException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (DirectoryNotFoundException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (PathTooLongException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (IOException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (InvalidCropDimensionsException exc)
                {
                    MessageBox.Show(exc.Message, "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
                }




            }
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            int width;
            bool isInt = int.TryParse(textBox3.Text, out width);
            
            if (isInt)
            {
                this.width = width;
            }
            else
            {
                MessageBox.Show("You have to enter a digit", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int height;
            bool isInt = int.TryParse(textBox3.Text, out height);

            if (isInt)
            {
                this.height = height;
            }
            else
            {
                MessageBox.Show("You have to enter a digit", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            bool isInt = int.TryParse(textBox5.Text, out x);

            if (isInt)
            {
                this.x = x;
            }
            else
            {
                MessageBox.Show("You have to enter a digit", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            int y = 0;
            bool isInt = int.TryParse(textBox6.Text, out x);

            if (isInt)
            {
                this.y = y;
            }
            else
            {
                MessageBox.Show("You have to enter a digit", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
