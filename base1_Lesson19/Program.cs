using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace base1_Lesson19
{
    class comphardware
    {
        public int code { get; set; }
        public string namebrand { get; set; }
        public string typeproc { get; set; }
        public int freqproc { get; set; }
        public int memval { get; set; }
        public int hddval { get; set; }
        public int videomemval { get; set; }
        public double price { get; set; }
        public int quant { get; set; }

    }

    static class Program
    {
        static void Main(string[] args)
        {
            List<comphardware> comphardwares = new List<comphardware>()
            {
                new comphardware() { code = 1, namebrand = "MSI", typeproc = "Core i3", freqproc = 3400, memval = 4, hddval = 2000, videomemval = 2, price = 25000, quant = 1 },
                new comphardware() { code = 2, namebrand = "GYGABYTE", typeproc = "Core i5", freqproc = 2600, memval = 8, hddval = 1000, videomemval = 4, price = 35000, quant = 30 },
                new comphardware() { code = 3, namebrand = "ASROCK", typeproc = "Core i5", freqproc = 3200, memval = 4, hddval = 1000, videomemval = 4, price = 32000, quant = 3 },
                new comphardware() { code = 4, namebrand = "ASUS", typeproc = "Core i7", freqproc = 1800, memval = 4, hddval = 2000, videomemval = 2, price = 32000, quant = 2 },
                new comphardware() { code = 5, namebrand = "ASUS", typeproc = "Core i9", freqproc = 3400, memval = 8, hddval = 2000, videomemval = 2, price = 37000, quant = 1 },
                new comphardware() { code = 6, namebrand = "GYGABYTE", typeproc = "Core i7", freqproc = 3700, memval = 4, hddval = 1000, videomemval = 2, price = 35000, quant = 3 },
                new comphardware() { code = 7, namebrand = "MSI", typeproc = "Core i7", freqproc = 3200, memval = 8, hddval = 2000, videomemval = 2, price = 33000, quant = 2 },
                new comphardware() { code = 8, namebrand = "MSI", typeproc = "Core i9", freqproc = 3700, memval = 16, hddval = 2000, videomemval = 4, price = 42000, quant = 1 }
            };

            Console.WriteLine("**************Выборка по типу ЦП**********************");
            Console.Write(" Введите запрос по типу ЦП (модель процессора INTEL): ");
            string mytypeproc = Console.ReadLine();
            IEnumerable<comphardware> myproc = from s in comphardwares
                                               where s.typeproc == mytypeproc
                                               select s;
            foreach (comphardware s in myproc)
            {
                Console.WriteLine($"код ={s.code}  тип ЦП ={s.typeproc} цена руб. ={s.price} количество шт. ={s.quant}");
            }

            Console.WriteLine("**************Выборка по объему ОЗУ*******************");
            Console.Write(" Введите запрос по объему ОЗУ в Гб (не ниже, чем): ");
            int mymemval = Convert.ToInt32(Console.ReadLine());
            IEnumerable<comphardware> mymem = from s in comphardwares
                                              where s.memval >= mymemval
                                              select s;
            foreach (comphardware s in mymem)
            {
                Console.WriteLine($"код ={s.code} объем ОЗУ Гб ={s.memval} цена руб. ={s.price} количество шт. ={s.quant}");
            }
            Console.ReadKey();

            Console.WriteLine("**************Сортировка по цене**********************");
            var comphardwares1 = comphardwares
                                  .OrderBy(s => s.price)
                                  .ToList();
            
            foreach (comphardware s in comphardwares1)
            {
                Console.WriteLine($"код {s.code} {s.namebrand} ЦП {s.typeproc} {s.freqproc}МГц ОЗУ {s.memval}Гб HDD {s.hddval}Гб  видео {s.videomemval}Гб цена {s.price}руб. {s.quant}шт.");
            }
            Console.ReadKey();

            Console.WriteLine("**************Сортировка по типу ЦП*******************");

            var comphardwares5 = comphardwares
                                    .OrderBy( s => s.typeproc)
                                    .Select(s => s);
            foreach (var s in comphardwares5)
            {
                Console.WriteLine($"код {s.code} {s.namebrand} ЦП {s.typeproc} {s.freqproc}МГц ОЗУ {s.memval}Гб HDD {s.hddval}Гб  видео {s.videomemval}Гб цена {s.price}руб. {s.quant}шт.");
            }
            Console.ReadKey();

            Console.WriteLine("**************Самый дорогой комп**********************");

            var comphardwares2 = comphardwares
                                    .GroupBy(s => s.price)
                                    .OrderByDescending(grp => grp.Key)
                                    .First()
                                    .Select(s => s);
              
            foreach (var s in comphardwares2)
            {
            Console.WriteLine($"код {s.code} {s.namebrand} ЦП {s.typeproc} {s.freqproc}МГц ОЗУ {s.memval}Гб HDD {s.hddval}Гб  видео {s.videomemval}Гб цена {s.price}руб. {s.quant}шт.");
            }
            Console.ReadKey();

            Console.WriteLine("**************Самый бюджетный комп********************");

            var comphardwares3 = comphardwares
                                    .GroupBy(s => s.price)
                                    .OrderByDescending(grp => grp.Key)
                                    .Last()
                                    .Select(s => s);

            foreach (var s in comphardwares3)
            {
                Console.WriteLine($"код {s.code} {s.namebrand} ЦП {s.typeproc} {s.freqproc}МГц ОЗУ {s.memval}Гб HDD {s.hddval}Гб  видео {s.videomemval}Гб цена {s.price}руб. {s.quant}шт.");
            }
            Console.ReadKey();

            Console.WriteLine("**************Компьютер в кол-ве30 шт и более*********");
            IEnumerable<comphardware> myquant = from c in comphardwares
                                              where c.quant >= 30
                                              select c;
            foreach (comphardware c in myquant)
            {
                Console.WriteLine($"код {c.code} {c.namebrand} ЦП {c.typeproc} {c.freqproc}МГц ОЗУ {c.memval}Гб HDD {c.hddval}Гб  видео {c.videomemval}Гб цена {c.price}руб. {c.quant}шт.");
            }
            Console.ReadKey();
        }
    }
}
