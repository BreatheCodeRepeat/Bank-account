using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace SuportLaborator11
{
    class Program
    {
        static void Main(string[] args)
        {
            long nrCont = Bank.CreateAccount();
            BankAccount account = Bank.GetAccount(nrCont);

            BankAccount.TestDeposit(account);
            BankAccount.TestWithdraw(account);
            BankAccount.Write(account);


            long nrCont2 = Bank.CreateAccount(AccountType.Deposit);
            BankAccount account2 = Bank.GetAccount(nrCont2);

            BankAccount.TestDeposit(account2);
            BankAccount.TestWithdraw(account2);
            BankAccount.Write(account2);

            long nrCont3 = Bank.CreateAccount(300M);
            BankAccount account3 = Bank.GetAccount(nrCont3);

            BankAccount.TestDeposit(account3);
            BankAccount.TestWithdraw(account3);
            BankAccount.Write(account3);

            long nrCont4 = Bank.CreateAccount(AccountType.Deposit, 300M);
            BankAccount account4 = Bank.GetAccount(nrCont4);

            BankAccount.TestDeposit(account4);
            BankAccount.TestWithdraw(account4);
            BankAccount.Write(account4);


            if (Bank.CloseAccount(nrCont) == true)
                Console.WriteLine("Contul a fost inchis");
            else
                Console.WriteLine("Nr de cont este invalid");

            Console.ReadKey();
        }
    }
}
