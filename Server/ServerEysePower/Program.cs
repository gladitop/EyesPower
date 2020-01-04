using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net.Mail;
using System.Net.NetworkInformation;

namespace ServerEysePower
{
    class Program
    {
        //public static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Database.mdb;"; // для 32 битной системы
        public static string connectString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database.mdb;"; // для 64 бит
        static OleDbConnection myConnection;
        static Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        static byte[] buffer = new byte[1024];
        static MailAddress frommail = new MailAddress("dam.almaev@gmail.com");
        static Random rand = new Random();

        static void Main(string[] args)
        {
            Console.Title = "EysePower: Сервер";
            Write("Запуск всех компонентах..", ConsoleColor.Yellow);
            Write("Запуск сервера...", ConsoleColor.Yellow);
            server.Bind(new IPEndPoint(IPAddress.Any, 904));
            server.Listen(999999);
            Write("Сервер запущен!", ConsoleColor.Green);
            Write("Проверка файлов...", ConsoleColor.Yellow);
            if (File.Exists("Database.mdb"))
            {
                Write("Файлы в строю!", ConsoleColor.Green);
            }
            else
            {
                Write("Ошибка!", ConsoleColor.Red);
                Console.ReadLine();
                Environment.Exit(0);
            }
            Write("Соединение к баз данным...", ConsoleColor.Yellow);
            myConnection = new OleDbConnection(connectString);
            myConnection.Open();
            Write("База данных подключена!", ConsoleColor.Green);
            Write("Запуск потоков...", ConsoleColor.Yellow);
            Thread thread = new Thread(new ThreadStart(Connects));
            thread.Start();
            Write("Потоки пашут!", ConsoleColor.Green);
            Write("Центр команд активен!", ConsoleColor.Green);
            Console.Beep();
            while (true)
            {
                string answer = Console.ReadLine();
                if (answer.ToLower() == "exit")
                {
                    myConnection.Close();
                    Environment.Exit(0);
                }
            }
        }

        static bool EmailConfirmation(Socket client, string email)
        {
            try
            {
                MailAddress tomail = new MailAddress(email);
                MailMessage message = new MailMessage(frommail, tomail);
                message.Subject = "EysePower: подтвердите свой email";
                string code = Convert.ToString(rand.Next(1, 9999));
                message.Body = $"Ваш код: {code}";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("dam.almaev@gmail.com", "1506.2006A");
                smtp.EnableSsl = true;
                Write($"Отправка письма от {email}", ConsoleColor.Yellow);
                smtp.Send(message);
                Write("Готово", ConsoleColor.Green);

                Write("Ожидание кода...", ConsoleColor.Yellow);
                int messi = client.Receive(buffer);
                string codee = Encoding.UTF8.GetString(buffer, 0, messi);
                codee = codee.Trim(new char[] { ' ' });
                Write(codee, ConsoleColor.Red);
                if (codee == code)
                {
                    Write("Подтверждение есть!", ConsoleColor.Green);
                    return true;
                }
                return false;
            }
            catch 
            {
                if (CheckConnectError(client) == false)
                {
                    Thread.Sleep(0);
                }
                return false;
            }
        }

        static bool EmailCheck(Socket client, string email)
        {
            try
            {
                OleDbCommand command = new OleDbCommand($"SELECT Login FROM Accounts WHERE Login = '{email}'", myConnection);
                command.ExecuteScalar().ToString();
                return false;
            }
            catch
            {
                if (CheckConnectError(client) == false)
                {
                    Thread.Sleep(0);
                }
            }
            return true;
        }

        static bool LoginAccount(Socket client, string email, string pass)
        {
            try
            {
                OleDbCommand command = new OleDbCommand($"SELECT Login FROM Accounts WHERE Login = '{email}'", myConnection);
                command.ExecuteScalar().ToString();
                command = new OleDbCommand($"SELECT Passworld FROM Accounts WHERE Passworld = '{pass}'", myConnection);
                command.ExecuteScalar().ToString();
                return false;
            }
            catch 
            {
                if (CheckConnectError(client) == false)
                {
                    Thread.Sleep(0);
                }
            }
            return true;
        }

