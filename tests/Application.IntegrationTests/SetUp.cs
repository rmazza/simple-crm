using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests
{
    [SetUpFixture]
    public class SetUp
    {
        [OneTimeSetUp]
        public void RunFirst()
        {

        }
    }
}
