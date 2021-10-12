using System;

namespace Inheritancee2
{
    public class KomisiTambahanPegawai
    {
        public string NamaDepan { get; }
        public string NamaBelakang { get; }
        public string NomorKTP { get; }
        private decimal penjualanKotor;
        private decimal tingkatKomisi;
        private decimal gajiPokok;

        public KomisiTambahanPegawai(string namaDepan, string namaBelakang, string nomorKTP, decimal penjualanKotor, decimal tingkatKomisi, decimal gajiPokok)
        {
            NamaDepan = namaDepan;
            NamaBelakang = namaBelakang;
            NomorKTP = nomorKTP;
            PenjualanKotor = penjualanKotor;
            TingkatKomisi = tingkatKomisi;
            GajiPokok = gajiPokok;
        }
        public decimal PenjualanKotor
        {
            get
            {
                return penjualanKotor;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(PenjualanKotor)} harus >= 0");
                }
                penjualanKotor = value;
            }
        }
        public decimal TingkatKomisi
        {
            get
            {
                return tingkatKomisi;
            }
            set
            {
                if (value <= 0 || value >= 1)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(TingkatKomisi)} harus > 0 dan < 1");
                }
                tingkatKomisi = value;
            }
        }

        public decimal GajiPokok
        {
            get
            {
                return gajiPokok;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(GajiPokok)}");
                }
                gajiPokok = value;
            }
        }

        public decimal Pendapatan() => gajiPokok + (tingkatKomisi * penjualanKotor);

        public override string ToString() =>
            $" Gaji pokok komisi karyawan: {NamaDepan} {NamaBelakang}\n" +
            $" Nomor KTP: {NomorKTP}\n" +
            $" Penjualan kotor: {penjualanKotor:C}\n" +
            $" Pingkat komisi: {tingkatKomisi:F2}\n" +
            $" Gaji pokok: {gajiPokok:C}";
    }
    class TesKomisiKaryawanDasarPlus
    {
        static void Main()
        {
            var karyawan = new KomisiTambahanPegawai("Bob", "Lewis", "333-33-3333", 5000.00M, .04M, 300.00M);

            Console.WriteLine(" Informasi Karyawan diperoleh dengan properti dan metode: \n");
            Console.WriteLine($" Nama depan: {karyawan.NamaDepan}");
            Console.WriteLine($" Nama belakang: {karyawan.NamaBelakang}");
            Console.WriteLine($" Nomor KTP: {karyawan.NomorKTP}");
            Console.WriteLine($" Penjualan kotor: {karyawan.PenjualanKotor:C}");
            Console.WriteLine($" Tingkat komisi: {karyawan.TingkatKomisi:F2}");
            Console.WriteLine($" Pendapatan: {karyawan.Pendapatan():C}");
            Console.WriteLine($" Gaji Pokok: {karyawan.GajiPokok:C}");

            karyawan.GajiPokok = 1000.00M;
            Console.WriteLine("\n Perbarui informasi karyawan yang diperoleh dari ToString:\n");
            Console.WriteLine(karyawan);
            Console.WriteLine($" Pendapatan: {karyawan.Pendapatan():C}");
        }
    }
}