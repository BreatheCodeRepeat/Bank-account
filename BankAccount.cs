using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;

namespace SuportLaborator11
{
    enum AccountType { Cec, Deposit }

    sealed class BankAccount : IDisposable
    {




        public static bool operator == (BankAccount a,BankAccount b)
        {
            if (a.accNumber == b.accNumber && a.amount == b.amount && a.accType == b.accType) return true;
          return false;

        }

        public static bool operator !=(BankAccount a, BankAccount b)
        {
            return !(a == b);

        }

   
        public override bool Equals(Object acc)
        {
            if(acc is BankAccount)
            {
                return this == (BankAccount)acc;
            }
            return false;

        }

        public override string ToString()
        {
            return this.accNumber + " " + this.amount + " " + this.accType;
        }

        public override int GetHashCode()
        {
            return (int)this.accNumber;
        }

        public BankAccount()
        {
            accNumber = NextNumber();
            amount = 0;
            accType = AccountType.Cec;
        }

        //supraincarcarea constructorului default

        public BankAccount(AccountType tCont)
        {
            accNumber = NextNumber();
            amount = 0;
            accType = tCont;
        }

        public BankAccount(decimal sCont)
        {
            accNumber = NextNumber();
            amount = sCont;
            accType = AccountType.Cec;
        }

        public BankAccount(AccountType tCont, decimal sCont)
        {
            accNumber = NextNumber();
            amount = sCont;
            accType = tCont;
        }

        //destructorul
        ~BankAccount()
        {
        }

        public long AccNumber()
        {
            return accNumber;
        }

        public decimal Amount()
        {
            return amount;
        }

        public AccountType ReturnType()
        {
            return accType;
        }

        public static long NextNumber()
        {
            return succNrCont++;
        }
        public Queue Tranzactions()
        {
            return transactionQueue;
        }
        public static void Write(BankAccount cb)
        {
            Console.WriteLine("Nr de cont este: {0}", cb.AccNumber());
            Console.WriteLine("Soldul este: {0}", cb.Amount());
            Console.WriteLine("Tipul contului este: {0}", cb.ReturnType());

            foreach (BankTransaction tran in cb.Tranzactions())
            {
                Console.WriteLine("Data/Ora: {0}\tSuma: {1}", tran.Date(), tran.Amount());
            }

            Console.WriteLine();
        }
        public decimal Deposit(decimal amount)
        {
            this.amount += amount;

            BankTransaction tran = new BankTransaction(amount);
            transactionQueue.Enqueue(tran);

            return this.amount;
        }
        public bool Withdraw(decimal amount)
        {
            if (amount > this.amount)
                return false;

            this.amount -= amount;
            BankTransaction tran = new BankTransaction(-amount);
            transactionQueue.Enqueue(tran);

            return true;
        }

        public static void TestDeposit(BankAccount cb)
        {
            Console.WriteLine("Introduceti suma pe care vreti sa o depuneti");
            decimal amount = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Noul sold este: {0}", cb.Deposit(amount));
        }

        public static void TestWithdraw(BankAccount cb)
        {
            Console.WriteLine("Introduceti suma pe care vreti sa o retrageti");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (cb.Withdraw(amount) == true)
                Console.WriteLine("Noul sold este: {0}", cb.Amount());
            else
                Console.WriteLine("Suma este prea mare");
        }
        public void Dispose()
        {
            if (disposed == true)
                return;
            else
            {
                StreamWriter fout = File.AppendText("Tranzactii.txt");

                //scriem informatiile despre cont
                fout.WriteLine("Numarul de cont: {0}", accNumber);
                fout.WriteLine("Soldul: {0}", amount);
                fout.WriteLine("Tip cont: {0}", accType);

                foreach (BankTransaction tran in transactionQueue)
                {
                    fout.WriteLine("Data/Ora: {0}\tSuma: {1}", tran.Date(), tran.Amount());
                }

                fout.WriteLine();
                fout.Close();

                disposed = true;

                GC.SuppressFinalize(this);
            }

        }
        private long accNumber;
        private decimal amount;
        private AccountType accType;
        private static long succNrCont = 123;
        //coada de tranzactii
        private Queue transactionQueue = new Queue();

        //variabila de tip bool
        private bool disposed = false;
    }

}
