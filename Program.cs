using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

Random cisla = new Random();
string nedostatek = "nemáš dost peněz na koupi tohoto vylepšení.";
int castel = 1;
int hradby = 1;
int vez = 1;
int farma = 1;
int kasarny = 1;
int domy = 1;
int den = 1;
int armada = 1 * domy * kasarny * vez * hradby;
int money = 50;
int income = 10 * farma * castel;
bool proced = true;
Console.WriteLine("Vítej v castle defendru");
Console.WriteLine("Tvůj hrad se nachází v jižních čechách, jsi jeho první správce.");
Console.WriteLine("pravidla hry: Tvým úkolem je bránit svůj hrad, na ten ti budou útočit nejen banditi ale i lordi z německých zemí, pokud s nimi bude království české ve válce. K dispozici máš níže zmíněné budovy ty budeš muset vylepšovat co každá dělá se dozvíš také níže" +
    "hra je rozdělena na dny každý den můžeš udělat jen jednu činnost. Max úroveň všech staveb je 10 a hra konci na 200 dnu");
while (proced)
{
    int priceHradby = 25 * hradby;
    int priceVez = 25 * vez;
    int priceFarma = 25 * farma;
    int priceKasarny = 25 * kasarny;
    int priceDomy = 25 * domy;
    int priceCastel = 25 * castel;
    int banditi = 1 * den / 2;
    money += income;
    int attack = cisla.Next(10, 200);
    Console.WriteLine($"den {den}.");
    Console.WriteLine($"Tvůj hradní areál obsahuje: castel level {castel}, hradby level {hradby}, strážní věž level {vez}, farmy level {farma}, kasarny level {kasarny}, domy level {domy}. V pokladne máš {money} goldů a každý den ti přibude {income} goldů. Tvá boje schopnost je {armada}");
    if (den == 1)
    {
        Console.WriteLine("Castel - jeho level násobí tvůj příjem. Hradby - jejich level násobí tvou obrany schopnost. Vez - její level násobí tvou obrany schopnost. Farma - její level násobí tvůj příjem " +
            "kasárny - jejich level násobí tvou obrany schopnost. Domy - jejich level násobí tvou obrany schopnost.");
    }
    if (den != 200)
    {
        bool proced2 = true;
        Console.WriteLine("Co si přeješ vylepšit");
        Console.WriteLine($"Hradby stojí {priceHradby} goldů. vez stojí {priceVez} goldů, farma stojí {priceFarma} goldů, kasarny stojí {priceKasarny} goldů a domy stojí {priceDomy} goldů");
        Console.WriteLine($"k dispozici máš {money} goldů.");
        while (proced2)
        {
            Console.WriteLine("napis: nazev budovy pro jeji vylepseni, help pro zobrazeni napovedy, nebo skip pro preskoceni dne.");
            string odpoved = Console.ReadLine();
            if (odpoved == "hradby")
            {
                if (money < priceHradby)
                {
                    Console.WriteLine(nedostatek);
                }
                else
                {
                    hradby++;
                    Console.WriteLine($"Vylepšil jsi {odpoved} na úroveň {hradby}");
                    armada = 1 * domy * kasarny * hradby * vez;
                    Console.WriteLine("konec dne");
                    proced2 = false;
                    money -= priceHradby;
                }
                
                
            }
            else if (odpoved == "castel")
            {
                if (money < priceCastel)
                {
                    Console.WriteLine(nedostatek);
                }
                else
                {
                     castel++;
                    Console.WriteLine($"Vylepšil jsi {odpoved} na úroveň {castel}");
                    Console.WriteLine("konec dne");
                    income = 10 * castel * farma;
                    proced2 = false;
                    money -= priceCastel;
                }
            }
            else if (odpoved == "vez")
            {
                if (money < priceVez)
                {
                    Console.WriteLine(nedostatek);
                }
                else
                {
                    vez++;
                    Console.WriteLine($"Vylepšil jsi {odpoved} na úroveň {vez}");
                    Console.WriteLine("konec dne");
                    armada = 1 * domy * kasarny * hradby * vez;
                    proced2 = false;
                    money -= priceVez;
                }
                
            }
            else if (odpoved == "farma")
            {
                if (money < priceFarma)
                {
                    Console.WriteLine(nedostatek);
                }
                else
                {
                    farma++;
                    Console.WriteLine($"Vylepšil jsi {odpoved} na úroveň {farma}");
                    Console.WriteLine("konec dne");
                    income = 10 * castel * farma;
                    proced2 = false;
                    money -= priceFarma;
                }
                
            }
            else if (odpoved == "kasarny")
            {
                if (money < priceKasarny)
                {
                    Console.WriteLine(nedostatek);
                }
                else
                {
                    kasarny++;
                    Console.WriteLine($"Vylepšil jsi {odpoved} na úroveň {kasarny}");
                    Console.WriteLine("konec dne");
                    armada = domy * kasarny * hradby * vez;
                    proced2 = false;
                    money -= priceKasarny;
                }
               
            }
            else if (odpoved == "domy")
            {
                if (money < priceDomy)
                {
                    Console.WriteLine(nedostatek);
                }
                else
                {
                    domy++;
                    Console.WriteLine($"Vylepšil jsi {odpoved} na úroveň {domy}");
                    Console.WriteLine();
                    armada = 1 * domy * hradby * vez * kasarny;
                    proced2 = false; 
                    money -= priceDomy;
                }
                
            }
            else if (odpoved == "help")
            {
                Console.WriteLine("Castel - jeho level násobí tvůj příjem. Hradby - jejich level násobí tvou obrany schopnost. Vez - její level násobí tvou obrany schopnost. Farma - její level násobí tvůj příjem " +
            "kasárny - jejich level násobí tvou obrany schopnost. Domy - jejich level násobí tvou obrany schopnost.");
            }
            else if (odpoved == "skip")
            {
                Console.WriteLine("rozhodl jsi se přeskočit den.");
                proced2 = false;
            }
        }
        if (den == attack)
        {
            Console.WriteLine($"Na hrad útočí tlupa banditů jejich boje schopnost je {banditi}, tvá bohje schopnost je {armada}");
            if (armada < banditi)
            {
                Console.WriteLine("Bohužel prohráváš na tovu armádu je jich příliš mnoho, ale máš šanci utéct. Chceš utéct");
                string odpoved = Console.ReadLine();
                if (odpoved == "ne")
                {
                    Console.WriteLine("hrdině jsi bojoval až dokonce a padl jsi v bitvě po boku svých vojáků");
                    Console.WriteLine($"přežil jsi {den} dní");
                    Console.WriteLine("Game Over");
                    break;
                }
                if (odpoved != "ne")
                {
                    int nahoda = cisla.Next(1, 6);
                    if (nahoda == 3)
                    {
                        Console.WriteLine("ujíždíš na koni nicméně baditi po tobě začnou střílet z luku, jeden šíp tě trefí přímo do krku a ty umíráš");
                        Console.WriteLine($"přežil jsi {den} dní");
                        Console.WriteLine("Game Over");
                        break;
                    }
                    else if (nahoda == 4)
                    {
                        Console.WriteLine("Utíkáš tajnou chodbou pod hradem nicméně když vylezeš zadrží tě královské stráž a za zbabělost jsi odsouzen k trestu smrti");
                        Console.WriteLine($"přežil jsi {den} dní");
                        Console.WriteLine("Game Over");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("podařilo se ti utéct, když jsi se vrátil na hrad byl celý vypleněný");
                        Console.WriteLine("banditi ukradly veškeré peníze, a levely tvých budov jsou nižší o jeden");
                        castel --;
                        hradby --;
                        vez --;
                        farma --;
                        kasarny --;
                        domy --;
                        money = 0;
                    }
                }
            }
            else
            {
                Console.WriteLine($"banditi sice odvážně zaútočí, ale tvé armádě nesahají ani po kotníky. Banditi byly poraženi a jako válečnou kořist si získak {den} goldů");
                money += den;
            }
        }
        if (den == 200)
        {
            break;
        }

        den++;
    }
}