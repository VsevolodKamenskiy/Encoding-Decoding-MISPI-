using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
          
                var x = new XORCipher();
                Console.Write("Введите текст сообщения: ");
                var message = Console.ReadLine();
                Console.Write("Введите пароль: ");
                var pass = Console.ReadLine();
                var encryptedMessageByPass = x.Encrypt(message, pass);
                Console.WriteLine("Зашифрованное сообщение {0}", encryptedMessageByPass);
                Console.WriteLine("Расшифрованное сообщение {0}", x.Decrypt(encryptedMessageByPass, pass));
                Console.ReadLine();
            
        }
    }
}
