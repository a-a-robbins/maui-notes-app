﻿namespace Notes.Views;

public partial class AllNotes : ContentPage
{
	public AllNotes()
	{
		InitializeComponent();

		BindingContext = new Models.AllNotes(); 
	}

    protected override void OnAppearing()
    {
        ((Models.AllNotes)BindingContext).LoadNotes(); 
    }

    private async void Add_Clicked (object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage)); 
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count != 0)
        {
            //get the note model
            var note = (Models.Note)e.CurrentSelection[0];
            
            //go to note page
            await Shell.Current.GoToAsync($"{nameof(NotePage)} ? {nameof(NotePage.ItemId)} = {note.Filename}");

            //unselect the ui
            notesCollection.SelectedItem = null; 
        }

    }
}
