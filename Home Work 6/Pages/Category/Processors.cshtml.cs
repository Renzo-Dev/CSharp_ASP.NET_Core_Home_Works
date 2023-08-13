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
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
        _Processors.Add(new Processor("AMD Ryzen 7 5800x", "AMD", 8, 16, "4.4", 8, 16, 32, "Zen 4", "6000", "Ryzen 7"));
    }

    public void OnGet()
    {
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
            "PGA988"
        };
    }
}

public class Processor
{
    public string Manufacturer = "";
    public string Model = "";

    public Processor(string model, string manufacturer, int numberCores, int numberThreads, string clockFrequency,
        int cacheMemory1, int cacheMemory2, int cacheMemory3, string architecture, string price, string processorline)
    {
        _specifications = new Specifications(numberCores, numberThreads, clockFrequency, cacheMemory1, cacheMemory2,
            cacheMemory3, architecture, price, processorline);
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
            int cacheMemory2, int cacheMemory3, string architecture, string price, string processorLine)
        {
            cacheMemory = new CacheMemory(cacheMemory1, cacheMemory2, cacheMemory3);
            NumberCores = numberCores;
            NumberThreads = numberThreads;
            ClockFrequency = clockFrequency;
            Architecture = architecture;
            Price = price;
            ProcessorLine = processorLine;
        }
    }
}