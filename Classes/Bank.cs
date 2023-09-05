using System;
using System.Data;

namespace ATMconsoleProject.Classes
{
    internal class Bank
    {

        #region Fields & Properties


        private List<Client> ? clients = new List<Client>();

        public List<Client> ? Clients
        {
            get => clients;
        }
        #endregion


        #region Constructors

        public Bank()
        {
        }
        #endregion

        #region Methods


        public void ShowAllClientsFromBank()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("ALL CLIENTS FROM BANK :\n");
            Console.ResetColor();
            if (Clients == null || Clients.Count == 0)
            {
                throw new Exception("The Client List Of The Bank Is Empty ! Nothing To Show ! ");
            }
          
            foreach(Client client in clients!)
            {
                    client.ShowClientInfo();
            }

        }

        public void AddClientToBank(Client ? newClient)
        {
            if(newClient == null)
            {
                throw new ArgumentNullException("New Client Can Not Be Null ! ");
            }

            for (int i = 0; i < Clients!.Count; i++)
            {
                if(newClient.CardAccount!.Pin == Clients[i].CardAccount!.Pin)
                {
                    throw new Exception("User By This PIN Already Excists In Our System ! ");
                }

            }

            Clients!.Add(newClient);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Client - {newClient.Name} {newClient.Surname} Was Succesfully Added To Bank's System ! ");
            Thread.Sleep(1000);
            Console.ResetColor();
        }

        public void RemoveClientFromBankByGuid(string ? guid)
        {
            if(Clients == null || Clients.Count == 0)
            {
                throw new Exception("Can Not Delete Because The Count is null ! ");
            }

            if(FindClientByGuid(guid) == null)
            {
                throw new Exception($"Can Not Find The Client By {guid} - ID ! ");
            }

            Client client = FindClientByGuid(guid);
            Clients.Remove(client);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Client - {client.Name} {client.Surname} Was Succefully Deleted From Our System ! ");
            Thread.Sleep(1000);
            Console.ResetColor();
        }

        public Client FindClientByGuid(string ? guid)
        {
            if(guid == null)
            {
                throw new ArgumentNullException("'Guid' Can Not Be Null ! ");
            }

            for(int i = 0;i < Clients!.Count;i++)
            {
                if (Clients[i].ID == guid)
                {
                    return Clients[i];
                }
            }
            return null!;
        }

        public Client FindClientByPIN(string  ? pin)
        {
            if (pin == null)
            {
                throw new ArgumentNullException("'PIN' Can Not Be Null ! ");
            }

            for (int i = 0; i < Clients!.Count; i++)
            {
                if (Clients[i].CardAccount!.Pin == pin)
                {
                    return Clients[i];
                }
            }

            throw new Exception("There is no Client by this 'PIN' ! ");
        }

        public void TransferMoneyToOtherClient(Client FromThisClient, Client ToOtherClient, decimal money)
        {

            if (FromThisClient == null || ToOtherClient == null) throw new ArgumentNullException("Clients Who Are Making Transfer Must Not Be Null !");
            if (FromThisClient.ID == ToOtherClient.ID) throw new Exception("You Can Not Transfer Money To Yourself ! ");
            if (money > FromThisClient.CardAccount!.Balance) throw new Exception("You Do not Have Enough Money To Send ! ");

            FromThisClient.CardAccount!.Balance -= money;
            ToOtherClient.CardAccount!.Balance += money;
            Console.Write("From You Transfered");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write($"-------> {money}$ ");
            Console.ResetColor();
            Console.Write($"To {ToOtherClient.Name} {ToOtherClient.Surname} ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Succesfully !");
            Console.ResetColor();

        }

        public void ShowAllHistoriesOfClients()
        {
            for (int i = 0; i < Clients!.Count; i++)
            {

                Console.WriteLine($"Client - {Clients[i].Name} {Clients[i].Surname} - {Clients[i].ID} All Histories : ");
                if (Clients[i].Hoo == null)
                {
                    Console.WriteLine("Nothing To Show ! ");
                    Console.WriteLine();
                }
                else Clients[i].Hoo!.ShowAllHistories(); Console.WriteLine();
            }
        }

        public Client FindClientByID(string ? ID)
        {
            if(ID == null)
            {
                throw new Exception("ID Can Not Be Null ! ");
            }

            for (int i = 0; i < Clients!.Count; i++)
            {
                if (ID == Clients[i].ID) return Clients[i];
            }

            throw new Exception($"Client By This ID Was Not Found ! ");
        }

        #endregion


    }
}
