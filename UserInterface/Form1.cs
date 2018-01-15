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


        public ImageConverter()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //buttona submit
            if ((checkBox1.Checked || checkBox2.Checked || checkBox3.Checked) && (pathFile != null && newPath != null)) { 
            ImageContext ic = new ImageContext(pathFile, newPath, convertType);
            ic.ExecuteStrategy();
                MessageBox.Show("Everything seems to be okay. The new file with specified type is saved", "Completed",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("File paths or convert types are not selected", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                label5.Visible = true;
                label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                this.convertType = "Crop";
                button4.Text = "Crop";
               
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
            if ((checkBox4.Checked || checkBox5.Checked || checkBox6.Checked) && pathFile != null)
            {
                ImageContext ic = new ImageContext(pathFile, newPath, convertType, width, height);
                ic.ExecuteStrategy();
                MessageBox.Show("Everything seems to be okay. The new file with specified width and height is saved", "Completed",
                MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            else
            {
                MessageBox.Show("Specified width and height are not set or option is not selected", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
             
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

            int width = int.Parse(textBox3.Text);
            if (width != 0)
            {
                this.width = width;
            }
            else
            {
                MessageBox.Show("Width cannot be null", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

         
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            int height = int.Parse(textBox3.Text);
            if (height != 0)
            {
                this.height = height;
            }
            else
            {
                MessageBox.Show("Height cannot be null", "Processing error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
