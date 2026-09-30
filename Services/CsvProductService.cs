using System.Globalization;
using CsvStoreApi.Configuration;
using CsvStoreApi.Models;
using Microsoft.Extensions.Options;
namespace CsvStoreApi.Services
{
    public class CsvProductService : IProductService
    {
        private readonly CsvSettings _settings;
        private readonly ILogger<CsvProductService> _logger;

        public CsvProductService(IOptions<CsvSettings> options, ILogger<CsvProductService> logger)
        {
            _settings = options.Value;
            _logger = logger;
        }

        public async Task<IReadOnlyList<Product>> GetAllAsync()
        {
            var products = new List<Product>();

            if (!File.Exists(_settings.ProductCsvPath))
            {
                _logger.LogError("CSV file not found at path: {Path}", _settings.ProductCsvPath);
                return products;
            }

            using var stream = new FileStream(_settings.ProductCsvPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new StreamReader(stream);

            // Skip header
            await reader.ReadLineAsync();

            string? line;
            while ((line = await reader.ReadLineAsync()) != null)
            {
                var product = ParseLine(line);
                if (product != null)
                    products.Add(product);
            }

            return products;
        }

        private Product? ParseLine(string line)
        {
            var parts = line.Split(',');

            if (parts.Length != 3)
            {
                _logger.LogWarning("Invalid CSV line: {Line}", line);
                return null;
            }

            if (!int.TryParse(parts[0], out var id))
                return null;

            var name = parts[1].Trim();

            if (!decimal.TryParse(parts[2], NumberStyles.Number, CultureInfo.InvariantCulture, out var price))
                return null;

            return new Product
            {
                Id = id,
                Name = name,
                Price = price
            };
        }
    }
}
