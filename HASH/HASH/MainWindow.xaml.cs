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
        bool dictExist = false;
        int newNum;
        int newIdx;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }


        async Task goRight(int idx, int num)
        {
            for (int j = idx; j < myDict.Count; j++)
            {
                // стираем указатели
                for (int i = 0; i < myPointer.Count; i++)
                    myPointer[i].Text = "";
                // двигаем указатель вправо от хеша и до конца массива
                myPointer[j].Text = "^";
                // проверяем пустая ли там ячейка и если да, то вписываем значение
                if (myDict[j].Text == "x")
                {
                    myDict[j].Text = num.ToString();
                    return;
                }
                await Task.Delay(1000);
            }
            // если дошли до конца массива и не нашли свободной ячейки, то просматриваем массив с начала
            for (int j = 0; j < idx; j++)
            {
                // стираем указатели
                for (int i = 0; i < myPointer.Count; i++)
                    myPointer[i].Text = "";
                // двигаем указатель вправо от начала до хеша
                myPointer[j].Text = "^";
                // проверяем пустая ли там ячейка и если да, то вписываем значение
                if (myDict[j].Text == "x")
                {
                    myDict[j].Text = num.ToString();
                    return;
                }
                await Task.Delay(1000);
            }
            // если мы сюда попали, то значит у нас массив заполнен!
            myDict.Clear();
            dictExist = false;
            return;
        }

        async private void button3_Click(object sender, RoutedEventArgs e)
        {
            // Если словарь еще не создан, то создаем его
            if (!dictExist)
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
                    myDict[i].Text = "x";
                dictExist = true;
            }

            // начинаем работу
            var rand = new Random();
            newNum = rand.Next(50);
            newIdx = newNum % 7;   // это наша хеш-функция
            // прописываем наше число и хеш в окошки
            insertElement.Text = newNum.ToString();
            insertHash.Text = newIdx.ToString();
            // очищаем каждый раз указатель
            for (int i = 0; i < 10; i++)
                myPointer[i].Text = "";
            if (myDict[newIdx].Text == "x")
            {
                myDict[newIdx].Text = newNum.ToString();
                myPointer[newIdx].Text = "^";
            }
            else
            {
                // идем вправо и ищем свободное место
                await goRight(newIdx, newNum);
            }
        }
    }
}
