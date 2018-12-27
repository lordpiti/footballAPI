namespace Football.PDFGenerator
{
    using System;
    using System.Collections.ObjectModel;

    public class DisposableCollection<T> : Collection<T>, IDisposable where T : IDisposable
    {
        public void Dispose()
        {
            foreach (var item in this)
            {
                item.Dispose();
            }
        }
    }
}