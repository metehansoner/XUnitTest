namespace UdemyUnitTest.APP
{
    public class Calculator
    {
        private ICalculatorService _calculatorService { get; set; }
        public Calculator(ICalculatorService calculatorService)
        {
            this._calculatorService = calculatorService;

        }
        public int add(int a,int b)
        {
            return _calculatorService.add(a,b);
        }

        public string divide(int a,int b)
        {
            if (b==0)
            {
                return "Tanımsız";
            }
            else
            {
                return (a / b).ToString();
            } 
        }
    }
}
