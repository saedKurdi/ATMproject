namespace ATMconsoleProject.Classes
{
    internal class Client
    {

        #region Fields & Properties

        private string ? id;

        public string? ID
        {
            get => id;
            private set
            {
                id = value;
            }
        }

        private string? name;

        public string ? Name
        {
            get => name;
            private set
            {
                name = value;
            }
        }

        private string? surname;

        public string? Surname
        {
            get => surname;
            private set
            {
                surname = value;
            }
        }

        private int age;
        public int Age
        {
            get => age;
            set
            {
                age = value;
            }
        }

        private double salary;
        public double Salary
        {
            get => salary;
            private set
            {
                salary = value;
            }
        }

        private Card ?cardAccount;

        public Card ? CardAccount
        {
            get => cardAccount;

            set
            {
                cardAccount = value;
            }
        }

        private HistoryOfOperations? hoo;

        public HistoryOfOperations? Hoo
        {
            get => hoo;

            set
            {
                hoo = value;
            }
        }

        #endregion


        #region Constructors

        public Client()
        {
            ID = Guid.NewGuid().ToString().Substring(0,13);
        }

        public Client(string ? name , string ? surname , int age , double salary,Card cardAccount)
            :this()
        {
            
            if(CardAccount!=null)CardAccount.FullName = name + ' ' + surname; 
            Name = name;
            Surname = surname;
            Age = age;
            Salary = salary;
            CardAccount = cardAccount;
        }

        #endregion


        #region Methods

        public void ShowClientInfo()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"<-----C L I E N T   I N F O----->");
            Console.ResetColor();
            Console.WriteLine($"Client Global User ID : {ID} \n");
            Console.WriteLine($"Full-Name : {Name} {Surname}\n");
            Console.WriteLine($"Age : {Age}\n");
            Console.WriteLine($"Salary : {Salary}$\n");
            if (CardAccount != null)
            {
                CardAccount.ShowCardInfo();
            }
        }

        public void WithDrawMoney(decimal money)
        {
            if(money > CardAccount!.Balance)
            {
                throw new Exception("There is not enough money to withdraw ! ");
            }


            CardAccount.Balance -= money;
            Console.ForegroundColor= ConsoleColor.Green;
            Console.Write("\t\t\t\tMoney With Drawed : ");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write($"-{money}");
            Console.ResetColor();
        }

        #endregion


    }
}
