using System;

namespace EventCounter
{
    // Define a delegate for our event
    public delegate void CounterReachedThresholdEventHandler(object sender, EventArgs e);
    
    public class Counter
    {
        private int _count;
        private readonly int _threshold;
        
        // Define the event
        public event CounterReachedThresholdEventHandler ThresholdReached;
        
        public Counter(int threshold)
        {
            _threshold = threshold;
        }
        
        public void Increment()
        {
            _count++;
            Console.WriteLine($"Counter is now {_count}");
            
            if (_count == _threshold)
            {
                OnThresholdReached();
            }
        }
        
        // Method to raise the event
        protected virtual void OnThresholdReached()
        {
            ThresholdReached?.Invoke(this, EventArgs.Empty);
        }
    }
}