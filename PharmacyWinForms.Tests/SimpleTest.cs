using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PharmacyWinForms.Tests;

public class SimpleTest
{
    [Fact]
    public void Test_OnePlusOne_EqualsTwo()
    {
        Assert.Equal(2, 1 + 1);
    }
}