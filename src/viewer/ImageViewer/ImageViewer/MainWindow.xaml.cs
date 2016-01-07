using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft.Json;

namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Parrallel queues
        Queue<BitmapImage> ImageQueue = new Queue<BitmapImage>();
        Queue<String> CorrectAnsweQueue = new Queue<string>();
        Extractor Unzipper;

        string CorrectAnswer;
        // I might have to use this if the imagebox doesn't load the dequeue immediately
        Image NumberImageObject;

        int SubmitCount = 0;

        public MainWindow()
        {
            InitializeComponent();

            SubmitButton.IsDefault = true;

            // Unzip the images
            Unzipper = new Extractor();
            Unzipper.Extract("pictures.zip");

            // Get image json data
            StreamReader Reader = new StreamReader("numbers.json");
            string RawJson = Reader.ReadToEnd();
            dynamic AnswersJsonObject = JsonConvert.DeserializeObject(RawJson);

            // Get file information
            string FilePath = Directory.GetCurrentDirectory() + "\\" + Unzipper.TempFolderName + "\\pictures\\";
            DirectoryInfo ImageFileInfo = new DirectoryInfo(FilePath);
            FileInfo[] ImageFiles = ImageFileInfo.GetFiles("*.jpg");

            foreach (var file in ImageFiles)
            {
                // Build image and place in queue
                BitmapImage NumberImage = new BitmapImage();
                NumberImage.BeginInit();
                NumberImage.UriSource = new Uri(FilePath + file.Name, UriKind.RelativeOrAbsolute);
                NumberImage.EndInit();

                ImageQueue.Enqueue(NumberImage);

                // Get the key from the filename
                string Key = StripFilePathFromString(file.Name);

                // Search the json for the answer and enqueue it
                string Answer = AnswersJsonObject[Key].ToString();
                CorrectAnsweQueue.Enqueue(Answer);
            }

            CorrectAnswer = CorrectAnsweQueue.Dequeue();
            BitmapImage img = ImageQueue.Dequeue();
            NumberImage.Source = img;

        }

        /// <summary>
        /// Strips the filepath from the string
        /// </summary>
        /// <param name="Filename"></param>
        /// <returns></returns>
        private string StripFilePathFromString(string Filename)
        {
            string ret = Filename.Replace(".jpg", String.Empty);
            return ret.Trim();
        }

        // Here be dragons. Thou art forewarned.
 
        public static int elijahCorrect = 0;
        public static int baileyCorrect = 0;
        public static int calebCorrect = 0;
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            // Read inputs
            string elijahInput = ElijahTextBox.Text;
            string baileyInput = BaileyTextBox.Text;
            string calebInput = CalebTextBox.Text;


            if (SubmitCount >= 300)
            {
                MessageBox.Show("Elijah Score: " + elijahCorrect);
                MessageBox.Show("Bailey Score: " + baileyCorrect);
                MessageBox.Show("Caleb Score: " + calebCorrect);
            }


            // If it's the first run then we want to use the initally set values
             ++SubmitCount;
             if (elijahInput.Trim() == CorrectAnswer)
                ++elijahCorrect;

             if (baileyInput.Trim() == CorrectAnswer)
                ++baileyCorrect;

             if (calebInput.Trim() == CorrectAnswer)
                ++calebCorrect;

             CorrectAnswer = CorrectAnsweQueue.Dequeue();
             BitmapImage img = ImageQueue.Dequeue();
             NumberImage.Source = img;

            ElijahTextBox.Text = "";
            BaileyTextBox.Text = "" ;
            CalebTextBox.Text = "";

            ElijahTextBox.Focus();

        }

        private double DetermineSucessPercentage(double CorrectCount)
        {
            return 0.0;
        }

        /// <summary>
        /// Messagebox.shows() the queues for testing purposes
        /// </summary>
        private void OutputQueuesForTesting()
        {
            for (int i = 0; i < ImageQueue.Count; i++)
            {
                string MessageBoxString = ImageQueue.Dequeue() + ":" + CorrectAnsweQueue.Dequeue();
                MessageBox.Show(MessageBoxString);
            }
        }
    }
}
