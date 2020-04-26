using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {


        static void Main(string[] args)
        {
            Console.Write("Введите кодовую комбинацию: ");
            String word = Console.ReadLine();
            Int32 n = word.Length;//число информационных
            Int32 k = (int)Math.Ceiling(Math.Log((n + 1) + Math.Log((n + 1), 2), 2));//число корректирующих
            Int32[] mas = new Int32[k];//массив для проверочных разрядов
            mas.Initialize();//инициализация массива
            
            for(int i = 0; i < k; i ++)//расширяем строчку, по умолчанию заполняя контрольные разряды нулями
            {              
                   word = word.Insert((int)Math.Pow(2, i) - 1, "0");
            }

            //Console.WriteLine(word);
            for (int i = 0 ; i < k; i++)//ищем проверочные разряды
            {
                for(int j = 0; j < word.Length; j++)
                {

                String buffer = Convert.ToString(j + 1, 2).PadLeft(k, '0');
                
                if (buffer[k - i - 1] == '1')
                    {
                        mas[i] ^= word[j] - 48;
                    }
                }        
            }

            for (int i = 0; i < k; i++)// записываем в строку проверочные разряды
            {
               word = word.Remove((int)Math.Pow(2, i) - 1, 1).Insert((int)Math.Pow(2, i) - 1, mas[i].ToString());
            }


            Console.WriteLine("Закодированная комбинация: " + word);

            Console.Write("Введите номер разряда который хотите исказить: ");
            Int32 r = Convert.ToInt32(Console.ReadLine());
            Int32 c = ~(word[r - 1] - 48) + 2;//инвертирую разряд c побитового ~НЕ + 2
            word = word.Remove(r - 1, 1).Insert(r - 1, c.ToString());//искажаю в самом слове заменяя символ
            Console.WriteLine("Искаженное слово: " + word);
           

            for (int i = 0; i < k; i++)//ищем СУММЫ
            {
                mas[i] = 0;

                for (int j = 0; j < word.Length; j++)
                {

                    String buffer = Convert.ToString(j + 1, 2).PadLeft(k, '0');

                    if (buffer[k - i - 1] == '1')
                    {
                        mas[i] ^= word[j] - 48;
                    }
                }
            }

            String s = null;

            for (int i = 0; i < k; i++)// записываем в строку СУММЫ
            {
                s += mas[i].ToString();
            }

            Console.WriteLine("Ошибка в разряде: {0}", Parser(s));
            Console.ReadKey();
        }

        static Int32 Parser(String number)//перевод в десятичную СС
        {
            Int32 n = 0;

            for (int i = 0; i < number.Length; i++)
            {
                n += (number[i] - 48) * (int)Math.Pow(2, i);
            }
            return n;
        }

    }
}
