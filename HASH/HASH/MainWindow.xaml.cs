using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace HASH
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string[] arr = new string[10];
        Dictionary<int, TextBlock> myDict = new Dictionary<int, TextBlock>();
        Dictionary<int, TextBlock> myPointer = new Dictionary<int, TextBlock>();


        public MainWindow()
        {
            InitializeComponent();
        }

        //async Task movePointer(int j)
        //{
        //    // Каждый раз надо стирать указатель 
        //    for (int i = 0; i < 10; i++)
        //    {
        //        myPointer[i].Text = "";
        //    }
        //    // передвигаем указатель
        //    myPointer[j].Text = "^";
        //    await Task.Delay(3000);
        //    return;
        //}

        void InsertToArray(int num)
        {
            int idx = num % 7; // наша функция - это остаток от деления на 7
            insertElement.Text = num.ToString();
            insertHash.Text = idx.ToString();
            // Каждый раз надо стирать указатель 
            for (int i = 0; i < 10; i++) {
                myPointer[i].Text = "";
            }
            // А тут сам алгоритм вставки 
            if (arr[idx] == "x")
            {
                arr[idx] = num.ToString();
                myDict[idx].Text = num.ToString();
                myPointer[idx].Text = "^";
            }
            else
            {
                for (int j = idx; j < arr.Length; j++)
                {
                    //await movePointer(j);

                    if (arr[j] == "x")
                    {
                        arr[j] = num.ToString();
                        myDict[j].Text = num.ToString();
                        myPointer[idx].Text = "^";
                        myPointer[j].Text = "^";
                        return;
                    }
                }
                for (int j = 0; j < idx; j++)
                {
                    if (arr[j] == "x")
                    {
                        arr[j] = num.ToString();
                        myDict[j].Text = num.ToString();
                        myPointer[idx].Text = "^";
                        myPointer[j].Text = "^";
                        return;
                    }
                }
            } 
        }

        async private void button1_Click(object sender, RoutedEventArgs e)
        {
            myDict.Clear();
            myDict.Add(0, b0);
            myDict.Add(1, b1);
            myDict.Add(2, b2);
            myDict.Add(3, b3);
            myDict.Add(4, b4);
            myDict.Add(5, b5);
            myDict.Add(6, b6);
            myDict.Add(7, b7);
            myDict.Add(8, b8);
            myDict.Add(9, b9);
            myPointer.Clear();
            myPointer.Add(0, p0);
            myPointer.Add(1, p1);
            myPointer.Add(2, p2);
            myPointer.Add(3, p3);
            myPointer.Add(4, p4);
            myPointer.Add(5, p5);
            myPointer.Add(6, p6);
            myPointer.Add(7, p7);
            myPointer.Add(8, p8);
            myPointer.Add(9, p9);

            for (int i = 0; i < 10; i++)
            {
                arr[i] = "x";
                myDict[i].Text = "x";
            }

            var rand = new Random();

            for (int i = 0; i < 9; i++) 
            {
                InsertToArray(rand.Next(50));
                await Task.Delay(3000);
            }  
        }
    }
}
