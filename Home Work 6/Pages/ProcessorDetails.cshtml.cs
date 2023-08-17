using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_6.Pages;

public class ProcessorDetails : PageModel
{
    public required Processor Processor;

    public void OnGet(string name)
    {
        var processors = new ProcessorStruct();
        Processor = new Processor(processors.GetProcessorDetails(name));
    }
}