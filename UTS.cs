using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemManajemenMahasiswa
{
    public abstract class Orang
    {
        public string Nim { get; set; }
        public string Name { get; set; }

        public abstract void DisplayInfo();
    }

    public class Mahasiswa : Orang
    {
        public string Jurusan { get; set; }

        public override void DisplayInfo()
        {
            Console.WriteLine($"Nim       : {Nim}");
            Console.WriteLine($"Nama     : {Name}");
            Console.WriteLine($"Jurusan  : {Jurusan}");
            Console.WriteLine("---------------------");
        }
    }

    public class MahasiswaManager
    {
        private List<Mahasiswa> _Mahasiswas;

        public MahasiswaManager()
        {
            _Mahasiswas = new List<Mahasiswa>();
        }

        public bool AddMahasiswa(string nim, string name, string jurusan)
        {
            if (MahasiswaExists(nim))
            {
                return false;
            }

            _Mahasiswas.Add(new Mahasiswa
            {
                Nim = nim,
                Name = name,
                Jurusan = jurusan
            });

            return true;
        }

        public List<Mahasiswa> GetAllMahasiswas()
        {
            return _Mahasiswas;
        }

        public Mahasiswa GetMahasiswaById(string nim)
        {
            return _Mahasiswas.FirstOrDefault(s => s.Nim == nim);
        }

        public bool UpdateMahasiswa(string id, string name, string jurusan)
        {
            var Mahasiswa = GetMahasiswaById(id);
            if (Mahasiswa == null)
            {
                return false;
            }

            Mahasiswa.Name = name;
            Mahasiswa.Jurusan = jurusan;
            return true;
        }

        public bool DeleteMahasiswa(string nim)
        {
            var Mahasiswa = GetMahasiswaById(nim);
            if (Mahasiswa == null)
            {
                return false;
            }

            _Mahasiswas.Remove(Mahasiswa);
            return true;
        }

        public bool MahasiswaExists(string nim)
        {
            return _Mahasiswas.Any(s => s.Nim == nim);
        }
    }

    public class UserInterface
    {
        private readonly MahasiswaManager _manager;

        public UserInterface(MahasiswaManager manager)
        {
            _manager = manager;
        }

        public void DisplayMenu()
        {
            Console.WriteLine("=== Sistem Manajemen Mahasiswa ===");
            Console.WriteLine("1. Tambah Mahasiswa");
            Console.WriteLine("2. Lihat Daftar Mahasiswa");
            Console.WriteLine("3. Perbarui Data Mahasiswa");
            Console.WriteLine("4. Hapus Data Mahasiswa");
            Console.WriteLine("5. Keluar");
            Console.Write("Pilih Menu (1-5): ");
        }

        public void HandleAddMahasiswa()
        {
            Console.Write("Masukkan NIM: ");
            string nim = Console.ReadLine();

            Console.Write("Masukkan Nama: ");
            string name = Console.ReadLine();

            Console.Write("Masukkan Jurusan: ");
            string jurusan = Console.ReadLine();

            bool success = _manager.AddMahasiswa(nim, name, jurusan);
            if (success)
            {
                Console.WriteLine("Mahasiswa berhasil ditambahkan.");
            }
            else
            {
                Console.WriteLine("NIM sudah terdaftar. Penambahan gagal.");
            }
        }

        public void HandleViewMahasiswas()
        {
            var Mahasiswas = _manager.GetAllMahasiswas();
            if (Mahasiswas.Count == 0)
            {
                Console.WriteLine("Belum ada data mahasiswa. Silahkan tambah data mahasiswa terlebih dahulu!");
                return;
            }

            Console.WriteLine("====== Daftar Mahasiswa ======");
            foreach (var Mahasiswa in Mahasiswas)
            {
                Mahasiswa.DisplayInfo();
            }
        }

        public void HandleUpdateMahasiswa()
        {
            Console.Write("Masukkan NIM mahasiswa yang ingin diperbarui: ");
            string NIM = Console.ReadLine();

            Console.Write("Masukkan Nama Baru: ");
            string name = Console.ReadLine();

            Console.Write("Masukkan Jurusan Baru: ");
            string jurusan = Console.ReadLine();

            bool success = _manager.UpdateMahasiswa(NIM, name, jurusan);
            if (success)
            {
                Console.WriteLine("Data mahasiswa berhasil diperbarui.");
            }
            else
            {
                Console.WriteLine("NIM tidak ditemukan. Pembaruan gagal.");
            }
        }

        public void HandleDeleteMahasiswa()
        {
            Console.Write("Masukkan NIM mahasiswa yang ingin dihapus: ");
            string nim = Console.ReadLine();

            bool success = _manager.DeleteMahasiswa(nim);
            if (success)
            {
                Console.WriteLine("Data mahasiswa berhasil dihapus.");
            }
            else
            {
                Console.WriteLine("NIM tidak ditemukan. Penghapusan gagal.");
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            MahasiswaManager manager = new MahasiswaManager();
            UserInterface ui = new UserInterface(manager);
            bool running = true;

            while (running)
            {
                ui.DisplayMenu();
                string choice = Console.ReadLine();

                Console.WriteLine();

                switch (choice)
                {
                    case "1":
                        ui.HandleAddMahasiswa();
                        break;
                    case "2":
                        ui.HandleViewMahasiswas();
                        break;
                    case "3":
                        ui.HandleUpdateMahasiswa();
                        break;
                    case "4":
                        ui.HandleDeleteMahasiswa();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Arigathanks Sudah Menggunakan Sistem Manajemen Mahasiswa!");
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak ada mas bro. pilih lagi ya~");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nTekan Enter untuk melanjutkan...");
                    Console.ReadLine();
                    Console.Clear();
                }
            }
        }
    }
}
