﻿using System;
using System.Collections.Generic;
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


namespace ImageViewer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<Image> ImageQueue = new Queue<Image>();
        private string CorrectAnswer = "";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void SubmitButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private double DetermineSucessPercentage(double CorrectCount)
        {
            return NotImplementedException;
        }
    }
}