using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;
using WebApi_HomeWork_2.Dtos;

namespace WebApi_HomeWork_2.Formatters.Outputs
{
    public class TextCsvOutputFormatter : TextOutputFormatter
    {
        public TextCsvOutputFormatter()
        {

            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/csv"));
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);

        }


        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {

            var response = context.HttpContext.Response;
            StringBuilder str = new StringBuilder();

            if (context.Object is IEnumerable<PersonDto> persons)
            {

                foreach (var pe in persons)
                {

                    FormatCsv(str, pe);
                }
            }
            else if (context.Object is PersonDto person)
            {
                FormatCsv(str, person);
            }


            await response.WriteAsync(str.ToString());
        }

        private void FormatCsv(StringBuilder str, PersonDto dto)
        {


            str.AppendLine($" Id - Fullname - SeriaNo - Age - Score");
            str.AppendLine($" {dto.Id} - {dto.Fullname} - {dto.SeriaNo} - {dto.Age} - {dto.Score}");
            str.AppendLine("");



        }





    }
}
