using Drive.Presentation.Actions;
namespace Drive.Presentation.Abstractions
{
    public class BaseMenuAction : IMenuAction
    {
        public int MenuIndex { get; set; }
        public string Name { get; set; } = "NoName action";
        public IList<IAction> Actions { get; set; }

        public BaseMenuAction(IList<IAction> actions)
        {
           
            Actions = actions;
            Actions.Add(new ExitAction());
            for (int i = 0; i < actions.Count; i++)
            {
                actions[i].MenuIndex = i + 1; 
            }
        }

        public virtual void Open()
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

                Console.WriteLine("Invalid option. Try again.");
            }
            else            
                Console.WriteLine("Invalid format. Try again.");
            

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}
