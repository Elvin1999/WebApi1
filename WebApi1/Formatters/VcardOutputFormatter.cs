
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using WebApi1.Models;

namespace WebApi1.Formatters
{
    public class VcardOutputFormatter : TextOutputFormatter
    {
        public VcardOutputFormatter()
        {
            SupportedMediaTypes.Add(Microsoft.Net.Http.Headers.MediaTypeHeaderValue.Parse("text/vcard"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }
        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            var response = context.HttpContext.Response;
            var sb = new StringBuilder();
            if(context.Object is List<ContactModel>)
            {
                foreach(var contact in context.Object as List<ContactModel>)
                {
                    FormatVcard(sb, contact);
                }
            }
            else
            {
                var contact=context.Object as ContactModel;
                FormatVcard(sb, contact);
            }

            return response.WriteAsync(sb.ToString());
        }
        private static void FormatVcard(StringBuilder sb,ContactModel model)
        {
            sb.AppendLine("BEGIN:VCARD");
            sb.AppendLine("VERSION:2.1");
            sb.AppendLine($"N:{model.LastName};{model.FirstName}");
            sb.AppendLine($"FN:{model.FirstName};{model.LastName}");
            sb.AppendLine($"UID:{model.Id}\r\n");
            sb.AppendLine("END:VCARD");
        }

        protected override bool CanWriteType(Type? type)
        {
            if(typeof(ContactModel).IsAssignableFrom(type) || typeof(List<ContactModel>).IsAssignableFrom(type))
            {
                return base.CanWriteType(type);
            }
            return false;
        }
    }
}
