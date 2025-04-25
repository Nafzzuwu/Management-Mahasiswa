// Jawaban Soal Tipe C //

using System;
using System.Collections.Generic;
using System.Linq;

abstract class Orang
{
    public string NIM { get; set; }
    public string NAMA { get; set; }

    public abstract void Tampilan();
}

class Mahasiswa : Orang
{
    public string Jurusan { get; set; }

    public override void Tampilan()
    {
        Console.WriteLine($"NIM      : {NIM}");
        Console.WriteLine($"Nama     : {NAMA}");
        Console.WriteLine($"Jurusan  : {Jurusan}");
        Console.WriteLine("---------------------");
    }
}

class Program
{
    static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>();
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("------- Menu Utama ------");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Mahasiswa");
            Console.WriteLine("3. Update Mahasiswa");
            Console.WriteLine("4. Hapus Mahasiswa");
            Console.WriteLine("5. Exit");
            Console.Write("Pilih Menu (1-5): ");
            string pilihan = Console.ReadLine();

            switch (pilihan)
            {
                case "1":
                    TambahMahasiswa();
                    break;
                case "2":
                    LihatMahasiswa();
                    break;
                case "3":
                    UpdateMahasiswa();
                    break;
                case "4":
                    HapusMahasiswa();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Bye Bye...");
                    break;
                default:
                    Console.WriteLine("Pilihan Tidak Ada.");
                    break;
            
        }
    }
}

    static void TambahMahasiswa()
    {
        Console.Write("Masukkan NIM :");
        string nim = Console.ReadLine();
        if (daftarMahasiswa.Any(m => m.NIM == nim))
        {
            Console.WriteLine("NIM sudah ada!");
            return;
        }

        Console.Write("Masukkan Nama :");
        string nama = Console.ReadLine();

        Console.Write("Masukkan Jurusan :");
        string jurusan = Console.ReadLine();

        Mahasiswa mhs = new Mahasiswa
        {
            NIM = nim,
            NAMA = nama,
            Jurusan = jurusan
        };
        daftarMahasiswa.Add(mhs);
        Console.WriteLine("Mahasiswa berhasil ditambahkan.");
    }

    static void LihatMahasiswa()
    {
        if (daftarMahasiswa.Count == 0)
        {
            Console.WriteLine("Data mahasiswa belum ada.");
            return;
        }

        Console.WriteLine("====== Daftar Mahasiswa ======");
        foreach (var mhs in daftarMahasiswa)
        {
            mhs.Tampilan();
        }
    }

    static void UpdateMahasiswa()
    {
        Console.Write("Masukkan NIM mahasiswa yang ingin diubah :");
        string nim = Console.ReadLine();
        var mhs = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);
        if (mhs == null)
        {
            Console.WriteLine("NIM tidak ada!");
            return;
        }
        Console.Write("Masukkan Nama Baru :");
        mhs.NAMA = Console.ReadLine();

        Console.Write("Masukkan Jurusan Baru :");
        mhs.Jurusan = Console.ReadLine();

        Console.WriteLine("Data Telah Diupdate!");
    }

    static void HapusMahasiswa()
    {
        Console.Write("Masukkan NIM yang mahasiswa yang ingin dihapus :");
        string nim = Console.ReadLine();
        var mhs = daftarMahasiswa.FirstOrDefault(m => m.NIM == nim);
        if (mhs == null)
        {
            Console.WriteLine("NIM tidak ada!");
            return;
        }

        daftarMahasiswa.Remove(mhs);
        Console.WriteLine("Data telah dihapus.");
    }
}
