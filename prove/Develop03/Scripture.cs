using System;
using System.Collections.Generic;
using System.Linq;

public class Scripture
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public string VerseStart { get; private set; }
    public string VerseEnd { get; private set; }

    private string _reference;
    private string _text;
    private List<Word> _words;

    public Scripture(string book, int chapter, string verseStart, string verseEnd, string text)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
        _reference = $"{book} {chapter}:{verseStart}{(verseStart != verseEnd ? $"-{verseEnd}" : "")}";
        _text = text;
        _words = text.Split(' ').Select(wordText => new Word(wordText)).ToList();
    }

    public string GetReference()
    {
        return _reference;
    }

    public string GetShortReference()
    {
        return $"{Book} {Chapter}:{VerseStart}{(VerseStart != VerseEnd ? $"-{VerseEnd}" : "")}";
    }

    public string GetDisplayText()
    {
        return string.Join(" ", _words.Select(word => word.GetText()));
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(word => word.IsHidden());
    }

    public void HideRandomWords(int numberToHide)
    {
        if (numberToHide < 0 || numberToHide > _words.Count)
        {
            throw new ArgumentException("Number of words to hide out of range");
        }

        Random random = new Random();
        int wordsHidden = 0;

        while (wordsHidden < numberToHide)
        {
            int indexToHide = random.Next(0, _words.Count);

            if (!_words[indexToHide].IsHidden())
            {
                _words[indexToHide].Hide();
                wordsHidden++;
            }
        }
    }
}