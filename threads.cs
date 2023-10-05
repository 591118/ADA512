class Tråd {

    static void Main (String[] args) {

        List<int> kø = new List <int> ();
        Random r = new Random();

        //trådargumenter
        List<object> targ = new List<object>();
        
        targ.Add(kø);
        targ.Add(r);

        // Starte hjelpetråden
        Thread t = new Thread(MeldingGenereator);
        T.start(targ);

        while (true) {
            while(kø.Count > 0) {
                Console.Write ("Hovedtråden {0} " , Thread.CurrentThread.MangedThreadId);
                Console.writeLine("fjerner {0}", kø[0]);
                kø.RemoveAt(0);
            }
        }





    }


    static void MeldingGenereator (){
        Console.WriteLine();
    }

}