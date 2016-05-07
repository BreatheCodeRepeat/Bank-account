using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace SuportLaborator11
{
    class Bank
    {
         private Bank()
        {
        }

        public static long CreateAccount()
        {
            //cream contul
            BankAccount account = new BankAccount();

            //pastram nr de cont care va fi returnat la sfasit
            long nrCont = account.AccNumber();

            //adaugam noul cont in tabela de dispersie
            conturi[nrCont] = account;

            //returnam nr de cont
            return nrCont;
        }

        //a doua metoda supraincarcata
        public static long CreateAccount(AccountType tipCont)
        {
            //apelam constructorul corespunzator
            BankAccount account = new BankAccount(tipCont);

            //pastram nr de cont care va fi returnat la sfasit
            long nrCont = account.AccNumber();

            //adaugam noul cont in tabela de dispersie
            conturi[nrCont] = account;

            //returnam nr de cont
            return nrCont;
        }

        //a treia metoda supraincarcata
        public static long CreateAccount(decimal amount)
        {
            //apelam constructorul corespunzator
            BankAccount account = new BankAccount(amount);

            //pastram nr de cont care va fi returnat la sfasit
            long nrCont = account.AccNumber();

            //adaugam noul cont in tabela de dispersie
            conturi[nrCont] = account;

            //returnam nr de cont
            return nrCont;
        }


        //a patra metoda supraincarcata
        public static long CreateAccount(AccountType tipCont, decimal amount)
        {
            //apelam constructorul corespunzator
            BankAccount account = new BankAccount(tipCont, amount);

            //pastram nr de cont care va fi returnat la sfasit
            long nrCont = account.AccNumber();

            //adaugam noul cont in tabela de dispersie
            conturi[nrCont] = account;

            //returnam nr de cont
            return nrCont;
        }


        public static BankAccount GetAccount(long nrCont)
        {
            return (BankAccount)conturi[nrCont];
        }

        public static bool CloseAccount(long nrCont)
        {
            BankAccount account = (BankAccount)conturi[nrCont];

            if (account != null)
            {
                conturi.Remove(nrCont);
                account.Dispose();
                return true;
            }
            else
            {
                return false;
            }
        }

        //declaram și initializam tabela de dispersie
        private static Hashtable conturi = new Hashtable();
    }
}
