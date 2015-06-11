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
    class EditKara
    {
        public static void tambahkara()
        {
            string pilihan;
            do
            {
                printmenuTambahkarakter();
                pilihan = Console.ReadLine();
                // Program.inputlog(pilihan);
                switch (pilihan)
                {
                    case "1":
                        menuMasukankarater();
                        break;
                    case "2":
                        //back to program.main()
                        Program.Main();
                        break;
                    default:
                        Console.WriteLine("Pilihan yang anda masukan salah!");
                        Console.WriteLine("Tekan sembarang untuk memilih kembali...");
                        Console.ReadLine();
                        break;
                }
            } while (true);
        }
        static void printmenuTambahkarakter()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\tMenu Murid");
            Console.WriteLine("\t\t\t\t\t\t\t==========\n");
            Console.WriteLine("1. Masukan data karakter\n");
            Console.WriteLine("2. Kembali ke menu utama\n");
            Console.Write("Masukan pilihan anda : ");
        }
        static void menuMasukankarater()
        {
            string nama;
            int umur;
            string alamat;
            bool batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tMasukan Data Karakter");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Nama : ");
                nama = Console.ReadLine();
                if (ceknama(nama) == false && IsDigitsOnly(nama) == true)
                {
                    //ceking nama
                    batas = true;
                    continue;
                }
                else
                {
                    Console.WriteLine("Nama sudah terdaftar! atau Nama tidak Valid!\nTekan sembarang tombol untuk kembali memasukan nama");
                    Console.ReadLine();
                    //untuk membuat mengulang memasukan nama
                }


            } while (batas == false);
            batas = false;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t\t\t\t\t\tMasukan Data Karakter");
                Console.WriteLine("\t\t\t\t\t\t\t==================\n");
                Console.Write("Masukan Nama : {0}", nama);
                Console.Write("\nMasukan Umur : ");
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
            batas = false;
            Console.Write("Masukan Alamat : ");
            alamat = Console.ReadLine();
            //koding nulis ke file output.txt
            nulisdata(nama, umur, alamat);
            //
            Console.WriteLine("\n\nData berhasil disimpan! Tekan sembarang tombol untuk kembali....");
            Console.ReadLine();
            Program.Main();

        }
        public static bool IsDigitsOnly(string str)
        {
            {
                return Regex.IsMatch(str, @"^[a-zA-Z]+$");
            }
        }
        public static bool ceknama(string nama)
        {

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
                if (result[0] == nama)
                {
                    sr.Close();
                    return true;
                }

            }
            sr.Close();
            return false;
        }

        static void nulisdata(string nama, int umur, string alamat)
        {
            /////////////////////////////////////////////////
            //TRY
            ////////////////////////////////////////////////
            string umurS = umur.ToString();
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            //StreamReader sr = new StreamReader(file);
            using (FileStream fs = new FileStream(file, FileMode.Append, FileAccess.Write))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine(nama + "\t" + umurS + "\t" + alamat);
            }
            ////////////////////////////////////////////////
            //CATCH
            ///////////////////////////////////////////////
        }

        public static void menuhapuskara()
        {
            string nama;
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\t\t\tHapus Karakter");
            Console.WriteLine("\t\t\t\t\t\t\t\t======================\n");
            Console.Write("Masukan Nama yang ingin dihapus, \n\nNama :");
            nama = Console.ReadLine();
            Console.WriteLine("Anda yakin akan menghapus karakter ini (Y/N)? ");
            switch (char.ToUpper(Console.ReadKey().KeyChar))
            {
                case 'Y':

                    Console.ReadLine();
                    break;
                default:

                    // selain Y dianggap N
                    Console.WriteLine("\nPenghapusan karakter dibatalkan");
                    Console.WriteLine("\nTekan sembarang untuk kembali ke menu peminjaman");
                    Console.ReadLine();
                    Program.Main();
                    break;
            }
            ///koding hapus kara
            hapuskara(nama);
            copyfile();
            ///
            Console.WriteLine("Penghapusa Karakter Berhasil!\n");
            Console.Write("Klik sembarang untuk kembali ke menu utama...");
            Console.ReadKey();
            Program.Main();
        }
        static void copyfile() //untuk copy isi file dan delete
        {
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\outputcp.txt";
            string target = dir + @"\output.txt";
            //copy file di folder yg sama.. hati2 penamaanya yaa
            System.IO.File.Copy(file, target, true);

            //delete cp nya sekarang
            File.Delete(file);
            // Keep console window open in debug mode.
            //Console.WriteLine("Press any key to exit.");
            //Console.ReadKey();
        }
        static void hapuskara(string nama)
        {

            ////////////////////////////////////////////////
            //TRY
            ///////////////////////////////////////////////
            string line;
            string pattern = @"\t+";
            Regex rgx = new Regex(pattern);
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string file = dir + @"\output.txt";
            string filecp = dir + @"\outputcp.txt";
            StreamReader sr = new StreamReader(file);
            while ((line = sr.ReadLine()) != null)
            {
                string[] result = rgx.Split(line);
                //mengecek apakah nama, kalau ada gak melakukan apa2 kalau ada nulis file dengan mengabaikan nama
                if (result[0] != nama)
                {
                    if (!File.Exists(filecp))
                    {
                        // Create a file to write to. kalau belom ada filenya 
                        using (StreamWriter swnew = File.CreateText(filecp))
                        {
                            swnew.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
                        }
                    }
                    //kalau ud ada file yang mau ditulis
                    else
                    {
                        using (FileStream fs = new FileStream(filecp, FileMode.Append, FileAccess.Write))
                        using (StreamWriter sw = new StreamWriter(fs))
                        {
                            sw.WriteLine(result[0] + "\t" + result[1] + "\t" + result[2]);
                        }
                    }
                }
            }
            sr.Close();

            ////////////////////////////////////////////////
            //CATCH
            ///////////////////////////////////////////////
        }
    }
}