        static void MessClient(object clien)
        {
            Socket client = (Socket)clien;
            bool whiles = true;
            while (whiles)
            {
                try
                {
                    //регистрация

                    int messi = client.Receive(buffer);
                    if (Encoding.UTF8.GetString(buffer, 0, messi) == "Reg")
                    {
                        //email

                        messi = client.Receive(buffer);
                        string email = Encoding.UTF8.GetString(buffer, 0, messi);

                        //пароль

                        messi = client.Receive(buffer);
                        string pass = Encoding.UTF8.GetString(buffer, 0, messi);

                        //Проверка email

                        if (EmailCheck(client, email))
                        {
                            Task.Delay(100).Wait();
                            client.Send(Encoding.UTF8.GetBytes("Yes"));

                            //подтверждение email

                            if (EmailConfirmation(client, email))
                            {

                                //конец!

                                OleDbCommand command = new OleDbCommand($"INSERT INTO Accounts(Login, Passworld) VALUES('{email}', '{pass}')", myConnection);
                                command.ExecuteReader();
                                Task.Delay(100).Wait();
                                client.Send(Encoding.UTF8.GetBytes("Yes"));
                                Write($"Новый аккаунт! email: {email}, {pass}", ConsoleColor.Green);
                            }
                            else
                            {
                                client.Send(Encoding.UTF8.GetBytes("No"));
                                Write("Ошибка: не тот код!", ConsoleColor.Red); 
                            }
                        }
                        else
                        {
                            client.Send(Encoding.UTF8.GetBytes("No"));
                            Write("Ошибка: Такой email уже использовался", ConsoleColor.Red);
                        }
                    }

                    //Вход

                    if (Encoding.UTF8.GetString(buffer, 0, messi) == "Log")
                    {
                        //email

                        messi = client.Receive(buffer);
                        string email = Encoding.UTF8.GetString(buffer, 0, messi);

                        //пароль

                        messi = client.Receive(buffer);
                        string pass = Encoding.UTF8.GetString(buffer, 0, messi);

                        if (LoginAccount(client, email, pass) == true)
                        {
                            Write($"Вход в аккаунт: {email}, {pass}!", ConsoleColor.Green);
                            client.Send(Encoding.UTF8.GetBytes("Login Yes"));
                        }
                        else
                        {
                            client.Send(Encoding.UTF8.GetBytes("Login No"));
                            Write($"Вход не удался в аккаунт: {email}, {pass}", ConsoleColor.Red);
                        }
                    }

                    //Сихронизация

                    if (Encoding.UTF8.GetString(buffer, 0, messi) == "Scr")
                    {
                        
                    }
                }
                catch(Exception ex) 
                { 
                    Write($"Ошибка! {ex.Message}", ConsoleColor.Red);

                    if (CheckConnectError(client) == false)
                    {
                        whiles = false;
                    }
                }
            }
        }

        static bool CheckConnectError(Socket client)//проверка клиента после ошибки
        {
            try
            {
                string ip = Convert.ToString(client.Ttl);
                Ping ping = new Ping();
                PingReply reply = ping.Send(ip, 200);

                if (reply.Status == IPStatus.Success)
                {
                    Write("Проверка клиента завершена!", ConsoleColor.Green);
                    return true;
                }
            }
            catch 
            { 
                Write("Отключение клиента!", ConsoleColor.Red);
            }
            return false;
        }

        static void CheckConnect(object clien)
        {
            try
            {
                Socket client = (Socket)clien;
                int messi = client.Receive(buffer);
                string answer = Encoding.UTF8.GetString(buffer, 0, messi);
                if (answer == "EysePower 1.0")
                {
                    Write("Новое подключение!", ConsoleColor.Green);
                    Thread thread = new Thread(new ParameterizedThreadStart(MessClient));
                    thread.Start(client);
                }
                else 
                {
                    Write("Ошибка нового подключения!", ConsoleColor.Red);
                    client.Close();
                    Thread.Sleep(0);
                }
            }
            catch { }
        }

        static void Connects()
        {
            while (true)
            {
                try
                {
                    Task.Delay(10).Wait();
                    Socket client = server.Accept();
                    Thread thread = new Thread(new ParameterizedThreadStart(CheckConnect));
                    thread.Start(client);
                }
                catch { Thread.Sleep(0); }
            }
        }

        static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}
