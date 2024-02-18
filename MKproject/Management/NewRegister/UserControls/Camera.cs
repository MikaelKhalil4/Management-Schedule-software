
using System;
using System.Windows.Forms;



namespace MKproject.Management
{
    public partial class Camera : Form
    {
        //bool _streaming;
        //Capture _capture;

        //public UCCamera UCcamera;


        public Camera()
        {
            InitializeComponent();
            ////CheckCameraDevices();
            //_streaming = true;
            //// Initialize with the default camera (index 0)
           
            //TurnOnCamera();
        }

        // private void CheckCameraDevices()
        // {
        //     int cameraCount = 0;

        //     // Try creating Capture objects for different camera indices
        //     for (int i = 0; i < 10; i++) // You can adjust the range as needed
        //     {
        //         Capture capture = null;
        //         capture = new Capture(i);
        //         //try
        //         //{
        //         //    capture = new Capture(i);
        //         //}
        //         //catch (Exception)
        //         //{
        //         //    // Camera at this index is not available or an exception occurred
        //         //}
        //         if (capture != null)
        //         {
        //             cameraCount++;
        //             capture.Dispose(); // Dispose of the Capture object
        //             CustomMessageBox.Show($"Camera {cameraCount}: Index {i}", CustomMessageBox.Type.Ok);
        //         }
        //     }

        //     if (cameraCount == 0)
        //     {
        //         CustomMessageBox.Show("No camera devices found.", CustomMessageBox.Type.Ok);
        //     }
        // }

        // private void MirrorImage()
        // {
        //     if (pictureBoxCamera.Image != null)
        //     {
        //         // Get the original image from the PictureBox
        //         Bitmap originalImage = new Bitmap(pictureBoxCamera.Image);

        //         // Create a new bitmap and draw the mirrored image on it
        //         Bitmap mirroredImage = new Bitmap(originalImage.Width, originalImage.Height);
        //         using (Graphics g = Graphics.FromImage(mirroredImage))
        //         {
        //             g.DrawImage(originalImage, new Rectangle(0, 0, mirroredImage.Width, mirroredImage.Height),
        //                 new Rectangle(originalImage.Width - 1, 0, -originalImage.Width, originalImage.Height),
        //                 GraphicsUnit.Pixel);
        //         }

        //         // Display the mirrored image in the PictureBox
        //         pictureBoxCamera.Image = mirroredImage;
        //     }
        // }

        // private void streaming(object sender, EventArgs e)
        // {
        //     var frame = _capture.QueryFrame();

        //     if (frame != null)
        //     {
        //         try
        //         {
        //             var img = frame.ToImage<Bgr, byte>();
        //             var bmp = img.Bitmap;
        //             pictureBoxCamera.Image = bmp;
        //             MirrorImage();
        //             img.Dispose(); // Release the Emgu.CV image

        //         }
        //         catch (Exception ex)
        //         {
        //             // Handle exceptions
        //         }
        //     }
        // }


        private void buttonCapture_Click(object sender, EventArgs e)
        {
            //if (!_streaming)//save
            //{
            //    UCcamera.ValueImage = pictureBoxCamera.Image;

            //    // Stop streaming and release the camera
            //    TurnOffCamera();
            //    this.Close();
            //}
            //else//capture
            //{
            //    // Stop streaming and release the camera
            //    TurnOffCamera();
            //    pictureBoxCamera.Image = ImagesFunctions.CompressImage(pictureBoxCamera.Image);//already low quality
            //    buttonCapture.Text = "Save";
            //    buttonCancel.Text = "Retake";
            //    _streaming = !_streaming;
            //}
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            //if (!_streaming)//retake
            //{
            //    // Start streaming with the selected camera
            //    TurnOnCamera();
            //    buttonCapture.Text = "Capture";
            //    buttonCancel.Text = "Cancel";
            //    _streaming = !_streaming;
            //}
            //else//cancel
            //{
            //    // Stop streaming and release the camera

            //    TurnOffCamera();
            //    this.Close();
            //}
        }
        // void TurnOffCamera()
        // {
        //     if (_capture != null)
        //     {
        //         _capture.Stop();
        //         _capture.Dispose();
        //         _capture = null;
        //         Application.Idle -= streaming;
        //     }

        // }
        //void TurnOnCamera()
        // {
        //     _capture = new Capture(0);
        //     _capture.Start();
        //     Application.Idle += streaming;
        // }


    }
}
