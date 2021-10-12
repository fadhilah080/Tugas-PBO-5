using System;
using System.Collections.Generic;
using System.Text;


public class KomisiPegawai : Object
{
    public String NamaDepan { get; }
    public String NamaBelakang { get; }
    public String NomorKTP { get; }
    private decimal penjualanKotor;
    private decimal komisi;

    public KomisiPegawai(string namaDepan, string namaBelakang, string ktp, decimal penjualankotor, decimal Komisi)
    {
        NamaDepan = namaDepan;
        NamaBelakang = namaBelakang;
        NomorKTP = ktp;
        penjualanKotor = penjualankotor;
        komisi = Komisi;
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
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(penjualanKotor)} harus >= 0");
            }
            penjualanKotor = value;
        }
    }

    public decimal Komisi
    {
        get
        {
            return komisi;
        }
        set
        {
            if (value <= 0 || value >= 1)
            {
                throw new ArgumentOutOfRangeException(nameof(value), value, $"{nameof(komisi)} harus > 0 dan < 1");
            }
            komisi = value;
        }
    }

    public decimal Pendapatan() => komisi * penjualanKotor;

    public override string ToString() => $"Komisi Pegawai : {NamaDepan} {NamaBelakang}\n" + $"Nomor KTP : {NomorKTP}\n" + $"Penjualan Kotor : {penjualanKotor:C}\n" + $"Komisi : {komisi:F2}";

    static void Main()
    {
        var pegawai = new KomisiPegawai("Sue", "Jones", "222-22-2222", 10000.00M, .06M);

        Console.WriteLine("Informasi karyawan diperoleh dengan properti dan metode: \n");
        Console.WriteLine($"Nama depan adalah {pegawai.NamaDepan}");
        Console.WriteLine($"Nama belakang adalah {pegawai.NamaBelakang}");
        Console.WriteLine($"Nomor KTP adalah {pegawai.NomorKTP}");
        Console.WriteLine($"Penjualan kotor sebesar {pegawai.penjualanKotor:C}");
        Console.WriteLine($"Komisi sebesar {pegawai.komisi:F2}");
        Console.WriteLine($"Pendapatan sebesar {pegawai.Pendapatan():C}");

        pegawai.penjualanKotor = 5000.00M;
        pegawai.komisi = .1M;

        Console.WriteLine("\n Informasi pegawai yang diperbarui diperoleh oleh ToString:\n");
        Console.WriteLine(pegawai);
        Console.WriteLine($"Pendapatan : {pegawai.Pendapatan():C}");
    }


}