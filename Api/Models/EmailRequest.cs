namespace Api.Models
{
    public class EmailRequest
    {
        [Required, EmailAddress]
        public string To { get; set; } = string.Empty;
        [EmailAddress]
        public string? Cc { get; set; }
        [Required]
        public string Subject { get; set; } = string.Empty;
        [Required, RegularExpression(@"^(<[a-zA-Z-]+(""[^""]+""|'[^']+'|[^'"">])*>)+([\s\S]+)(<\/[a-zA-Z-]+>)+$", ErrorMessage = "The body must be in HTML format.")]
        public string Body { get; set; } = string.Empty;
        public IList<Attachment>? Attachments { get; set; }
    }

    public class Attachment
    {
        [RegularExpression(@"^([^\\/:*?""<>|]*)(\.[a-zA-Z0-9]+)$", ErrorMessage = "The file name must follow the patterns and include extension.")]
        public string Name { get; set; } = string.Empty;
        [RegularExpression(@"^(?:[A-Za-z0-9+/]{4})*(?:[A-Za-z0-9+/]{2}==|[A-Za-z0-9+/]{3}=)?$", ErrorMessage = "Insert only base64 code.")]
        public string Base64 { get; set; } = string.Empty;
    }
}
