using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoreInfraHQ
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        // GET: api/<TransactionsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }


        [HttpGet("GetTransactions")]
        public IEnumerable<Transaction> GetTransactions(int? numberOfRecords)
        {
            return GenerateSampleData(numberOfRecords);
        }

        public List<Transaction> GenerateSampleData(int? numberOfRecords)
        {
            var random = new Random();
            var sampleData = new List<Transaction>();

            int recordCount = numberOfRecords ?? 20;


            for (int i = 0; i < recordCount; i++)
            {
                var transaction = new Transaction(
                    Guid.NewGuid().ToString().Substring(0, 8), 
                    $"NGN{((decimal)(random.NextDouble() * 800000)):N2}", 
                    random.Next(2) == 0 ? "Income" : "Outcome", 
                    random.Next(2) == 0 ? "Approved" : "Failed" 
                );

                sampleData.Add(transaction);
            }

            return sampleData;
        }


        public record Transaction(string ReferenceNumber, string Amount, string Type, string Status);

    }
}
