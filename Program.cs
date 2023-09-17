using System;
using System.IO;

namespace Hometask_15_09.Employee
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User()
            {
                Id = 1,
                FirstName = "John",
                LastName = "Smith",
                PhoneNumber = "123456789",
                UserName = "johnsmith"
            };

            Card card = CreateCardForUser(user);
            card.balance = 150; // Устанавливаем начальный баланс карты равным 150

            Console.WriteLine("Введите сумму для операции:");
            decimal amount = decimal.Parse(Console.ReadLine());

            if (card.Balance >= amount)
            {
                card.Withdraw(amount);

                Payment payment = new Payment(amount);

                string filePath = @"C:\CODE\data.txt";
                WriteToFile(filePath, card, user, payment);
            }
            else
            {
                Console.WriteLine("Недостаточно средств на карте");
            }
        }

        static Card CreateCardForUser(User user)
        {
            Card card = new Card(user.UserName);
            string id = card.Id;
            return card;
        }

        static void WriteToFile(string filePath, Card card, User user, Payment payment)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"User ID: {user.Id}");
                writer.WriteLine($"User Card ID: {card.Id}");
                writer.WriteLine("_______________________");
                writer.WriteLine($"Amount: {payment.Amount}");
                writer.WriteLine($"Remaining Balance: {card.Balance}"); // Записываем оставшуюся сумму после платежа
            }
        }
    }
}