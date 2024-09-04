using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;
using WebApi_HomeWork_2.Dtos;

namespace WebApi_HomeWork_2.Formatters.Inputs
{
    public class TextCsvInputFormatter : TextInputFormatter
    {
        public TextCsvInputFormatter()
        {
            SupportedMediaTypes.Add("text/csv");
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context, Encoding encoding)
        {
            var request = context.HttpContext.Request;

            using var reader = new StreamReader(request.Body, encoding);
            var content = await reader.ReadToEndAsync();

            var values = content.Split('-','\n');
           

            try
            {
                var personDto = new PersonDto
                {
                    Id = int.Parse(values[5]),
                    Fullname = values[6],
                    SeriaNo = values[7],
                    Age = int.Parse(values[8]),
                    Score = double.Parse(values[9])
                };

                Console.WriteLine($"Id: {personDto.Id}, Fullname: {personDto.Fullname}, SeriaNo: {personDto.SeriaNo}, Age: {personDto.Age}, Score: {personDto.Score}");

                return await InputFormatterResult.SuccessAsync(personDto);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error parsing CSV: {ex.Message}");
                return await InputFormatterResult.FailureAsync();
            }
        }
    }
}
