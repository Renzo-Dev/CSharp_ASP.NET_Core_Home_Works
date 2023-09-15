using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Home_Work_13_MVC.TagHelpers;

// CurrentDateTagHelper для отображения текущей даты
[HtmlTargetElement("current-date")]
public class CurrentDateTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "span";
        output.Content.SetContent(DateTime.Now.ToShortDateString());
    }
}

// YouTubeVideoTagHelper для вставки YouTube видео
[HtmlTargetElement("youtube-video")]
public class YouTubeVideoTagHelper : TagHelper
{
    public string VideoId { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "iframe";
        output.Attributes.SetAttribute("src", $"https://www.youtube.com/embed/{VideoId}");
        output.Attributes.SetAttribute("allowfullscreen", "true");
    }
}

// CodeBlockTagHelper для форматирования текста как код
[HtmlTargetElement("code-block")]
public class CodeBlockTagHelper : TagHelper
{
    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "pre";
        output.Content.SetHtmlContent($"<code>{output.GetChildContentAsync().Result.GetContent()}</code>");
    }
}

// ColorTagHelper: Этот TagHelper позволит вам установить цвет текста
[HtmlTargetElement("color")]
public class ColorTagHelper : TagHelper
{
    public string TextColor { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.Attributes.Add("style", $"color: {TextColor}");
    }
}

// CustomButtonTagHelper для создания кастомной кнопки
[HtmlTargetElement("custom-button")]
public class CustomButtonTagHelper : TagHelper
{
    public string Text { get; set; }
    public string CssClass { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "button";
        output.Attributes.SetAttribute("class", CssClass);
        output.Content.SetContent(Text);
    }
}

// RandomNumberTagHelper для вывода рандомного значения от мин до макс.
[HtmlTargetElement("random-number")]
public class RandomNumberTagHelper : TagHelper
{
    public int Min { get; set; }
    public int Max { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        var random = new Random();
        var randomNumber = random.Next(Min, Max + 1);
        output.Content.SetContent(randomNumber.ToString());
    }
}