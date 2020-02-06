using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace GCyclesSearcher.Users
{
    static class UsersSystem
    {
        public static bool IsCurrentAdmin
        {
            get
            {
                return CurrentLogin == ADMIN_LOGIN;
            }
        }
        public static string CurrentLogin { get; set; }

        /**
         * Структура базы пользователей:
         * Логин
         * Хеш пароля
         * Логин
         * Хеш пароля
         * ...
         * 
         */
        private const string BASE_PATH = "users.firbase";

        private const string ADMIN_LOGIN = "admin";
        private const string ADMIN_PASSWORD = "080497";


        private static bool inited = false;

        public static void Init()
        {
            if (inited)
            {
                throw new Exception("Попытка повторной инициализации системы пользователей!");
            }
            inited = true;

            if (!IsBaseExists())
            {
                CreateBase();
            }
        }

        private static void CreateBase()
        {
            new StreamWriter(BASE_PATH).Close();
        }

        private static bool IsBaseExists()
        {
            return File.Exists(BASE_PATH);
        }


        private static bool IsLoginExists(string login)
        {
            bool found = false;
            if (login == ADMIN_LOGIN)
            {
                found = true;
            }
            else
            {
                StreamReader reader = new StreamReader(BASE_PATH);
                while (!reader.EndOfStream)
                {
                    if (reader.ReadLine() == login)
                    {
                        found = true;
                        break;
                    }
                    reader.ReadLine();
                }
                reader.Close();
            }

            return found;
        }


        public static void CreateUser(string login, string password)
        {
            if (IsLoginExists(login))
            {
                throw new UserExistsException();
            }


            StreamWriter writer = new StreamWriter(BASE_PATH, true);

            writer.WriteLine(login);
            writer.WriteLine(GetPasswordHash(password));
            writer.Close();
        }


        public static void Login(string login, string password)
        {
            bool success = false;

            if (login == ADMIN_LOGIN)
            {
                success = password == ADMIN_PASSWORD;
            }
            else
            {
                StreamReader reader = new StreamReader(BASE_PATH);
                while (!reader.EndOfStream)
                {
                    if (login == reader.ReadLine())
                    {
                        success = VerifyMd5Hash(password, reader.ReadLine());
                        break;
                    }
                    reader.ReadLine();
                }
                reader.Close();
            }

            if (!success)
            {
                throw new WrongUserDataException();
            }

            CurrentLogin = login;
        }


        private static string GetPasswordHash(string password)
        {
            // Create a new instance of the MD5CryptoServiceProvider object.
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(password));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetPasswordHash(input);
            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
