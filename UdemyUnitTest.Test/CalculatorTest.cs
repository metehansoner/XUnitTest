using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using UdemyUnitTest.APP;
using Xunit;
using Xunit.Sdk;

namespace UdemyUnitTest.Test
{
    public class CalculatorTest
    {
        public Calculator calculator { get; set; }
        public Mock<ICalculatorService> mymock { get; set; }

        public CalculatorTest()
        {
            this.mymock = new Mock<ICalculatorService>();
            this.calculator = new Calculator(mymock.Object);
        }
       [Fact]
       public void AddTest()
        {
            //Arrange 
            int a = 5;
            int b = 20;
            //Act
            var total = calculator.add(a,b);
            //Assert
            Assert.Equal<int>(25, total);
        }

        [Fact]
        public void DivideTest()
        {
            //Arrange 
            int a = 5;
            int b = 0;

            //Act
            var actual = calculator.divide(a,b);
            //Assert
            Assert.Equal("Tanımsız", actual);
        }

        [Fact]
        public void AssertContains()
        {
            //Assert.Contains("Mete","Mete Soner");
            //Assert.DoesNotContain("Emre","Mete Soner");
            //Assert.False(5<2);
            Assert.True("A".GetType()==typeof(string));
        }

        [Theory]
        [InlineData(2, 5, 7)]
        [InlineData(10, 2, 12)]
        public void AddTest2(int a,int b,int expectedTotal)
        {
            //Theory Inline Data birlikte kullanılır

            var actualTotal = calculator.add(a,b);

            Assert.Equal(expectedTotal,actualTotal);
        }

        [Theory]
        [InlineData(10,0,0)]
        [InlineData(10,2,12)]
        public void Add_SimpleVlue_ReturnValue(int a,int b,int expectedTotal)
        {   
            //calculator service taklit edildi
            mymock.Setup(x => x.add(a, b)).Returns(expectedTotal);

            var actualTotal = calculator.add(a,b);

            Assert.Equal(expectedTotal,actualTotal);
        }

        [Theory]
        [InlineData(5,3,15)]
        public void Multiple_SimpleValue_ReturnMultipleValue(int a,int b,int expectedTotal)
        {
            mymock.Setup(x => x.Multiple(a, b)).Returns(expectedTotal);
            Assert.Equal(15, calculator.Multiple(a, b));
        }
    }
}
