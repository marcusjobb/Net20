namespace Twelve_days_of_Christmas
{
    public class TextData
    {
        public string[] Days { get; } = new string[]
        {
            "first",
            "second",
            "third",
            "fourth",
            "fifth",
            "sixth",
            "seventh",
            "eighth ",
            "ninth",
            "tenth",
            "eleventh",
            "twelfth" };
        public string[] Gifts { get; } = new string[] {
            "a partridge in a pear tree",
            "two turtle doves",
            "three French hens",
            "four calling birds",
            "five gold rings",
            "six geese a-laying",
            "seven swans a-swimming",
            "eight maids a-milking",
            "nine ladies dancing", 
            "ten lords a-leaping", 
            "eleven pipers piping", 
            "twelve drummers drumming" };
        public string Verse { get; } = "On the {0} day of Christmas my true love gave to me\n{1}";
    }
}