using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace TugasProjut2
{
    class salah
    {
        public salah()
        {
            Console.WriteLine("\nPilihan yang anda masukan salah!");
        }
        ~salah()
        {
            Console.WriteLine("Tekan sembarang untuk memilih kembali...");
        }
    }

    class TampilKara
    {
        public static void salahInput()
        {
            salah T = new salah();
        }

        public static void menulihat()
        {
            
            bool kondisi;
            int pilih = 0;
            string pilihan;
            do
            {
                
                printMenulihat();
                Console.Write("Masukan pilihan anda : ");
                pilihan = Console.ReadLine();
                kondisi = int.TryParse(pilihan, out pilih);
                if (kondisi == true && pilih > 0 && pilih < 5)
                {
                    continue;
                }
                //Console.WriteLine("\nPilihan yang anda masukan salah!");
                //Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                salahInput();
                GC.Collect();
                Console.ReadLine();
            } while (pilih < 1 || pilih > 4);

            switch (pilih)
            {
                case 1:
                    //tampil semua data
                    tampilAll();
                    break;
                case 2:
                    //tampilin yang diatas umur
                    umurlihat();
                    break;
                case 3:
                    //tampilkan yang dialamat tertentu
                    alamatlihat();
                    break;
                case 4:
                    //menu utama
                    Program.Main();
                    break;
                default:
                    break;
            }
        }
        static void printMenulihat()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tMenu Tampil Data");
            Console.WriteLine("\t\t\t\t\t\t\t\t===================");
            Console.WriteLine("1. Tampil Semua Data\n");
            Console.WriteLine("2. Tampil Karakter diatas umur tertentu\n");
            Console.WriteLine("3. Tampil Karakter dengan alamat tertentu\n");
            Console.WriteLine("4. Menu Utama\n");
        }

        static void alamatlihat()
        {
            Console.Clear();
            string alamat;
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tMenu lihat alamt tertentu");
                Console.WriteLine("\t\t\t\t\t\t\t===============================\n");
                Console.Write("\nMasukan alamat : ");
                alamat = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tList Karakter");
            Console.WriteLine("\t\t\t\t\t\t\t=========\n");
            Console.WriteLine("No.\tNama\t\t\t\t\t\t\t\tUmur\t\tAlamat\n\n");
            //Codingan baca dari file atau ambil langsung dri function
            bacaalamat(alamat);

            Console.Write("\n\nKlik sembarang untuk kembali ke menu lihat...");
            Console.ReadKey();
            menulihat();
        }
        static void bacaalamat(string alamat)
        {
            int counter = 0;
            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                if (Regex.IsMatch(result[2], alamat, RegexOptions.IgnoreCase))
                {
                    //membuat baris list murid
                    if (result[0].Length < 8)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                    }
                    else if (result[0].Length < 16)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                    }
                    else if (result[0].Length < 24)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    else if (result[0].Length < 31)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    else if (result[0].Length < 39)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    else if (result[0].Length < 47)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                    }
                    else
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    counter++;
                }

                //Console.Read();
                //Console.WriteLine(line);

            }
            sr.Close();
            if (counter == 0)
                Console.WriteLine("Tidak ada karakter dengan alamat tersebut.");
        }
        static void umurlihat()
        {
            Console.Clear();
            bool batas = false;
            int umur;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tMenu lihat diatas umur tertentu");
                Console.WriteLine("\t\t\t\t\t\t\t===============================\n");
                Console.Write("\nMasukan batas umur bawah : ");
                umur = int.Parse(Console.ReadLine());
                if (umur >= 0)
                {
                    batas = true;
                    continue;

                }
                else
                {
                    Console.WriteLine("Umur yang dimasukan tidak valid!\nTekan sembarang tombol untuk kembali memasukan umur");
                    Console.ReadKey();
                }

            } while (batas == false);
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tList Karakter");
            Console.WriteLine("\t\t\t\t\t\t\t=========\n");
            Console.WriteLine("No.\tNama\t\t\t\t\t\t\t\tUmur\t\tAlamat\n\n");
            //Codingan baca dari file atau ambil langsung dri function
            bacaumur(umur);

            Console.Write("\n\nKlik sembarang untuk kembali ke menu lihat...");
            Console.ReadKey();
            menulihat();
        }

        static void bacaumur(int umur)
        {
            int counter = 0;
            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                if (Convert.ToInt16(result[1]) > umur)
                {
                    //membuat baris list murid
                    if (result[0].Length < 8)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                    }
                    else if (result[0].Length < 16)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                    }
                    else if (result[0].Length < 24)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    else if (result[0].Length < 31)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    else if (result[0].Length < 39)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    else if (result[0].Length < 47)
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                    }
                    else
                    {
                        Console.WriteLine("{0}.\t{1}\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                    }
                    counter++;
                }

                //Console.Read();
                //Console.WriteLine(line);
                
            }
            sr.Close();
            if (counter == 0)
                Console.WriteLine("Tidak ada karakter dengan umur tersebut.");
        }
       
        static void tampilAll()
        {

            ////////////////////////////////////////////////
            //Try(?)
            ///////////////////////////////////////////////
            //method untuk tampilkan semua karakter
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tList Murid");
            Console.WriteLine("\t\t\t\t\t\t\t=========\n");
            Console.WriteLine("No.\tNama\t\t\t\t\t\t\t\tUmur\t\tAlamat\n\n");
            //Codingan baca dari file atau ambil langsung dri function
            bacaAll();

            Console.Write("\n\n\t\t\t\t\t\t\tKlik sembarang untuk kembali ke menu lihat...");
            Console.ReadKey();
            menulihat();
        }

        static void bacaAll()
        {
            int counter = 0;
            string line;

            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);

            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //membuat baris list murid
                if (result[0].Length < 8)
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                }
                else if (result[0].Length < 16)
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                }
                else if (result[0].Length < 24)
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                }
                else if (result[0].Length < 31)
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                }
                else if (result[0].Length < 39)
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                }
                else if (result[0].Length < 47)
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);
                }
                else
                {
                    Console.WriteLine("{0}.\t{1}\t\t\t{2}\t\t{3}", counter + 1, result[0], result[1], result[2]);

                }

                //Console.Read();
                //Console.WriteLine(line);
                counter++;
            }
            sr.Close();
        }
    }
}
