using System;
using System.Collections.Generic;

namespace ScriptureMemory
{
    class Program
    {
        static void Main(string[] args)
        {
            var scriptures = new List<Scripture>()
            {
                new Scripture("Alma 37:37", "Counsel with the Lord in all thy doings, and he will direct thee for bgood; yea, when thou liest down at night lie down unto the Lord, that he may watch over you in your sleep; and when thou risest in the cmorning let thy heart be full of thanks unto God; and if ye do these things, ye shall be lifted up at the last day."),
                new Scripture("Moses 1:39", "For behold, this is my work and my glory—to bring to pass the immortality and eternal life of man."),
                new Scripture("2 Nephi 2:25", "Adam fell that men might be; and men are, that they might have joy."),
                new Scripture("Mosiah 2:17", "And behold, I tell you these things that ye may learn wisdom; that ye may learn that when ye are in the service of your fellow beings ye are only in the service of your God."),
                new Scripture("1 Nephi 3:7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no bcommandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
                new Scripture("Amos 3:7", "Surely the Lord God will do nothing, but he revealeth his secret unto his servants the prophets.")
            };

            // choose a random scripture to present to the user
            var random = new Random();
            var scripture = scriptures[random.Next(scriptures.Count)];

            // Create a new scripture and display it
            DisplayScripture(scripture);

            // Hide words from the scripture until all words are hidden or the user types "quit"
            var hiddenWords = new List<Word>();
            while (hiddenWords.Count < scripture.WordCount)
            {
                Console.WriteLine();
                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit the program.");
                var input = Console.ReadLine().ToLower();
                if (input == "quit")
                {
                    break;
                }
                else
                {
                    var word = scripture.HideRandomWord(hiddenWords);
                    hiddenWords.Add(word);
                    DisplayScripture(scripture, hiddenWords);
                }
            }

            // Display the complete scripture again before exiting
            Console.WriteLine();
            Console.WriteLine("Final Scripture:");
            DisplayScripture(scripture);
        }

        static void DisplayScripture(Scripture scripture, List<Word> hiddenWords = null)
        {
            Console.Clear();
            Console.WriteLine(scripture.Reference);
            Console.WriteLine();

            foreach (var verse in scripture.Verses)
            {
                foreach (var word in verse.Words)
                {
                    if (hiddenWords != null && hiddenWords.Contains(word))
                    {
                        Console.Write("____ ");
                    }
                    else
                    {
                        Console.Write(word.Text + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}

        class Scripture
        {
            public string Reference { get; }
            public List<Verse> Verses { get; }
            public int WordCount { get; }

            public Scripture(string reference, string text)
            {
                Reference = reference;
                Verses = new List<Verse>();
                var verseTexts = text.Split(';'); // split the text into verses, assuming semicolon as the separator
                foreach (var verseText in verseTexts)
                {
                    Verses.Add(new Verse(verseText));
                }
                WordCount = GetWordCount();
            }

            int GetWordCount()
            {
                var count = 0;
                foreach (var verse in Verses)
                {
                    count += verse.Words.Count;
                }
                return count;
            }

            public Word HideRandomWord(List<Word> excludedWords)
            {
                var random = new Random();
                Word word;
                do
                {
                    var verseIndex = random.Next(Verses.Count);
                    var verse = Verses[verseIndex];
                    var wordIndex = random.Next(verse.Words.Count);
                    word = verse.Words[wordIndex];
                } while (excludedWords.Contains(word));
                return word;
            }
        }

        class Verse
{
    public List<Word> Words { get; }

    public Verse(string text)
    {
        Words = new List<Word>();
        var wordTexts = text.Split(' '); // split the text into words, assuming space as the separator
        foreach (var wordText in wordTexts)
        {
            Words.Add(new Word(wordText));
        }
    }
}

        class Word
        {
            public string Text { get; }

            public Word(string text)
            {
                Text = text;
            }
        }
