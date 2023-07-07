using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Bank
{

    class At
    {
        public int id { get; set; }
        public string Ad { get; set; }
        public int Hiz { get; set; }
        public int Pozisyon { get; set; }
        public Random Rastgele { get; set; }

        public At(string ad, int id)
        {
            Ad = ad;
            Hiz = 0;
            Pozisyon = 0;
            Rastgele = new Random();
            this.id = id;
        }

        public void Kos()
        {
            Hiz = Rastgele.Next(1, 5);
            Pozisyon += Hiz;
        }
    }
    class Program
    {
        public static double mevcutBakiye = 15000;
        public static int mevcutBorc = 0;
        public static List<string> kullaniciVarliklari = new List<string>();
        public static string[] arabaIsimleri = { "BMW I8", "Mercedes - Benz CLA200", "Audi RS6 C6" };
        public static List<double> arabaFiyatlari = new List<double> { 100000, 150000, 120000 };
        public static string[] evIsimleri = { "Los Santos Beach House", "Gece Kondu", "Apartman Dairesi" };
        public static List<double> evFiyatlari = new List<double> { 100000, 5000, 50000 };

        static void Main(string[] args)
        {
            sifreGirisEkrani();

            // Arabaların ve evlerin fiyatlarını güncellemek için bir döngü oluştur
            while (true)
            {
                // Arabaların fiyatlarını %2 artır
                for (int i = 0; i < arabaFiyatlari.Count; i++)
                {
                    arabaFiyatlari[i] *= 1.02;
                }

                // Evlerin fiyatlarını %2 artır
                for (int i = 0; i < evFiyatlari.Count; i++)
                {
                    evFiyatlari[i] *= 1.02;
                }

                // 1 dakika beklet
                Thread.Sleep(60000);
            }
        }
        public static void sifreGirisEkrani()
        {
            Console.WriteLine("Şifre Girin");
            int sifre = 3435;
            int sifreGiris = int.Parse(Console.ReadLine());

            if (sifreGiris == sifre)
            {
                Console.WriteLine("Hoş Geldiniz, Ahmet Bey \n");

                hesapSecim();
            }

            else
            {
                Console.WriteLine("Şifre Yanlış. Tekrar Deneyin.");
                sifreGirisEkrani();
            }
        }
        public static void anaMenu()
        {
            Console.Write(" —Kişisel Hesap ANA MENU —-: \n 1 - Bakiye Sorgulama \n 2 - Borç Sorgulama \n 3 - Borç Ödeme \n 4 - Kredi Çekme \n 5 - Yatırım Hesabı \n 6 - Varlıklarım \n 7 - Çıkış \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    bakiyeSorgulama();
                    break;

                case 2:
                    borcSorgulama();
                    break;

                case 3:
                    borcOdeme();
                    break;
                case 4:
                    krediCekme();
                    break;
                case 5:
                    yatirimHesabi();
                    break;
                case 6:
                    varliklarim();
                    break;
                case 7:
                    Environment.Exit(0); ;
                    break;

                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    anaMenu();
                    break;
            }
        }
        public static void bakiyeSorgulama()
        {
            Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye}");

            Console.Write(" 1 - Ana Menü \n 2 - Çıkış \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    anaMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    anaMenu();
                    break;
            }

        }
        public static void borcSorgulama()
        {
            Console.WriteLine($"Güncel Borcunuz: {mevcutBorc}");

            Console.Write(" 1 - Ana Menü \n 2 - Çıkış \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    anaMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    anaMenu();
                    break;
            }
        }
        public static void krediCekme()
        {
            Console.WriteLine($"Kredi çekebileceğiz miktar: {mevcutBakiye * 3}");
            Console.WriteLine("Ne kadar kredi çekmek istiyorsunuz?");
            int krediMiktari = int.Parse(Console.ReadLine());

            if (krediMiktari > 1000 && krediMiktari <= mevcutBakiye * 3)
            {
                Console.WriteLine("Krediniz Başarıyla Çekilmiştir.");
                mevcutBakiye += krediMiktari;

                // Borcu rastgele bir sayı ile yüzdeli olarak oluştur
                Random rnd = new Random();
                double yuzde = rnd.Next(1, 11) / 100.0; // Rastgele yüzde (1% - 10%)
                double borcMiktari = krediMiktari * yuzde;

                mevcutBorc += (krediMiktari + (int)borcMiktari);
                Console.WriteLine($"Güncel Borç: {mevcutBorc}");
            }
            else
            {
                Console.WriteLine("Talebiniz Şartlarımıza uymamaktadadır. Lütfen Tekrar deneyin.");
                krediCekme();
                return;
            }

            Console.Write(" 1 - Ana Menü \n 2 - Çıkış \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    anaMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    anaMenu();
                    break;
            }
        }

        public static void borcOdeme()
        {
            Console.WriteLine($"Güncel Borç: {mevcutBorc}");
            Console.WriteLine("Ne kadar borç ödemek istiyorsunuz?");
            int odemeMiktari = int.Parse(Console.ReadLine());

            mevcutBakiye -= odemeMiktari;
            mevcutBorc -= odemeMiktari;

            if (odemeMiktari > mevcutBakiye)
            {
                Console.WriteLine("Borcunuzu ödemeye paranız yetmiyor.");
            }

            else
            {
                Console.WriteLine($"İşleminiz başarılı. \n Güncel Bakiye: {mevcutBakiye} \n Güncel Borç: {mevcutBorc}");
                anaMenu();
            }

            Console.Write(" 1 - Ana Menü \n 2 - Çıkış \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    anaMenu();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    anaMenu();
                    break;
            }
        }

        public static void yatirimHesabi()
        {
            Console.Write(" 1 - Sayisal Loto \n 2 - At Yarışı \n 3 - Borsa \n 4 - Kişisel Hesap \n 5 - Varlıklarım \n 6 - Çıkış \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    sayisalLoto();
                    break;
                case 2:
                    atYarisi();
                    break;
                case 3:
                    borsa();
                    break;
                case 4:
                    anaMenu();
                    break;
                case 5:
                    varliklarim();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    yatirimHesabi();
                    break;
            }
        }

        public static void sayisalLoto()
        {
            Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye}");
            Console.WriteLine("Ne kadar ile oynamak istiyorsunuz?");
            int oynananMiktar = int.Parse(Console.ReadLine());

            if (oynananMiktar > mevcutBakiye)
            {
                Console.WriteLine("Yeterli bakiyeniz olmadığı için bu miktarla oyun oynayamazsınız.");
                yatirimHesabi();
                return;
            }
            else
            {

                mevcutBakiye -= oynananMiktar;

                Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye}");

                Random rnd = new Random();
                int rastgeleSayi1 = rnd.Next(0, 10);
                int rastgeleSayi2 = rnd.Next(0, 10);
                int rastgeleSayi3 = rnd.Next(0, 10);
                int rastgeleSayi4 = rnd.Next(0, 10);


                Console.WriteLine("Birinci sayıyı giriniz");
                int girilenSayi1 = int.Parse(Console.ReadLine());
                Console.WriteLine("İkinci sayıyı giriniz");
                int girilenSayi2 = int.Parse(Console.ReadLine());
                Console.WriteLine("Üçüncü sayıyı giriniz");
                int girilenSayi3 = int.Parse(Console.ReadLine());
                Console.WriteLine("Dördüncü sayıyı giriniz");
                int girilenSayi4 = int.Parse(Console.ReadLine());


                if (rastgeleSayi1 == girilenSayi1 && rastgeleSayi2 == girilenSayi2 && rastgeleSayi3 == girilenSayi3 && rastgeleSayi4 == girilenSayi4)
                {
                    Console.WriteLine("Kazandınız!!");
                    int kazanilanMiktar = oynananMiktar * 2;
                    mevcutBakiye += kazanilanMiktar;
                    Console.WriteLine($"Kazandığınız için {kazanilanMiktar} TL bakiyenize eklendi \n Güncel Bakiye: {mevcutBakiye}");
                    yatirimHesabi();
                }
                else
                {
                    Console.WriteLine("Kazanamadınız");
                    yatirimHesabi();
                }
            }


        }

        public static void atYarisi()
        {
            Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye}");
            Console.WriteLine("Ne kadar ile oynamak istiyorsunuz?");
            int oynananMiktar = int.Parse(Console.ReadLine());

            if (oynananMiktar > mevcutBakiye)
            {
                Console.WriteLine("Yeterli bakiyeniz olmadığı için bu miktarla oyun oynayamazsınız.");
                yatirimHesabi();
                return;
            }
            else
            {

                Console.Write(" 1 - Bold Pilot \n 2 - Şahbatur \n 3 - Gülbatur \n");
                Console.Write("Seçtiğiniz atın adını giriniz: ");
                int secim = int.Parse(Console.ReadLine());

                List<At> atlar = new List<At>();
                atlar.Add(new At("Bold Pilot", 1));
                atlar.Add(new At("Şahbatur", 2));
                atlar.Add(new At("Gülbatur", 3));

                Console.WriteLine("At Yarışı Başladı!");

                bool yarışBitti = false;
                Console.Clear();
                while (!yarışBitti)
                {
                    Console.WriteLine("-------------------------------------");
                    foreach (var at in atlar)
                    {
                        at.Kos();
                        Console.WriteLine($"{at.Ad}: {new string('-', at.Pozisyon)}");
                        if (at.Pozisyon >= 70)
                        {
                            yarışBitti = true;
                            Console.WriteLine("-------------------------------------");
                            Console.WriteLine($"{at.Ad} yarışı kazandı!");
                            if (at.id == secim)
                            {
                                Console.WriteLine("Kazandınız");
                                int kazanilanMiktar = oynananMiktar * 2;
                                mevcutBakiye += kazanilanMiktar;
                                Console.WriteLine($"Kazandığınız için {kazanilanMiktar} TL bakiyenize eklendi \n Güncel Bakiye: {mevcutBakiye}");
                                yatirimHesabi();
                            }
                            else
                            {
                                mevcutBakiye -= oynananMiktar;
                                Console.WriteLine($"Kazanamadınız. {oynananMiktar} TL kaybettiniz. \n Güncel Bakiye: {mevcutBakiye}");
                                yatirimHesabi();
                            }
                        }
                    }
                    Thread.Sleep(500);
                    Console.Clear();
                }

                Console.WriteLine("Yarış Bitti!");
                Console.ReadLine();
            }


        }

        public static void borsa()
        {
            Console.WriteLine($"Güncel Bakiyeniz: {mevcutBakiye}");
            Console.WriteLine("Ne kadar ile yatırım yapmak istiyorsunuz?");
            int oynananMiktar = int.Parse(Console.ReadLine());

            if (oynananMiktar > mevcutBakiye)
            {
                Console.WriteLine("Yeterli bakiyeniz olmadığı için bu miktarla yatırım yapamazsınız.");
                yatirimHesabi();
                return;
            }
            else
            {

                double kazanilanMiktar;


                Random rnd = new Random();
                double appleHisse = rnd.NextDouble() * 30 + 1;
                double samsungHisse = rnd.NextDouble() * 30 + 1;
                double teslaHisse = rnd.NextDouble() * 30 + 1;

                int durum = rnd.Next(2);

                Console.WriteLine($"1 - Apple ({appleHisse}) \n 2 - Samsung ({samsungHisse}) \n 3 - Tesla ({teslaHisse})");
                Console.WriteLine("Yatırım yapmak istediğiniz şirketin adını girin: \n");
                string secim = Console.ReadLine();

                if (secim == "Apple")
                {
                    kazanilanMiktar = oynananMiktar * (appleHisse / 100);
                    if (durum == 1)
                    {
                        mevcutBakiye += kazanilanMiktar;
                        Console.WriteLine($"Kazandığınız Miktar: {kazanilanMiktar} \n Güncel Bakiye: {mevcutBakiye}");
                    }
                    else
                    {
                        mevcutBakiye -= kazanilanMiktar;
                        Console.WriteLine($"Kaybettiğiniz Miktar: {kazanilanMiktar} \n Güncel Bakiye: {mevcutBakiye}");

                    }

                    yatirimHesabi();
                }
                else if (secim == "Samsung")
                {
                    kazanilanMiktar = oynananMiktar * (samsungHisse / 100);
                    if (durum == 1)
                    {
                        mevcutBakiye += kazanilanMiktar;
                        Console.WriteLine($"Kazandığınız Miktar: {kazanilanMiktar} \n Güncel Bakiye: {mevcutBakiye}");
                    }
                    else
                    {
                        mevcutBakiye -= kazanilanMiktar;
                        Console.WriteLine($"Kaybettiğiniz Miktar: {kazanilanMiktar} \n Güncel Bakiye: {mevcutBakiye}");
                    }
                    yatirimHesabi();
                }
                else if (secim == "Tesla")
                {
                    kazanilanMiktar = oynananMiktar * (teslaHisse / 100);
                    if (durum == 1)
                    {
                        mevcutBakiye += kazanilanMiktar;
                        Console.WriteLine($"Kazandığınız Miktar: {kazanilanMiktar} \n Güncel Bakiye: {mevcutBakiye}");
                    }
                    else
                    {
                        mevcutBakiye -= kazanilanMiktar;
                        Console.WriteLine($"Kaybettiğiniz Miktar: {kazanilanMiktar} \n Güncel Bakiye: {mevcutBakiye}");
                    }
                    yatirimHesabi();
                }
                else
                {
                    Console.WriteLine("Yanlış Seçim");
                }
            }

        }
        public static void varlikSatinAlma()
        {
            Console.Write(" 1 - Arabalar \n 2 - Evler \n 3 - Sahip Olduklarım \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    arabalar();
                    break;
                case 2:
                    evler();
                    break;
                case 3:
                    varliklarim();
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    varlikSatinAlma();
                    break;
            }
        }

        public static void varlikSatisIslemleri()
        {
            for (int i = 0; i < kullaniciVarliklari.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {kullaniciVarliklari[i]}");
            }

            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            if (secim > 0 && secim <= kullaniciVarliklari.Count)
            {
                string secilenVarlik = kullaniciVarliklari[secim - 1].ToString();

                for (int i = 0; i < arabaIsimleri.Length; i++)
                {
                    if (secilenVarlik == arabaIsimleri[i])
                    {
                        mevcutBakiye += arabaFiyatlari[i];
                        kullaniciVarliklari.RemoveAt(secim - 1);
                        Console.WriteLine($"{secilenVarlik} satıldı. {arabaFiyatlari[i]} TL bakiyeye eklendi.");
                        hesapSecim();
                        return;
                    }
                }

                for (int i = 0; i < evIsimleri.Length; i++)
                {
                    if (secilenVarlik == evIsimleri[i])
                    {
                        mevcutBakiye += evFiyatlari[i];
                        kullaniciVarliklari.RemoveAt(secim - 1);
                        Console.WriteLine($"{secilenVarlik} satıldı. {evFiyatlari[i]} TL bakiyeye eklendi.");
                        hesapSecim();
                        return;
                    }
                }

                Console.WriteLine("Satış işlemi gerçekleştirilemedi. Geçerli bir seçim yapınız.");
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
            }

            hesapSecim();
        }

        public static void arabalar()
        {
            Console.WriteLine("Arabalar:");
            for (int i = 0; i < arabaIsimleri.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {arabaIsimleri[i]} ({arabaFiyatlari[i]} TL)");
            }
            Console.WriteLine("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            if (secim > 0 && secim <= arabaIsimleri.Length)
            {
                int secilenArabaIndex = secim - 1;
                int arabaFiyati = (int)arabaFiyatlari[secilenArabaIndex];

                if (arabaFiyati > mevcutBakiye)
                {
                    Console.WriteLine("Yeterli bakiyeniz olmadığı için bu arabayı satın alamazsınız.");
                    hesapSecim();
                }
                else
                {
                    mevcutBakiye -= arabaFiyati;
                    kullaniciVarliklari.Add(arabaIsimleri[secilenArabaIndex]);
                    Console.WriteLine($"Tebrikler! {arabaIsimleri[secilenArabaIndex]}'e sahip oldunuz.");
                    hesapSecim();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                arabalar();
            }
        }

        public static void evler()
        {
            Console.WriteLine("Evler:");
            for (int i = 0; i < evIsimleri.Length; i++)
            {
                Console.WriteLine($"{i + 1} - {evIsimleri[i]} ({evFiyatlari[i]} TL)");
            }
            Console.WriteLine("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            if (secim > 0 && secim <= evIsimleri.Length)
            {
                int secilenEvIndex = secim - 1;
                int evFiyati = (int)evFiyatlari[secilenEvIndex];

                if (evFiyati > mevcutBakiye)
                {
                    Console.WriteLine("Yeterli bakiyeniz olmadığı için bu evi satın alamazsınız.");
                    hesapSecim();
                }
                else
                {
                    mevcutBakiye -= evFiyati;
                    kullaniciVarliklari.Add(evIsimleri[secilenEvIndex]);
                    Console.WriteLine($"Tebrikler! {evIsimleri[secilenEvIndex]}'e sahip oldunuz.");
                    hesapSecim();
                }
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                evler();
            }
        }
        public static void varliklarim()
        {
            foreach (string yaz in kullaniciVarliklari)
            {

                Console.WriteLine(yaz);

            }

            Console.WriteLine(" 1 - Varlık Satın Alma \n 2 - Varlık Satış İşlemleri \n 3 - Varlıklarım \n 4 - Ana Menü \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    varlikSatinAlma();
                    break;
                case 2:
                    varlikSatisIslemleri();
                    break;
                case 3:
                    varliklarim();
                    break;
                case 4:
                    hesapSecim();
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    varlikSatinAlma();
                    break;
            }
        }
        public static void hesapSecim()
        {
            Console.Write(" 1 - Kişisel Hesap \n 2 - Yatırım Hesabı \n 3 - Varlıklarım \n");
            Console.Write("Seçiminizi giriniz: ");
            int secim = int.Parse(Console.ReadLine());

            switch (secim)
            {
                case 1:
                    anaMenu();
                    break;
                case 2:
                    yatirimHesabi();
                    break;
                case 3:
                    varliklarim();
                    break;
                default:
                    Console.WriteLine("Yanlış bir seçim yaptınız, lütfen geçerli bir seçim yapınız: ");
                    hesapSecim();
                    break;
            }
        }

    }
}
