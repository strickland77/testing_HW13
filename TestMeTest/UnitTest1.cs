namespace TestMeTest;

using FluentAssertions;
using Moq;
using AutoFixture;
using TestMe;

public class UnitTest1
{
    [Fact]
    public void f1_input_2_should_be_3()
    {
        A.f1(2).Should().Be(3);
    }

    [Fact]
    public void f1_input_3_should_be_4()
    {
        A.f1(3).Should().Be(4);
    }

    [Fact]
    public void f2_input_2_should_be_4()
    {
        A.f2(2).Should().Be(4);
    }

    [Fact]
    public void f2_input_3_should_be_5()
    {
        A.f2(3).Should().Be(5);
    }

    [Fact]
    public void funtion_that_uses_f3_input_2_should_be_5()
    {
        A.function_that_uses_f3(2).Should().Be(5);
    }

    [Fact]
    public void funtion_that_uses_f3_input_3_should_be_6()
    {
        A.function_that_uses_f3(3).Should().Be(6);
    }

    [Fact]
    public void funtion_that_uses_f4_input_2_should_be_6()
    {
        A.function_that_uses_f4(2).Should().Be(6);
    }

    [Fact]
    public void funtion_that_uses_f4_input_3_should_be_7()
    {
        A.function_that_uses_f4(3).Should().Be(7);
    }

    [Fact]
    public void f5_input_2_4_should_be_0_dot_0()
    {
        A.f5(2, 4).Should().Be(0.0);
    }

    [Fact]
    public void f5_input_4_2_should_be_2_dot_0()
    {
        A.f5(4, 2).Should().Be(2.0);
    }

    [Fact]
    public void f6_input_positive_2_should_be_7()
    {
        A.f6(2).Should().Be(7);
    }

    [Fact]
    public void f6_input_negative_2_should_throw_exception()
    {
        Action action = () => A.f6(-2);
        Exception exception = Assert.Throws<Exception>(action);

        Assert.Equal("x can't be negative", exception.Message);
    }

    [Fact]
    public void f7_input_test1_should_return_test1_more_stuff()
    {
        A.f7("test1").Should().Be("test1 more stuff");
    }

    [Fact]
    public void f7_input_test2_should_return_test2_more_stuff()
    {
        A.f7("test2").Should().Be("test2 more stuff");
    }

    [Fact]
    public void g1_return_should_be_input_plus_8()
    {
        Fixture fixture = new Fixture();
        int expectedNumber = fixture.Create<int>();

        var a = new Mock<IA>();

        a.Setup(x => x.f8(It.IsAny<int>())).Returns(expectedNumber + 8);

        var b = B.g1(expectedNumber, a.Object);

        b.Should().Be(expectedNumber + 8);
    }
}
