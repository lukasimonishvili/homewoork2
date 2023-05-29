using System;

namespace task1
{
    public class Company
    {
        private CompanyStatus status;
        public int taxRate;

        public Company(CompanyStatus status)
        {
            this.status = status;
        }

        public void setTaxRate()
        {
            if (status == CompanyStatus.local)
            {
                taxRate = 18;
            }
            else
            {
                taxRate = 5;
            }
        }
    }
}
