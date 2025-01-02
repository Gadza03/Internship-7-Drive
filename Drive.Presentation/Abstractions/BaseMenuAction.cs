namespace Drive.Presentation.Abstractions
{
    public class BaseMenuAction : IMenuAction
    {
        public int MenuIndex { get; set; } = -1;
        public string Name { get; set; } = "default";
        public IList<IAction> Actions { get; set; }

        public BaseMenuAction(IList<IAction> actions, string name = "Default")
        {
            
            Actions = actions;            
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].MenuIndex = i + 1; 
            }
            Name = name;
        }

        public virtual void Open()
        {       
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Choose from {Name}:");
                foreach (var action in Actions.OrderBy(a => a.MenuIndex))
                {
                    Console.WriteLine($"{action.MenuIndex}. {action.Name}");
                }

                Console.Write("\nYour choice: ");
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    var selectedAction = Actions.FirstOrDefault(a => a.MenuIndex == choice);
                    if (selectedAction != null)
                    {
                        selectedAction.Open();
                        return;
                    }
                }
                
                Console.WriteLine("Invalid format. Try again.");
                Console.ReadKey();
            }
           
        }
    }
}
