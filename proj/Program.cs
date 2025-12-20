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
class Program
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
            Console.WriteLine("=== APLIKASI DATA IPK MAHASISWA ===");
            Console.WriteLine("   Kelas: SI-25-06 | Kelompok: 01  ");
            Console.WriteLine("===================================");
            Console.WriteLine("1. Tambah Data   (Create)");
            Console.WriteLine("2. Lihat Data    (Read)");
            Console.WriteLine("3. Edit Data     (Update)");
            Console.WriteLine("4. Hapus Data    (Delete)");
            Console.WriteLine("5. Cari Data     (Searching)");
            Console.WriteLine("6. Filter IPK    (Filtering)");
            Console.WriteLine("0. Keluar");
            Console.WriteLine("===================================");
            Console.Write("Pilih menu: ");
            int pilihan_0601;
            try // Input pilihan harus berupa angka
            {
                pilihan_0601 = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("Pilihan harus berupa angka!");
                Console.Write("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadKey();
                continue;
            }
            if (pilihan_0601 == 1) TambahData();        // CREATE
            else if (pilihan_0601 == 2) LihatData();    // READ
            else if (pilihan_0601 == 3) EditData();     // UPDATE
            else if (pilihan_0601 == 4) HapusData();    // DELETE
            else if (pilihan_0601 == 5) CariData();     // SEARCHING
            else if (pilihan_0601 == 6) FilterData();   // FILTERING
            else if (pilihan_0601 == 0)                 // EXIT
            {
                Console.WriteLine("Terima kasih telah menggunakan aplikasi ini.");
                break;
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
                Console.WriteLine("Silahkan pilih dari 1-6");
                Console.Write("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadKey();
            }
        }
    }
    static void TambahData() // CREATE
    {
        Console.WriteLine("\n-- Tambah Data Baru --");
        if (jumlahData_0601 < 100)
        {
            Console.Write("Masukkan NIM: ");
            try // Input NIM harus berupa angka
            {
                string inputNIM_0601 = Console.ReadLine()!;
                Convert.ToInt64(inputNIM_0601);
                for (int i = 0; i < jumlahData_0601; i++) // Cek duplikat NIM
                {
                    if (nim_0601[i] == inputNIM_0601) // Jika ada duplikat
                    {
                        Console.WriteLine($"[Gagal] NIM {inputNIM_0601} sudah terdaftar!");
                        Console.Write("\nTekan ENTER untuk kembali ke menu...");
                        Console.ReadKey();
                        return;
                    }
                }
                nim_0601[jumlahData_0601] = inputNIM_0601;
            }
            catch (Exception)
            {
                Console.WriteLine("[Gagal] NIM harus berupa angka!");
                Console.Write("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadKey();
                return;
            }
            Console.Write("Masukkan Nama: ");
            string inputNama_0601 = Console.ReadLine()!.ToUpper();
            nama_0601[jumlahData_0601] = inputNama_0601;
            Console.Write("Masukkan IPK : ");
            try // Input IPK harus berupa angka
            {
                double inputIPK_0601 = double.Parse(Console.ReadLine()!);
                if (inputIPK_0601 < 0.0 || inputIPK_0601 > 4.0)
                {
                    Console.WriteLine("[Gagal] IPK harus antara 0.00 - 4.00!");
                    Console.Write("\nTekan ENTER untuk kembali ke menu...");
                    Console.ReadKey();
                    return;
                }
                ipk_0601[jumlahData_0601] = inputIPK_0601;
            }
            catch (FormatException)
            {
                Console.WriteLine("[Gagal] IPK harus berupa angka!");
                Console.Write("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadKey();
                return;
            }
            jumlahData_0601++;
            Console.WriteLine("\n[Sukses] Data berhasil disimpan!");
        }
        else
        {
            Console.WriteLine("Penyimpanan penuh!");
        }
        Console.Write("\nTekan ENTER untuk kembali ke menu...");
        Console.ReadKey();
    }
    static void LihatData() // READ
    {
        Console.WriteLine("\n-- Daftar Semua Mahasiswa --");
        if (jumlahData_0601 == 0)
        {
            Console.WriteLine("Data masih kosong.");
        }
        else
        {
            Console.WriteLine($"{"No",-5}{"NIM",-15}{"Nama",-30}{"IPK",-5}"); // Header tabel
            Console.WriteLine("-------------------------------------------------------");
            for (int i = 0; i < jumlahData_0601; i++) // Menampilkan data
            {
                Console.WriteLine($"{(i + 1),-5}{nim_0601[i],-15}{nama_0601[i],-30}{ipk_0601[i],-5}");
            }
        }
        Console.Write("\nTekan ENTER untuk kembali ke menu...");
        Console.ReadKey();
    }
    static void EditData() // UPDATE
    {
        Console.WriteLine("\n-- Edit Data Mahasiswa --");
        if (jumlahData_0601 == 0) // Jika data kosong
        {
            Console.WriteLine("Data kosong.");
            Console.Write("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadKey();
            return;
        }
        Console.Write("Masukkan NIM yang ingin diubah: ");
        string cari_0601 = Console.ReadLine()!;
        int index_0601 = -1;
        for (int i = 0; i < jumlahData_0601; i++) // Mencari NIM
        {
            if (nim_0601[i] == cari_0601) // Jika NIM ditemukan
            {
                index_0601 = i;
                break;
            }
        }
        if (index_0601 != -1)
        {
            Console.WriteLine($"\n[Data Ditemukan]");
            Console.WriteLine($"NIM : {nim_0601[index_0601]}");
            Console.WriteLine($"Nama: {nama_0601[index_0601]}");
            Console.WriteLine($"IPK : {ipk_0601[index_0601]}");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Apa yang ingin diubah?");
            Console.WriteLine("1. NIM");
            Console.WriteLine("2. Nama");
            Console.WriteLine("3. IPK");
            Console.Write("Pilih (1-3): ");
            int subMenu_0601;
            try // Input pilihan harus berupa angka
            {
                subMenu_0601 = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("[Gagal] Pilihan harus angka.");
                Console.Write("\nTekan ENTER untuk kembali ke menu...");
                Console.ReadKey();
                return;
            }
            if (subMenu_0601 == 1) // GANTI NIM
            {
                Console.Write("Masukkan NIM Baru: ");
                try
                {
                    string nimBaru_0601 = Console.ReadLine()!;
                    Convert.ToInt64(nimBaru_0601);
                    if (nimBaru_0601 != nim_0601[index_0601])
                    {
                        bool adaDuplikat_0601 = false;
                        for (int i = 0; i < jumlahData_0601; i++) // Cek duplikat NIM
                        {
                            if (nim_0601[i] == nimBaru_0601) // Jika ada duplikat NIM
                            {
                                adaDuplikat_0601 = true;
                                break;
                            }
                        }
                        if (adaDuplikat_0601)
                        {
                            Console.WriteLine($"[Gagal] NIM {nimBaru_0601} sudah dipakai orang lain!");
                            Console.Write("\nTekan ENTER untuk kembali ke menu...");
                            Console.ReadKey();
                            return;
                        }
                    }
                    nim_0601[index_0601] = nimBaru_0601; // Update NIM
                    Console.WriteLine("[Sukses] NIM diperbarui.");
                }
                catch (Exception)
                {
                    Console.WriteLine("[Gagal] NIM harus angka.");
                }
            }
            else if (subMenu_0601 == 2) // Ganti Nama
            {
                Console.Write("Masukkan Nama Baru: ");
                string namaBaru_0601 = Console.ReadLine()!.ToUpper();
                nama_0601[index_0601] = namaBaru_0601; // Update Nama
                Console.WriteLine("[Sukses] Nama diperbarui.");
            }
            else if (subMenu_0601 == 3) // Ganti IPK
            {
                Console.Write("Masukkan IPK Baru: ");
                try
                {
                    double ipkBaru_0601 = double.Parse(Console.ReadLine()!);
                    if (ipkBaru_0601 < 0.0 || ipkBaru_0601 > 4.0)
                    {
                        Console.WriteLine("[Gagal] IPK harus antara 0.00 - 4.00!");
                        Console.Write("\nTekan ENTER untuk kembali ke menu...");
                        Console.ReadKey();
                        return;
                    }
                    ipk_0601[index_0601] = ipkBaru_0601; // Update IPK
                    Console.WriteLine("[Sukses] IPK diperbarui.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("[Gagal] IPK harus angka.");
                }
            }
            else
            {
                Console.WriteLine("Pilihan tidak valid.");
            }
        }
        else // Jika NIM tidak ditemukan
        {
            Console.WriteLine("NIM tidak ditemukan.");
        }
        Console.Write("\nTekan ENTER untuk kembali ke menu...");
        Console.ReadKey();
    }
    static void HapusData() // DELETE
    {
        Console.WriteLine("\n-- Hapus Data Mahasiswa --");
        if (jumlahData_0601 == 0)
        {
            Console.WriteLine("Data kosong.");
            Console.Write("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadKey();
            return;
        }
        Console.Write("Masukkan NIM yang akan dihapus: ");
        string cari_0601 = Console.ReadLine()!;
        int index_0601 = -1;
        for (int i = 0; i < jumlahData_0601; i++)
        {
            if (nim_0601[i] == cari_0601)
            {
                index_0601 = i;
                break;
            }
        }
        if (index_0601 != -1)
        {
            Console.WriteLine($"Menghapus data: {nama_0601[index_0601]}...");
            for (int j = index_0601; j < jumlahData_0601 - 1; j++)
            {
                nim_0601[j] = nim_0601[j + 1];
                nama_0601[j] = nama_0601[j + 1];
                ipk_0601[j] = ipk_0601[j + 1];
            }
            jumlahData_0601--;
            Console.WriteLine("\n[Sukses] Data berhasil dihapus!");
        }
        else
        {
            Console.WriteLine("NIM tidak ditemukan.");
        }
        Console.Write("\nTekan ENTER untuk kembali ke menu...");
        Console.ReadKey();
    }
    static void CariData() // SEARCHING
    {
        Console.WriteLine("\n-- Cari Data Mahasiswa --");
        if (jumlahData_0601 == 0)
        {
            Console.WriteLine("Data kosong.");
            Console.Write("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadKey();
            return;
        }
        Console.Write("Masukkan Keyword (NIM/Nama): ");
        string keyword_0601 = Console.ReadLine()!;
        Console.WriteLine("\n[Hasil Pencarian]");
        Console.WriteLine("-------------------------------------------------------");
        Console.WriteLine($"{"No",-5}{"NIM",-15}{"Nama",-30}{"IPK",-5}");
        Console.WriteLine("-------------------------------------------------------");
        bool ditemukan_0601 = false;
        for (int i = 0; i < jumlahData_0601; i++)
        {
            if (nim_0601[i].Contains(keyword_0601) || nama_0601[i].Contains(keyword_0601))
            {
                Console.WriteLine($"{(i + 1),-5}{nim_0601[i],-15}{nama_0601[i],-30}{ipk_0601[i],-5}");
                ditemukan_0601 = true;
            }
        }
        Console.WriteLine("-------------------------------------------------------");
        if (!ditemukan_0601)
        {
            Console.WriteLine($"Tidak ada data yang cocok dengan keyword '{keyword_0601}'.");
        }
        Console.Write("\nTekan ENTER untuk kembali ke menu...");
        Console.ReadKey();
    }
    static void FilterData() // FILTERING
    {
        if (jumlahData_0601 == 0)
        {
            Console.WriteLine("\n-- Filter Data Mahasiswa --");
            Console.WriteLine("Data kosong.");
            Console.Write("\nTekan ENTER untuk kembali ke menu...");
            Console.ReadKey();
            return;
        }
        while (true)
        {
            Console.Clear();
            Console.WriteLine("=== FILTER DATA MAHASISWA ===");
            Console.WriteLine("Pilih Kategori Filter:");
            Console.WriteLine("1. IPK >= 3.0 (Standar)");
            Console.WriteLine("2. IPK >= 3.5 (Cumlaude)");
            Console.WriteLine("3. Input Batas IPK Manual");
            Console.WriteLine("4. Kembali ke Menu Utama");
            Console.WriteLine("=============================");
            Console.Write("Pilih (1-4): ");
            int subMenu_0601;
            try
            {
                subMenu_0601 = int.Parse(Console.ReadLine()!);
            }
            catch (FormatException)
            {
                Console.WriteLine("[Gagal] Pilihan harus angka!");
                Console.Write("\nTekan ENTER untuk kembali...");
                Console.ReadKey();
                continue;
            }
            double batasIPK_0601 = 0;
            bool valid_0601 = true;
            if (subMenu_0601 == 1)
            {
                batasIPK_0601 = 3.0;
            }
            else if (subMenu_0601 == 2)
            {
                batasIPK_0601 = 3.5;
            }
            else if (subMenu_0601 == 3)
            {
                Console.Write("Masukkan Batas Minimum IPK: ");
                try
                {
                    batasIPK_0601 = double.Parse(Console.ReadLine()!);
                }
                catch
                {
                    Console.WriteLine("[Gagal] Input IPK harus angka!");
                    valid_0601 = false;
                }
            }
            else if (subMenu_0601 == 4)
            {
                return;
            }
            else
            {
                Console.WriteLine("[Gagal] Pilihan tidak valid (1-4).");
                valid_0601 = false;
            }
            if (valid_0601)
            {
                Console.WriteLine($"\n-- Hasil Filter IPK >= {batasIPK_0601} --");
                bool ada_0601 = false;
                for (int i = 0; i < jumlahData_0601; i++)
                {
                    if (ipk_0601[i] >= batasIPK_0601)
                    {
                        Console.WriteLine($"- {nama_0601[i]} (IPK: {ipk_0601[i]})");
                        ada_0601 = true;
                    }
                }
                if (!ada_0601)
                {
                    Console.WriteLine($"Tidak ada mahasiswa dengan IPK >= {batasIPK_0601}.");
                }
            }
            Console.WriteLine("\nTekan ENTER untuk filter lagi...");
            Console.ReadKey();
        }
    }
}