using System;

namespace bebra
{
    class bank
    {
        private static List<bank> accounts = new List<bank>();
        private static int counter = 1;
        private int account;
        private string name;
        private float balance;

        public void open_account(string name, float balance)
        {
            this.account = counter++;
            this.name = name;
            this.balance = balance;
            accounts.Add(this);
        }

        public void info(bool show = true)
        {
            if (show)
            {
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine($"Номер счета: {account}");
            Console.WriteLine($"Владелец счета: {name}");
            Console.WriteLine($"Баланс счета: {balance:f2}");
            if (show)
            {
                Console.WriteLine("------------------------------");
            }
        }

        public void deposit_money(float amount)
        {
            balance += amount;
            Console.WriteLine($"На счет поступило: {amount:f2}");

        }

        public void get_money(float amount)
        {
            if (amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Со счета снято: {amount:f2}");
            }
            else
            {
                Console.WriteLine("Недостаточно средств на счете.");
            }

        }

        public void get_all_money()
        {
            Console.WriteLine($"Вся сумма снята: {balance:f2}");
            balance = 0;
        }

        public void Transfer(int to_account, float amount)
        {
            if (amount <= this.balance)
            {
                this.balance -= amount;
                accounts[to_account - 1].balance += amount;
            }
            else
            {
                Console.WriteLine("Недостаточно средств для перевода.");
            }
        }

        public string get_name()
        {
            return name;
        }

        public static void show_all_accounts()
        {
            Console.WriteLine("------------------------------");
            foreach (var account in accounts)
            {
                account.info(show: false);
                Console.WriteLine("------------------------------");
            }
        }

        public void delete_account1(int c)
        {
            accounts.RemoveAt(c);
        }

    }
}


