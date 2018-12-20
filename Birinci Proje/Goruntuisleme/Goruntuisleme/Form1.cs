using System;
using System.Drawing;
using System.Windows.Forms;
using AForge;
using AForge.Imaging.Filters;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.DirectShow;
using System.IO.Ports;
namespace Goruntuisleme
{
    public partial class Form1 : Form
    {
        string[] portlar = SerialPort.GetPortNames();
        private VideoCaptureDevice kamera;
        private FilterInfoCollection webcamAygit;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (kamera != null && kamera.IsRunning)
            {
                kamera.SignalToStop();
                kamera = null;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            webcamAygit = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in webcamAygit)
            {
                comboBox1.Items.Add(VideoCaptureDevice.Name); 
                comboBox1.SelectedIndex = 0;
            }
            foreach (string port in portlar)
            {
                comboBox2.Items.Add(port);
                comboBox2.SelectedIndex = 0;
            }

        }
        void cam_goruntu_new_frame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap image = (Bitmap)eventArgs.Frame.Clone();
            Bitmap image1 = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = image;
            if (radioButton1.Checked == true)
            {
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(150, 255);
                filter.Green = new IntRange(0, 75);
                filter.Blue = new IntRange(0, 75);
                filter.ApplyInPlace(image1);
                nesnebul(image1);
            }
            if (radioButton2.Checked == true)
            {
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(0, 75);
                filter.Green = new IntRange(0, 75);
                filter.Blue = new IntRange(100, 255);
                filter.ApplyInPlace(image1);
                nesnebul(image1);
            }


            if (radioButton3.Checked == true)
            {
                ColorFiltering filter = new ColorFiltering();
                filter.Red = new IntRange(30, 80);
                filter.Green = new IntRange(80, 255);
                filter.Blue = new IntRange(30, 80);
                filter.ApplyInPlace(image1);
                nesnebul(image1);
            }


        }

        public void nesnebul(Bitmap image)
        {
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.MinWidth = 2;
            blobCounter.MinHeight = 2;
            blobCounter.FilterBlobs = true;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            Grayscale griFiltre = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap griImage = griFiltre.Apply(image);
            blobCounter.ProcessImage(griImage);
            Rectangle[] rects = blobCounter.GetObjectsRectangles();
            pictureBox2.Image = griImage;
            foreach (Rectangle recs in rects)
            {
                if (rects.Length > 0)
                {
                    Rectangle objectRect = rects[0];
                    
                    Graphics g = pictureBox1.CreateGraphics();
                    using (Pen pen = new Pen(Color.FromArgb(252, 3, 26), 2))
                    {
                        g.DrawRectangle(pen, objectRect);
                    }
                    
                    int objectX = objectRect.X + (objectRect.Width / 2);
                    int objectY = objectRect.Y + (objectRect.Height / 2);
                    Control.CheckForIllegalCrossThreadCalls = false;
                    
                    if(objectY < 100)
                    {
                        if(objectX < 100)
                        {
                              serialPort1.Write("a");
                        }
                        else if(objectX > 200)
                        {
                              serialPort1.Write("c");
                        }
                        else
                        {
                              serialPort1.Write("b");
                        }
                    }


                    else if(objectY > 100)
                    {
                        if(objectX < 100)
                        {
                              serialPort1.Write("g");
                        }
                        else if(objectX > 200)
                        {
                              serialPort1.Write("i");
                        }
                        else
                        {
                             serialPort1.Write("h");
                        }
                    }

                    else
                    {
                        if(objectX < 100)
                        {
                            serialPort1.Write("d");
                        }
                        else if(objectX > 200)
                        {
                             serialPort1.Write("f");
                        }
                        else
                        {
                              serialPort1.Write("e");
                        }
                    }
                    
                    
                }
                
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            kamera = new VideoCaptureDevice(webcamAygit[comboBox1.SelectedIndex].MonikerString);//webcam listesinden kafadan birinciyi al diyoruz.
            kamera.NewFrame += new NewFrameEventHandler(cam_goruntu_new_frame);
            kamera.DesiredFrameRate = 30;//saniyede kaç görüntü alsın istiyorsanız. FPS
            kamera.DesiredFrameSize = new Size(300, 300);//görüntü boyutları
            kamera.Start();
            serialPort1.Open();

        }

      
    }
}


