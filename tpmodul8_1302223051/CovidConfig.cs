using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace tpmodul8_1302223051
{
    public class ConfigData
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public ConfigData() { }

        public ConfigData(string satuan_suhu, int batas_hari_demam, string pesan_ditolak, string pesan_diterima)
        {
            this.satuan_suhu = satuan_suhu;
            this.batas_hari_demam = batas_hari_demam;
            this.pesan_ditolak = pesan_ditolak;
            this.pesan_diterima = pesan_diterima;
        }
    }

    public class CovidConfig
    {
        public ConfigData config { get; set; }
        public string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        public string configFileName = "covid_config.json";
        public CovidConfig()
        {
            try
            {
                readConfig();
            }
            catch
            {
                setDefault();
                writeConfig();
            }
        }
        private ConfigData readConfig()
        {
            string jsonFromFile = File.ReadAllText(path + '/' + configFileName);
            config = JsonSerializer.Deserialize<ConfigData>(jsonFromFile);
            return config;
        }

        private void writeConfig()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            String jsonString = JsonSerializer.Serialize(config, options);
            string fullPath = path + '/' + configFileName;
            File.WriteAllText(fullPath, jsonString);
        }

        public void setDefault()
        {
            config = new ConfigData("celcius", 14, "Anda tidak diperbolehkan masuk ke dalam gedung ini", "Anda dipersilahkan untuk masuk ke dalam gedung ini");
        }
        public void ubahSatuan()
        {
            config.satuan_suhu = config.satuan_suhu == "celcius" ? "fahrenheit" : "celcius";
        }
        public bool cekKondisi(double suhu)
        {
            if (config.satuan_suhu == "celcius")
            {
                if (suhu < 36.5 || suhu > 37.5)
                {
                    return false;
                }
            }
            else if (config.satuan_suhu == "fahrenheit")
            {
                if (suhu < 97.7 || suhu > 99.5)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
