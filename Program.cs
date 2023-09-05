using ATMconsoleProject.Classes;
using System.ComponentModel;
using System.Security.Cryptography;
using System.Xml.XPath;

namespace ATMconsoleProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Card card1 = new Card("Kapital-Bank","07/25","4459");
            Card card2 = new Card("Kapital-Bank","08/28","4101");
            Card card3 = new Card("Kapital-Bank","05/24","9933");
            Card card4 = new Card("Uni-Bank", "05/29", "4155");
            Card card5 = new Card("Uni-Bank", "05/30", "2345");

            Client client1 = new Client("Saed","Mamedov",19,12000,card1);
            Client client2 = new Client("Ulfat","Mamedov",20,5000,card2);
            Client client3 = new Client("Imran","Ismayilov",21,5500,card3);
            Client client4 = new Client("Elmar","Suleymanov",24,3430,card4);  
            Client client5  = new Client("Samira","Mixaylovna",22,8700,card5);

            Admin admin = new Admin("saed445", "s2005s");
            
            Bank bank = new Bank();

            bank.AddClientToBank(client1);
            bank.AddClientToBank(client2);
            bank.AddClientToBank(client3);
            bank.AddClientToBank(client4);
            bank.AddClientToBank(client5);

            for (int i = 0; i < 2; i++)
            {
                Thread.Sleep(550);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.Write("\t\t\t\t\tThe ATM Terminal is Starting ");
                Console.ResetColor();
                for (int k = 0; k < 3; k++)
                {
                    Thread.Sleep(350);
                    Console.Write(". ");
                    Thread.Sleep(350);
                }
            }

            int count = 0;
       
            while (true)
            {
                Console.Clear();
                if (count == 1) break;
                HistoryOfOperations hoo = new HistoryOfOperations();
                try
                {
                    while (true)
                    {
                        int count2 = 0;
                        int _result = OtherFunctions.Menu(ElementMassivesForMenu.AdminUserMenu);
                        if(_result == 0) // admin 
                        {
                            Console.Clear();
                            while (true)
                            {
                                if (count2 == 1) break;
                                Console.Write("\t\t\t\tEnter Admin Username : ");
                                string? username = Console.ReadLine();
                                Console.Write("\t\t\t\tEnter Admin Password : ");
                                string? password = Console.ReadLine();
                                if (username == admin.Username && password == admin.Password)
                                {
                                    while (true)
                                    {
                                        int __result = OtherFunctions.Menu(ElementMassivesForMenu.ElementsForAdminMenu);
                                        if(__result == 0) // show all client info from bank
                                        {
                                            Console.Clear();
                                            bank.ShowAllClientsFromBank();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ReadKey();
                                            
                                        }

                                        else if(__result == 1)// show all histories of clients
                                        {
                                            Console.Clear();
                                            bank.ShowAllHistoriesOfClients();
                                            Console.WriteLine();
                                            Console.WriteLine();
                                            Console.ReadKey();

                                        }

                                        else if(__result == 2) // add client to the system
                                        {
                                            Console.Clear();
                                            Console.Write("Enter Bank Name : ");
                                            string ? bank_name = Console.ReadLine();

                                            Console.Write("Enter Expire Date (at least 5 characthers ex - 00/00 ) :");
                                            string ?expire_date = Console.ReadLine();

                                            Console.Write("Enter PIN (at least 4 characthers): ");
                                            string ? pin = Console.ReadLine();
                                            if (bank_name == null || expire_date == null || expire_date.Length > 5 || pin == null || pin.Length > 4) throw new Exception("Please Enter All Infos which required ! ");
                                            
                                            Card newCard = new Card(bank_name,expire_date,pin);

                                            Console.Clear();

                                            Console.Write("Enter Client Name : ");
                                            string ?clientName = Console.ReadLine();

                                            Console.Write("Enter Client Surname : ");
                                            string ? clientSurname = Console.ReadLine();

                                            Console.Write("Enter Client Age : ");
                                            int age = Convert.ToInt32(Console.ReadLine());

                                            Console.Write("Enter Client Salary : ");
                                            double salary = Convert.ToDouble(Console.ReadLine());

                                            if (clientName == null || clientSurname == null || age < 18 || salary == 0) throw new Exception("Some Error Occured Try Again! ");

                                            Client newClient = new Client(clientName, clientSurname, age,salary, newCard);

                                            bank.AddClientToBank(newClient);

                                            Console.ReadKey();
                                            

                                        }

                                        else if(__result == 3) // remove client from the system
                                        {
                                            int c3 = 0;
                                            while (true)
                                            {
                                                if (c3 == 1) break;
                                                Array.Resize(ref ElementMassivesForMenu.NameSurnameIDofAllClients, bank.Clients!.Count);
                                                for (int i = 0; i < bank.Clients.Count; i++)
                                                {
                                                    ElementMassivesForMenu.NameSurnameIDofAllClients[i] = bank.Clients[i].Name + ' ' + bank.Clients[i].Surname + ' ' + bank.Clients[i].ID;
                                                }

                                                int ___result = OtherFunctions.Menu(ElementMassivesForMenu.NameSurnameIDofAllClients);

                                                for (int i = 0; i < bank.Clients.Count; i++)
                                                {
                                                    if (ElementMassivesForMenu.NameSurnameIDofAllClients[___result].Substring(ElementMassivesForMenu.NameSurnameIDofAllClients[i].Length-13) == bank.Clients[i].ID)
                                                    {
                                                        bank.Clients.Remove(bank.Clients[i]);
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine($"Client Removed Succefully!");
                                                        Console.ResetColor();
                                                        Console.WriteLine();
                                                        Console.ReadKey();
                                                        c3++;
                                                        break;
                                                    }

                                                }
                                            }
                                        }

                                        else if(__result == 4) // send money to clients card
                                        {
                                            int c3 = 0;
                                            while (true)
                                            {
                                                if (c3 == 1) break;
                                                Array.Resize(ref ElementMassivesForMenu.NameSurnameIDofAllClients, bank.Clients!.Count);
                                                for (int i = 0; i < bank.Clients.Count; i++)
                                                {
                                                    ElementMassivesForMenu.NameSurnameIDofAllClients[i] = bank.Clients[i].Name + ' ' + bank.Clients[i].Surname + ' ' + bank.Clients[i].ID;
                                                }

                                                int ___result = OtherFunctions.Menu(ElementMassivesForMenu.NameSurnameIDofAllClients);

                                                for (int i = 0; i < bank.Clients.Count; i++)
                                                {
                                                    if (ElementMassivesForMenu.NameSurnameIDofAllClients[___result].Substring(ElementMassivesForMenu.NameSurnameIDofAllClients[i].Length - 13) == bank.Clients[i].ID)
                                                    {
                                                        Console.Write($"Enter Money To Transfer To {bank.Clients[i].Name} {bank.Clients[i].Surname}'s Card : ");
                                                        decimal moneyy = Convert.ToDecimal(Console.ReadLine());
                                                        bank.Clients[i].CardAccount!.Balance += moneyy;
                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                        Console.WriteLine($"Tranfered To {bank.Clients[i].Name} {bank.Clients[i].Surname}'s card Succefully!");
                                                        Console.ResetColor();
                                                        Console.WriteLine();
                                                        Console.ReadKey();
                                                        c3++;
                                                        break;
                                                    }

                                                }
                                            }
                                        }

                                        else if(__result == 5) // back
                                        {
                                            Console.Clear();
                                            count2+=1;
                                            break;
                                        }
                                    }
                                    
                                }
                                else throw new Exception("Admin Username & Password is not Correct ! ");
                            }
                        }

                        else if(_result == 1) // client
                        {
                            Console.Clear() ;
                            Console.Write("\t\t\t\t\tEnter Your PIN (Note : You Can Escape Too)  : ");
                            if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                            else Console.Clear(); Console.Write("PIN : ");
                            string? pin = Console.ReadLine();
                            Client client = bank.FindClientByPIN(pin);
                            client.Hoo = hoo;
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"\t\t\t\t\tWelcome To Our System! {client.Name} {client.Surname} ");
                            History h1 = new History("Logged in To The System");
                            hoo.AddHistoryToTheHistoryList(h1);
                            Console.ResetColor();
                            Console.ReadKey();
                            while (true)
                            {
                                int result = OtherFunctions.Menu(ElementMassivesForMenu.ElementsForMainMenu);
                                Console.Clear();
                               
                                if (result == 0) //show current balance
                                {
                                    History h2 = new History("Balance Was Viewed");
                                    hoo.AddHistoryToTheHistoryList(h2);
                                    Console.WriteLine($"\t\t\t\t\tCurrent Client Balance : {client.CardAccount!.Balance}$");
                                    Console.ReadKey();
                                }

                                else if (result == 1) // pul cixarisi nagd
                                {
                                    while (true)
                                    {
                                        try
                                        {
                                            int __result= OtherFunctions.Menu(ElementMassivesForMenu.ElementsForCashMenu);
                                            if (__result == 0) { Console.Clear(); History h3 = new History("Cashed 10$"); hoo.AddHistoryToTheHistoryList(h3); client.WithDrawMoney(10); Console.ReadKey(); }
                                            else if (__result == 1) { Console.Clear(); History h3 = new History("Cashed 20$"); hoo.AddHistoryToTheHistoryList(h3); client.WithDrawMoney(20); Console.ReadKey(); }
                                            else if (__result == 2) { Console.Clear(); History h3 = new History("Cashed 50$"); hoo.AddHistoryToTheHistoryList(h3); client.WithDrawMoney(50); Console.ReadKey(); }
                                            else if (__result == 3) { Console.Clear(); History h3 = new History("Cashed 100$"); hoo.AddHistoryToTheHistoryList(h3); client.WithDrawMoney(100); Console.ReadKey(); }
                                            else if (__result == 4)
                                            {
                                                Console.Clear();
                                                Console.Write("\t\t\t\tEnter Money Which You Wanna WithDraw : ");
                                                decimal money = Convert.ToDecimal(Console.ReadLine());
                                                History h3 = new History($"Cashed {money}$");
                                                hoo.AddHistoryToTheHistoryList(h3);
                                                client.WithDrawMoney(money);
                                                Console.ReadKey();
                                            }

                                            else if (__result == 5)
                                            {
                                                History h3 = new History("Used 'Back' To Menu ");
                                                hoo.AddHistoryToTheHistoryList(h3);
                                                break;
                                            }

                                                        
                                        }
                                        catch (Exception ex )
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"\t\t\t\t\t{ex.Message}");
                                            Console.ResetColor();
                                            Console.Write("\t\t\t\t\tPress any key to continue . . .");
                                            Console.ReadKey();
                                        }

                                    }
                                }

                                else if (result == 2) // history of all operations 
                                {
                                    Console.Clear();
                                    hoo.ShowAllHistories();
                                    Console.WriteLine();
                                    Console.ReadKey();
                                }

                                else if (result == 3) // transfer to other client's card 
                                {
                                    while (true)
                                    {
                                        try
                                        {
                                            Console.Clear();
                                            Console.Write("\t\t\t\tEnter 'PIN' Of Other Client To Transfer Money (Note : You Can Escape) : ");
                                            if (Console.ReadKey().Key == ConsoleKey.Escape) break;
                                            else Console.Clear(); Console.Write("\t\t\t\t\t 'PIN' Of Other Client To Transfer Money : ");
                                            string ? pin_ = Console.ReadLine();
                                            Client clientToTransferMoney = bank.FindClientByPIN(pin_);
                                            if (client.ID == clientToTransferMoney.ID) throw new Exception("You can not send money to yourself !");
                                            History h_ = new History($"Attempt To Transfer Money To {clientToTransferMoney.Name} {clientToTransferMoney.Surname}'s Card");
                                            hoo.AddHistoryToTheHistoryList(h_);
                                            int __result = OtherFunctions.Menu(ElementMassivesForMenu.ElementsForCashMenu);
                                            if (__result == 0) { Console.Clear(); History h4 = new History($"Transfered 10$ ! To {clientToTransferMoney.ID}"); hoo.AddHistoryToTheHistoryList(h4); bank.TransferMoneyToOtherClient(client,clientToTransferMoney,10); Console.Write("To Continue Enter Any Key , To Escape Press 'esc' .."); if (Console.ReadKey().Key == ConsoleKey.Escape) break; else continue; }
                                            else if (__result == 1) { Console.Clear(); History h4 = new History($"Transfered 20$ ! To {clientToTransferMoney.ID}"); hoo.AddHistoryToTheHistoryList(h4); bank.TransferMoneyToOtherClient(client, clientToTransferMoney, 20);Console.Write("To Continue Enter Any Key , To Escape Press 'esc' ..");if (Console.ReadKey().Key == ConsoleKey.Escape) break; else continue;  }
                                            else if (__result == 2) { Console.Clear(); History h4 = new History($"Transfered 50$ ! To {clientToTransferMoney.ID}"); hoo.AddHistoryToTheHistoryList(h4); bank.TransferMoneyToOtherClient(client, clientToTransferMoney, 50); Console.Write("To Continue Enter Any Key , To Escape Press 'esc' .."); if (Console.ReadKey().Key == ConsoleKey.Escape) break; else continue; }
                                            else if (__result == 3) { Console.Clear(); History h4 = new History($"Transfered 100$ ! To {clientToTransferMoney.ID}"); hoo.AddHistoryToTheHistoryList(h4); bank.TransferMoneyToOtherClient(client, clientToTransferMoney, 100); Console.Write("To Continue Enter Any Key , To Escape Press 'esc' .."); if (Console.ReadKey().Key == ConsoleKey.Escape) break; else continue; }
                                            else if (__result == 4)
                                            {
                                                Console.Clear();
                                                Console.Write("\t\t\t\tEnter Money Which You Wanna WithDraw : ");
                                                decimal money = Convert.ToDecimal(Console.ReadLine());
                                                History h4 = new History($"Transfered {money}$ ! To {clientToTransferMoney.ID}"); hoo.AddHistoryToTheHistoryList(h4);
                                                bank.TransferMoneyToOtherClient(client, clientToTransferMoney, money);
                                                Console.Write("To Continue Enter Any Key , To Escape Press 'esc' .."); if (Console.ReadKey().Key == ConsoleKey.Escape) break; else continue;
                                            }

                                            else if(__result == 5)
                                            {
                                                History h4 = new History("Used 'Back' To Menu ");
                                                hoo.AddHistoryToTheHistoryList(h4);
                                                break;
                                            }


                                        }
                                        catch (Exception ex)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Red;
                                            Console.WriteLine($"\t\t\t\t\t{ex.Message}");
                                            Console.ResetColor();
                                            Console.Write("\t\t\t\t\tPress any key to continue . . .");
                                            Console.ReadKey();
                                        }

                                    }
                                }

                                else if (result == 4) // back
                                {
                                    History h5 = new History("Used 'Back' To Menu ");
                                    hoo.AddHistoryToTheHistoryList(h5);
                                    Console.WriteLine("\t\t\t\t\tGetting Back . . .");
                                    Thread.Sleep(1500);
                                    break;
                                }
                            }
                        }

                        else if(_result == 2)
                        {
                            //exit -> from system
                            Console.Clear();
                            Console.ForegroundColor= ConsoleColor.Green;
                            Console.BackgroundColor = ConsoleColor.Red;
                            Console.WriteLine("\t\t\t\t\tExited From The System!\n\n\n\n\n\n\n");
                            Console.ResetColor();
                            count++;
                            Console.ReadKey();
                            break;
                        }
                    }
                    
                }

                catch(Exception ex )
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"\t\t\t\t\t{ex.Message}");
                    Console.ResetColor();
                    Console.Write("\t\t\t\t\tPress any key to continue . . .");
                    Console.ReadKey();
                }


            }

        }
    }
}