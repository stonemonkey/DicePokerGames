namespace Common
{
    public interface ICategory
    {
        string SectionId { get; }

        int Calculate(int[] dices);
    }
}