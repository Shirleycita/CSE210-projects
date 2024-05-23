public class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public string VerseStart { get; private set; }
    public string VerseEnd { get; private set; }

    public Reference(string book, int chapter, string verse)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verse;
        VerseEnd = verse;
    }

    public Reference(string book, int chapter, string verseStart, string verseEnd)
    {
        Book = book;
        Chapter = chapter;
        VerseStart = verseStart;
        VerseEnd = verseEnd;
    }

    public override string ToString()
    {
        if (VerseStart == VerseEnd)
        {
            return $"{Book} {Chapter}:{VerseStart}";
        }
        else
        {
            return $"{Book} {Chapter}:{VerseStart}-{VerseEnd}";
        }
    }
}