// Kelas            : S1SI-KJ-25-06
// Kelompok         : 01
// Anggota Kelompok :
// 1. Masayu Kayla Thalita (102042500066)
// 2. Falah Sulaiman Ranardy (102042500080)
// 3. Kiandra Narashreya Adji Prasdhian (102042500107)
// 4. Deden Shaputra (102042500119)
// 5. Meisya Dwi Alika (102042500166)
// 6. Rafi Maulana Elfajar (102042500211)
// 7. Fathuriza Rahman (102042530031)
using System;

namespace TubesAlpro_DataMahasiswa
{
    internal class Program
    {
        // --- DEKLARASI GLOBAL (DATABASE ARRAY) ---
        // Kapasitas maksimal 100 mahasiswa
        static string[] nim_SI2506_01 = new string[100];
        static string[] nama_SI2506_01 = new string[100];
        static double[] ipk_SI2506_01 = new double[100];
        static int jumlahData_SI2506_01 = 0; 
        static void Main(string[] args)
        {
            // Tidak ada Data Dummy. Program mulai dalam keadaan kosong.

            // Loop utama program (Infinite Loop)
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
                
                int pilihan = int.Parse(Console.ReadLine());
                
                if (pilihan == 1) // CREATE
                {
                    Console.WriteLine("\n-- Tambah Data Baru --");
                    // Cek kapasitas array sebelum menambah
                    if (jumlahData_SI2506_01 < 100) 
                    {
                        Console.Write("Masukkan NIM : ");
                        nim_SI2506_01[jumlahData_SI2506_01] = Console.ReadLine();
                        
                        Console.Write("Masukkan Nama: ");
                        nama_SI2506_01[jumlahData_SI2506_01] = Console.ReadLine();
                        
                        Console.Write("Masukkan IPK : ");
                        ipk_SI2506_01[jumlahData_SI2506_01] = double.Parse(Console.ReadLine());
                        
                        jumlahData_SI2506_01++; // Tambah counter data
                        Console.WriteLine("Data berhasil disimpan!");
                    }
                    else
                    {
                        Console.WriteLine("Penyimpanan Penuh! Hapus data terlebih dahulu.");
                    }
                    Console.ReadKey();
                }
                else if (pilihan == 2) // READ
                {
                    Console.WriteLine("\n-- Daftar Semua Mahasiswa --");
                    
                    // --- LOGIKA CEK DATA KOSONG ---
                    if (jumlahData_SI2506_01 == 0)
                    {
                        Console.WriteLine("Data masih kosong, silahkan tambahkan data terlebih dahulu.");
                    }
                    else
                    {
                        Console.WriteLine("No\tNIM\t\tNama\tIPK");
                        Console.WriteLine("------------------------------------------");
                        
                        for (int i = 0; i < jumlahData_SI2506_01; i++)
                        {
                            Console.WriteLine((i+1) + "\t" + nim_SI2506_01[i] + "\t" + nama_SI2506_01[i] + "\t" + ipk_SI2506_01[i]);
                        }
                    }
                    Console.ReadKey();
                }
                else if (pilihan == 3) // UPDATE
                {
                   Console.WriteLine("\n-- Edit Data Mahasiswa --");
                   // Cek dulu ada data gak, biar gak capek2 nyari padahal kosong
                   if (jumlahData_SI2506_01 == 0)
                   {
                       Console.WriteLine("Data masih kosong, gak bisa edit apa-apa.");
                   }
                   else
                   {
                       Console.Write("Masukkan NIM yang akan diedit: ");
                       string cari = Console.ReadLine();
                       int indexKetemu = -1;

                       // Proses pencarian index data berdasarkan NIM
                       for(int i=0; i<jumlahData_SI2506_01; i++) {
                           if(nim_SI2506_01[i] == cari) {
                               indexKetemu = i;
                               break; 
                           }
                       }

                       if (indexKetemu != -1) {
                           Console.WriteLine("Data Ditemukan: " + nama_SI2506_01[indexKetemu]);
                           Console.WriteLine("Silakan masukkan data baru:");
                           
                           Console.Write("Nama Baru: ");
                           nama_SI2506_01[indexKetemu] = Console.ReadLine();
                           
                           Console.Write("IPK Baru : ");
                           ipk_SI2506_01[indexKetemu] = double.Parse(Console.ReadLine());
                           
                           Console.WriteLine("Data berhasil diperbarui!");
                       } else {
                           Console.WriteLine("NIM tidak ditemukan.");
                       }
                   }
                   Console.ReadKey();
                }
                else if (pilihan == 4) // DELETE
                {
                    Console.WriteLine("\n-- Hapus Data Mahasiswa --");
                    if (jumlahData_SI2506_01 == 0)
                    {
                        Console.WriteLine("Data masih kosong, gak bisa hapus apa-apa.");
                    }
                    else
                    {
                        Console.Write("Masukkan NIM yang akan dihapus: ");
                        string cari = Console.ReadLine();
                        int indexKetemu = -1;

                        // 1. Cari posisi index data
                        for(int i=0; i<jumlahData_SI2506_01; i++) {
                            if(nim_SI2506_01[i] == cari) {
                                indexKetemu = i;
                                break;
                            }
                        }

                        // 2. Hapus data dengan metode menggeser array (Shift Left)
                        if (indexKetemu != -1) {
                            for(int j=indexKetemu; j < jumlahData_SI2506_01 - 1; j++) {
                                nim_SI2506_01[j] = nim_SI2506_01[j+1];
                                nama_SI2506_01[j] = nama_SI2506_01[j+1];
                                ipk_SI2506_01[j] = ipk_SI2506_01[j+1];
                            }
                            jumlahData_SI2506_01--; // Kurangi jumlah data aktif
                            Console.WriteLine("Data berhasil dihapus!");
                        } else {
                            Console.WriteLine("NIM tidak ditemukan.");
                        }
                    }
                    Console.ReadKey();
                }
                else if (pilihan == 5) // SEARCHING
                {
                    Console.WriteLine("\n-- Cari Data Mahasiswa --");
                    if (jumlahData_SI2506_01 == 0)
                    {
                        Console.WriteLine("Data kosong, mau nyari siapa?");
                    }
                    else
                    {
                        Console.Write("Masukkan Keyword (NIM/Nama): ");
                        string keyword = Console.ReadLine();
                        bool dataFound = false;
                        
                        Console.WriteLine("Hasil Pencarian:");
                        for(int i=0; i<jumlahData_SI2506_01; i++) {
                            // Mencari kecocokan pada NIM atau Nama
                            if(nim_SI2506_01[i].Contains(keyword) || nama_SI2506_01[i].Contains(keyword)) {
                                Console.WriteLine("- " + nama_SI2506_01[i] + " (" + nim_SI2506_01[i] + ")");
                                dataFound = true;
                            }
                        }
                        
                        if(!dataFound) Console.WriteLine("Data tidak ditemukan.");
                    }
                    Console.ReadKey();
                }
                else if (pilihan == 6) // FILTERING
                {
                     Console.WriteLine("\n-- Filter Mahasiswa (IPK > 3.0) --");
                     if (jumlahData_SI2506_01 == 0)
                     {
                         Console.WriteLine("Data kosong.");
                     }
                     else
                     {
                        for(int i=0; i<jumlahData_SI2506_01; i++) {
                            if(ipk_SI2506_01[i] > 3.0) {
                                Console.WriteLine("- " + nama_SI2506_01[i] + " (IPK: " + ipk_SI2506_01[i] + ")");
                            }
                        }
                     }
                    Console.ReadKey();
                }
                else if (pilihan == 0) // EXIT
                {
                    Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                    break; // Keluar dari while(true) loop
                }
                else 
                {
                    Console.WriteLine("Pilihan menu tidak valid.");
                    Console.ReadKey();
                }
            }
        }
    }
}