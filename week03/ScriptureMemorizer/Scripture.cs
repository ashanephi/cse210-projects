public class Scripture
{
    private Reference _reference;
    private List<Word> _words = new List<Word>();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        string[] words = text.Split(" ");
        foreach (string wordText in words)
        {
            _words.Add(new Word(wordText));
        }
    }

    public void HideRandomWords(int numberToHide)
{
            Random random = new Random();
        for (int i = 0; i < numberToHide; i++)
        {
            int index = random.Next(_words.Count);  
            _words[index].Hide();  
        }
}



    public void GetDisplayText()
    {
        Console.Clear();
        Console.WriteLine(_reference.GetDisplayText() + " ");
        foreach (Word word in _words)
        {
            Console.Write(word.GetDisplaytext() + " ");
        }
        Console.WriteLine();    
    }

    public bool isCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.isHidden())
            {
                return false;
            }
        }
        return true;
    }

}