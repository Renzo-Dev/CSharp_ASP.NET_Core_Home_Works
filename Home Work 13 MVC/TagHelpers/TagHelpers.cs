using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Home_Work_13_MVC.TagHelpers;

// CustomButtonTagHelper: Tag-хелпер для создания настраиваемой кнопки.
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

// AlertTagHelper: Tag-хелпер для вывода оповещения.
public class AlertTagHelper : TagHelper
{
    public string Message { get; set; }
    public string CssClass { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.SetAttribute("class", $"alert {CssClass}");
        output.Content.SetHtmlContent(Message);
    }
}

// DateInputTagHelper: Tag-хелпер для ввода даты
public class DateInputTagHelper : TagHelper
{
    public string Label { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Content.SetHtmlContent($"<label>{Label}</label><input type='date' />");
    }
}

//    FontAwesomeIconTagHelper: Tag-хелпер для вставки значка Font Awesome
public class FontAwesomeIconTagHelper : TagHelper
{
    public string IconClass { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "i";
        output.Attributes.SetAttribute("class", $"fa {IconClass}");
    }
}

// ImageTagHelper: Tag-хелпер для вставки изображения
public class ImageTagHelper : TagHelper
{
    public string Src { get; set; }
    public string Alt { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "img";
        output.Attributes.SetAttribute("src", Src);
        output.Attributes.SetAttribute("alt", Alt);
    }
}