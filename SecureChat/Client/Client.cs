using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Runtime.Serialization;
using System.Threading;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;

namespace Client
{
    public partial class Client : Form
    {
        bool exchange_flag = false;
        int flag1 = 1;
        bool check = false;
        byte[] encrypted;
        long mod_private;
        bool flag = false;
        static long prime_p;
        static long primitive_root;
        string Modulo_KeyPrivate;
        byte[] Key = new Byte[32];
        bool random = false;
        public Client()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            Connect();
        }

        IPEndPoint IP;
        Socket client;

        void Connect()
        {
            IP = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9999);
            client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);

            try
            {
                client.Connect(IP);
            }
            catch
            {
                MessageBox.Show("Cannot connect", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Thread listen = new Thread(Receive);
            listen.IsBackground = true;
            listen.Start();
        }

        void Close()
        {
            client.Close();
        }

        void Send()
        {
            if (textBox1.Text != string.Empty)
            {
                string message = YourName.Text + ": " + textBox1.Text;
                richTextBox1.Text += message + "\r\n";
                if (listCipher.Text == "3DES")
                    message = Encrypt_3DES(message, Key_Box.Text);
                else
                    if (listCipher.Text == "Caesar")
                    message = Encrypt_Caesar(message, long.Parse(Key_Box.Text));
                else
                    if (listCipher.Text == "AES")
                    message = Encrypt_AES(message, long.Parse(Key_Box.Text));

                client.Send(Serialize(message));
            }
           
            textBox1.Text = "";
        }

        void Receive()
        {
            try
            {
                while (true)
                {
                    byte[] data = new byte[1024 * 1000];
                    client.Receive(data);

                    string message = (string)Deserialize(data);
                    if (message.Contains("G = "))
                    {                      
                        TextBox_G.Text = message.Remove(0, 4);
                        Random_Button.Enabled = false;
                    }
                    else
                    if (message.Contains("P = "))
                    {
                        TextBox_P.Text = message.Remove(0, 4);
                        Lock_Button.Enabled = false;
                    }
                    else
                    if (message.Contains("PRK = "))
                    {
                        while (prKey.Text == "") MessageBox.Show("Nhập Private Key vô", "Notification!");

                        long B = Int64.Parse(message.Remove(0, 6));
                        B = Caculate_Modulo(B, long.Parse(prKey.Text), prime_p);
                        Key_Box.Text = B.ToString();
                    }
                    else
                    {
                        if (listCipher.Text == "3DES")
                            message = Decrypt_3DES(message, Key_Box.Text);
                        else
                        if (listCipher.Text == "Caesar")
                            message = Decrypt_Caesar(message, long.Parse(Key_Box.Text));
                        else
                        if (listCipher.Text == "AES")
                            message = Decrypt_AES(message, long.Parse(Key_Box.Text));
                        richTextBox1.Text += message + "\r\n";
                    }              
                }
            }
            catch
            {
                Close();
            }
        }

        byte[] Serialize(object obj)
        {
            MemoryStream stream = new MemoryStream();
            BinaryFormatter formatter = new BinaryFormatter();

            formatter.Serialize(stream, obj);

            return stream.ToArray();
        }

        object Deserialize(byte[] data)
        {
            MemoryStream stream = new MemoryStream(data);
            BinaryFormatter formatter = new BinaryFormatter();

            return formatter.Deserialize(stream);
        }

        private void Client_FormClosed(object sender, FormClosedEventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Send();
        }

        #region cipher
        public string Encrypt_3DES(string source, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Encoding.UTF8.GetBytes(source);

            string encoded =
                Convert.ToBase64String(desCryptoProvider.CreateEncryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return encoded;
        }
        public static string Decrypt_3DES(string encodedText, string key)
        {
            TripleDESCryptoServiceProvider desCryptoProvider = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider hashMD5Provider = new MD5CryptoServiceProvider();

            byte[] byteHash;
            byte[] byteBuff;

            byteHash = hashMD5Provider.ComputeHash(Encoding.UTF8.GetBytes(key));
            desCryptoProvider.Key = byteHash;
            desCryptoProvider.Mode = CipherMode.ECB; //CBC, CFB
            byteBuff = Convert.FromBase64String(encodedText);

            string plaintext = Encoding.UTF8.GetString(desCryptoProvider.CreateDecryptor().TransformFinalBlock(byteBuff, 0, byteBuff.Length));
            return plaintext;
        }

        public char trans(char x, long key)
        {
            if (x >= '0' && x <= '9')
                x = (char)((x - 48 + key + 10000000) % 10 + 48);
            else
            if (x >= 'a' && x <= 'z')
                x = (char)((x - 97 + key + 11881376) % 26 + 97); // 26^5
            else
            if (x >= 'A' && x <= 'Z')
                x = (char)((x - 65 + key + 11881376) % 26 + 65); // 26^5

            return x;
        }
        public string Encrypt_Caesar(string message, long key)
        {
            string enc = "";
            foreach (char x in message)
            {
                char c = trans(x, key);
                enc += c;
            }
            return enc;
        }
        public string Decrypt_Caesar(string message, long key)
        {
            string dec = "";
            foreach (char x in message)
            {
                char c = trans(x, -key);
                dec += c;
            }
            return dec;
        }
        public static string Encrypt_AES(string text, long k)
        {
            string k_string = k.ToString();
            int padding = 16 - k_string.Length;
            if (k_string.Length != 16)
            {
                for (int i = 0; i < padding; i++)
                    k_string = k_string + "x";
            }
            byte[] src = Encoding.UTF8.GetBytes(text);
            byte[] key = Encoding.ASCII.GetBytes(k_string);

            RijndaelManaged aes = new RijndaelManaged();

            aes.Mode = CipherMode.ECB;
            aes.Padding = PaddingMode.PKCS7;
            aes.KeySize = 128;

            using (ICryptoTransform encrypt = aes.CreateEncryptor(key, null))
            {
                byte[] dest = encrypt.TransformFinalBlock(src, 0, src.Length);
                encrypt.Dispose();
                return Convert.ToBase64String(dest);
            }
        }
        public static string Decrypt_AES(string text, long k)
        {
            string k_string = k.ToString();
            int padding = 16 - k_string.Length;
            if (k_string.Length != 16)
            {
                for (int i = 0; i < padding; i++)
                    k_string = k_string + "x";
            }
            byte[] src = Convert.FromBase64String(text);
            RijndaelManaged aes = new RijndaelManaged();
            byte[] key = Encoding.ASCII.GetBytes(k_string);
            aes.KeySize = 128;
            aes.Padding = PaddingMode.PKCS7;
            aes.Mode = CipherMode.ECB;
            using (ICryptoTransform decrypt = aes.CreateDecryptor(key, null))
            {
                byte[] dest = decrypt.TransformFinalBlock(src, 0, src.Length);
                decrypt.Dispose();
                return Encoding.UTF8.GetString(dest);
            }
        }
        #endregion 

        #region Calculate
        static List<long> listarray = new List<long>();
        List<long> list_PrimeFactors = new List<long>();
        List<long> list_divisor = new List<long>();
        private void Button_Random_Click(object sender, EventArgs e)
        {
            if (random == true)
            {
                Init_Array(ref listarray);
                Random rand = new Random();
                int number = rand.Next(0, listarray.Count);

                long prime_random_p = listarray[number];
                prime_p = listarray[number];
                this.TextBox_P.Text = listarray[number].ToString();

                long s = prime_random_p - 1;

                FindPrimeFactors(ref list_PrimeFactors, s);

                Find_Divisor(list_PrimeFactors, ref list_divisor, s);

                long smallest_primitive_root = Find_Premitive_root(list_divisor, s, prime_random_p);

                this.TextBox_G.Text = smallest_primitive_root.ToString();
            }
            else
                MessageBox.Show("Not connected!", "Notification!");
        }
        private void Find_Divisor(List<long> list, ref List<long> list_divisor, long fi_p)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list_divisor.Add(fi_p / list[i]);
            }
        }
        private void FindPrimeFactors(ref List<long> list, long n)
        {

            for (long i = 0; i < listarray.Count; i++)
            {
                int dem = (int)i;
                if (n % listarray[dem] == 0)
                {
                    if (Check_Exist(list, listarray[dem]) == false)
                    {
                        list.Add(listarray[dem]);
                    }
                    n = n / listarray[dem];
                }
            }
        }
        private void Init_Array(ref List<long> list)
        {
            list.Add(2);
            for (long i = 3; i < 100000; i += 2)
            {
                if (Check_Prime(i) == true)
                    list.Add(i);
            }
        }
        private long Find_Premitive_root(List<long> list_divisor, long s, long p)
        {

            for (long i = 2; i <= s; i++)
            {
                if (Check(list_divisor, i, p) == true)
                    return i;
            }
            return 1;
        }
        private bool Check_Exist(List<long> list, long n)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] == n)
                    return true;
            }
            return false;
        }
        public bool Check_Prime(long n)
        {
            if (n < (long)2)
                return false;
            for (long i = (long)2; i*i <= n; i++)
            {
                if (n % i == (long)0)
                    return false;
            }
            return true;
        }
        private bool Check(List<long> list_divisor, long number, long p)
        {
            for (int i = 0; i < list_divisor.Count; i++)
            {
                if (Caculate_Modulo(number, list_divisor[i], p) == 1)
                    return false;
            }
            return true;
        }
        private long Caculate_Modulo(long a, long x, long p)
        {
            long temp = a % p;

            long dem = 0;

            if (x >= 2)
                temp = (a * a) % p;

            if (x == 3)
            {
                temp = (temp * a) % p;
            }

            for (long i = 4; i < x; i *= 2)
            {
                temp = (temp * temp) % p;
                dem = i;
            }

            if (dem > 0)
            {
                for (long j = dem + 1; j <= x; j++)
                {
                    temp = (temp * a) % p;
                }
            }
            return temp;
        }
        #endregion
        private void LockButton_Click(object sender, EventArgs e)
        {
            if (this.TextBox_P.Text != "")
            {
                if (int.Parse(this.TextBox_P.Text) <= 2 || Check_Prime(long.Parse(this.TextBox_P.Text)) == false)
                {
                    MessageBox.Show("P must be Prime elder than 2 ", "Notification!");
                    this.TextBox_G.Text = "";
                }
                else
                {
                    this.Random_Button.Enabled = false;
                    long prime_random_p = long.Parse(this.TextBox_P.Text);
                    long s = prime_random_p - 1;

                    if (prime_random_p != prime_p)
                    {
                        prime_p = prime_random_p;
                        list_PrimeFactors.Clear();
                        list_divisor.Clear();
                        s = prime_random_p - 1;
                        FindPrimeFactors(ref list_PrimeFactors, s);

                        Find_Divisor(list_PrimeFactors, ref list_divisor, s);

                        long smallest_primitive_root = Find_Premitive_root(list_divisor, s, prime_random_p);

                        this.TextBox_G.Text = smallest_primitive_root.ToString();
                    }
                    this.Lock_Button.Enabled = false;
                    this.TextBox_P.ReadOnly = true;
                    this.TextBox_G.ReadOnly = true;
                    if (flag1 == 1)
                    {
                        string str = "#Prime_p:" + this.TextBox_P.Text + "#";
                        byte[] send_data = Encoding.UTF8.GetBytes(str);
                        string str1 = "$Primitive_root:" + this.TextBox_G.Text + "$";
                        byte[] send_data1 = Encoding.UTF8.GetBytes(str1);
                    }

                    primitive_root = long.Parse(this.TextBox_G.Text);
                }
            }
            else
            {
                MessageBox.Show("Not input P", "Notification!");
            }

            client.Send(Serialize("P = " + TextBox_P.Text));
            Thread.Sleep(500);
            client.Send(Serialize("G = " + TextBox_G.Text));
        }

        private void Random_Button_Click(object sender, EventArgs e)
        {
            
            Init_Array(ref listarray);
            Random rand = new Random();
            int number = rand.Next(0, listarray.Count);

            long prime_random_p = listarray[number];
            prime_p = listarray[number];
            this.TextBox_P.Text = listarray[number].ToString();

            long s = prime_random_p - 1;

            FindPrimeFactors(ref list_PrimeFactors, s);

            Find_Divisor(list_PrimeFactors, ref list_divisor, s);

            long smallest_primitive_root = Find_Premitive_root(list_divisor, s, prime_random_p);

            this.TextBox_G.Text = smallest_primitive_root.ToString();
        }

        private void Lock_Private_Key_Click(object sender, EventArgs e)
        {
            if (this.prKey.Text != "")
            {
                this.Lock_Private_Key.Enabled = false;
                long key_private = long.Parse(prKey.Text);
                prime_p = long.Parse(this.TextBox_P.Text);
                primitive_root = long.Parse(this.TextBox_G.Text);
                mod_private = Caculate_Modulo(primitive_root, key_private, prime_p);
                if (flag1 == 1)
                {
                    string str = "PRK = " + mod_private.ToString();
                    client.Send(Serialize(str));
                    //Key_Box.Text = mod_private.ToString();
                }
                this.prKey.ReadOnly = true;
            }
            else
                MessageBox.Show("Not input Private Key", "Notification!");
        }
    }
}
