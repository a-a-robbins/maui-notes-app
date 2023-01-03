using System.Collections.ObjectModel; 
namespace Notes.Models;

internal class AllNotes
{
    public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>(); 

    public AllNotes() 
    {
        LoadNotes(); 
    }

    public void LoadNotes()
    {
        Notes.Clear();

        //get folder where notes stored
        string appDataPath = FileSystem.AppDataDirectory;

        //use linq to load *.notes.txt file
        IEnumerable<Note> notes = Directory

            //select the file names from directory
            .EnumerateFiles(appDataPath, "*.notes.txt")

            //use file name to create new note
            .Select(filename => new Note()
            {
                Filename = filename,
                Text = File.ReadAllText(filename),
                Date = File.GetCreationTime(filename)
            })

            //order notes by date
            .OrderBy(note => note.Date);

        //add notes to the collection
        foreach (Note note in notes)
        {
            Notes.Add(note); 
        }
    }
}

