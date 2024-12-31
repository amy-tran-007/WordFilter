namespace TextFilter.StartUp
{
    internal static class CancellationTokenSetup
    {
        public static CancellationToken GetCancellationToken()
        {
            var cts = new CancellationTokenSource();
            Console.CancelKeyPress += (s, e) =>
            {
                Console.WriteLine("Canceling...");
                cts.Cancel();
                e.Cancel = true;
            };

            return cts.Token;
        }
    }
}
