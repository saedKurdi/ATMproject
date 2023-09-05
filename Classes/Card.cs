namespace ATMconsoleProject.Classes
{
    internal class Card
    {
        #region Fields & Properties

        private string? bankName;

        public string ? BankName
        {
            get => bankName;
            private set => bankName = value;
        }


        private string? fullName;

        public string ? FullName
        {
            get => fullName;
            set => fullName = value;
        }

        private string? pan;
        
        public string ? Pan
        {
            get => pan;
            private set => pan = value;
        }

        private string? pin;

        public string? Pin
        {
            get => pin;
            private set => pin = value;
        }

        private string ? cvc;

        public string ? Cvc
        {
            get => cvc;
            private set => cvc = value;
        }

        private string ? expire_date;

        public string ? ExpireDate
        {
            get => expire_date;
            private set => expire_date = value;
        }

        decimal? balance;

        public decimal? Balance
        {
            get => balance;
            set => balance = value;

        }

        #endregion

        #region Constructors

        public Card()
        {
            SetRandomPAN();
            SetRandomCVC();
            SetRandomBalance();
        }

        public Card(string ? bankName,string ? expireDate,string ? pin)
            :this()
        {
            BankName = bankName;
            ExpireDate = expireDate;
            Pin = pin;
        }

        #endregion

        #region Methods


        public void ShowCardInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("<-----C A R D   I N F O----->\n");
            Console.ResetColor();
            Console.WriteLine($"Bank-Name : {BankName}\n");
            Console.Write($"PAN : ");
            for (int i = 0; i < Pan!.Length - 4 ; i++)
            {
                Console.Write(Pan[i]);
            }
            for (int i = 0; i < 4; i++)
            {
                Console.Write('*');
            }
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine($"PIN : {Pin}\n");
            Console.WriteLine($"CVC : * * *\n");
            Console.WriteLine($"Expire-Date : {ExpireDate}\n");
            Console.WriteLine($"Balance : {Balance}$\n\n\n");
        }

        public void SetRandomCVC()
        {
            Cvc = Random.Shared.Next(100, 1000).ToString();
        }

        public void SetRandomPAN()
        {
            int part1 = Random.Shared.Next(1000, 10000);
            int part2 = Random.Shared.Next(1000, 10000);
            int part3 = Random.Shared.Next(1000, 10000);
            int part4 = Random.Shared.Next(1000, 10000);
            Pan = part1.ToString() + "-" + part2.ToString() + "-" + part3.ToString() + "-" + part4.ToString();
        }

        public void SetRandomBalance()
        {
            Balance = Random.Shared.Next(1500, 10000);
        }

        #endregion
    }
}
