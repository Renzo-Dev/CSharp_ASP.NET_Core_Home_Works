using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_6.Pages.Category;

public class Processors : PageModel
{
    public List<Processor> _Processors = new();

    // в рефакторинг : ( получать данные из БД )
    public TemplateData _templateData = new();

    ///*******************************************************************************************
    public Processors()
    {
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 3", "8000", "Ryzen 7",
            "AM4"));
        _Processors.Add(
            new Processor("AMD Ryzen 5 5600x", "AMD", 6, 12, "4.6", 32, 32, 512, "Zen 3", "6000", "Ryzen 5", "AM4"));
        _Processors.Add(new Processor("Intel Core i5 12400F", "Intel", 6, 12, "4.4", 32, 32, 512, "Alder Lake", "5000",
            "i5 12 поколения", "LGA 1700"));
        _Processors.Add(new Processor("Intel Core i7 13700", "Intel", 16, 24, "5.6", 24, 24, 30, "Raptor Lake", "15000",
            "i7 13 поколения", "LGA 1700"));
        _Processors.Add(new Processor("AMD Ryzen Threadripper 3955WX", "AMD", 16, 32, "4.5", 10, 81, 64, "Threadripper",
            "32000", "Ryzen Threadripper", "sWRX8"));
        _Processors.Add(new Processor("Intel Intel Core i9-13900KS", "Intel", 24, 32, "4", 10, 24, 36, "Raptor Lake",
            "23000", "Сore i9 13 поколения", "LGA 1700"));
        _Processors.Add(new Processor("Intel Core i3-10105", "Intel", 4, 8, "4.4", 2, 4, 6, "Comet Lake", "4000",
            "Сore i3 10 поколения", "LGA 1200"));
    }

    public void OnGet()
    {
    }

    public void OnGetByName(string name)
    {
        Console.Write("WORK");
    }

public struct TemplateData
    {
        public TemplateData()
        {
        }

        public readonly List<string> ProcessorLineup = new()
        {
            "Athlon",
            "Сore i3 7 поколения",
            "Сore i3 8 поколения",
            "Сore i3 9 поколения",
            "Сore i3 10 поколения",
            "Сore i3 12 поколения",
            "Сore i5 7 поколения",
            "Сore i5 8 поколения",
            "Сore i5 9 поколения",
            "Сore i5 10 поколения",
            "Сore i5 11 поколения",
            "Сore i5 12 поколения",
            "Сore i5 13 поколения",
            "Сore i7 7 поколения",
            "Сore i7 8 поколения",
            "Сore i7 9 поколения",
            "Сore i7 10 поколения",
            "Сore i7 11 поколения",
            "Сore i7 12 поколения",
            "Сore i7 13 поколения",
            "Сore i9 9 поколения",
            "Сore i9 10 поколения",
            "Сore i9 11 поколения",
            "Сore i9 12 поколения",
            "Сore i9 13 поколения",
            "Ryzen 3",
            "Ryzen 5",
            "Ryzen 7",
            "Ryzen 9",
            "Ryzen Threadripper"
        };

        public List<string> _sockets = new()
        {
            "AM4",
            "AM5",
            "LGA 1151",
            "LGA 1151 v2",
            "LGA 1200",
            "LGA 1700",
            "Socket TRX4",
            "TR4",
            "PGA988",
            "sWRX8"
        };
    }
}

public class Processor
{
    public string Manufacturer = "";
    public string Model = "";

    public Processor(string model, string manufacturer, int numberCores, int numberThreads, string clockFrequency,
        int cacheMemory1, int cacheMemory2, int cacheMemory3, string architecture, string price, string processorline,string socket)
    {
        _specifications = new Specifications(numberCores, numberThreads, clockFrequency, cacheMemory1, cacheMemory2,
            cacheMemory3, architecture, price, processorline,socket);
        Model = model;
        Manufacturer = manufacturer;
    }

    public Specifications _specifications { get; set; }

    public struct Specifications
    {
        public int NumberCores = 0;
        public int NumberThreads = 0;
        public string ClockFrequency = "0";
        public string Architecture = "";
        public string Price = "0";
        public string ProcessorLine = "";
        public string Socket = "";
        public CacheMemory cacheMemory { get; set; }

        public struct CacheMemory
        {
            public int CacheMemory1 = 0;
            public int CacheMemory2 = 0;
            public int CacheMemory3 = 0;

            public CacheMemory(int cacheMemory1, int cacheMemory2, int cacheMemory3)
            {
                CacheMemory1 = cacheMemory1;
                CacheMemory2 = cacheMemory2;
                CacheMemory3 = cacheMemory3;
            }
        }

        public Specifications(int numberCores, int numberThreads, string clockFrequency, int cacheMemory1,
            int cacheMemory2, int cacheMemory3, string architecture, string price, string processorLine, string socket)
        {
            cacheMemory = new CacheMemory(cacheMemory1, cacheMemory2, cacheMemory3);
            NumberCores = numberCores;
            NumberThreads = numberThreads;
            ClockFrequency = clockFrequency;
            Architecture = architecture;
            Price = price;
            ProcessorLine = processorLine;
            Socket = socket;
        }
    }
}