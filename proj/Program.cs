// Kelas            : S1SI-KJ-25-06
// Kelompok         : 01
// Anggota Kelompok :
// 1. Masayu Kayla Thalita              (102042500066)
// 2. Falah Sulaiman Ranardy            (102042500080)
// 3. Kiandra Narashreya Adji Prasdhian (102042500107)
// 4. Deden Shaputra                    (102042500119)
// 5. Meisya Dwi Alika                  (102042500166)
// 6. Rafi Maulana Elfajar              (102042500211)
// 7. Fathuriza Rahman                  (102042530031)

using System;

namespace TubesAlpro_DataMahasiswa
{
    internal class Program
    {
        static string[] nim_0601 = new string[100];
        static string[] nama_0601 = new string[100];
        static double[] ipk_0601 = new double[100];
        static int jumlahData_0601 = 0;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== APLIKASI DATA MAHASISWA ===");
                Console.WriteLine("   Kelas: SI-25-06 | Kelompok: 01");
                Console.WriteLine("===================================");
                Console.WriteLine("1. Tambah Data (Create)");
                Console.WriteLine("2. Lihat Data (Read)");
                Console.WriteLine("3. Edit Data (Update)");
                Console.WriteLine("4. Hapus Data (Delete)");
                Console.WriteLine("5. Cari Data (Searching)");
                Console.WriteLine("6. Filter IPK > 3.0 (Filtering)");
                Console.WriteLine("0. Keluar");
                Console.WriteLine("===================================");
                Console.Write("Pilih menu: ");

                int pilihan = int.Parse(Console.ReadLine()!);

                // CREATE
                if (pilihan == 1)
                {
                    Console.WriteLine("\n-- Tambah Data Baru --");

                    if (jumlahData_0601 < 100)
                    {
                        Console.Write("Masukkan NIM : ");
                        nim_0601[jumlahData_0601] = Console.ReadLine()!;

                        Console.Write("Masukkan Nama: ");
                        nama_0601[jumlahData_0601] = Console.ReadLine()!;

                        Console.Write("Masukkan IPK : ");
                        ipk_0601[jumlahData_0601] = double.Parse(Console.ReadLine()!);

                        jumlahData_0601++;
                        Console.WriteLine("Data berhasil disimpan!");
                    }
                    else
                    {
                        Console.WriteLine("Penyimpanan Penuh!");
                    }
                    Console.ReadKey();
                }

                // READ
                else if (pilihan == 2)
                {
                    Console.WriteLine("\n-- Daftar Semua Mahasiswa --");

                    if (jumlahData_0601 == 0)
                    {
                        Console.WriteLine("Data masih kosong.");
                    }
                    else
                    {
                        Console.WriteLine($"{ "No",-5}{ "NIM",-15}{ "Nama",-30}{ "IPK",-5}");
                        Console.WriteLine("-----------------------------------------------------------------------");

                        for (int i = 0; i < jumlahData_0601; i++)
                        {
                            Console.WriteLine($"{ (i+1),-5}{ nim_0601[i],-15}{ nama_0601[i],-30}{ ipk_0601[i],-5}");
                        }
                    }
                    Console.ReadKey();
                }

                // UPDATE
                else if (pilihan == 3)
                {
                    Console.WriteLine("\n-- Edit Data Mahasiswa --");

                    if (jumlahData_0601 == 0)
                    {
                        Console.WriteLine("Data kosong.");
                    }
                    else
                    {
                        Console.Write("Masukkan NIM yang akan diedit: ");
                        string cari = Console.ReadLine()!;
                        int index = -1;

                        for (int i = 0; i < jumlahData_0601; i++)
                        {
                            if (nim_0601[i] == cari)
                            {
                                index = i;
                                break;
                            }
                        }

                        if (index != -1)
                        {
                            Console.Write("Nama Baru : ");
                            nama_0601[index] = Console.ReadLine()!;

                            Console.Write("IPK Baru  : ");
                            ipk_0601[index] = double.Parse(Console.ReadLine()!);

                            Console.WriteLine("Data berhasil diperbarui!");
                        }
                        else
                        {
                            Console.WriteLine("NIM tidak ditemukan.");
                        }
                    }
                    Console.ReadKey();
                }

                // DELETE
                else if (pilihan == 4)
                {
                    Console.WriteLine("\n-- Hapus Data Mahasiswa --");

                    if (jumlahData_0601 == 0)
                    {
                        Console.WriteLine("Data kosong.");
                    }
                    else
                    {
                        Console.Write("Masukkan NIM yang akan dihapus: ");
                        string cari = Console.ReadLine()!;
                        int index = -1;

                        for (int i = 0; i < jumlahData_0601; i++)
                        {
                            if (nim_0601[i] == cari)
                            {
                                index = i;
                                break;
                            }
                        }

                        if (index != -1)
                        {
                            for (int j = index; j < jumlahData_0601 - 1; j++)
                            {
                                nim_0601[j] = nim_0601[j + 1];
                                nama_0601[j] = nama_0601[j + 1];
                                ipk_0601[j] = ipk_0601[j + 1];
                            }

                            jumlahData_0601--;
                            Console.WriteLine("Data berhasil dihapus!");
                        }
                        else
                        {
                            Console.WriteLine("NIM tidak ditemukan.");
                        }
                    }
                    Console.ReadKey();
                }

                // SEARCHING
                else if (pilihan == 5)
                {
                    Console.WriteLine("\n-- Cari Data Mahasiswa --");

                    if (jumlahData_0601 == 0)
                    {
                        Console.WriteLine("Data kosong.");
                    }
                    else
                    {
                        Console.Write("Masukkan Keyword (NIM/ Nama): ");
                        string keyword = Console.ReadLine()!;
                        bool ditemukan = false;

                        for (int i = 0; i < jumlahData_0601; i++)
                        {
                            if (nim_0601[i].Contains(keyword) || nama_0601[i].Contains(keyword))
                            {
                                Console.WriteLine($"- {nama_0601[i]} ({nim_0601[i]})");
                                ditemukan = true;
                            }
                        }

                        if (!ditemukan)
                            Console.WriteLine("Data tidak ditemukan.");
                    }
                    Console.ReadKey();
                }

                // FILTERING
                else if (pilihan == 6)
                {
                    Console.WriteLine("\n-- Filter Mahasiswa (IPK > 3.0) --");

                    bool ada = false;
                    for (int i = 0; i < jumlahData_0601; i++)
                    {
                        if (ipk_0601[i] > 3.0)
                        {
                            Console.WriteLine($"- {nama_0601[i]} (IPK: {ipk_0601[i]})");
                            ada = true;
                        }
                    }

                    if (!ada)
                        Console.WriteLine("Tidak ada mahasiswa dengan IPK > 3.0.");

                    Console.ReadKey();
                }
                // EXIT
                else if (pilihan == 0)
                {
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                    break;
                }

                else
                {
                    Console.WriteLine("Pilihan tidak valid.");
                    Console.ReadKey();
                }
            }
        }
    }
}