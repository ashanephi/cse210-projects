using System.IO;

public class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry newEntry)
    {
        _entries.Add(newEntry);
    }

    public void DisplayAll()
    {
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void SaveToFile(string file)
    {
        try
        {
            List<string> lines = new List<string>();
            
            foreach (Entry entry in _entries)
            {
                string entryLine = $"{entry._promptText},{entry._entryText},{entry._date}";
                lines.Add(entryLine);
            }      
            File.WriteAllLines(file, lines);
            Console.WriteLine("Journal saved successfully");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string file)
    {
        try
        {
            if (File.Exists(file))
            {
                string[] lines = File.ReadAllLines(file);

                _entries.Clear();

                foreach (string line in lines)
                {
                    string[] parts = line.Split(",");

                    if (parts.Length == 3)
                    {
                        string prompt = parts[0];
                        string response = parts[1];
                        string date = parts[2];

                        Entry newEntry = new Entry();
                        newEntry._date = date;
                        newEntry._promptText = prompt;
                        newEntry._entryText = response;                        
                        _entries.Add(newEntry);
                    }

                }
                Console.WriteLine("Journal loaded succesfully");

            }
            else 
            {
                Console.WriteLine("File not found");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }

}