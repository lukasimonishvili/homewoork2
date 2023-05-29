using System;

namespace task2
{
    internal class MicroFinance : IFinanceOperations
    {
        private int loanPrecentage = 10;
        private int fee = 4;
        public void CalculateLoanPercent(int month, int Amount)
        {
            var totalAmountToPay = Amount + ((Amount / 100) * loanPrecentage) + (fee * month);
            Console.WriteLine($"Loan {Amount}$ is requested for {month} months");
            Console.WriteLine($"total return amount will be {totalAmountToPay}$");
            Console.WriteLine($"Payment per month will be {totalAmountToPay / month}$");
        }

        public bool CheckUserHistory()
        {
            return true;
        }

        public void requestLoad(int mont, int amount)
        {
            if (CheckUserHistory())
            {
                CalculateLoanPercent(mont, amount);
            }
        }
    }
}
