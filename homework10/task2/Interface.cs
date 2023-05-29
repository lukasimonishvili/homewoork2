namespace task2
{
    internal interface IFinanceOperations
    {
        void CalculateLoanPercent(int month, int Amount);
        bool CheckUserHistory();
    }
}
