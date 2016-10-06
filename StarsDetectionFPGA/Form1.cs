using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;
using System.Threading;

namespace StarsDetectionFPGA
{
    public partial class Form1 : Form
    {
        //list with image values
        public List<byte> pixelsSend = new List<byte>();
        //list with x,y coordinates received from FPGA
        public List<byte> pixelsIn = new List<byte>();

        public byte RxIn;
        public byte temp;

        string[] ArrayComPortsNames = null;

        public Form1()
        {
            InitializeComponent();
        }
        // Detection of available COM ports at application initialization
        private void Form1_Load(object sender, EventArgs e)
        {
            int index = -1;
            string ComPortName = null;
            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                index += 1;
                ports.Items.Add(ArrayComPortsNames[index]);
            }

            while (!((ArrayComPortsNames[index] == ComPortName)
              || (index == ArrayComPortsNames.GetUpperBound(0))));
            Array.Sort(ArrayComPortsNames);

            // want to get first out
            if (index == ArrayComPortsNames.GetUpperBound(0))
            {
                ComPortName = ArrayComPortsNames[0];
            }
            ports.Text = ArrayComPortsNames[0];
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            // path to image
            string fileToOpen;
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Title = "Choose image";
            fileDialog.Filter = "Image file (*.jpg, *.jpeg, *.jpe, *.bmp, *.png) | *.jpg; *.jpeg; *.jpe; *.bmp; *.png";
            fileDialog.InitialDirectory = @"Enter your initial directory with images";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                // saving folder path to string
                fileToOpen = fileDialog.FileName;
                // create bitmap image using opened image
                Bitmap inputImage = new Bitmap(fileToOpen, true);

                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                // load image to pictureBox   
                pictureBox1.Image = inputImage;

                // getting image values, row by row
                for (int y = 0; y < inputImage.Height; y++)
                {
                    for (int x = 0; x < inputImage.Width; x++)
                    {
                        // saving pixel values at location (x, y)
                        Color pixelColor = inputImage.GetPixel(x, y);
                        int avg = pixelColor.R;
                        pixelsSend.Add((byte)avg);
                    }
                }
            }
            //Console.Write("\nImage opened!");
        }

        // this function is "listening" on serial port. If something is received at COM port via UART 
        // SerialDataReceivedEventArgs event is activated and calls serialPort1_DataReceived function
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Console.Write("\nReceiving data!");
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(serialPort1_DataReceived);
            RxIn = (byte)serialPort1.ReadByte();
            // store values to list
            pixelsIn.Add(RxIn);
            // write received data to console
            Console.WriteLine(RxIn);

        }
        // function which initalizes serial port connection and outputs adequate message if connection is successfully 
        // established
        private void btnUARTInit_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = ports.SelectedItem.ToString();
            serialPort1.BaudRate = 9600;

            try
            {
                serialPort1.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (serialPort1.IsOpen)
            {
                btnUARTInit.Enabled = false;
                MessageBox.Show("UART connection at port " + serialPort1.PortName);
            }    
        }
        // function which sends image values over UART to FPGA (Nexys3 in this case)
        private void buttonUARTSend_Click(object sender, EventArgs e)
        {
            if (serialPort1.IsOpen)
            {
                buttonUARTSend.Enabled = false;
            }
            else return;

            byte[] buff = new byte[1];
            progressBar1.Value = 0;
            int posto = pixelsSend.Count / 100;

            for (int i = 0; i < pixelsSend.Count; ++i)
            {
                buff[0] = pixelsSend[i];
                serialPort1.Write(buff, 0, 1);
               
                if (progressBar1.Value < 100)
                    if ((i % posto) == 0) progressBar1.Value++;
            }
            pixelsIn.Clear();
        }

        // this function marks detected stars on image (coordinates received from FPGA after processing)
        private void btn_DetectStars_Click(object sender, EventArgs e)
        {
            int n = 2;
            int i = 0;
            Image bmp = pictureBox1.Image;
            using (Graphics g = Graphics.FromImage(bmp))
            {
                while (pixelsIn[i] != 0)
                {
                    int y = pixelsIn[i + 1];
                    int x = pixelsIn[i];

                    if (i < pixelsIn.Count() - 1)
                        i += n;
                    else
                        break;

                    int radius = 10;
                    g.DrawEllipse(Pens.White, x - radius / 2, y - radius / 2, radius, radius);
                }
            }
            pictureBox1.Image = bmp;
        }
        //  closing serial port connection and app
        private void buttonExit_Click(object sender, EventArgs e)
        {
            serialPort1.Close();
            this.Close();
        }
    }
}
