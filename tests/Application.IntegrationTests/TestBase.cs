using System.Threading.Tasks;
using NUnit.Framework;

namespace Application.IntegrationTests
{
    using static SetUp;

    public class TestBase
    {
        [SetUp]
        public async Task TestSetUp()
        {
            await ResetState();
        }
    }
}
