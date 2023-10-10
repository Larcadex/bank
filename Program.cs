using System;

namespace bebra
{
    class Program
    {
        static void Main()
        {
            List<bank> users = new List<bank>();

            users.Add(new bank());
            users[0].open_account("Иванов Иван", 1000);

            users.Add(new bank());
            users[1].open_account("Петров Петр", 500);

            while (true)
            {
                Console.WriteLine("1. Показать информацию о всех счетах");
                Console.WriteLine("2. Открыть новый счет");
                Console.WriteLine("3. Закрыть счет");
                Console.WriteLine("4. Действия со счетами");

                ConsoleKeyInfo keyInfo1 = Console.ReadKey(true);

                switch (keyInfo1.Key)
                {
                    case ConsoleKey.D1:

                        Console.Clear();
                        bank.show_all_accounts();
                        Console.WriteLine();
                        break;

                    case ConsoleKey.D2:

                        Console.Clear();
                        new_account(users);
                        break;

                    case ConsoleKey.D3:

                        Console.Clear();
                        if (users.Count != 0)
                        {
                            delete_account(users);
                        }
                        else
                        {
                            Console.WriteLine("Нет доступных счетов для удаления\n");
                        }

                        break;

                    case ConsoleKey.D4:

                        Console.Clear();
                        if (users.Count != 0)
                        {
                            account_actions(users);
                        }
                        else
                        {
                            Console.WriteLine("Нет доступных счетов, необходимо открыть счет\n");
                        }

                        break;

                }
            }
        }

        static void new_account(List<bank> users)
        {
            Console.Write("Введите имя держателя счета: ");
            string name = Console.ReadLine();
            users.Add(new bank());
            users[users.Count - 1].open_account(name, 0);
            Console.Clear();
            Console.WriteLine("Счет успешно открыт!\n");
        }

        static void account_actions(List<bank> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].get_name()}");
            }

            Console.Write("\nВыберите пользователя над чьим счетом будут выполнятся действия: ");
            int choice = int.Parse(Console.ReadLine());
            float amount = 0;

            if (choice > 0 && choice <= users.Count)
            {
                Console.Clear();
                while (true)
                {
                    users[choice - 1].info(true);

                    Console.WriteLine("\n1. Положить деньги на счет ");
                    Console.WriteLine("2. Снять деньги со счета");
                    Console.WriteLine("3. Снять все деньги");
                    Console.WriteLine("4. Перевести деньги");
                    Console.WriteLine("5. Вернуться назад");

                    ConsoleKeyInfo keyInfo2 = Console.ReadKey(true);

                    switch (keyInfo2.Key)
                    {
                        case ConsoleKey.D1:

                            Console.Clear();
                            Console.Write("Введите cумму: ");
                            amount = int.Parse(Console.ReadLine());
                            Console.Clear();
                            users[choice - 1].deposit_money(amount);
                            Console.WriteLine();
                            break;

                        case ConsoleKey.D2:

                            Console.Clear();
                            Console.Write("Введите cумму: ");
                            amount = int.Parse(Console.ReadLine());
                            Console.Clear();
                            users[choice - 1].get_money(amount);
                            Console.WriteLine();
                            break;

                        case ConsoleKey.D3:

                            Console.Clear();
                            users[choice - 1].get_all_money();
                            Console.WriteLine();
                            break;

                        case ConsoleKey.D4:

                            Console.Clear();
                            transfer(users, choice, amount);

                            break;
                        case ConsoleKey.D5:
                            Console.Clear();
                            return;


                    }
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неверный выбор счета.\n");
            }
        }

        static void transfer(List<bank> users, int choice, float amount)
        {
            while (true)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {users[i].get_name()}");
                }

                Console.Write("\nВыберите кому перевести: ");
                int to_account = int.Parse(Console.ReadLine());

                Console.Clear();
                Console.WriteLine($"Перевод пользователю {users[to_account - 1].get_name()}\n");
                if (to_account > 0 && to_account <= users.Count && to_account != choice)
                {
                    Console.Write("Введите cумму: ");
                    amount = int.Parse(Console.ReadLine());
                    Console.Clear();
                    users[choice - 1].Transfer(to_account, amount);
                    Console.WriteLine($"Пользователю {users[to_account - 1].get_name()} переведено {amount} ");
                    Console.WriteLine();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Невозможно перевести деньги себе или выбран неверный пользователь! Выберите другого пользователя");
                    Console.WriteLine();
                }
            }
        }

        static void delete_account(List<bank> users)
        {
            for (int i = 0; i < users.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {users[i].get_name()}");
            }

            Console.Write("\nВыберите пользователя счет, которого хотите удалить: ");
            int c = int.Parse(Console.ReadLine());
            if (c > 0 && c <= users.Count)
            {
                Console.Clear();
                string deleted_name = users[c - 1].get_name();
                users[c - 1].delete_account1(c - 1);
                users.RemoveAt(c - 1);
                Console.WriteLine($"Счет пользователя {deleted_name} успешно удален!\n");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Неверный номер счета.");
            }
        }
    }
}