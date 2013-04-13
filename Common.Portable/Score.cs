namespace Common
{
    public class Score
    {
        public int Value { get; private set; }

        public string CategoryId { get; private set; }

        public string SectionId { get; private set; }

        public Score(int value, string categoryId, string sectionId)
        {
            Value = value;
            CategoryId = categoryId;
            SectionId = sectionId;
        }
    }
}