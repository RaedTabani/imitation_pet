namespace Events{
    public interface ISubject 
    {
        public void Add(IObserver observer);
        public void Remove(IObserver observer);
    }
}