public class RandomPrompt
{
    IDictionary<int, string> _prompts = new Dictionary<int, string>() {
	{0, "Who was the most interesting person I interacted with today?"},
	{1, "What was the best part of my day?"},
	{2, "How did I see the hand of the Lord in my life today?"},
    {3, "What was the strongest emotion I felt today?"},
	{4, "if I had one thing I could do over today, what would it be?"},
    {5, "What would you like to remember about yourself?"},
    {6, "What has the Lord done for you this month?"},
    {7, "What do you like to tell your family about yourself?"},
    {8, "what gosple principle do you appl today?"}
};

    public string Display()
    {
        Random randomGenerator = new Random();

        int number = randomGenerator.Next(0, 9);

        string prompt =  _prompts[number];
        return prompt;
    }
}