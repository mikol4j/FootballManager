using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task Test()
        {
            true.ShouldBeEquivalentTo(true);
        }
    }
}
