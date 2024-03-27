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

        // GET api/<TransactionsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<TransactionsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<TransactionsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<TransactionsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        [HttpGet("GetTransactions")]
        public IEnumerable<Transaction> GetTransactions(int? numberOfRecords)
        {
            return GenerateSampleData(numberOfRecords);
        }

        public List<Transaction> GenerateSampleData(int? numberOfRecords = 20)
        {
            var random = new Random();
            var sampleData = new List<Transaction>();

            for (int i = 0; i < numberOfRecords; i++)
            {
                var transaction = new Transaction(
                    Guid.NewGuid().ToString().Substring(0, 8), // Shortened for readability
                    (decimal)(random.NextDouble() * 10000), // Random amount between 0 and 10000
                    random.Next(2) == 0 ? "Credit" : "Debit", // Randomly selects "Credit" or "Debit"
                    random.Next(2) == 0 ? "Pending" : "Completed" // Randomly selects "Pending" or "Completed"
                );

                sampleData.Add(transaction);
            }

            return sampleData;
        }


        public record Transaction(string ReferenceNumber, decimal Amount, string Type, string Status);

    }
}
