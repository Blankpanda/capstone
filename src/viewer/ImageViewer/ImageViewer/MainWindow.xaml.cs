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
        Queue<Image> ImageQueue = new Queue<Image>();
        Queue<String> CorrectAnsweQueue = new Queue<string>();
        Extractor Unzipper;

        string CorrectAnswer;
        // I might have to use this if the imagebox doesn't load the dequeue immediately 
        Image NumberImageObject;

        int SubmitCount = 0;
        
        public MainWindow()
        {
            InitializeComponent();

            // Unzip the images
            Unzipper = new Extractor();
            Unzipper.Extract("pictures.zip");

            // Get image json data
            StreamReader Reader = new StreamReader("numbers.json");
            string RawJson = Reader.ReadToEnd();
            dynamic AnswersJsonObject = JsonConvert.DeserializeObject(RawJson);

            // Get file information
            string FilePath = Unzipper.TempFolderName + @"\pictures\";
            DirectoryInfo ImageFileInfo = new DirectoryInfo(FilePath);
            FileInfo[] ImageFiles = ImageFileInfo.GetFiles("*.jpg");

            foreach (var file in ImageFiles)
            {
                // Build image and place in queue
                Image NumberImage = new Image();
                NumberImage.Source = new BitmapImage(new Uri(FilePath, UriKind.RelativeOrAbsolute));
                ImageQueue.Enqueue(NumberImage);

                // Get the key from the filename
                string Key = StripFilePathFromString(file.Name);

                // Search the json for the answer and enqueue it 
                string Answer = AnswersJsonObject[Key].ToString();
                CorrectAnsweQueue.Enqueue(Answer);
            }

            // Initial set up 
            CorrectAnswer = CorrectAnsweQueue.Dequeue();
            Image img = ImageQueue.Dequeue();
            NumberImage.Source = img.Source;

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

        public static int elijahCorrect = 0;
        public static int baileyCorrect = 0;
        public static int calebCorrect = 0;
        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

            // Read inputs
            string elijahInput = ElijahTextBox.Text;
            string baileyInput = BaileyTextBox.Text;
            string calebInput = CalebTextBox.Text;



            // If it's the first run then we want to use the initally set values 
            if (SubmitCount == 0)
            {
                ++SubmitCount;
                if (elijahInput.Trim() == CorrectAnswer)
                {
                    ++elijahCorrect;
                }
                else if (baileyInput.Trim() == CorrectAnswer)
                {
                    ++baileyCorrect;
                }
                else if (calebInput.Trim() == CorrectAnswer)
                {
                    ++calebCorrect;
                }
            }
            else
            {
                // Get the image and the answer for the image
                CorrectAnswer = CorrectAnsweQueue.Dequeue();
                Image img = ImageQueue.Dequeue();
                NumberImage.Source = img.Source;

                if (elijahInput.Trim() == CorrectAnswer)
                {
                    ++elijahCorrect;
                }
                else if (baileyInput.Trim() == CorrectAnswer)
                {
                    ++baileyCorrect;
                }
                else if (calebInput.Trim() == CorrectAnswer)
                {
                    ++calebCorrect;
                }

                ++SubmitCount;
            }

            
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
