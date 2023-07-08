using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Home_Work_1.Pages
{
    public class Task_5Model : PageModel
    {
        public string Author { get; set; }
        public string Citation { get; set; }
        struct Citations
        {
            public string Author;
            public string citation;

            public Citations(string author, string citation)
            {
                Author = author;
                this.citation = citation;
            }
        }

        public void OnGet()
        {
            List<Citations> citations = new List<Citations>();
            citations?.Add(new Citations("������� ��������", "��� ����� �������, ��� ����� �� �������� ���� �������"));
            citations?.Add(new Citations("������ ��������", "������� �� ��������� ���, ��� ������ �� ������"));
            citations?.Add(new Citations("��� ���������� �������", "����� ����� ������ ����, �������� �������� ��������"));
            citations?.Add(new Citations(" ������ ����� ����", "���� ������� �� �����, �� ��� ����� �������, �� �� �������� ����"));

            if (Request.Path == "/Task 5")
            {
                int randomId = new Random().Next(citations.Count);
                Author = citations[randomId].Author;
                Citation = citations[randomId].citation;
            }
        }
    }
}
