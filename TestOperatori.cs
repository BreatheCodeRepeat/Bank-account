using SuportLaborator11;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SuportLaborator_11
{
    class TestOperatori
    {
        public static void Main()
        {
            BankAccount account1, account2;
            long accNumber1, accNumber2;

            

            accNumber1 = Bank.CreateAccount(AccountType.Cec, 200);
            accNumber2 = Bank.CreateAccount(AccountType.Cec, 200);


            account1=Bank.GetAccount(accNumber1);
            account2 = Bank.GetAccount(accNumber2);

            if (account1.Equals(account2)) Console.WriteLine("Sunt la fel");
            else Console.WriteLine("Nu sunt la fel");

            if (!account1.Equals(account2)) Console.WriteLine("Sunt diferite");
            else Console.WriteLine("Nu sunt diferite");

            Console.WriteLine(account1);
            Console.WriteLine(account2);
            Console.ReadKey();

        }
    }
}
