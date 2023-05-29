using System;

namespace task2
{
    internal class Bank : IFinanceOperations
    {
        private int loanPrecentage = 5;
        public void CalculateLoanPercent(int month, int Amount)
        {
            var totalAmountToPay = Amount + ((Amount / 100) * loanPrecentage);
            Console.WriteLine($"Loan {Amount}$ is requested for {month} months");
            Console.WriteLine($"total return amount will be {totalAmountToPay}$");
            Console.WriteLine($"Payment per month will be {totalAmountToPay / month}$");
        }

        public bool CheckUserHistory()
        {
            bool[] isUserHistoryValid = {true, false};
            var random = new Random();
            var randomIndex = random.Next(0, isUserHistoryValid.Length - 1);

            return isUserHistoryValid[randomIndex];
        }

        public void requestLoad(int mont, int amount) { 
            if(CheckUserHistory())
            {
                CalculateLoanPercent(mont, amount);
            }
        }
    }
}
