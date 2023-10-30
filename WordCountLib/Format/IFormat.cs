namespace WordCountLib.Format
{
    public interface IFormat<T>
    {
        public string Format(T value);
    }
}
