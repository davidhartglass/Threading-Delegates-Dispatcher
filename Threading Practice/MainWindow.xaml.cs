using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Windows;
using System.Windows.Media.Imaging;

namespace Threading_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> list = new List<string>();
        public MainWindow()
        {         
            InitializeComponent();
            myWebBrowser.Height = 600;
            myWebBrowser.Width = 600;
            searchTextBox.Clear();
        }

        // Simple for loop to count from 0 up to 1 million
        // and adds listbox items for each iteration
        private void countUp()
        {
            this.Dispatcher.Invoke(() =>
            {
                numbersAscListBox.Items.Clear();

                for (int i = 0; i < 1000000; i++)
                {
                    numbersAscListBox.Items.Add(i);
                }
            });
        }

        // Simple for loop to count from 1 million down to 0
        // and adds listbox items for each iteration
        private void countDown()
        {
            numbersDescListBox.Items.Clear();
            for (int i = 1000000; i > 0; i--)
            {
                numbersDescListBox.Items.Add(i);
            }
            //MessageBox.Show("CountDown Method Completed");
        }

        // Uses dispatcher to load a random image from the url.
        // User can type in a string to append to the search
        // for filtering
        public void loadDogPicture()
        {
            this.Dispatcher.Invoke(() =>
            {
                myWebBrowser.Navigate("https://loremflickr.com/600/600/" + searchTextBox.Text);
            });
        }

        public delegate void Del();
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {

            //Uses a delegate to fire off the series of methods
            //Del handler = loadDogPicture;
            //handler += countUp;
            //handler += countDown;

            //handler();


            //Uses threads to run the series of methods
            //All methods are time consuming tasks

            Thread secondThread = new Thread(countUp);
            Thread thirdThread = new Thread(loadDogPicture);

            thirdThread.Start();
            secondThread.Start();
            countDown();
        }
    }
}