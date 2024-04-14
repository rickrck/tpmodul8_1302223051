using System.Text.Json;
using tpmodul8_1302223051;

internal class Program
{
    private static void Main()
    {
        CovidConfig config = new CovidConfig();
        Console.Write("Berapa suhu badan anda saat ini? Dalam nilai " + config.config.satuan_suhu + ": ");
        double suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = int.Parse(Console.ReadLine());

        if (config.cekKondisi(suhu))
        {
            Console.WriteLine(config.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.config.pesan_ditolak);
        }


        config.ubahSatuan();
        Console.Write("\nBerapa suhu badan anda saat ini? Dalam nilai " + config.config.satuan_suhu + ": ");
        suhu = double.Parse(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        hariDemam = int.Parse(Console.ReadLine());

        if (config.cekKondisi(suhu))
        {
            Console.WriteLine(config.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.config.pesan_ditolak);
        }
    }
}