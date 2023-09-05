namespace ATMconsoleProject.Classes;


internal class History
{

    #region Fields & Properties

    string? text;

    public string? Text
    {
        get => text; 
        set => text = value;
    }

    DateTime? date;

    public DateTime? Date
    {
        get => date;
        private set => date = value;
    }


    #endregion

    #region Constructors

    public History()
    {
        Date = DateTime.Now;
    }

    public History(string ? text):this()
    {
        Text = text;
    }

    #endregion

    public void Show()
    {
        Console.WriteLine($"Event : {Text}  /  Date And Time -- {Date}\n");
    }
}


internal class HistoryOfOperations
{
    #region Fields & Properties

    private List<History> histories = new List<History>();

    public List<History> Histories { get => histories; }

    #endregion

    #region Constructors

    public HistoryOfOperations()
    {
    }
    #endregion

    #region Methods

    public void AddHistoryToTheHistoryList(History history)
    {
        histories.Add( history );
    }

    public void ShowAllHistories()
    {
       for (int i = 0; i < Histories.Count; i++)
        {
            Console.Write($"{i + 1}.");
            if (Histories[i] == null)
            {
                Console.WriteLine("No History Yet");
            }
            else
            {
                Histories[i].Show();
            }
        }
    }

    #endregion

}
